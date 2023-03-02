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
    private Vector3 cameraPos;

    [Header("Camera Settings")] //use this to seperate public variables in inspector under a title
    public float speed;
    void Start()
    {
        cameraPos = this.transform.position; //get camera position
    }
    void Update()
    {
        float minview = 15f;
        float maxview = 90f;
        float sensitivity = 10f;
        float view = Camera.main.fieldOfView;
        view += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        view = Mathf.Clamp(view, minview, maxview);
        Camera.main.fieldOfView = view;
        /*
        float scrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWheelChange != 0)
        {
            float radius = scrollWheelChange * 15;
            float posX = Camera.main.transform.eulerAngles.x + 90; //up and down
            float posY = -1 * (Camera.main.transform.eulerAngles.y - 90); //left and right
            posX = posX / 180 * Mathf.PI; //converts to radians
            posY = posY / 180 * Mathf.PI;
            float x = radius * Mathf.Sin(posX) * Mathf.Sin(posY);
            float z = radius * Mathf.Sin(posX) * Mathf.Sin(posY);
            float y = radius * Mathf.Cos(posX);
            float cameraX = Camera.main.transform.position.x;
            float cameraY = Camera.main.transform.position.y;
            float cameraZ = Camera.main.transform.position.z;
            Camera.main.transform.position = new Vector3(cameraX + x, cameraY + y, cameraZ + z);
        }
        */
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
