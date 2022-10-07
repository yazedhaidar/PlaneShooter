using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;

    public bool isPlaying = false;

    public UnityAction OnGameOverAction;

    public ScriptableInteger life;
    public ScriptableInteger coin;

    public EnemySpawner spawner;

    public List<GameObject> items;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void gameOver()
    {
        isPlaying = false;
        OnGameOverAction?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
    }

    private void spawnPlayer()
    {
       activePlayer = Instantiate(playerPrefab);
    }

    public static GameManager getInstance()
    {
        return instance;
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
       
    }

    public void starGame()
    {
        isPlaying = true;
        spawnPlayer();
    }

    public void pauseGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    internal void retryGame()
    {
        life.reset();
        coin.reset();
        spawner.clearEnemies();
        ObjectPool.GetInstance().deactivateAllObjects();
        clearAllItems();
    
    }

    public void resumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }
    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);
    }

    public void clearAllItems()
    {
        foreach(GameObject go in items)
        {
            Destroy(go);
        }
        items.Clear();
    }

}
