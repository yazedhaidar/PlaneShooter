using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public ObjectSpawnRate[] enemies;

    private List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        StartCoroutine(spawnDelay());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnDelay()
    {
        while(true)
        {
            if(GameManager.getInstance().isPlaying)
            {
                Spawn();
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return null;
            }
       
            
        }
    }

    public void Spawn()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-7.5f, 7.5f);

       enemyList.Add(Instantiate(getEnemy(), newPosition, transform.rotation));
    }

    public void clearEnemies()
    {
        foreach(GameObject go in enemyList)
        {
            Destroy(go);
        }
        enemyList.Clear();
    }


    
    private GameObject getEnemy()
    {
        int limit = 0;
        foreach (ObjectSpawnRate osr in enemies)
        {
            limit += osr.rate;
        }

        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in enemies)
        {
            if (random < osr.rate)
            {
                return osr.prefab;
            }
            else
            {
                random -= osr.rate;
            }
            
        }
        return null;
    }
}
