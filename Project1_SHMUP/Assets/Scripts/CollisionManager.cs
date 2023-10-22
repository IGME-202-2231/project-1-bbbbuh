using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionManager : MonoBehaviour
{
    //singleton
    public static CollsionManager Instance {get; private set;}
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

    // game objects
    GameObject player;


    [SerializeField]
    List<GameObject> enemies;

    [SerializeField]
    BulletManager bm;
    List<GameObject> playerBullets;

    //camera
    [SerializeField]
    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance.transform.gameObject;
        playerBullets = bm.BulletList;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {

        //enemy && bullet collision
        for (int i = 0; i < enemies.Count; i++) 
        {
            //playercollision
            if (AABBCheck(player, enemies[i])) {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);

                PlayerController.Instance.Health--;
                if (PlayerController.Instance.Health <= 0) {
                    Destroy(player);
                }
            }

            for (int j = 0; j < playerBullets.Count; j++) 
            {
                if (AABBCheck(enemies[i],playerBullets[j])) 
                {   
                    // enemies[i].Health--;

                    // if (enemies[i].Health <= 0) 
                    // {
                    //     Destroy(enemies[i]);
                    //     enemies.RemoveAt(i);
                    // }
                    
                    
                    Destroy(playerBullets[j]);
                    playerBullets.RemoveAt(j);
                
                    i--;
                    j--;
                }
            }
        }

        //delete offscreen bullets
        for (int j = 0; j < playerBullets.Count; j++) 
        {
            if (Mathf.Abs(playerBullets[j].transform.position.y) > camHeight/2 || Mathf.Abs(playerBullets[j].transform.position.x) > camWidth/2) 
            {
                GameObject current = playerBullets[j];
                playerBullets.RemoveAt(j);
                Destroy(current);
            }
        } 
        
    }

    bool AABBCheck(GameObject objA, GameObject objB)
    {
        Renderer rendererA = objA.GetComponent<Renderer>();
        Renderer rendererB = objB.GetComponent<Renderer>();

        Bounds boundsA = rendererA.bounds;
        Bounds boundsB = rendererB.bounds;

        return boundsB.min.x < boundsA.max.x &&
           boundsB.max.x > boundsA.min.x &&
           boundsB.max.y > boundsA.min.y &&
           boundsB.min.y < boundsA.max.y;
    }
}
