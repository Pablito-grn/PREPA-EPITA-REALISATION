using System;
using System.IO;

namespace SortingHat
{
    public class Student
    {
        public int[] grades = new int[8];
        public Houses[] preferences = new Houses[4];
        public string name;
        public Houses assignement = global::SortingHat.Houses.None;
        
        public Student(string input)
        {
            string[] tmp = input.Split(',');
            int tmp2;
            name = tmp[0];
            for (int i = 1; i < 13; i++)
            {
                tmp2 = Int32.Parse(tmp[i]);

                if (i < 5)
                    preferences[i - 1] = (Houses) tmp2;

                else
                {
                    if (tmp2 < 0)
                        throw new InvalidDataException("Grades must be positive.");
                    
                    grades[i - 5] = tmp2;
                }

            }
        }
    }
}