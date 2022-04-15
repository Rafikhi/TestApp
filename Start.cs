using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace TestApp
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        //Funkcja sprawdza czy pola tekstowe nie są puste
        //Jeśli nie są puste, umożliwa wciśnięcie przycisku Zatwierdź
        private void ArePathsNotNull()
        {
            if (txt_file_path.Text.Length != 0 && folder_path.Text.Length != 0)
            {
                confirm_btn.Enabled = true;
            }
            else
            {
                confirm_btn.Enabled = false;
            }
        }

        //Funkcje uruchamiają sprawdzenie czy pola tekstowe są puste, za każdym razem gdy pole tekstowe zostanie zmienione
        private void txt_file_path_TextChanged(object sender, EventArgs e)
        {
            ArePathsNotNull();
        }

        private void folder_path_TextChanged(object sender, EventArgs e)
        {
            ArePathsNotNull();
        }

        //Funkcja uruchamia wbudowane narzędzie do szukania pliku z testami
        private void file_path_btn_Click(object sender, EventArgs e)
        {
            if(browse_file.ShowDialog() == DialogResult.OK)
            {
                txt_file_path.Text = browse_file.FileName;
            }
        }

        //Funkcja uruchamia wbudowane narzędzie do wyboru folderu z rozwiązaniami
        private void folder_path_btn_Click(object sender, EventArgs e)
        {
            if (browse_folder.ShowDialog() == DialogResult.OK)
            {
                folder_path.Text = browse_folder.SelectedPath;
            }
        }

        //Funkcja sprawdza poprawność danych, które potem zostaną wysłane do okna Check
        //Jeśli funkcja napotka błąd, przerwie działanie i da komunikat z czym jest problem
        //Jeśli funkcja zadziała poprawnie, wyśle listy z rozwiązaniami i testami do okna Check
        private void confirm_btn_Click(object sender, EventArgs e)
        {
            //Tworzenie pustych list rozwiązań oraz testów
            List<Solution> solutions = new List<Solution>();
            List<Test> tests = new List<Test>();
            try
            {
                //Próba wczytania rozwiązań z folderu
                solutions = GetFolders.GetSolutions(Directory.GetDirectories(folder_path.Text));
                if (solutions.Count==0)
                {
                    throw new Exception("Dany folder nie posiada żadnych rozwiązań.");
                }

                //Próba wczytania testów z pliku
                tests = GetTests.LoadTests(txt_file_path.Text);
                
                //Jeśli plik .csv w danym folderze istnieje to funkcja sprawdza czy nie jest otwarty
                if (File.Exists(folder_path.Text+"\\wyniki.csv"))
                {
                    FileStream f = File.Open(folder_path.Text + "\\wyniki.csv", FileMode.Open);
                    f.Close();
                }
            }
            //Bloki catch, które wychwytują konkretne typy błędów
            catch(FileNotFoundException fnfe)
            {
                MessageBox.Show("Błąd przetwarzania pliku z testami. Wczytana ścieżka: " + fnfe.FileName);
                return;
            }
            catch(FormatException)
            {
                MessageBox.Show("Zły format pliku wejściowego.");
                return;
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Dany folder nie istnieje lub wpisano niepoprawną ścieżkę.");
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\n\n"+ex.GetType());    //DEBUG: wykorzystywane gdy błąd nie został przewidziany
                return;
            }

            //Ukrywa okno, potem dodaje zdarzenie zamknięcia tego okna przy zamknięciu programu i pokazuje okno Check
            this.Hide();
            Check c = new Check(solutions, tests, folder_path.Text);
            c.FormClosed += (s, args) => this.Close();
            c.Show();
        }
    }
}
