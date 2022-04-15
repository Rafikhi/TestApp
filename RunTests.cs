using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace TestApp
{
    class RunTests
    {
        //Funkcja szuka pliku PD.dll w katalogu i otwiera pierwszy jaki znajdzie (zazwyczaj jest jeden, ale może wystąpić więcej jeśli zmieniało się wersje)
        static string GetLibrary(string path)
        {
            string[] retpath = Directory.GetFiles(path+"\\PD\\","PD.dll", SearchOption.AllDirectories);
            if(retpath.Length == 0)
            {
                return "";
            }
            return retpath[0];
        }

        //Funkcja uruchamia testy dla funkcji za pomocą refleksji
        public static bool[] TestFunction(Test test, string path)
        {
            //Przygotowywujemy tablicę z wynikami testów oraz szukamy biblioteki z funkcjami.
            //Jeśli jej nie znajdziemy testy dla tej funkcji są uznawane za negatywne.
            bool[] temp = new bool[test.param.Count];
            string libraryDir = GetLibrary(path);
            if (libraryDir=="")
            {
                return temp;
            }

            //Funkcja wczytuje biblioteke i szuka w typach metody o nazwie takiej samej jak funkcja testowana
            Assembly a = Assembly.LoadFile(libraryDir);
            Type[] t = a.GetTypes();
            MethodInfo m = null;
            for (int i = 0; i < t.Length && m == null; i++)
            {
                MethodInfo[] methods = t[i].GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (MethodInfo j in methods)
                {
                    if (j.Name == test.name)
                    {
                        //Jeśli taka metoda została odnaleziona, informacje o niej są zapisywane
                        m = j;
                        break;
                    }
                }
            }

            //Jeśli udało się znaleźć metodę, funkcja uruchamia testy
            if (m != null)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    //Jeśli funkcja napotka jakikolwiek problem, test jest uznany za nieudany.
                    //Ważne jest aby funkcja testująca metodę dla konkretnych parametrów była jak najbardziej bezawaryjna
                    try
                    {
                        temp[i] = TestParameters(m, test.param[i], test.results[i]);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message + "\n\n" + ex.GetType());          //Pomocniczy MessageBox do debugowania
                        temp[i] = false;
                    }
                }
            }
            return temp;
        }

        //Głównym zadaniem funkcji jest określenie dla wykonywania funkcji czasu w jakim ma zostać wykonana.
        //W czasie testu program jest zamrażany
        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }

        //Funkcja testuje metodę dla konkretnych parametrów
        static bool TestParameters(MethodInfo method, string[] parameters, string results)
        {
            try
            {
                //Najpierw funkcja kopiuje informacje o parametrach metody
                //Głównie zależy tu na typach
                ParameterInfo[] param = method.GetParameters();
                Type[] types = new Type[param.Length];
                for (int i = 0; i < param.Length; i++)
                {
                    types[i] = param[i].ParameterType;
                }

                //Tworzymy tablicę z parametrami, które są zapisane w postaci tekstu i zamieniamy tekst na tablicę obiektów
                object[] temp = ParametersIntoArray(types, parameters).ToArray();

                //Próbujemy uruchomić metodę z parametrami przekonwertowanymi z tekstu
                //Jeśli funkcja napotka jakikolwiek problem z konwersją podczas działąnia metody
                //lub będzie metoda będzie uruchomiona przez 30 sekund, test jest niezaliczony.
                object res = null;
                bool Completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(30000), () =>
                {
                    try
                    {
                        res = method.Invoke(null, temp);
                    }
                    catch(Exception ex)
                    {
                        res = null;
                    }

                });
                if (Completed)
                {
                    //Jeśli konwersja przebiegła pomyślnie, konwertujemy wartość zwracaną tym samym sposobem
                    //Jeśli są takie same, test został zaliczony
                    object rez = GetResults(method.ReturnType, results);
                    if (res.Equals(rez))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Funkcja zamienia parametry metody na ArrayList (którą potem łatwo przekonwertować na tablicę obiektów)
        static ArrayList ParametersIntoArray(Type[] param, string[] tab)
        {
            ArrayList temp = new ArrayList();
            for (int i = 0; i < param.Length; i++)
            {
                //Jeśli typ parametru nie jest tablicą stosuje podstawową konwersje
                if(!param[i].IsArray)
                {
                    temp.Add(Convert.ChangeType(tab[i], param[i]));
                }
                else
                {
                    //Jeśli jest tablicą, wykorzystuje funkcje z CreateParametersArray.cs do stworzenia tablicy z parametrami
                    //Ilość wymiarów tablicy
                    int dim = param[i].GetArrayRank();

                    //Jeśli wymiary tablic wynikowej i z parametru nie są równe, zwraca aktualny stan parametrów aby na pewno wywalić błąd
                    if (dim != CreateParametersArray.GetSourceRank(tab[i]))
                    {
                        return temp;
                    }

                    //Tablica jednowymiarowa z elementami tablicy
                    object[] o = CreateParametersArray.GetElements(tab[i], dim, param[i].GetElementType()).ToArray();

                    //Tablica z wielkościami wszystkich wymiarów
                    int[] lengths = CreateParametersArray.GetLengths(tab[i], dim);

                    //Pusta tablica wielowymiarowa konkretnego typu
                    Array arr = Array.CreateInstance(param[i].GetElementType(), lengths);

                    //Uruchomienie funkcji kopiującej elementy z tablicy jednowymiarowej do wielowymiarowej
                    int[] len = new int[lengths.Length];
                    int j = 0;
                    CreateParametersArray.Copy(ref arr, o, len, ref j, arr.Rank, arr.Rank);
                    temp.Add(arr);
                }
            }
            return temp;
        }

        //Funkcja działa analogicznie do ParametersIntoArray, ale dla jednego obiektu
        static object GetResults(Type type, string res)
        {
            //Jeśli typ parametru nie jest tablicą stosuje podstawową konwersje
            if (!type.IsArray)
            {
                return Convert.ChangeType(res, type);
            }
            //Jeśli jest tablicą, wykorzystuje funkcje z CreateParametersArray.cs do stworzenia tablicy z parametrami
            //Ilość wymiarów tablicy
            int dim = type.GetArrayRank();

            //Jeśli wymiary tablic wynikowej i z parametru nie są równe, zwraca null
            if (dim != CreateParametersArray.GetSourceRank(res))
            {
                return null;
            }

            //Tablica jednowymiarowa z elementami tablicy
            object[] o = CreateParametersArray.GetElements(res, dim, type.GetElementType()).ToArray();

            //Tablica z wielkościami wszystkich wymiarów
            int[] lengths = CreateParametersArray.GetLengths(res, dim);

            //Pusta tablica wielowymiarowa konkretnego typu
            Array arr = Array.CreateInstance(type.GetElementType(), lengths);

            //Uruchomienie funkcji kopiującej elementy z tablicy jednowymiarowej do wielowymiarowej
            int[] len = new int[lengths.Length];
            int i = 0;
            CreateParametersArray.Copy(ref arr, o, len, ref i, arr.Rank, arr.Rank);
            return arr;
        }
    }
}
