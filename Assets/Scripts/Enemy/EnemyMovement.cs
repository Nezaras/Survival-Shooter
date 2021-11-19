using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    private void Awake ()
    {
        // Cari game object dengan tag player
        player = GameObject.FindGameObjectWithTag("player").transform;

        // Mendapatkan Reference component
        playerHealth = player.GetComponent<PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth> ();
        nav = GetComponent<NavMeshAgent> ();
    }


    void Update ()
    {
        // Memindahkan posisi player
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else // Hentikan moving
        {
            nav.enabled = false;
        }
    }
}
