using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] int gameLevelNumber;

    int myScore = -1;
    [SerializeField] Text scoreDisplay1;
    [SerializeField] Text scoreDisplay2;

    [SerializeField] float speedInterval;

    private void OnEnable()
    {
        instance = this;
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(gameLevelNumber);
    }

    public void TurnButton()
    {
        if (!BallController.instance.isStarted)
        {
            BallController.instance.isStarted = true;
        }
        BallController.instance.isGoingRight = !BallController.instance.isGoingRight;
        AddScore();
    }

    void AddScore()
    {
        myScore++;
        scoreDisplay1.text = myScore.ToString();
        scoreDisplay2.text = myScore.ToString();

        SpeedUp();
    }

    void SpeedUp()
    {
        BallController.instance.currentSpeed += speedInterval;
    }


}
