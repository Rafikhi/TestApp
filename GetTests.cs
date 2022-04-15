using System;
using System.Collections.Generic;
using System.IO;

namespace TestApp
{
    class GetTests
    {
        //Funkcja zwraca listę z informacjami na temat testów
        public static List<Test> LoadTests(string path)
        {
            List<Test> tests = new List<Test>();        //lista przechowywująca informacje o testach
            Test temp;                                  //zmienna pomocnicza przechowywująca aktualne informacje o teście
            string[] s;                                 //zmienna pomocnicza przechowywująca informacje o pierwszym wierszu z informacjami
            StreamReader sr = new StreamReader(path);   //obiekt czytający plik tekstowy

            //pętla wykonuje się do ostatniej linii w pliku (zakładamy że plik jest stworzony poprawnie wg. wzoru)
            while (!sr.EndOfStream)
            {
                //tworzymy zmienną pomocniczą z testem i wpisujemy informacje z pierwszego wiersza
                temp = new Test();
                s = sr.ReadLine().Split(' ');
                temp.name = s[0];
                temp.n = Convert.ToInt32(s[1]);
                temp.SetParamCount();
                
                //Na podstawie wcześniejszych informacji zapisujemy informacje o parametrach testów oraz to, co funkcja ma zwrócić, do zmiennej pomocniczej
                for (int i = 0; i < temp.n; i++)
                {
                    temp.param.Add(new string[Convert.ToInt32(s[2])]);
                    for (int j = 0; j < Convert.ToInt32(s[2]); j++)
                    {
                        temp.param[i][j] = sr.ReadLine();
                    }
                    temp.results[i] = sr.ReadLine();
                }

                //Dodajemy test do listy
                tests.Add(temp);
            }
            sr.Close();         //zamknięcie pliku
            return tests;
        }

    }
}
