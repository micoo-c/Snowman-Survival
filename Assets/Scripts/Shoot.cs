using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    public AudioSource gunAudio;
    public float fireRate = .15f;
    private float nextFire;
    public Rigidbody projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            gunAudio.Play();
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * 20);
        }  
    }
}
