using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score, lives, highScore;

    public List<GameObject> targets;
    public Vector2 spawnRate;

    public bool isGameOver;

    [Header("User Interface Elements")]
    public TMP_Text scoreText, livesText, scoreTextGameOver, highScoreText;
    public GameObject gameOverScreen;

    public GameObject HUD;
    public GameObject titleScreen;


    void Start()
    {
        //StartCoroutine(spawnObjects());
        //score = 0;
        //scoreText.text = "Score " + score;
        //updateScore(0);
    }
    void Update()
    {
        
    }
    public void updateScore(int scoreToAdd)
    {
        if (lives <= 0)
        {
            gameOverState();
        }
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        highScoreText.text = "Highscore " + highScore;
    }
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
        StartCoroutine(spawnObjects());
        score = 0;
        //scoreText.text = "Score " + score;
        updateScore(0);
    }
    IEnumerator spawnObjects()
    {
        while (isGameOver == false)
        {
            int spawnIndex = Random.Range(0, targets.Count - 1);

            Instantiate(targets[spawnIndex]);

            float randomWaitTime = Random.Range(1, 5);

            yield return new WaitForSeconds(randomWaitTime);
        }
    }

    void gameOverState()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        scoreTextGameOver.text = "SCORE " + score;
        highScoreText.text = "HIGHSCORE " + PlayerPrefs.GetInt("Highscore");
        if(PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        HUD.SetActive(false);
    }
    
    public void restartLevel()
    {
        SceneManager.LoadScene(0);
    }    
}
