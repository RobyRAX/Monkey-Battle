using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float gameTimer;
    private int isAllPlayerReady;//2 for Ready

    public GameObject red;
    public GameObject blue;
    public GameObject redGround;
    public GameObject blueGround;

    public Text textTimer;
    public Text redWinText;
    public Text blueWinText;
    public Text drawText;
    public GameObject restartButton;
    public GameObject backToMenu;
    public GameObject bgOver;

    // Start is called before the first frame update
    void Start()
    {
        isAllPlayerReady = 0;

        redWinText.enabled = false;
        blueWinText.enabled = false;
        drawText.enabled = false;
        restartButton.SetActive(false);
        backToMenu.SetActive(false);
        bgOver.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        countDownTimer();
        whoWon();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void countDownTimer()
    {
        if(isAllPlayerReady == 2)//Game Start
        {
            charController redChar = red.GetComponent<charController>();
            charController blueChar = blue.GetComponent<charController>();
            redChar.isGameStart = true;
            blueChar.isGameStart = true;

            spawnCoin redCoin = redGround.GetComponent<spawnCoin>();
            spawnCoin blueCoin = blueGround.GetComponent<spawnCoin>();
            redCoin.isGameStart = true;
            blueCoin.isGameStart = true;

            if (gameTimer >= 0)
            {
                gameTimer -= Time.deltaTime;
                textTimer.text = gameTimer.ToString("0");
            }               
        }
    }

    void whoWon()
    {
        if(gameTimer <= 0)//Game Over
        {
            int redScore, blueScore;
            charController redChar = red.GetComponent<charController>();
            charController blueChar = blue.GetComponent<charController>();
            redScore = redChar.getScore();
            blueScore = blueChar.getScore();

            if(redScore > blueScore)//Red Won
            {
                redWinText.enabled = true;
                Destroy(blueWinText);
                Destroy(drawText);
            }
            else if(blueScore > redScore)//Blue Won
            {
                blueWinText.enabled = true;
                Destroy(redWinText);
                Destroy(drawText);
            }
            else if(blueScore == redScore)//Draw
            {
                drawText.enabled = true;
                Destroy(blueWinText);
                Destroy(redWinText);
            }

            bgOver.SetActive(true);
            restartButton.SetActive(true);
            backToMenu.SetActive(true);
            Time.timeScale = 0.25f;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void setReady()
    {
        isAllPlayerReady++;
    }

    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}


