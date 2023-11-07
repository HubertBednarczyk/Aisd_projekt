using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zajecia3
{
    public partial class Form1 : Form
    {
        private string tekst;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int count = (int)numericUpDown1.Value;

            if (checkBox1.Checked)
            {
                int randomValue = random.Next(0, 2000000);
                numericUpDown1.Value = randomValue;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = true;
                textBox4.Visible = true;
            }
            else if (!checkBox1.Checked) // Dodaliśmy warunek, aby sprawdzić, czy checkBox1 jest niezaznaczony
            {
                numericUpDown1.Enabled = false;
                textBox4.Visible = false;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int count = (int)numericUpDown1.Value;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int randomValue = random.Next(0, 2000001);
                sb.Append(randomValue);

                if (i != count - 1)
                {
                    sb.Append(" ");
                }
            }

            if (!checkBox1.Checked)
            {
                textBox1.Text = sb.ToString();
            }
            else
            {
                textBox4.Text = sb.ToString();
            }
        }


        private string GenerujCiąg(string tekst)
        {
            // Tutaj możesz wpisać dowolny kod do generowania ciągu na podstawie tekstu
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
            }
            return liczby;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wynik = "";

            if (!string.IsNullOrEmpty(tekst))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                wynik = BubbleSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                double elapsedSeconds = elapsedMilliseconds / 1000.0; // Konwersja na sekundy

                textBox3.Text = " " + elapsedSeconds.ToString("F2") + " s"; // Wyświetlamy czas z dwoma miejscami po przecinku
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }

            if (checkBox1.Checked)
            {
                wynik = BubbleSort(textBox4.Text); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku BubbleSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wynik = "";

            if (!string.IsNullOrEmpty(tekst))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                wynik = SelectionSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku SelectionSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                double elapsedSeconds = elapsedMilliseconds / 1000.0; // Konwersja na sekundy

                textBox3.Text = " " + elapsedSeconds.ToString("F2") + " s"; // Wyświetlamy czas z dwoma miejscami po przecinku
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }

            if (checkBox1.Checked)
            {
                wynik = SelectionSort(textBox4.Text); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku SelectionSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wynik = "";

            if (!string.IsNullOrEmpty(tekst))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                wynik = InsertionSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku InsertionSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                double elapsedSeconds = elapsedMilliseconds / 1000.0; // Konwersja na sekundy

                textBox3.Text = " " + elapsedSeconds.ToString("F2") + " s"; // Wyświetlamy czas z dwoma miejscami po przecinku
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }

            if (checkBox1.Checked)
            {
                wynik = InsertionSort(textBox4.Text); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku InsertionSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wynik = "";

            if (!string.IsNullOrEmpty(tekst))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                wynik = MergeSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku MergeSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                double elapsedSeconds = elapsedMilliseconds / 1000.0; // Konwersja na sekundy

                textBox3.Text = " " + elapsedSeconds.ToString("F2") + " s"; // Wyświetlamy czas z dwoma miejscami po przecinku
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }

            if (checkBox1.Checked)
            {
                wynik = MergeSort(textBox4.Text); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku MergeSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text; // Pobieramy tekst z TextBoxa
            string wynik = "";

            if (!string.IsNullOrEmpty(tekst))
            {
                if (IsValidInput(tekst)) // Dodajemy walidację
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    wynik = QuickSort(tekst); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku QuickSort)
                    textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami

                    stopwatch.Stop();
                    long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    double elapsedSeconds = elapsedMilliseconds / 1000.0; // Konwersja na sekundy

                    textBox3.Text = " " + elapsedSeconds.ToString("F2") + " s"; // Wyświetlamy czas z dwoma miejscami po przecinku
                }
                else
                {
                    MessageBox.Show("Nieprawidłowy format ciągu wejściowego.");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź tekst przed sortowaniem.");
            }

            if (checkBox1.Checked)
            {
                wynik = QuickSort(textBox4.Text); // Tutaj używamy odpowiedniego algorytmu sortowania (w tym przypadku QuickSort)
                textBox2.Text = string.Join(" ", wynik); // Dodajemy spacje między liczbami
            }
        }

        private bool IsValidInput(string input)
        {
            return input.Split(' ').All(num => int.TryParse(num, out _));
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
