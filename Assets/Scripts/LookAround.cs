using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public new Camera camera;
    //private GameObject selectedObject;
    //Ray ray;
    RaycastHit hitData;
    public float adjustment;

    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        lookAround();
    }

    void lookAround()
    {
        //RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.down, Vector3.up);
        if (Physics.Raycast(ray, out hitData, 1000)) //&& Input.GetMouseButtonDown(0))
        {
            //float selectedObject = hitData.transform.position.y;
            ground = new Plane(Vector3.down, hitData.point.y-adjustment);
        }
        //Physics.Raycast(ray, out hitData, 1000); //&& Input.GetMouseButtonDown(0))
        //ground = new Plane(Vector3.down, hitData.transform.position.y);

        if (ground.Raycast(ray, out float rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            //point = (point.x, point.y, point.z);
            transform.LookAt(point);
        }
    }

}
