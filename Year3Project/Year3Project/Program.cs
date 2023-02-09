// See https://aka.ms/new-console-template for more information
using Year3Project;
using System;
using System.Linq;

namespace Year3Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filme = File.ReadAllLines("Films.txt");
            List<Film> trainFilms = new List<Film>();
            foreach(string line in filme)
            {
                Film lineFilm = new Film(line.Substring(0, line.IndexOf(':')).Trim());
                string commas = line.Substring(line.IndexOf(':') + 1);
                string[] commasList = commas.Split(',');
                List<string> lineShots = new List<string>();
                for (int i = 0; i < commasList.Length; i++)
                {
                    lineShots.Add(commasList[i].Trim());
                }
                lineFilm.Add(lineShots);
                trainFilms.Add(lineFilm);
            }
            string inputGenre;
            try
            {
                Console.WriteLine("Please input the type of genre you wish to test: Western, Action, Thriller or Comedy");
                inputGenre = Console.ReadLine();
                List<string> resultantShots = Film.outputShots(inputGenre, trainFilms);
                Console.WriteLine("Final shot sequence should therefore follow this guideline: ");
                resultantShots.ForEach(Console.WriteLine);
            }
            catch (InvalidGenre g)
            {
                Console.WriteLine(g.Message);
            }
        }

    }
}
