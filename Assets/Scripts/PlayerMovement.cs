using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speedH = 5;
    [SerializeField]
    private float _speedV = 5;

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        moveAround();
    }

    void moveAround()
    {
        float horixontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horixontalInput, 0, 0) * Time.deltaTime * _speedV);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * Time.deltaTime * _speedH);
    }
}
