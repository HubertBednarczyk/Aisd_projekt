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
            //Array.Reverse(charArray);
            return new string(charArray);
        }

        private int[] Convert(string napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            var liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                if (int.TryParse(liczbyS[i], out int parsedNumber))
                {
                    liczby[i] = parsedNumber;
                }
                else
                {
                    throw new ArgumentException("Nieprawidłowy format ciągu wejściowego.");
                }
            }
            return liczby;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa

            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = BubbleSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa

            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = SelectionSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa

            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = InsertionSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa

            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = MergeSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa

            if (!string.IsNullOrEmpty(tekst))
            {
                string wynik = QuickSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }
        }


        // Implementacja algorytmów

        private string BubbleSort(string tekst)
        {
            int[] liczby = Convert(tekst);

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < liczby.Length; i++)
                {
                    if (liczby[i - 1] > liczby[i])
                    {
                        int temp = liczby[i - 1];
                        liczby[i - 1] = liczby[i];
                        liczby[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            return string.Join(" ", liczby);
        }
/*        private string BubbleSort2(string tekst)
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
        }*/





        private string SelectionSort(string tekst)
        {
            int[] liczby = Convert(tekst);
            for (int i = 0; i < liczby.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < liczby.Length; j++)
                {
                    if (liczby[j] < liczby[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = liczby[i];
                liczby[i] = liczby[minIndex];
                liczby[minIndex] = temp;
            }

            return string.Join(" ", liczby);
        }

        private string InsertionSort(string tekst)
        {
            int[] liczby = Convert(tekst);
            for (int i = 1; i < liczby.Length; i++)
            {
                int key = liczby[i];
                int j = i - 1;
                while (j >= 0 && liczby[j] > key)
                {
                    liczby[j + 1] = liczby[j];
                    j = j - 1;
                }
                liczby[j + 1] = key;
            }

            return string.Join(" ", liczby);
        }

        private string MergeSort(string tekst)
        {
            int[] liczby = Convert(tekst);

            if (liczby.Length <= 1)
            {
                return string.Join(" ", liczby);
            }

            int middle = liczby.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[liczby.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = liczby[i];
            }

            for (int i = middle; i < liczby.Length; i++)
            {
                right[i - middle] = liczby[i];
            }

            left = MergeSort(string.Join(" ", left)).Split(' ').Select(int.Parse).ToArray();
            right = MergeSort(string.Join(" ", right)).Split(' ').Select(int.Parse).ToArray();

            return string.Join(" ", Merge(left, right));
        }

        private int[] Merge(int[] left, int[] right)
        {
            List<int> result = new List<int>();

            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Length)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Length)
            {
                result.Add(right[j]);
                j++;
            }

            return result.ToArray();
        }


        private string QuickSort(string tekst)
        {
            int[] liczby = Convert(tekst);

            if (liczby.Length <= 1)
            {
                return string.Join(" ", liczby);
            }

            int pivotIndex = liczby.Length / 2;
            int pivotValue = liczby[pivotIndex];

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < liczby.Length; i++)
            {
                if (i == pivotIndex)
                    continue;

                if (liczby[i] <= pivotValue)
                    less.Add(liczby[i]);
                else
                    greater.Add(liczby[i]);
            }

            return string.Join(" ", QuickSort(string.Join(" ", less)).Split(' ').Select(int.Parse).ToArray()) +
                   " " + pivotValue +
                   " " + string.Join(" ", QuickSort(string.Join(" ", greater)).Split(' ').Select(int.Parse).ToArray());
        }

    }
}
