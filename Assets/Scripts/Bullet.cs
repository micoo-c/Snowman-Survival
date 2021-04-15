using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Rigidbody rb;
    // Start is called before the first frame update
    private Vector3 refPos;
    private GameObject target;
    //private bool sticked = false;
    public int damage = 1;
    int hit = 0;

    void Start()
    {
        Destroy(gameObject, 10f);
        //rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        target = collision.gameObject;
        refPos = contact.point - target.transform.position;
        //sticked = true;
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        //Output the Collider's GameObject's name
        if (hit != 1)
        {
            Destroy(gameObject, 0f);
            //ShootableBox boxHealth = target.GetComponent<ShootableBox>();
            EnemyAI health = target.GetComponent<EnemyAI>();
            if (health != null)
            {
                health.Damage(damage);
            }
            hit = 1;
        }
            Debug.Log(collision.collider.name);
    }
}
