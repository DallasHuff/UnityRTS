using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{

    private int mDelta = 5;
    private int mSpeed = 25;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PanCamera();

    }

    private void PanCamera()
    {

        // Move Screen Right
        if (Input.mousePosition.x >= Screen.width - mDelta | Input.GetKey(KeyCode.RightArrow))
        {
            cam.transform.position += cam.transform.right * Time.deltaTime * mSpeed;
        }
        // Move Screen Left
        if (Input.mousePosition.x <= mDelta | Input.GetKey(KeyCode.LeftArrow))
        {
            cam.transform.position -= cam.transform.right * Time.deltaTime * mSpeed;
        }
        // Move Screen Up
        if (Input.mousePosition.y >= Screen.height - mDelta | Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.position += cam.transform.up * Time.deltaTime * mSpeed;
        }
        // Move Screen Down
        if (Input.mousePosition.y <= mDelta | Input.GetKey(KeyCode.DownArrow)) 
        {
            cam.transform.position -= cam.transform.up * Time.deltaTime * mSpeed;
        }
    }


}
