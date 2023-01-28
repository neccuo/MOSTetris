using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public SquareManager squareManager;


    [SerializeField] InGameSounds inGameSounds;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWinText;

    [SerializeField] GameObject heartContainer;


    public int heartLeft = 3;

    void Update()
    {
        if(Input.GetKeyDown("space") && heartLeft > 0)
        {
            // universal spacebar
            PlaceRow();
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

    void PlaceRow()
    {
        inGameSounds.PlayHit();
        bool isSuccess = squareManager.PlayMove();
        if(isSuccess)
        {
            float moveRate = squareManager.GetCurrentMoveRate();
            inGameSounds.SetMusicPitchByMoveRate(moveRate);
            if(squareManager.IsWin())
                YouWin();
        }
        else
            LoseHeart();
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

    void YouWin()
    {
        inGameSounds.SetMusicPitchToDefault();
        youWinText.SetActive(true);
    }

    void GameOver()
    {
        inGameSounds.SetMusicPitchToDefault();
        squareManager.StopCurrentSquares();
        gameOverText.SetActive(true);
    }
}
