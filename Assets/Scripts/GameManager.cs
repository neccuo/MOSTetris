using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public SquareManager squareManager;

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject heartContainer;


    public int heartLeft = 3;

    void Update()
    {
        if(Input.GetKeyDown("space") && heartLeft > 0)
        {
            // universal spacebar
            bool isSuccess = squareManager.PlayMove();
            if(!isSuccess)
                LoseHeart();
        }
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void LoseHeart()
    {
        heartLeft--;
        Debug.Log("" + heartLeft + " heart left");
        if(heartLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        squareManager.StopCurrentSquares();
        gameOverText.SetActive(true);
    }
}
