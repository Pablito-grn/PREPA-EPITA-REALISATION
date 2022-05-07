using System;
using System.Collections.Generic;

namespace CovidMeetsHogwarts
{
    public class PandemicSimulator
    {
        public static List<Human> infectious;
        
        /// <summary>
        /// initialize pandemic by infecting a random human by the corona virus in given location.
        /// </summary>
        /// <param name="location">location where the pandemic is simulated</param>
        public static void InitializePandemic(Location location)
        {
            Virus Covid19 = new Virus("Covid-19", 0.6, 3, 14);
            var randomHuman = alea(location.GetHumans().Count);
            location.GetHumans()[randomHuman].SetVirus(Covid19);
            location.GetHumans()[randomHuman].SetSir(Human.SIR.INFECTIOUS);
            infectious.Add(location.GetHumans()[randomHuman]);
        }
        
        public static int alea(int i = 10)
        {
            return (new Random().Next(i));
        }

        /// <summary>
        /// move/travel given human to a neighboring spot according to their
        /// travelling rate.
        /// </summary>
        /// <param name="human">human to move (or not)</param>
        static void MoveAround(Human human)
        {
            
            int nbAlea = alea(100);
            if (nbAlea < human.GetTravellingRate())
            {
                // recuperation DU VOISIN -------------------------------------
                int randNeighbours = alea(human.GetCurrentSpot().GetNeighbors().Count);
                Node currentPoint = human.GetCurrentSpot();
                
                human.GetCurrentSpot().GetHumans().Remove(human);
                human.SetCurrentSpot(currentPoint.GetNeighbors()[randNeighbours]);
            }
        }

        /// <summary>
        /// try to infect susceptible humans at the transmitter's spot.
        /// the following factors are taken into account:
        ///     - the virus' infection range
        ///     - the virus's transmission rate
        ///     - the average hygiene between the transmitter and the susceptible human
        ///     - the distance between the transmitter and the susceptible human (also average of social distance)
        /// </summary>
        /// <param name="transmitter">the human carrying the virus</param>
        /// <param name="justGotInfected">the list of humans to update when someone gets infected</param>
        static void InfectOthers(Human transmitter, List<Human> justGotInfected)
        {
            List<Human> human_list = transmitter.GetCurrentSpot().GetHumans();

            Virus virus = transmitter.GetVirus();
            double proba = virus.GetTransmissionRate();
            proba *= 100;

            int min;

            if (virus.GetInfectionRange() < human_list.Count)
            {
                min = virus.GetInfectionRange();
            }
            else
            {
                min = human_list.Count;
            }

            for (int i = 0; i < min; i++)
            {
                Random random = new Random();
                int nb_random1 = random.Next(100);

                if (proba >= nb_random1) 
                {
                    if (justGotInfected[i] == transmitter)
                    {
                        if (min<human_list.Count)
                        {
                            min++;
                        }
                        continue;
                    }

                    if (human_list[i].GetSir() == Human.SIR.SUSCEPTIBLE)
                    {
                        double moyenne_hygiene = (transmitter.GetHygiene() + human_list[i].GetHygiene()) / 2;
                        double moyenne_distance = (transmitter.GetSocialDistance() + human_list[i].GetSocialDistance()) / 2;
                        int nb_random2 = random.Next(100);

                        if ((moyenne_distance < nb_random2) && (moyenne_hygiene < nb_random2))
                        {
                            human_list[i].SetSir(Human.SIR.INFECTIOUS);
                            human_list[i].SetVirus(virus);
                            justGotInfected.Add(justGotInfected[i]);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// update pandemic by a unit of time at given location.
        ///     - infectious humans will infect around them
        ///     - some of the infectious humans will heal/die if enough days have passed
        ///     - some humans will travel to a neighboring spot
        /// the infectious list should be updated as well
        /// </summary>
        /// <param name="location">location where the pandemic is simulated</param>
        /// <returns>return number of infectious humans at this round</returns>
        public static int UpdatePandemic(Location location)
        {
            foreach (Human human in location.GetHumans())
            {
                if (human.GetSir() == Human.SIR.INFECTIOUS)
                {
                    int life = human.GetVirus().GetLifetime();
                    human.GetVirus().SetLifetime(life - 1); 

                    if (human.GetVirus().GetLifetime() > 0)
                    {
                        InfectOthers(human, infectious);
                    }

                    if (human.GetVirus().GetLifetime() == 0)
                    {
                        human.SetSir(Human.SIR.REMOVED);
                        human.SetVirus(null);
                        infectious.Remove(human);
                    }
                }
                MoveAround(human);
            }

            return infectious.Count;
        }
    }
}