using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public SquareManager squareManager;


    [SerializeField] InGameSounds inGameSounds;
    [SerializeField] Text heartLeftText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWinText;


    private int heartLeft = 2;

    private void Start() 
    {
        HeartLeftTextUpdate();
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && heartLeft >= 0)
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

    void HeartLeftTextUpdate()
    {
        heartLeftText.text = heartLeft.ToString();
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
        if(heartLeft < 0)
            GameOver();
        else
        {
            HeartLeftTextUpdate();
            Debug.Log("" + heartLeft + " heart left");
        }
    }

    void YouWin()
    {
        inGameSounds.SetMusicPitchToDefault();
        youWinText.SetActive(true);
    }

    void GameOver()
    {
        inGameSounds.SetMusicPitchToLose();
        squareManager.StopCurrentSquares();
        gameOverText.SetActive(true);
    }
}
