using System;
using System.IO;
using System.Collections.Generic;

namespace SortingHat
{
    public class Output
    {
        private static void Sort(List<Student> students)
        {
            int n = students.Count -1;
        
            for ( int i = n; i>=1; i--)
            for ( int j = 2; j<=i; j++) 
                if (String.Compare(students[j-1].name, students[j].name, StringComparison.Ordinal) > 0 ) // comparaison de la position alphabetique des noms
                {
                    Student temp = students[j-1];
                    students[j-1] = students[j];
                    students[j] = temp;
                }
        }

        public static void SaveAssignments(SortingHat sh, string filename)
        {
            List<Student> st = new List<Student>();
            foreach (var sth in sh.Students)
                st.Add(sth);
            
            Sort(st);
            
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                foreach (var std in st)
                {
                    streamWriter.WriteLine(std.name + ": " + std.assignement);
                }
            }
        }
    }
}