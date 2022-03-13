using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;

    private void Awake() {
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore");
		highScoreText.text = "最高纪录： " + highScore;
    }

    public void IncreaseScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        highScore = PlayerPrefs.GetInt("Highscore");
        if(score > highScore){
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "最高纪录： " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanel.SetActive(true);
        Debug.Log("Bomb Hit");
    }

    public void RestartGame() {
        score = 0;
        scoreText.text = "0";

        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "Score: 0";

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable")) {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
}
