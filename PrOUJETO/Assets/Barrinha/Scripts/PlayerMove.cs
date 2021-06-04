using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float dirX;
    [SerializeField] float movSpeed;    
    private GameObject scoreText;

    public float topScore = 0, actualScore;

    private void Start()
    {
        scoreText = GameObject.Find("Score Text");
    }
    void Update()
    {
       if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
            actualScore += 1;
        }
        scoreText.GetComponent<Text>().text = "Score: " + topScore.ToString("F0");
    }

    private void FixedUpdate()
    {
        dirX = Input.acceleration.x * movSpeed;
        rb.velocity = new Vector2(dirX , rb.velocity.y);
    }
}
