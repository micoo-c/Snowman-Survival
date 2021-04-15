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
    public float dashSpeed = 20;
    public float playerHealth = 5;
    private const float maxDashTime = 2.0f;
    public float dashDistance = 20;
    public float dashStoppingSpeed = 0.1f;
    float currentDashTime = maxDashTime;
    public float dashRate = .25f;
    private float nextDash;

    public AudioSource moveAudio;
    public AudioSource hurt;
    public AudioSource death;

    void Update()
    {
        MoveAround();
        if (Input.GetButtonDown("Jump") && Time.time > nextDash) // dash move
        {
            nextDash = Time.time + dashRate;
            currentDashTime = 0;
        }
        if (currentDashTime < maxDashTime)
        {
            moveAudio.Play();
            float horixontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(horixontalInput, 0, 0) * Time.deltaTime * dashSpeed);
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, verticalInput) * Time.deltaTime * dashSpeed);
            currentDashTime += dashStoppingSpeed;            
        }
    }

    void MoveAround() // general movement
    {
        float horixontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horixontalInput, 0, 0) * Time.deltaTime * _speedV);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * Time.deltaTime * _speedH);
        if(horixontalInput != 0 | verticalInput != 0 && moveAudio.isPlaying == false)
            {
            moveAudio.Play();
            }
    }

    public void Damage(int damageAmount) // damage to player
    {
        playerHealth -= damageAmount;
        hurt.Play();
        if (playerHealth <= 0)
        {
            hurt.Play();
            gameObject.SetActive(false);
        }
    }

    public void EnemyDeath() // play enemy death sound
    {
        death.Play();
    }
}
