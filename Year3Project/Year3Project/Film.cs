using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year3Project
{
    internal class Film
    {
        private string genre;
        private List<string> shots;
        public Film(string g)
        {
            genre = g;
            shots = new List<string>();
        }
        public void Add(string shot)
        {
            shots.Add(shot);
        }
        public void Add(List<string> shotList)
        {
            shots.AddRange(shotList);
        }
        public void Add(string shot, int index)
        {
            shots.Insert(index, shot);
        }
        public void Add(List<string> shotList, int index)
        {
            shots.InsertRange(index, shotList);
        }
        public string getGenre() { return genre; }
        public string getItem(int index)
        {
            return shots[index];
        }
        public int getListSize()
        {
            return shots.Count;
        }
        public static List<string> outputShots(string input, List<Film> films)
        {
            List<Film> matchingFilms = new List<Film>();
            List<string> output = new List<string>();
            for (int i = 0; i < films.Count; i++)
            {
                if (input == films[i].getGenre()) matchingFilms.Add(films[i]);
            }
            int smallestList = 100000;
            for (int i = 0; i < matchingFilms.Count; i++)
            {
                if (matchingFilms[i].getListSize() < smallestList)
                {
                    smallestList = matchingFilms[i].getListSize();
                }
            }
            for (int i = 0; i < smallestList; i++)
            {
                List<string> currentShots = new List<string>();
                for (int j = 0; j < matchingFilms.Count; j++)
                {
                    currentShots.Add(matchingFilms[j].getItem(i));
                }
                var common = currentShots.GroupBy(item => item).OrderByDescending(group => group.Count()).Select(group => group.Key).First(); //https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
                output.Add(common);
                //var common = (from item in currentShots
                //              group item by item into group
                //              orderby group.Count() descending
                //              select group.Key).First();
            }
            return output;
        }
    }
}
