using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.CodeDom;
using System.Dynamic;

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
    private Vector3 startPos;
    private float view;
    public GameObject actor;
    private Vector3 actorPosition;
    private Quaternion actorRotation;
    List<GameObject> secondaryActors;
    public CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        secondaryActors = new List<GameObject>();
        startPos = Camera.main.transform.position;
        view = Camera.main.fieldOfView;
        actorPosition = actor.transform.position;
        actorRotation = actor.transform.rotation;
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
        shotLoader();
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
        shotLoader();
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
        shotLoader();
    }
    void Reset()
    {
        Debug.Log("And this is called");
        cam.cameraPos = startPos;
        Camera.main.fieldOfView = view;
        actor.transform.position = actorPosition;
        actor.transform.rotation = actorRotation;
        foreach(GameObject act in secondaryActors)
        {
            Destroy(act);
        }
    }
    void shotLoader()
    {
        Debug.Log(startPos);
        Reset();
        if(shotText.text == "Full")
        {
            cam.cameraPos = new Vector3(0, 4.3000004f, -10);
        }
        else if(shotText.text == "Medium Close Up")
        {
            Camera.main.fieldOfView = 33f;
            cam.cameraPos = new Vector3(1.27f, 9.03f, -10);
        }
        else if(shotText.text == "Medium")
        {
            Camera.main.fieldOfView = 33f;
            cam.cameraPos = new Vector3(0.19f, 7.5f, -10);
        }
        else if(shotText.text == "Medium Full")
        {
            Camera.main.fieldOfView = 33f;
            cam.cameraPos = new Vector3(0.2f, 6.05f, -10);
        }
        else if(shotText.text == "Close Up")
        {
            Camera.main.fieldOfView = 15f;
            cam.cameraPos = new Vector3(0.2f, 8.91f, -10);
        }
        else if(shotText.text == "Extreme Close Up")
        {
            Camera.main.fieldOfView = 2f;
            cam.cameraPos = new Vector3(0.2f, 8.61f, -10);
        }
        else if(shotText.text == "Establishing")
        {
            Camera.main.fieldOfView = 160f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Master")
        {
            Camera.main.fieldOfView = 130f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Wide")
        {
            actor.transform.position = new Vector3(-10, 0, 0);
            actor.transform.rotation = Quaternion.Euler(0, 90, 0);
            GameObject newActor = Instantiate(actor, new Vector3(20, 0, 0), Quaternion.Euler(0, -90, 0));
            secondaryActors.Add(newActor);
            Camera.main.fieldOfView = 110f;
            cam.cameraPos = new Vector3(0.0f, 9f, -10);
        }
        else if (shotText.text == "Insert")
        {
            cam.cameraPos = new Vector3(3.84f, 0.22f, -10);
            Camera.main.fieldOfView = 7f;
        }
    }
}
