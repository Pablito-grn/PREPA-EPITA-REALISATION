using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;

namespace SortingHat
{
    public enum Houses
    {
        Gryffindor = 0,
        Hufflepuff = 1,
        Slytherin = 2,
        Ravenclaw = 3,
        None,
    }
    public class SortingHat
    {
        public HouseInfo[] Houses;
        public HashSet<Student> Students;

        public SortingHat(HouseInfo[] houses, HashSet<Student> students)
        {
            Houses = houses;
            Students = students;
        }

        public void __ProcessAssignments(Student studentAtt)
        {
            foreach (var pref in studentAtt.preferences)
            {
                HouseInfo housePotentiel = Houses[(int) pref];

                if (housePotentiel.ranking.Count < housePotentiel.number_of_students)
                {
                    housePotentiel.ranking.Add(studentAtt);
                    studentAtt.assignement = pref; // On modifie la valeur d'assignement du student

                    // on relance le tri de la liste ===============================================================
                }
                else
                {
                    // un couple (m', w) existe
                    // On compare la moyen de l'eleve actuel avec celle du derniere de la liste de la house. je sais ca fait moche comme condition :{
                    if (housePotentiel.__GetAverage(studentAtt) >
                        housePotentiel.__GetAverage(housePotentiel.ranking[housePotentiel.ranking.Count - 1]))
                    {
                        //On desafecte
                        housePotentiel.ranking[housePotentiel.ranking.Count - 1].assignement =
                            global::SortingHat.Houses.None;
                        housePotentiel.ranking.RemoveAt(housePotentiel.ranking.Count - 1);

                        //On reaffecte
                        housePotentiel.ranking.Add(studentAtt);
                        studentAtt.assignement = pref;
                    }
                }
            }
        }


        public void ProcessAssignments()
        {
            Student studentAtt = IsManAlone(Students);

            do
            {
                __ProcessAssignments(studentAtt);
                studentAtt = IsManAlone(Students);

            } while (studentAtt != null && IsAllHouseNotFill());

        }

        public Student IsManAlone(HashSet<Student> students)
            // si on trouve un eleve libre, on regarde dans ses preferences les maisons qui ont encore des places disponibles
        {
            foreach (var man in students)
            {
                if (man.assignement == global::SortingHat.Houses.None)
                    return man;
            }
            
            return null;
        }

        public bool IsAllHouseNotFill()
        {
            foreach (var hs in Houses)
            {
                if (hs.ranking.Count < hs.number_of_students)
                    return true;
            }
            return false;
        }
        
        
    }
    
}