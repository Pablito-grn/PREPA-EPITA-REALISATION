using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;

namespace SortingHat
{
    public class HouseInfo
    {
        public int number_of_students; //représente le nombre d’élèves maximal que la maison va accepter.
        public int[] coefficients = new int[8];
        public int sum;
        public List<Student> ranking = new List<Student>();

        
        public HouseInfo(string input)
        {
            string[] tmp = input.Split(',');
            int tmp2; // == tmp
            sum = 0; // initialisation de la somme des coeffs

            number_of_students = Int32.Parse(tmp[0]);
            
            for (int i = 1; i < 9; i++)
            {
                tmp2 = Int32.Parse(tmp[i]);
                
                if (tmp2 < 0)
                    throw new InvalidDataException("Coefficients must be positive.");
                else
                {
                    coefficients[i-1] = tmp2;
                    sum += tmp2; //actualisation du test de nullité des coeffs 
                }
                
            }

            if (sum == 0)
                throw new InvalidDataException("Sum of coefficients cannot be equal to zero.");
        }

        private double GetAverage(Student student)
        {
            double moyenne = 0;
            for (int i = 0; i < 8; i++) // parcour des moyennes de l'eleve
                moyenne += student.grades[i] * coefficients[i];
            
            return moyenne / 8.0;

        }

        public double __GetAverage(Student student)
        {
            return GetAverage(student);
        }

        public void RankStudents(HashSet<Student> students)
        {
            (Student, double)[] noteEleve= new (Student, double)[students.Count]; // tableau qui servira a classer les eleves en fonctions de leurs notes.
            int i = 0;
            foreach (var st in students)
            {
                noteEleve[i] = (st, GetAverage(st));
                i++;
            }
            
            __RankStudentsBubbleSort(ref noteEleve); // On trie les eleves. la variable ref precise que on modifie la liste en place
            
            foreach (var st in noteEleve) // on ajoute l'eleve dans la liste des eleves triées
            {
                ranking.Add(st.Item1);
            }
        }

        static void __RankStudentsBubbleSort(ref (Student, double)[] table) 
        {
            int n = table.Length -1;
            
            for ( int i = n; i>=1; i--)
            for ( int j = 2; j<=i; j++) 
                if (table[j-1].Item2 > table[j].Item2)
                {
                    (Student, double) temp = table[j-1];
                    table[j-1] = table[j];
                    table[j] = temp;
                }
        }
        
        
    }
}