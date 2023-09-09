using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private Transform[] obstaclePosition;
    [SerializeField] private GameObject[] obstacleOneLane;
    [SerializeField] private GameObject[] obstacleTwoLeftLane;
    [SerializeField] private GameObject[] obstacleTwoRightLane;
    [SerializeField] private GameObject[] obstacleAllLane;

    private void Awake()
    {

    }
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int posIndex = Random.Range(0, obstaclePosition.Length);
            switch (posIndex)
            {
                case 0:
                    RandomLeftLane(posIndex);
                    break;
                case 1:
                    RandomMiddleLane(posIndex);
                    break;
                case 2:
                    RandomRightLane(posIndex);
                    break;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void RandomLeftLane(int posIndex)
    {
        int obstacleType = Random.Range(0, 1);
        switch (obstacleType)
        {
            case 0:
                int objOneLaneIndex = Random.Range(0, obstacleOneLane.Length);
                Instantiate(obstacleOneLane[objOneLaneIndex], obstaclePosition[posIndex].position, Quaternion.identity, transform);
                break;
            case 1:
                int objTwoLaneIndex = Random.Range(0, obstacleTwoLeftLane.Length);
                Instantiate(obstacleTwoLeftLane[objTwoLaneIndex], obstaclePosition[posIndex].position, Quaternion.identity, transform);
                break;
        }
    }

    private void RandomRightLane(int posIndex)
    {
        int obstacleType = Random.Range(0, 1);
        switch (obstacleType)
        {
            case 0:
                int objOneLaneIndex = Random.Range(0, obstacleOneLane.Length);
                Instantiate(obstacleOneLane[objOneLaneIndex], obstaclePosition[posIndex].position, Quaternion.identity, transform);
                break;
            case 1:
                int objTwoLaneIndex = Random.Range(0, obstacleTwoRightLane.Length);
                Instantiate(obstacleTwoRightLane[objTwoLaneIndex], obstaclePosition[posIndex].position, Quaternion.identity, transform);
                break;
        }
    }

    private void RandomMiddleLane(int posIndex)
    {
        int randObj = Random.Range(0, obstacleAllLane.Length);
        Instantiate(obstacleAllLane[randObj], obstaclePosition[posIndex].position, Quaternion.identity, transform);
    }
}
