using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] asteroids;
    int randomSpawnPoint, randomAsteroid;
    public static bool spawnAllowed;
    public static AudioSource audio1;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public Text Lives;
    public Text Score;
    public Text Score2;
    public Text HighestScore;
    public static int score;
    public static int life;
    public static int highscore;


    private void Awake()
    {
        Time.timeScale = 1;
        life = 5;
        score = 0;
        Canvas1.SetActive(true);
        Canvas2.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        
        spawnAllowed = true;
        InvokeRepeating("SpawnAsteroid", 0f, 1f);
        audio1 = GetComponent<AudioSource>();
        highscore = PlayerPrefs.GetInt("highscore", highscore);

    }

    private void Update()
    {
        Lives.text = "LIVES: " + life;
        Score.text = "SCORE: " + score;

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        if (life < 0)
        {
            Time.timeScale = 0;
            Score2.text = "Your Score: " + score;
            HighestScore.text = "HIGHSCORE: " + highscore;
 
             Canvas1.SetActive(false);
             Canvas2.SetActive(true);

        }

    }


    void SpawnAsteroid()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomAsteroid = Random.Range(0, asteroids.Length);
            Instantiate(asteroids[randomAsteroid], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
       
    }

  
}
