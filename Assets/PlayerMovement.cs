using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horixontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horixontalInput, 0, 0) * Time.deltaTime * _speed);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * Time.deltaTime * _speed);
        //float mouseXInput = Input.GetAxis("MouseX");
        //transform.Rotate(new Vector3(mouseXInput, 0, 0) * Time.deltaTime * _speed);
        //float mouseYInput = Input.GetAxis("MouseY");
        //transform.Rotate(new Vector3(0, 0, mouseYInput) * Time.deltaTime * _speed);
    }
}
