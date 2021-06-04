using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject player;

    [SerializeField] int numberOfPlatform;
    [SerializeField] float levelWidth;
    [SerializeField] float minY = .2f;
    [SerializeField] float maxY = 1f;
    void Start()
    {
        Vector3 spawnPosition = new Vector3(0, -3, 6.38f);

        for(int i = 0; i < numberOfPlatform; i++)
        {
            spawnPosition.y += (-player.transform.position.y/1.5f) - (1 - Random.Range(minY, maxY));
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            //spawnPosition.z = 6.38f;
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
