using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStart
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");
            string file = "movies.csv";
            Console.WriteLine("Movie Library");
            int frst;
            
            do
            {
                Console.WriteLine("1) View Library\n 2) Add to library");
                frst = Int32.Parse(Console.ReadLine());

                while (frst == 1)
                {
                    try
                    {
                        logger.Info("Read File");
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);

                        }
                        sr.Close();
                        break;
                    }catch(Exception e)
                    {
                        logger.Error("File not read");
                    }
                }

                while (frst == 2)
                {
                    try {
                        logger.Info("Write file movie to file");
                        int id = 1;
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            id++;
                        }

                        string gen = "";
                        int i = 0;
                        Console.WriteLine("Enter Information Bellow");
                        Console.Write("Title:");
                        String title = Console.ReadLine();
                        Console.Write("Year: ");
                        int year = Int32.Parse(Console.ReadLine());
                        Console.Write("Genere (type X when finished");
                        string genre = "";
                        while (genre != "x" || genre != "X")
                        {
                            genre = Console.ReadLine();
                            gen += genre + " | ";
                            i++;

                            if (genre != "x" || genre != "X")
                            {
                                break;
                            }


                        }


                        string line3 = id.ToString() + ", " + title + ", " + "(" + year.ToString() + ")" + ", " + string.Join("|", gen);
                        StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine(line3);
                        sw.Close();
                        break;

                    }catch(Exception e)
                    {
                        logger.Error("File not writen");
                    }
                }

                Console.WriteLine("1) View Library\n2) Add to library\n3)Exit");
                frst = Int32.Parse(Console.ReadLine());

            } while (frst == 3);
           

        }

    } }
