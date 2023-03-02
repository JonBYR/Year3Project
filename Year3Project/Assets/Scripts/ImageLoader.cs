using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Versioning;
public class Films
{
    public string[] shots;
    public string[] shotPaths;
    public string genre;
}
public class ImageLoader : MonoBehaviour
{
    public Image image;
    public TMP_Text shotText;
    public TMP_Text genreText;
    public TextAsset jsonFile;
    public TMP_Text errorText;
    public TMP_Text stillText;
    Sprite filmSprite;
    int index;
    int maxLength;
    Films film;
    // Start is called before the first frame update
    void Start()
    {
        
        //json tutorial from here https://forum.unity.com/threads/how-to-read-json-file.401306/
        film = JsonUtility.FromJson<Films>(jsonFile.text); //parse in the film object
        genreText.text = film.genre; //Display the film genre
        shotText.text = film.shots[0];
        stillText.text = (index + 1).ToString();
        filmSprite = Resources.Load<Sprite>(film.shotPaths[0]);
        image.sprite = filmSprite;
        index = 0;
        maxLength = film.shotPaths.Length;
        errorText.enabled = false;
    }
    public void Forward()
    {
        index++;
        if (index >= maxLength)
        {
            index = maxLength - 1;
            shotText.text = film.shots[maxLength - 1];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[maxLength - 1]);
            errorText.enabled = true;
            errorText.text = "Final previs shot reached!";
        }
        else
        {
            shotText.text = film.shots[index];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[index]);
            image.sprite = filmSprite;
            errorText.enabled = false;
            errorText.text = "";
        }
        
    }
    public void Back()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            shotText.text = film.shots[0];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[0]);
            errorText.enabled = true;
            errorText.text = "First previs shot reached!";
        }
        else
        {
            shotText.text = film.shots[index];
            stillText.text = (index + 1).ToString();
            filmSprite = Resources.Load<Sprite>(film.shotPaths[index]);
            image.sprite = filmSprite;
            errorText.enabled = false;
            errorText.text = "";
        }
        
    } 
}
