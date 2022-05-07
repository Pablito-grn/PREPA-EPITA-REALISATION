using System;
using System.Collections.Generic;
using System.IO;

namespace SortingHat
{
    public class Input
    {
        public static SortingHat ParseFile(string filename)
        {
            HouseInfo[] house = new HouseInfo[4];
            HashSet<Student> students = new HashSet<Student>();
            
            using (StreamReader streamReader = new StreamReader(filename))
            { 
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (i < 4)
                        house[i] = new HouseInfo(line);
                    else
                        students.Add(new Student(line));
                    i++;
                }
            }

            SortingHat hat = new SortingHat(house, students);
            return hat;
        }
    }
}