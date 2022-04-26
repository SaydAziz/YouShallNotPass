using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set;}
    public GameObject[] player;
    public Transform[] spawners;
    public Transform[] camPos;
    private int level = 0;
    private int p1Spawn = 3;
    private int p2Spawn = 4;
    private int camPosIndex = 1;
    private Camera cam;
    private int p1Score = 0;
    private int p2Score = 0;
    public Text p1ScoreTxt;
    public Text p2ScoreTxt;

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
       SetPlayerSpawn(1, p1Spawn); 
       SetPlayerSpawn(2, p2Spawn); 
       cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetPlayerSpawn(int playerIndex, int spawnIndex)
    {
        player[playerIndex - 1].GetComponent<Player>().SetRespawnLoc(spawners[spawnIndex - 1]);
    }

    public void SetLevel(int next)
    {
        Debug.Log(next);
        p1Spawn += next * 2;
        p2Spawn += next * 2;
        camPosIndex += next;
        UpdateSpawners();
        cam.transform.position = camPos[camPosIndex].position;
        cam.backgroundColor = SwitchColor();
        
    }

    private void UpdateSpawners()
    {
        SetPlayerSpawn(1, p1Spawn);
        SetPlayerSpawn(2, p2Spawn);
        player[0].GetComponent<Player>().Respawn();
        player[1].GetComponent<Player>().Respawn();

    }

    public IEnumerator ResetGame()
    {
        Time.timeScale = 0;
        p1Spawn = 3;
        p2Spawn = 4;
        camPosIndex = 1;
        UpdateSpawners();
        cam.transform.position = camPos[camPosIndex].position;
        cam.backgroundColor = Color.red;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
    }

    private Color SwitchColor()
    {
        
        return cam.backgroundColor == Color.blue ? Color.red : Color.blue;     
    }

    public void AddScore(int player)
    {
        if (player == 1)
        {
            p1Score++;
            p1ScoreTxt.text = "Player 1: " + p1Score.ToString();
        }
        else if (player == 2)
        {
            p2Score++;
            p2ScoreTxt.text = "Player 2: " + p1Score.ToString();
        }
    }
}
