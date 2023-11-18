using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRotater : MonoBehaviour
{
    public GameObject point;
    public float rotateSpeed = 100.0f;
    public float scrollSpeed = 2000.0f;
    private float xRotateMove, yRotateMove;

    bool isAlt;
    Vector2 clickPoint;
    float dragSpeed = 30.0f;
    void start(){
        point=GameObject.Find("EmptyObject");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) clickPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Input.GetMouseButton(0))
        {
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            Vector3 pos = point.transform.position;

            transform.RotateAround(pos, Vector3.right, -yRotateMove);
            transform.RotateAround(pos, Vector3.up, xRotateMove);

            transform.LookAt(pos);
        
        }
        else
        {
            float scroollWheel = Input.GetAxis("Mouse ScrollWheel");

            Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

            this.transform.position += cameraDirection * Time.deltaTime * scroollWheel * scrollSpeed;
        }
    }
}