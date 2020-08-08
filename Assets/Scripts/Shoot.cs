using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damage = 1;
    public float fireRate = .25f;
    public float range = 50f;
    public float hitForce = 100f;
    public Transform barrelEnd;

    private Camera fpsCam;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());
        }

    }
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
