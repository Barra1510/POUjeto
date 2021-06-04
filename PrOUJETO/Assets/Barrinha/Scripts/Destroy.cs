using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{

    //[SerializeField] Text text;
    [SerializeField] GameObject player;
    //[SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject bluePlatPrefab;
    //public GameObject myPlat;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name.StartsWith("Platform 1"))
        {

            Destroy(collision.gameObject);
            if (Random.Range(1, 10) == 1)
            {
                Instantiate(bluePlatPrefab, new Vector3(Random.Range(-2.5f, 2.5f), player.transform.position.y + (5 + Random.Range(0.2f, 1.0f)), 6.38f), Quaternion.identity);
            }

        }

        if (collision.gameObject.name.StartsWith("Blue Platform"))
        {
            Destroy(collision.gameObject);
        }
    }

}