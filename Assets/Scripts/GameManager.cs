using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set;}

    public GameObject[] player;
    public Transform[] spawners;

    void Awake()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(this);   //basic singleton pattern
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
       SetPlayerSpawn(1, 1); 
       SetPlayerSpawn(2, 2); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetPlayerSpawn(int playerIndex, int spawnIndex)
    {
        player[playerIndex - 1].GetComponent<Player>().SetRespawnLoc(spawners[spawnIndex - 1]);
    }
}
