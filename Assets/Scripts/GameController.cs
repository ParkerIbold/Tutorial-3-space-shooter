using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWate;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool Gameover;
    private bool Restart;
    private int score;


    private void Start()
    {
        Gameover = false;
        Restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();

        StartCoroutine (SpawnWaves());
    }


    private void Update()
    {
        if (Restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Main"); // or whatever the name of your scene is
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWate);

            if (Gameover)
            {
                RestartText.text = "Press 'R' for Restart";
                Restart = true;
                break;
            }
        }


    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver ()
    {
        GameOverText.text = "Game Over!";
        Gameover = true;
    }
    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

}

