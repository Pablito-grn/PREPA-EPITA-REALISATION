using System;
using System.Collections.Generic;

namespace Crypto
{
    public class Substitution
    {
        public static Dictionary<string, char> Morse = Utils.Morse;
        
        public static string Morse_decode(string message)
        {
            string[] messageArr = new string[] {};
            messageArr = message.Split(" ");
            string res = "";
            
            foreach (var letter in messageArr)
            {
                if (Utils.Morse.ContainsKey(letter))
                {
                    res += Utils.Morse[letter];
                }
                else
                {
                    Console.Error.WriteLine("Key Not found");
                    //break;
                }
            }

            return res;
        }
        
        public static string Morse_encode(string message)
        {
            string res = "";
            Dictionary<string, char>.KeyCollection cle = Utils.Morse.Keys;

            foreach (var letter in message)
            {
                if (Utils.Morse.ContainsValue(letter))
                {
                    foreach (var key in cle)
                    {
                        if (Utils.Morse[key] == letter)
                            res += key + " ";
                        
                    }
                }                
                else
                    Console.Error.WriteLine("Value Not found");
            }
            return res;        
        }
    }
}