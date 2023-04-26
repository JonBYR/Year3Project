using UnityEngine;
using UnityEditor;
using Year3Project.Model;
using Year3Project.Controller;
using System.IO;
using System.Runtime.Versioning;
using System.Collections.Generic;
using UnityEngine.UIElements;
//taken from Unity documentation https://docs.unity3d.com/ScriptReference/EditorWindow.html
public class GenreGeneratorWindow : EditorWindow
{
    FilmController filmController;
    string inputGenre = "";
    public TextAsset filmFile;
    List<string> acceptableStrings = new List<string>() { "action", "thriller", "comedy", "western" };
    // Add menu named "My Window" to the Window menu
    [MenuItem("Tools/Genre Generation")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        GenreGeneratorWindow window = (GenreGeneratorWindow)EditorWindow.GetWindow(typeof(GenreGeneratorWindow), false, "Genre Generator");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Output", EditorStyles.boldLabel);
        inputGenre = EditorGUILayout.TextField("Genre", inputGenre);
        
        if (GUILayout.Button("Start Genre Generation"))
        {
            inputGenre = inputGenre.Trim();
            if(acceptableStrings.Contains(inputGenre.ToLower()))
            {
                string[] filme = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Films.txt"));
                List<Film> myFilms = Film.FilmObjectsFromDatafile(filme);
                filmController = new FilmController(myFilms);
                filmController.GetOutputShotsFromGenre(inputGenre);
                filmController.GetMostCommonShots();
                filmController.MatchShotLibraryShotToFilmShot();
                filmController.SerializeFilm();
                AssetDatabase.Refresh();
                EditorUtility.DisplayDialog("Genre Generator", $"Film Sequence of {char.ToUpper(inputGenre[0]) + inputGenre.Substring(1).ToLower()} has been generated.", "Ok");
            }
            else
            {
                Debug.Log("Invalid Genre Given! Please give a genre of Western, Action, Thriller or Comedy");
            }
        }
        
        
    }
}
