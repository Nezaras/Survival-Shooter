using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag ("player");

        //Mendapatkan komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();

        //Mendapat komponen Animator
        anim = GetComponent<Animator>();

        //Mendapatkan enemy health
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter (Collider other)
    {
        //set player dalam range
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        //set player jika tidak dalam range
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        // mentrigger animasi playerdead jika darah player kurang dari sama dengan 0
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        //Reset timer
        timer = 0f;

        // Taking damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
