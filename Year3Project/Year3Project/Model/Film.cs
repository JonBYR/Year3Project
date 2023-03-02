using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year3Project.Model
{
    public class Film
    {
        public List<string> shots { get; set; }
        public List<string> shotPaths { get; set; }

        public string genre { get; set; }
        //public string name { get; set; }

        public Film()
        {
            shots = new List<string>();
            shotPaths = new List<string>();
        }

        public static List<Film> FilmObjectsFromDatafile(string[] filmFile)
        {
            // This is what we are adding to.
            List<Film> returnableFilms = new List<Film>();

            foreach (string line in filmFile)
            {
                Film returnableFilm = new Film();

                // Get Genre from First Part of the the line.
                returnableFilm.genre = line.Substring(0, line.IndexOf(':')).Trim();

                // Get Shots
                string lineWithoutGenre = line.Substring(line.IndexOf(':') + 1);
                string[] shotList = lineWithoutGenre.Split(",");

                // Converting array into shot list for the returnable Film object
                foreach (string shot in shotList)
                {
                    returnableFilm.shots.Add(shot.Trim());
                }

                returnableFilms.Add(returnableFilm);
            }

            // Give back a film object.
            return returnableFilms;
        }
    }
}
