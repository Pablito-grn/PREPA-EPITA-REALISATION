using System;

namespace Crypto
{
    public class Vigenere
    {
        public static string Vigenere_encode(string msg, string key)
        {
            int msgLen = msg.Length, keyLen = key.Length, tmp, tmp2, tmp3, j = 0;
            msg = msg.ToUpper();
            key = key.ToUpper();
            
            string res = "";

            for (int i = 0; i < msgLen; i++)
            {
                if (msg[i] != ' ')
                {
                    tmp = msg[i];
                    tmp2 = key[j % keyLen];
                    tmp3 = (tmp + tmp2) % 26;

                    if (tmp3 < 0)
                        res += (char) (91 + tmp3);
                    else
                        res += (char) (65 + tmp3);

                    j++;
                }
                else
                    res += " ";
                
            }

            return res;
        }

        public static string Vigenere_decode(string msg, string key)
        {
            int msgLen = msg.Length, keyLen = key.Length, tmp, tmp2, tmp3, j = 0;
            string res = "";

            for (int i = 0; i < msgLen; i++)
            {
                if (msg[i] != ' ')
                {
                    tmp = msg[i];
                    tmp2 = key[j % keyLen];
                    tmp3 = (tmp - tmp2) % 26;

                    if (tmp3 < 0)
                        res += (char) (91 + tmp3);
                    else
                        res += (char) (65 + tmp3);

                    j++;
                }
                else
                {
                    res += " ";
                }
            }

            return res;
        }
    }
}
