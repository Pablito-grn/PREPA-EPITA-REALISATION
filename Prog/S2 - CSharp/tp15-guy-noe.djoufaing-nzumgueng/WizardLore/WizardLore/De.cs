using System;
using System.Collections.Generic;
using System.IO;

namespace WizardLore
{
    public class De
    {
        //private const double valeurFace = 0.16666; //   1.0/6.0
        private Dictionary<int, string> faceDe = new Dictionary<int, string>();
        
        
        /*
        private static double ROUGE = 0;
        private static double VERTE = ROUGE + valeurFace;
        private static double BLEUE = VERTE + valeurFace;
        private static double DUEL = BLEUE;
        private static double RETRAITE = DUEL + 2 * valeurFace;
        */

        public De()
        {
            faceDe.Add(0, "ROUGE");
            faceDe.Add(1, "VERTE");
            faceDe.Add(2, "BLEUE");
            faceDe.Add(3, "DUEL");
            faceDe.Add(4, "RETRAITE");
        }
        
        
         public string LanceDe()
         {
             Random random = new Random();
             double randomFace = random.NextDouble() * (6 - 1) + 0;

             string res = "";
             
             foreach (var key in faceDe.Keys)
             {
                 if ((int) randomFace > key) 
                     res = faceDe[key];
                 else break;
             }
             return res;
         }
         
         
    }
}