using System.Collections.Generic;

namespace TestApp
{
    //Klasa przechowywuje informacje o testach
    public class Test
    {
        public string name;             //nazwa funkcji
        public int n;                   //ilość testów
        public List<string[]> param;    //lista z parametrami zapisanymi w postaci tekstowej
        public string[] results;        //tablica z wynikami jakie testy mają uzyskać w postaci tekstowej
        public Test() { }

        //Funkcja inicjalizuje puste zbiory z danymi o parametrach i wynikach
        public void SetParamCount()
        {
            param = new List<string[]>();
            results = new string[n];
        }
    }
}
