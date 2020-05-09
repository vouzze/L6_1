using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace L4_2
{
    class RatingInfo
    {
        string[] LastName = { "Aivazovsky", "Altman", "Bashkirtseff", "Brackman", "Burachek", "Burliuk", "Choris", "Dmytrenko", "Sologoub", "Zholud" };
        string[] GradebookNumber = { "01521111", "01522222", "01523333", "01524444", "01525555", "01526666", "01527777", "01528888", "01529999", "01520000" };
        int[] Rating = {50, 52, 70, 87, 90, 100, 63, 78, 81, 94 };
        public string[] Name
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }
        public string[] Grades
        {
            get
            {
                return GradebookNumber;
            }
            set
            {
                GradebookNumber = value;
            }
        }
        public int[] Rate
        {
            get
            {
                return Rating;
            }
            set
            {
                Rating = value;
            }
        }
        public void Sorting(int[] arr, string[] str, string[] s)
        {
            if ((arr.Length != str.Length) || (arr.Length != s.Length) || (str.Length != s.Length)) throw new System.Exception("Information is missed.");
            int temp_1;
            string temp_2;
            string temp_3;
            string ex = "";
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] < arr[j])
                    {

                        temp_1 = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp_1;

                        temp_2 = str[i];
                        str[i] = str[j];
                        str[j] = temp_2;

                        temp_3 = s[i];
                        s[i] = s[j];
                        s[j] = temp_3;
                    }
            for (int i = 0; i < arr.Length; i++)
            {
                if (str[i].Length > ex.Length) ex = str[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (str[i].Length != ex.Length)
                {
                    int dif = ex.Length - str[i].Length;
                    for (int j = 0; j < dif; j++) str[i] += " "; 
                }
            }
        }

        public double Average(int[] a)
        {
            if (a.Length == 0) throw new Exception("Not enough arguments.");
            double av = 0;
            foreach (int b in a) av+=b;
            return av/a.Length;
        }
        public int UnderAv(int[] a, double av)
        {
            int un = 0;
            foreach (int b in a)
            {
                if (b < av) un++;
            }
            return un;
        }
    }
    class Program
    {
        static void Main()
        {
            RatingInfo r = new RatingInfo();
            Console.WriteLine("\n\t\t\t\tSTUDENTS");
            Console.WriteLine("\t_________________________________________________________");
            Console.WriteLine("\tLast name\t\tGradebook Number\tRating");
            Console.WriteLine("\t_________________________________________________________");
            for (int i = 0; i < r.Rate.Length; i++)
            {
                Console.WriteLine("\t" + r.Name[i] + "\t\t" + r.Grades[i] + "\t\t" + r.Rate[i]);
            }
            Console.WriteLine("\t_________________________________________________________");
            Console.WriteLine("\tAfter the sorting:");
            Console.WriteLine("\t_________________________________________________________");
            r.Sorting(r.Rate, r.Name, r.Grades);
            for (int i = 0; i < r.Rate.Length; i++)
            {
                Console.WriteLine("\t" + r.Name[i] + "\t\t" + r.Grades[i] + "\t\t" + r.Rate[i]);
            }
            Console.WriteLine("\t_________________________________________________________\n");
            Console.WriteLine("\tThe average rating is " + r.Average(r.Rate));
            Console.WriteLine("\tNumber of students with under average rating is " + r.UnderAv(r.Rate, r.Average(r.Rate)));
        }
    }
}
