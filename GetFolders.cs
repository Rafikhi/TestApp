using System.IO;
using System.Collections.Generic;

namespace TestApp
{
    class GetFolders
    {
        //Funkcja sprawdza poprawność nazwy folderu z rozwiązaniem
        static bool IsGood(string s)
        {
            if (s.Length != 11)
            {
                return false;
            }
            if (s[0] != 'K')
            {
                return false;
            }
            if (!(s[1] >= '1' && s[1] <= '9'))
            {
                return false;
            }
            for (int i = 3; i < 9; i++)
            {
                if (!(s[i] >= '0' && s[i] <= '9'))
                {
                    return false;
                }
            }
            if (!(s[10] >= 'A' && s[10] <= 'Z'))
            {
                return false;
            }
            return true;
        }
        //Funkcja sprawdza czy folder ma w sobie folder o nazwie PD
        static bool IsPDInside(string s)
        {
            string[] dirs = Directory.GetDirectories(s);
            for (int i = 0; i < dirs.Length; i++)
            {
                if(s+"\\PD"==dirs[i])
                {
                    return true;
                }
            }
            return false;
        }

        //Funkcja wczytuje informacje o rozwiązaniach i zapisuje je do listy rozwiązań
        public static List<Solution> GetSolutions(string[] d)
        {
            List<Solution> temp = new List<Solution>();
            string[] temp2;
            foreach (string s in d)
            {
                temp2 = s.Split('\\');
                if (IsGood(temp2[temp2.Length - 1]) && IsPDInside(s))
                {
                    temp.Add(new Solution(s,temp2[temp2.Length - 1]));
                }
            }
            return temp;
        }

    }
}
