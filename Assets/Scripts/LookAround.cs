using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public new Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        float rayDistance;

        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            transform.LookAt(point);
        }
    }

}
