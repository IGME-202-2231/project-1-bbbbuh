using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //singleton
    public static ScoreScript Instance {get; private set;}
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    private int score = 0;

    public int Score { get { return score; } }
    
    [SerializeField]
    Text scoreText;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int change)
    {
        score += change;
        scoreText.text = "Score: " + score;
    }
}
