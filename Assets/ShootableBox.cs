using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth;
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
