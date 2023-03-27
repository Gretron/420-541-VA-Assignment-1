using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    public Text scoreText;
    [SerializeField]
    private int sceneCount = 5;

    void Awake() 
    {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);    
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadFirstLevel() {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < sceneCount)
            SceneManager.LoadScene(currentScene + 1);
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(int points) 
    {
        score += points;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
