using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }


    void Start ()
    {
        //Mengeksekusi fungsi spawn setiap beberapa detik sesuai dengan nilai spawn time
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //jika player telah mati maka atidak membuat enmy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //mendapatkan nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);

        //menduplikasi enemy
        GameObject newEnemy = Factory.FactoryMethod(spawnPointIndex);
        newEnemy.transform.position = spawnPoints[spawnPointIndex].position;
        Factory.FactoryMethod(spawnEnemy);

    }
}
