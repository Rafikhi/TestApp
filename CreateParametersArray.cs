using System;
using System.Collections;

namespace TestApp
{
    class CreateParametersArray
    {
        //Zwraca tablicę z wymiarami tablicy wielowymiarowej na podstawie napisu oraz wymiaru tablicy wyjściowej
        public static int[] GetLengths(string s, int dim)
        {
            int[] lengths = new int[dim];
            for (int i = lengths.Length - 1; i >= 0; i--)
            {
                lengths[i] = GetDimLength(s, i, lengths.Length - i - 1);
            }
            return lengths;
        }

        //Funkcja zwraca wielkość wymiaru tablicy
        static int GetDimLength(string s, int dim, int ignoreD)
        {
            int count = 0;              //ilość elementów w wymiarze 
            int i = dim;                //startowy indeks
            int ignoreDi = ignoreD;     //ilość ignorowanych zamknięć klamer
            bool ignore = false;        //mówi czy ignorować znaki znajdujące się między cudzsłowiami
            bool ignoreDim = false;     //mówi czy ignorować znaki ze względu na wymiar
            
            //Przejście przez wszystkie elementy dopóki nie znajdziemy zamknięcia tablicy dla danego wymiaru
            //Elementy są określane przez średniki
            while (s[i] != '}' || ignore || ignoreDim)
            {
                //Przy znalezieniu otwarcia kolejnej tablicy nie należącej do danego wymiaru ustawiamy ignorowanie średników
                if (s[i].Equals('{') && !ignore && ignoreDi > 0)
                {
                    ignoreDim = true;
                    if (ignoreDi < ignoreD)
                    {
                        ignoreDi++;
                    }
                }

                //Przy znalezieniu zamknięcia tablicy
                //Jeśli należy ona do danego wymiaru wyłączamy ignorowanie
                //Jeśli nie należy to zmniejszamy ilość ignorowanych klamer
                if (s[i].Equals('}') && ignoreDim && !ignore && ignoreDi > 0)
                {
                    ignoreDi--;
                    if (ignoreDi < 1)
                    {
                        ignoreDim = false;
                    }
                }

                //Ustawienie głównie dla najniższego wymiaru tablicy
                //Ustawia ignorowanie znaków specjalnych jeśli znajdują się między cudzysłowiami
                if (s[i].Equals('\"') && !s[i - 1].Equals('\\'))
                {
                    if (ignore)
                    {
                        ignore = false;
                    }
                    else
                    {
                        ignore = true;
                    }
                }

                //Jeśli żadne z ignorowań nie jest ustawione, nowy średnik zwiększa nam liczbę elementów o 1
                if (s[i].Equals(';') && !ignore && !ignoreDim && ignoreDi < 1)
                {
                    count++;
                    ignoreDi = ignoreD;
                }
                i++;
            }
            return count + 1;
        }

        //Funkcja ma zwrócić ArrayList obiektów wczytanych ze stringa z tablicą wielowymiarową
        public static ArrayList GetElements(string s, int dim, Type type)
        {
            ArrayList objects = new ArrayList();    //ArrayList wypełniany obiektami ze stringa
            int j = dim;                            //Indeksator przechodzący przez napis
            bool ignore = false;                    //Mówi czy ignorować znaki znajdujące się między cudzsłowiami

            //Pętla przechodzi przez cały napis
            for (int i = dim; i < s.Length; i++)
            {
                //Gdy napotka cudzysłów, który nie jest zapisany w postaci \", ustawia ignorowanie
                //Ustawia indeksator na początek napisu jeśli jest to początek obiektu
                if (s[i].Equals('\"') && !s[i - 1].Equals('\\'))
                {
                    if (ignore)
                    {
                        ignore = false;
                    }
                    else
                    {
                        j = i;
                        ignore = true;
                    }
                }
                //Gdy napotka cudzysłów i ignore nie jest ustawione, dodaje do obiektów przekonwertowany napis na obiekt
                if (s[i].Equals('"') && !ignore)
                {
                    objects.Add(Convert.ChangeType(s.Substring(j + 1, i - j - 1), type));
                }
            }
            return objects;
        }

        //Funkcja kopiuje wartości z jednowymiarowej tablicy obiektów do wielowymiarowej tablicy
        //Tablica wielowymiarowa jest parametrem funkcji używanej w refleksji
        public static void Copy(ref Array arr, object[] o, int[] length, ref int ob, int dim, int dimMax)
        {
            //Jeśli jesteśmy w najniższym wymiarze, wpisujemy do tablicy wartość z tablicy jednowymiarowej
            if(dim==0)
            {
                arr.SetValue(o[ob],length);
                ob++;
                return;
            }
            //Pętla przechodzi w danym wymiarze przez wszystkie indeksy
            //Podczas działania przechodzi rekurencyjnie do niższego wymiaru
            for (int i = arr.GetLowerBound(dimMax-dim); i <= arr.GetUpperBound(dimMax - dim); i++)
            {
                length[dimMax - dim] = i;
                Copy(ref arr, o, length, ref ob, dim-1, dimMax);
            }
        }
    }
}
