using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Check : Form
    {
        string solutionsPath;           //Przechowuje ścieżkę do folderu z rozwiązaniami
        List<Solution> solutions;       //Przechowuje informacje o rozwiązaniach
        List<Test> tests;               //Przechowuje informacje o testach
        public Check(List<Solution> sol, List<Test> tes, string folderPath)
        {
            //Przypisanie wszystkich wartości przesłanych z okna Start do zmiennych
            solutions = sol;
            tests = tes;
            solutionsPath = folderPath;

            InitializeComponent();
            counter.Text = "Sprawdzono " + 0 + " na " + solutions.Count + " rozwiązań";
        }

        //Funkcja wysyła ścieżkę do katalogu z wynikami do okna Output po wciśnięciu przycisku Zatwierdź
        //Dodaje również potem Delegata zamykającego okno po poprawnym zamknięciu programu (normalnie okno jest tylko ukrywane)
        private void end_Click(object sender, EventArgs e)
        {
            this.Hide();
            Output o = new Output(solutionsPath + "\\wyniki.csv");
            o.FormClosed += (s, args) => this.Close();
            o.Show();
        }

        //Funkcja uruchamia funkcję testującą oraz na bieżąco zapisującą dane do pliku CSV
        //Po przetestowaniu wszystkich rozwiązań pokazuje przycisk przechodzący do okna output
        private void Check_Shown(object sender, EventArgs e)
        {
            ResearchSolutionsAndExportToCSV(solutionsPath);
            end.Visible = true;
        }

        //Funkcja przyjmuje jako argument ścieżkę do folderu w którym ma powstać plik CSV.
        //Wykonuje ona testy na podstawie danych z list z rozwiązaniami oraz testami.
        void ResearchSolutionsAndExportToCSV(string path)
        {
            //Ustawiamy wartość maksymalną dla paska ładowania na ilość rozwiązań
            progressBar.Maximum = solutions.Count;

            //Tworzymy StreamWritera do zapisywania rozwiązań do pliku CSV oraz wpisanie pierwszego wiersza nagłówkowego
            StreamWriter sw = new StreamWriter(path + "\\wyniki.csv", false, Encoding.UTF8);
            sw.WriteLine("Numer Albumu;Grupa;Podejście;Data Utworzenia pliku .sln; Rozmiar" + CountTests(tests));

            //Indeks aktualnie sprawdzanego rozwiązania
            int i = 0;

            //Pętla przechodząca przez wszystkie rozwiązania
            foreach (Solution s in solutions)
            {
                //Pętla wykonuje wszystkie testy dla danego rozwiązania i zapisuje je do listy przechowywującej wyniki
                for (int j = 0; j < tests.Count; j++)
                {
                    s.testResults.Add(RunTests.TestFunction(tests[j], s.path));
                }

                //Zapisujemy informacje o rozwiązaniu do pliku CSV
                sw.WriteLine(s.FormatCSV());

                //Zaktualizowanie danych w GUI
                progressBar.PerformStep();
                i++;
                counter.Text = "Sprawdzono " + i + " na " + solutions.Count + " rozwiązań";
            }

            //Zamknięcie pliku
            sw.Close();
        }

        //Funkcja zwraca stringa sformatowanego do zapisu w pliku CSV
        //String zawiera numery zadań oraz numery indywidualnych testów dla każdego zadania
        string CountTests(List<Test> tab)
        {
            string s = "";
            for (int i = 1; i <= tab.Count; i++)
            {
                for (int j = 1; j <= tab[i - 1].n; j++)
                {
                    s += $";Zad{i}Test{j}";
                }
            }
            return s;
        }
    }
}
