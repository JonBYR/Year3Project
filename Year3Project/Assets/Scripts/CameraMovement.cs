using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
//Tutorials used
//https://www.youtube.com/watch?v=k_-sOqkvoI8
//https://answers.unity.com/questions/218347/how-do-i-make-the-camera-zoom-in-and-out-with-the.html
public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraPos;

    [Header("Camera Settings")] //use this to seperate public variables in inspector under a title
    public float speed;
    void Awake()
    {
        cameraPos = this.transform.position; //get camera position
    }
    void Update()
    {
        float minview = 0f;
        float maxview = 180f;
        float sensitivity = 10f;
        float view = Camera.main.fieldOfView;
        view += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        view = Mathf.Clamp(view, minview, maxview);
        Camera.main.fieldOfView = view;
        if (Input.GetKey(KeyCode.W))
        {
            cameraPos.y += speed / 10;
        }
        if (Input.GetKey(KeyCode.S)) cameraPos.y -= speed / 10;
        if (Input.GetKey(KeyCode.A)) cameraPos.x -= speed / 10;
        if (Input.GetKey(KeyCode.D)) cameraPos.x += speed / 10;
        this.transform.position = cameraPos;
    }
}
