using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarfRotate : MonoBehaviour
{
    //public new Camera camera;
    //private GameObject selectedObject;
    //Ray ray;
    //RaycastHit hitData;
    //public float adjustment;
    //yAngle = GetComponent<Head>();
    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -angle-90f, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
