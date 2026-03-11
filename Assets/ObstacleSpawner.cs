using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    GameObject obstacle;
    bool isFalse = false;

    public List <GameObject> canavarList;

    void Start()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(0, canavarList.Count+1);
        if (random == canavarList.Count)
        {
            return;
        }
        obstacle = canavarList[random];
        obstacle.SetActive(true);
    }

    private void Update()
    {
        if (Player.Instance.kalpCount == 0 && !isFalse)
        {
            obstacle.SetActive(false);
            gameObject.SetActive(false);
            isFalse = true;
            
        }
    }
}
