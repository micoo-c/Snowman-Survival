using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Rigidbody enemy;
    GameObject[] enemies;
    GameObject[] location;
    GameObject spawnLocation;
    GameObject player;
    Pathfinding.AIDestinationSetter target;

    // Start is called before the first frame update
    void Start()
    {
        location = GameObject.FindGameObjectsWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < 6)
        {
            int x = Random.Range(0,location.Length);
            spawnLocation = location[x]; // select random spawn location from list of spawns
            Rigidbody clone;
            clone = Instantiate(enemy, spawnLocation.transform.position, spawnLocation.transform.rotation); // spawn enemy
            target = clone.GetComponent<Pathfinding.AIDestinationSetter>();
            target.target = player.transform; // set path finding target to player
        }
    }
}
