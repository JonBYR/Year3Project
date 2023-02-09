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
            Film Zulu = new Film("Action");
            List<string> zuluShots = new List<string> { "Medium Close Up", "Wide", "Establishing", "Establishing", "Wide", "Wide", "Master", "Master", "Master", "Establishing", "Master", "Master", "Wide", "Wide", "Master", "Wide", "Wide", "Master", "Wide", "Master", "Wide", "Medium Close Up", "Wide", "Medium", "Wide", "Master", "Wide", "Wide", "Master", "Establishing", "Wide", "Wide", "Establishing", "Establishing" };
            Zulu.Add(zuluShots);
            Film Memento = new Film("Thriller");
            List<string> mementoShots = new List<string> { "Establishing", "Medium", "Insert", "Close Up", "Insert", "Medium", "Full", "Medium Close Up", "Medium Close Up", "Insert", "Medium Close Up", "Insert", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium", "Medium Close Up" };
            Memento.Add(mementoShots);
            Film johnWick = new Film("Action");
            List<string> wickShots = new List<string> { "Medium Close Up", "Medium", "Medium", "Medium Close Up", "Medium Close Up", "Full", "Medium Full", "Medium Full", "Medium Close Up", "Close Up", "Wide", "Full", "Medium Close Up", "Medium Close Up", "Medium Full", "Medium", "Medium Full", "Medium", "Medium", "Wide", "Medium", "Wide", "Medium Full", "Wide", "Medium Full", "Wide", "Medium Full", "Medium", "Medium Full", "Medium Close Up", "Wide", "Full", "Medium", "Full", "Medium", "Close Up" };
            johnWick.Add(wickShots);
            Film grossePointBlank = new Film("Comedy");
            List<string> grossePointShots = new List<string> { "Close Up", "Full", "Master", "Master", "Full", "Medium", "Medium", "Insert", "Master", "Insert", "Medium", "Master", "Medium Full Shot", "Master", "Medium", "Master", "Close Up", "Full", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Full", "Medium Full", "Wide", "Medium", "Medium Full", "Medium", "Medium", "Medium Full", "Medium Full", "Wide", "Close Up", "Medium", "Medium", "Medium", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium" };
            grossePointBlank.Add(grossePointShots);
            Film marathonMan = new Film("Thriller");
            List<string> marathonShots = new List<string> { "Medium Close Up", "Medium", "Wide", "Close Up", "Medium Close Up", "Close Up", "Medium Close Up", "Close Up", "Medium Close Up", "Insert", "Medium", "Close Up", "Full", "Wide", "Medium", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Wide", "Medium Close Up", "Medium Close Up", "Medium Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Full", "Medium" };
            marathonMan.Add(marathonShots);
            Film libertyVallance = new Film("Western");
            List<string> libertyShots = new List<string> { "Medium Full", "Full", "Medium Full", "Full", "Medium Full", "Full", "Medium Full", "Full", "Medium Full", "Medium Full", "Medium Full", "Medium Full", "Medium", "Medium Full", "Medium", "Wide", "Insert", "Wide", "Medium Full", "Wide" };
            libertyVallance.Add(libertyShots);
            Film djangoUnchained = new Film("Western");
            List<string> djangoShots = new List<string> { "Close Up", "Medium Full", "Medium Close Up", "Medium", "Wide", "Full", "Full", "Full", "Wide", "Medium Close Up", "Medium Full", "Full", "Medium Close Up", "Insert", "Full", "Medium Full", "Wide", "Medium", "Medium", "Wide", "Medium" };
            djangoUnchained.Add(djangoShots);
            Film budapestHotel = new Film("Comedy");
            List<string> budapestShots = new List<string> { "Medium", "Wide", "Medium", "Insert", "Medium", "Medium", "Close Up", "Medium Full", "Medium", "Medium Full", "Wide", "Medium", "Medium Close Up", "Medium Close Up", "Wide", "Wide", "Full", "Full" };
            budapestHotel.Add(budapestShots);
            Film reserviorDogs = new Film("Action");
            List<string> dogsShots = new List<string> { "Wide", "Medium Full", "Full", "Medium Full", "Medium", "Medium Full", "Medium", "Medium", "Medium Close Up", "Medium Full", "Medium", "Medium Close Up", "Medium", "Medium Full", "Medium Close Up", "Medium", "Medium Close Up", "Wide", "Medium Close Up", "Medium", "Medium", "Medium Close Up", "Medium Close Up", "Wide" };
            reserviorDogs.Add(dogsShots);
            Film goodBadUgly = new Film("Western");
            List<string> goodBadUglyShots = new List<string> { "Wide", "Close Up", "Close Up", "Extreme Close Up", "Close Up", "Extreme Close Up", "Close Up", "Extreme Close Up", "Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Extreme Close Up", "Close Up", "Close Up", "Close Up", "Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Extreme Close Up", "Wide" };
            goodBadUgly.Add(goodBadUglyShots);
            List<Film> trainFilms = new List<Film> { Zulu, Memento, johnWick, grossePointBlank, marathonMan, libertyVallance, djangoUnchained, budapestHotel, reserviorDogs, goodBadUgly };
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
