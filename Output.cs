using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Output : Form
    {
        public Output(string csvPath)
        {
            InitializeComponent();
            csvLink.Text = csvPath;
        }

        //Funkcja otwiera plik wynikowy przez aplikację explorer.exe
        private void csvLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", @$"{csvLink.Text}");
        }

        //Funkcja dodaje zdarzenie zamknięcia okna, jeśli przeszło się do okna startowego
        private void btn_go_to_start_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.FormClosed += (s, args) => this.Close();
            s.Show();
        }
    }
}
