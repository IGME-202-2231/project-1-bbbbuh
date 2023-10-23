using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //singleton
    public static HealthScript Instance {get; private set;}
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
    private int health;
    
    [SerializeField]
    Text healthText;

    void Start()
    {
        health = PlayerController.Instance.GetComponent<ObjectInfo>().Health;
        healthText.text = "Health: " + health;
    }

    public void UpdateHealth(int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health;
    }
}
