using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float dirX;
    [SerializeField] float movSpeed;
    [SerializeField] GameObject deathMenu;
    public float topScore = 0, actualScore;
    
    [SerializeField] GameObject scoreText;
    
    private SaveData saveData;    

    private void Start()
    {        
        deathMenu.SetActive(false);
        saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        //xml.LoadByXml();        
    }
    void Update()
    {
        Debug.Log(saveData);
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
            actualScore += 1;
            
        }
        scoreText.GetComponent<Text>().text = "Score: " + topScore.ToString("F0");
        if (transform.position.y <= topScore - 40)
        {            
            deathMenu.SetActive(true); //to set active the deathmenu that i created on canvas
            saveData.TransformScoreInMoney();
            Time.timeScale = 0;
            //to freeze the game

        }

    }    

    private void FixedUpdate()
    {
        dirX = Input.acceleration.x * movSpeed;
        rb.velocity = new Vector2(dirX , rb.velocity.y);
    }

    public void EndMiniGame()
    {        
        SceneManager.LoadScene(0);        
    }
}
