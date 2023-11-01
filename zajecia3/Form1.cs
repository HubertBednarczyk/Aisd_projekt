using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace zajecia3
{
    public partial class Form1 : Form
    {
        private string tekst;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = BubbleSort(tekst); // Sortowanie bąbelkowe
                MessageBox.Show("Posortowany ciąg (Bubble Sort): " + wynik);
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string wynik = SelectionSort(tekst); // Sortowanie przez wybór
            MessageBox.Show("Posortowany ciąg (Selection Sort): " + wynik);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string wynik = InsertionSort(tekst); // Sortowanie przez wstawianie
            MessageBox.Show("Posortowany ciąg (Insertion Sort): " + wynik);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string wynik = MergeSort(tekst); // Sortowanie przez scalanie
            MessageBox.Show("Posortowany ciąg (Merge Sort): " + wynik);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string wynik = QuickSort(tekst); // Sortowanie szybkie
            MessageBox.Show("Posortowany ciąg (Quick Sort): " + wynik);
        }


        // Implementacja algorytmów

        private string BubbleSort(string tekst)
        {
            char[] charArray = tekst.ToCharArray();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < charArray.Length; i++)
                {
                    if (charArray[i - 1] > charArray[i])
                    {
                        char temp = charArray[i - 1];
                        charArray[i - 1] = charArray[i];
                        charArray[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            return new string(charArray);
        }

        private string SelectionSort(string tekst)
        {
            char[] charArray = tekst.ToCharArray();
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < charArray.Length; j++)
                {
                    if (charArray[j] < charArray[minIndex])
                    {
                        minIndex = j;
                    }
                }
                char temp = charArray[i];
                charArray[i] = charArray[minIndex];
                charArray[minIndex] = temp;
            }

            return new string(charArray);
        }

        private string InsertionSort(string tekst)
        {
            char[] charArray = tekst.ToCharArray();
            for (int i = 1; i < charArray.Length; i++)
            {
                char key = charArray[i];
                int j = i - 1;
                while (j >= 0 && charArray[j] > key)
                {
                    charArray[j + 1] = charArray[j];
                    j = j - 1;
                }
                charArray[j + 1] = key;
            }

            return new string(charArray);
        }

        private string MergeSort(string tekst)
        {
            if (tekst.Length <= 1)
            {
                return tekst;
            }

            int middle = tekst.Length / 2;
            string left = tekst.Substring(0, middle);
            string right = tekst.Substring(middle);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private string Merge(string left, string right)
        {
            string result = "";
            while (left.Length > 0 && right.Length > 0)
            {
                if (left[0] < right[0])
                {
                    result += left[0];
                    left = left.Substring(1);
                }
                else
                {
                    result += right[0];
                    right = right.Substring(1);
                }
            }

            result += left + right;
            return result;
        }

        private string QuickSort(string tekst)
        {
            if (tekst.Length <= 1)
            {
                return tekst;
            }

            char pivot = tekst[tekst.Length / 2];
            string left = "";
            string right = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if (i == tekst.Length / 2)
                {
                    continue;
                }
                if (tekst[i] < pivot)
                {
                    left += tekst[i];
                }
                else
                {
                    right += tekst[i];
                }
            }

            return QuickSort(left) + pivot + QuickSort(right);
        }
    }
}
