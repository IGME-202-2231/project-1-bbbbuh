using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //singleton
    public static PlayerController Instance {get; private set;}
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


    //fields
    //movement
    Vector3 objectPosition = Vector3.zero;
    
    [SerializeField]
    float speed = 1.0f;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    //camera
    [SerializeField]
    Camera cam;
    float camHeight;
    float camWidth;

    //mouse
    Vector3 mousePos;

    //stats
    int health;

    public int Health {get {return health;} set{health = value;}}

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        velocity = direction * speed * Time.deltaTime;
        objectPosition += velocity;
        
        if (objectPosition.y >= camHeight/2) 
        {
            objectPosition.y = -1 * camHeight/2;
        }
        else if (objectPosition.y <= -1 * camHeight/2)
        {
            objectPosition.y = camHeight/2;
        }

        if (objectPosition.x >= camWidth/2) 
        {
            objectPosition.x = -1 * camWidth/2;
        }
        else if (objectPosition.x <= -1 * camWidth/2)
        {
            objectPosition.x = camWidth/2;
        }


        transform.position = objectPosition;

        //mouse controls
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0,0,rotZ);


    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;      
    }

}

