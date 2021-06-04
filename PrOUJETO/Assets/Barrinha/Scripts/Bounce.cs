using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float upForce;
    [SerializeField] Collider col;
    [SerializeField] PlayerMove player;

    private void Update()
    {        
       
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {
            col.enabled = true;
        }
        if (other.gameObject.GetComponent<Rigidbody>().velocity.y > 0)
        {
            col.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {
            col.enabled = false;
        }
        if (other.gameObject.GetComponent<Rigidbody>().velocity.y > 0)
        {
            col.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {
           
            Vector3 velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            velocity.y = upForce;
            collision.gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.y > 0)
        {
            //Debug.Log("desativar");
            //col.enabled = false;
            
        }

    }
}
