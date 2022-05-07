using System;
using System.IO;

namespace Basics
{
    class Basics
    {
        static void Main(string[] args)
        {
            
        }

        public static void PrintMe(string path)
        {
            if (File.Exists(path))
            {

                StreamReader fileR = new StreamReader(path);
                int i = 0;
                string line;


                while ((line = fileR.ReadLine()) != null)
                {
                    Console.WriteLine("Line " + i + " :  " + line);
                    i++;
                }

                fileR.Close();
            }
            else
            {
                Console.Error.Write("Error: " + path + "does not exist");
            }
        }

        public static void MyLs(string path)
        {
            int i = 1;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);

                FileInfo[] filer = di.GetFiles();
                DirectoryInfo[] folder = di.GetDirectories();

                foreach (FileInfo file in filer)
                    Console.Write(file.Name + " ");

                foreach (DirectoryInfo folde in folder)
                {
                    if (i < folder.Length)
                        Console.Write(folde.Name + " ");
                    else
                        Console.Write(folde.Name);
                }
            }
            else
            {
                Console.Error.WriteLine(path + " is not a directory");
            }
        }

        public static void FillMe(string path, string content)
        {
            if (Directory.Exists(path))
                Console.Error.WriteLine("Directory with the same name already exists");

            else
            {
                StreamWriter fw = File.AppendText(path);
                fw.WriteLine(content);
                fw.Close();
                Console.Write(content + " successfully in " + path);
            }
        }


        public static void CopyMe(string path, string dest)
        {
            string repUser;

            if (File.Exists(path))
            {

                if (File.Exists(dest))
                {
                    Console.Error.WriteLine("Warning: The file " + dest + " already exists");
                    Console.Write("Do you want to overwrite it (yes/no): ");
                    repUser = Console.ReadLine();

                    if (repUser.Equals("yes"))
                    {
                        File.Copy(path, dest, true);
                        Console.WriteLine("Copy from " + path + " to " + dest + " was successful");
                    }
                    else if (repUser.Equals("no"))
                        Console.Write("Mission aborted successfully");
                    else
                        Console.Error.Write("Error: bad input, you had one job...");
                }
                else
                {
                    File.Copy(path, dest);
                    Console.WriteLine("Copy from " + path + " to " + dest + " was successful");
                }
            }
            else
            {
                Console.Error.WriteLine(path + " does not exist, abort mission");
            }

        }

        public static char AsciiMajWeehl(char a, char b)
        {
            if ((int) a > 96 && (int) a < 123)
                a = (char) ((int) a - 32);

            var res = (int) a + (int) b - 65;

            while (res > 90)
                res -= 26;


            return ((char) res);
        }

        public static void enCryptoVerman(string decrypted, string key, string encrypted)
        {
            if (File.Exists(decrypted))
            {
                StreamReader fileR = new StreamReader(decrypted);

                StreamWriter fileW = File.AppendText(encrypted);
                int lstr, cptkey = 0;
                string line, result = "";


                while ((line = fileR.ReadLine()) != null)
                {
                    lstr = line.Length;
                    for (int i = 0; i < lstr; i++)
                    {
                        if (line[i] == ' ')
                            result += " ";
                        else
                        {
                            result += AsciiMajWeehl(line[i], key[cptkey]);
                            cptkey++;
                        }
                    }

                    fileW.WriteLine(result);
                    fileW.Close();
                }

                fileR.Close();
            }
            else
            {
                Console.Error.Write("Error: " + decrypted + "does not exist");
            }
        }

        public static char AsciiMajWeehl2(char a, char b)
        {
            int bi = (int) b;
            int res = (int) a - bi + 65;

            while (res < 65)
            {
                res += 26;
            }

            return ((char) res);
        }

        public static void deCryptoVerman(string encrypted, string key, string decrypted)
        {
            if (File.Exists(encrypted))
            {
                StreamReader fileR = new StreamReader(encrypted);

                StreamWriter fileW = File.AppendText(decrypted);
                int lstr, cptkey = 0;
                string line, result = "";


                while ((line = fileR.ReadLine()) != null)
                {
                    lstr = line.Length;
                    for (int i = 0; i < lstr; i++)
                    {
                        if (line[i] == ' ')
                            result += " ";
                        else
                        {
                            result += AsciiMajWeehl2(line[i], key[cptkey]);
                            cptkey++;
                        }
                    }

                    fileW.WriteLine(result);
                    fileW.Close();
                }

                fileR.Close();
            }
            else
            {
                Console.Error.Write("Error: " + encrypted + "does not exist");
            }
        }
// ---------------------------------------------Bonus------------------------------------------------------
        public static void BetterLs(string path)
        {
            int i = 1;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);

                FileInfo[] filer = di.GetFiles();
                DirectoryInfo[] folder = di.GetDirectories();

                foreach (FileInfo file in filer)
                    Console.Write(file.Name + " ");

                foreach (DirectoryInfo folde in folder)
                {
                    if (i < folder.Length)
                        Console.Write(folde.Name + "/ ");
                    else
                        Console.Write(folde.Name);
                }
            }
            else
            {
                Console.Error.WriteLine(path + " is not a directory");
            }
        }


    }
}

