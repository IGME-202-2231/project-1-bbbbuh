using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryController : MonoBehaviour
{
    //singleton
    public static ParryController Instance {get; private set;}
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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerController.Instance.gameObject.transform.position;
        transform.rotation = PlayerController.Instance.gameObject.transform.rotation;
    }
}
