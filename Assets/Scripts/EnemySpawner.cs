using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyAmount;

    [SerializeField] Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawmEnemy());
        
    }

    IEnumerator SpawmEnemy()
    {
        while (true)
        {
            if (transform.childCount == 0)
            {
                for (int i = 0; i < enemyAmount; i++)
                {
                    GameObject enemy = Instantiate(enemyPrefab);
                    enemy.transform.parent = transform;
                    float randomX = Random.Range(-8, 8);
                    float randomY = Random.Range(-4, 4);

                    enemy.transform.position = new Vector3(randomX, randomY, 0);
                    player.AddEnemy(enemy.GetComponentInChildren<Enemy>());

                    yield return new WaitForSeconds(1);
                }
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
