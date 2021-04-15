using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int currentHealth;
    public float timeBetweenAttacks = 2f;
    public float wait = 0.8f;
    public int attackDamage = 1;
    bool playerInRange;
    float timer;

    public AudioSource attackSound;
    public AudioSource hurt;


    GameObject player;
    PlayerMovement playerHealth;

    GameObject enemy;
    Pathfinding.AIPath canmove;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerMovement>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        canmove = enemy.GetComponent<Pathfinding.AIPath>();
    }

    public void Damage(int damageAmount) // damage to enemy
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            playerHealth.EnemyDeath();
            gameObject.SetActive(false);
            Destroy(gameObject, 0f);
        }
        else 
        {
            hurt.Play();
        }
    }

    void OnCollisionEnter(Collision collision) // attack range collider
    {
        if (collision.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit(Collision collision) // attack range collider
    {
        if (collision.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange) // enemy attack speed check
        {
            Attack();
        }
    }

    void Attack() // enemy attack on player
    {
        attackSound.Play();
        timer = 0f;
        if (playerHealth.playerHealth > 0)
        {
            playerHealth.Damage(attackDamage);
        }
        StartCoroutine(StopMoving());
    }

    IEnumerator StopMoving() // stop movement during attack
    {
        canmove.canMove = false;
        yield return new WaitForSeconds(wait);
        canmove.canMove = true;
    }
}
