using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zajecia3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wygenerowanyCiąg = GenerujCiąg(tekst); // Wywołujemy funkcję do generowania ciągu
            MessageBox.Show("Wygenerowany ciąg: " + wygenerowanyCiąg); // Wyświetlamy wygenerowany ciąg w MessageBoxie
        }

        private string GenerujCiąg(string tekst)
        {
            // Tutaj możesz wpisać dowolny kod do generowania ciągu na podstawie tekstu
            // W tym przykładzie zwracam tekst odwrócony
            char[] charArray = tekst.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        int[] Convert(string napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            var liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }

    }
}
