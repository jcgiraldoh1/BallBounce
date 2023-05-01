using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;  
    public GameObject timeTextUI;
    public Text timeText;
    int score  = 0;
    private float timeElapsed = 0f;
    private bool endGame = false;



    private void Start()
    {
        timeText.text = "Time: 00:00:00";
    }


    // Update is called once per frame
    void Update()
    {

        if (!endGame)
        {
            timeElapsed += Time.deltaTime;

            int hours = Mathf.FloorToInt(timeElapsed / 3600);
            int min = Mathf.FloorToInt((timeElapsed % 3600) / 60);
            int seg = Mathf.FloorToInt(timeElapsed % 60);

            timeText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", hours, min, seg);
        }


    }

    public void IncreaseScore()
    {
        score++;
        if(score >= 10)
        {
            Win();
            endGame = true;
        }
    }

    void Win()
    {
        winText.SetActive(true);        
        restartButton.SetActive(true);
        timeTextUI.SetActive(true);



    }

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
