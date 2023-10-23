using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    Text gameOver;
    [SerializeField]
    Text finalScore;


    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        finalScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        finalScore.text = "Final Score: " + ScoreScript.Instance.Score;
        gameOver.gameObject.SetActive(true);
        finalScore.gameObject.SetActive(true);
        HealthScript.Instance.gameObject.SetActive(false);
        ScoreScript.Instance.gameObject.SetActive(false);
    }
}
