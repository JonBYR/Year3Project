using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Year3Project.Model;
namespace Year3Project.Controller
{
    public class FilmController
    {
        List<Film> films;
        List<Film> matchedFilms;
        Film outputFilm;


        // Make new film reference if we don't have one.
        public FilmController()
        {
            films = new List<Film>();
            matchedFilms = new List<Film>();
            outputFilm = new Film();
        }

        // Take the film and make it global to this class.
        public FilmController(List<Film> films)
        {
            this.films = films;
            matchedFilms = new List<Film>();
            outputFilm = new Film();    
        }

        // Match film to create a subset.
        public void GetOutputShotsFromGenre(string genre)
        {
            List<Film> matchingFilms = new List<Film>();
            outputFilm.genre = genre;

            foreach (Film film in films)
            {
                if (film.genre.ToLower() == genre.ToLower())
                {
                    matchingFilms.Add(film);
                }
            }

            matchedFilms = matchingFilms;
        }
        //This will get the most common shots for the specific genre the user specifies
        public void GetMostCommonShots()
        {
            
            int smallestSize = 100000;
            List<int> shotListSizes = new List<int>();
            for(int i = 0; i < matchedFilms.Count; i++)
            {
                shotListSizes.Add(matchedFilms[i].shots.Count);
            }
            shotListSizes.Sort(); //sorts in ascending order
            smallestSize = shotListSizes[shotListSizes.Count - 2]; //allows for comparisons with at most two films
            /*
            for (int i = 0; i < matchedFilms.Count; i++)
            {
                if (matchedFilms[i].shots.Count < smallestSize)
                {
                    smallestSize = matchedFilms[i].shots.Count;
                }
            }
            */
            for (int i = 0; i < smallestSize; i++)
            {
                List<string> currentShots = new List<string>();

                //for each position, store a list of all the shots at this position
                for (int j = 0; j < matchedFilms.Count; j++)
                {
                    if (i >= matchedFilms[j].shots.Count) continue; //if we find a list that is smaller than what i currrently is then it will not be used
                    else currentShots.Add(matchedFilms[j].shots[i]);
                }
                //ShotStatistics stats = new ShotStatistics(i, currentShots);
                var common = currentShots.GroupBy(item => item).OrderByDescending(group => group.Count()).Select(group => group.Key).First(); //https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
                outputFilm.shots.Add(common);
                //stats.shotsBreakdown();
            }
        }

        // Returns path to each image.
        public void MatchShotLibraryShotToFilmShot()
        {
            foreach (string shot in outputFilm.shots)
            {
                string shotPng = $"{shot}";
                outputFilm.shotPaths.Add(Path.Combine(outputFilm.genre, shotPng));
            }
        }

        // Create a json object.
        public void SerializeFilm()
        {
            using(StreamWriter jsonWriter = new StreamWriter("C:\\Users\\Computing\\Documents\\GitHub\\Year3Project\\Year3Project\\Assets\\Resources\\Film.json"))
            {
                jsonWriter.Write(JsonConvert.SerializeObject(outputFilm));
            }
            
        }
    }
}
