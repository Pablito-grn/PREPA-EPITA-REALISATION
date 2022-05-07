using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ParseMyCSV
{
    class Program
    {
        static void Main(string[] args)
        {

        }
       
        public class Student
        {
            public string Name;
            public Houses House;
            public int Points;
            
            public Student(string name, Houses house, int points)
            {
                Name = name;
                House = house;
                Points = points;
            }
        }

        public enum Houses : int
        {
            None,
            Gryffindor,
            Hufflepuff,
            Ravenclaw,
            Slytherin,
        }
        public static void AssignHouse(Student student)
        {
            switch (student.Name)
            {
                case "Ron Weasley" : 
                case "Hermione Granger":
                case "Harry Potter": student.House = Houses.Gryffindor;
                    break;
                
                case "Draco Malfoy": student.House = Houses.Slytherin;
                    break;
                
                case "Ernie Macmillan":
                    break;
                
                case "Terry Boot":
                    break;
                
                default:
                    student.House = (Houses) new Random().Next(1, 5);
                    break;
            }
        }
        
        public static Dictionary<string, Student> CreateStudentsInfoFromFormat(string path)
        {
            Dictionary<string, Student> registrePoudlard = new Dictionary<string, Student>();

            if (File.Exists(path))
            {
                string line;
                string[] linetab;
                
                
                StreamReader parse = new StreamReader(path);

                while ((line = parse.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        linetab = line.Split(',');
                        Student sorcier = new Student(linetab[0], (Houses) int.Parse(linetab[1]) , int.Parse(linetab[2]));

                        if (sorcier.House == 0)
                        {
                            AssignHouse(sorcier);
                        }
                        registrePoudlard.Add(sorcier.Name, sorcier );
                    }
                }
                parse.Close();
            }
            else
            {
                Console.Error.Write(" Error: "+ path+ " does not exist");
            }
            return registrePoudlard;
        }

        public static void SaveStudents(Dictionary<string, Student> students, string dest)
        {
            File.Delete(dest);
            StreamWriter sauv = File.AppendText(dest);

            foreach (KeyValuePair<string, Student> appel in students)
                sauv.WriteLine(appel.Value.Name + ", " + appel.Value.House + ", " + appel.Value.Points);
            
            
            sauv.Close();
        }
        public static void AddPoints(Dictionary<string, Student> students, string student, int point)
        {
                if (students.ContainsKey(student))
                {
                    students[student].Points += point;
                }
                else
                {
                    Console.Error.Write("Error: " + student + " does not exist");
                }
        }

        public static void GivePoints(Dictionary<string, Student> students)
        {
            foreach (KeyValuePair<string, Student> eleve in students)
            {
                eleve.Value.Points += new Random().Next(0, 100);
            }
            AddPoints(students, "Harry Potter", 99999);
            AddPoints(students, "Hermione Granger", 99999);
            AddPoints(students, "Ron Weasley", 99999);
        }
        public static int test(int a, int b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }

        public static void WinnerOfTheHouseCup(Dictionary<string, Student> students)
        {
            int GryffindorPts = 0, HufflepuffPts = 0, RavenclawPts = 0, SlytherinPts = 0 , res;
            
            foreach (KeyValuePair<string, Student> eleve in students)
            {
                if (eleve.Value.House == (Houses) 1)
                    GryffindorPts += eleve.Value.Points;
                
                else if (eleve.Value.House == (Houses) 2)
                    HufflepuffPts += eleve.Value.Points;
                
                else if (eleve.Value.House == (Houses) 3)
                    RavenclawPts += eleve.Value.Points;
                
                else if (eleve.Value.House == (Houses) 4)
                    SlytherinPts += eleve.Value.Points;
            }

            res = test(test(GryffindorPts, HufflepuffPts), test(RavenclawPts, SlytherinPts));
            if (res == GryffindorPts)
                Console.Write("Winner of the House Cup is : Gryffindor");
            else if (res == HufflepuffPts)
                Console.Write("Winner of the House Cup is : Hufflepuff");
            else if (res == RavenclawPts)
                Console.Write("Winner of the House Cup is : Ravenclaw");
            else if (res == SlytherinPts)
                Console.Write("Winner of the House Cup is : Slytherin");

        }

        public static void ListofHouses(Dictionary<string, Student> students, string dest)
        {
            File.Delete(dest);
            var i = 1;
            StreamWriter sauv = File.AppendText(dest);

            while (i < 5)
            {
                sauv.WriteLine((Houses) i + " :");
                
                foreach (KeyValuePair<string, Student> eleve in students)
                {
                    if (eleve.Value.House == (Houses) i)
                        sauv.WriteLine(eleve.Value.Name);
                }
                
                sauv.WriteLine();

                i++;
            }
            sauv.Close();
            
        }

        public static void Update(Dictionary<string, Student> students, string path)
        {
            StreamReader upt = new StreamReader(path);
            string line;
            string [] command;

            while ((line = upt.ReadLine()) != null)
            {
                command = line.Split('/');
                if (command[0] == "RenameStudent")
                    students[command[1]].Name = command[2];
                
                else if (command[0] == "ChangeHouse")
                    students[command[1]].House = (Houses) int.Parse(command[2]);

                else if (command[0] == "AddStudent")
                    students.Add(command[1], new Student(command[1], (Houses) int.Parse(command[2]), int.Parse(command[3])));
                
                else if (command[0] == "RemoveStudent")
                    students.Remove(command[1]);
                //bonus
                else if (command[0] == "TricheCommePotter")
                    students[command[1]].Points = int.Parse(command[2]);
                
                else if (command[0] == "ReinitPoint")
                    students[command[1]].Points = int.Parse(command[2]);
                //
                else
                    Console.Error.Write("Error Invalid command");
            }

        }

        
        
        
        //-----------------------------------------Bonus---------------------------------------

        //eg: 'bonjour, je, suis, une, seule, valeur'
        public static void BetterCSV(string path)
        {
            if (File.Exists(path))
            {
                string line; string[] linetab = new string[] {};
                StreamReader parse = new StreamReader(path);

                while ((line = parse.ReadLine()) != null)
                    linetab = line.Split('\'');

                for (int i = 0; i < linetab.Length; i++)
                    Console.WriteLine(linetab[i]);
                
                parse.Close();
            }
            else
                Console.Error.Write(" Error: "+ path + " does not exist");
        }
        
        public static void BetterUpdate(Dictionary<string, Student> students, string path)
        {
            StreamReader upt = new StreamReader(path);
            string line;
            string [] command;

            while ((line = upt.ReadLine()) != null)
            {
                command = line.Split('/');
                if (command[0] == "RenameStudent")
                    students[command[1]].Name = command[2];
                
                else if (command[0] == "ChangeHouse")
                    students[command[1]].House = (Houses) int.Parse(command[2]);

                else if (command[0] == "AddStudent")
                    students.Add(command[1], new Student(command[1], (Houses) int.Parse(command[2]), int.Parse(command[3])));
                
                else if (command[0] == "RemoveStudent")
                    students.Remove(command[1]);
                
                else 
                    Console.Error.Write("Error Invalid command");
            }
    }
}