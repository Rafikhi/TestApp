using System;
using System.Collections.Generic;
using System.IO;

namespace TestApp
{
    //Klasa przechowywująca informacje o rozwiązaniu
    public class Solution
    {
        public string path;                 //ścieżka do rozwiązania
        public string index;                //nr. albumu
        public char group;                  //grupa
        public char approuch;               //podejście
        public DateTime date;               //Data utworzenia pliku .sln
        public double size=0.0;             //rozmiar???
        public List<bool[]> testResults;    //tablice z rezultatami testów
        public Solution(string path, string name)
        {
            this.path = path;
            approuch = name[1];
            group = name[10];
            date = File.GetCreationTime(path + '\\' + name + ".sln");
            index = name.Substring(3, 6);
            testResults = new List<bool[]>();
        }
        public override string ToString()
        {
            return path + "\n" + index + "\n" + group + "\n" + approuch + "\n" + date + "\n" + size + "\n\n";
        }

        //Funkcja formatująca informacje z obiektu na string odpowiadający formatowi pliku wynikowego .csv
        public string FormatCSV()
        {
            //Wczytanie informacji o testach
            string s = "";
            for (int i = 0; i < testResults.Count; i++)
            {
                for (int j = 0; j < testResults[i].Length; j++)
                {
                    if(testResults[i][j])
                    {
                        s += ";1";
                    }
                    else
                    {
                        s += ";0";
                    }
                }
            }

            //Najpierw są dodawane informacje na temat rozwiązania, a potem wyniki testów
            return $"{index};{group};{approuch};{date};{size}"+s;
        }
    }
}
