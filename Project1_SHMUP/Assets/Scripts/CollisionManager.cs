using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //singleton
    public static CollisionManager Instance {get; private set;}
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
    EnemyManager enemyManager;
    List<GameObject> enemies;
    List<GameObject> enemyBullets;

    [SerializeField]
    BulletManager bulletManager;
    List<GameObject> playerBullets;

    //camera
    [SerializeField]
    Camera cam;
    float camHeight;
    float camWidth;

    public float CamHeight { get { return camHeight; }}
    public float CamWidth { get {  return camWidth; }}

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance.transform.gameObject;
        playerBullets = bulletManager.BulletList;
        enemies = enemyManager.EnemyList;
        enemyBullets = enemyManager.EnemyBulletList;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {

        //enemy && bullet collision
        for (int i = enemies.Count - 1; i >= 0; i--) 
        {
            //playercollision
            if (CircleCollision(player, enemies[i])) {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
                
                if (!PlayerController.Instance.ParryActive) 
                {
                    PlayerController.Instance.GetComponent<ObjectInfo>().Health--;
                    PlayerController.Instance.GetComponent<ObjectInfo>().Hurt();
                    HealthScript.Instance.UpdateHealth(1);
                }
                else 
                {
                    ScoreScript.Instance.UpdateScore(10);
                    PlayerController.Instance.ParryTimer = PlayerController.Instance.ParryLockout;
                }
            }

            for (int j = playerBullets.Count - 1; j >= 0; j--)
            {
                if (CircleCollision(enemies[i],playerBullets[j])) 
                {
                    enemies[i].GetComponent<ObjectInfo>().Health--;
                    enemies[i].GetComponent<ObjectInfo>().Hurt();
                    ScoreScript.Instance.UpdateScore(1);

                    if (enemies[i].GetComponent<ObjectInfo>().Health <= 0) 
                    {
                        Destroy(enemies[i]);
                        enemies.RemoveAt(i);
                        ScoreScript.Instance.UpdateScore(10);
                    }


                    Destroy(playerBullets[j]);
                    playerBullets.RemoveAt(j);
                    
                }
            }
        }

        //delete offscreen bullets
        for (int j = playerBullets.Count - 1; j >= 0; j--) 
        {
            if (Mathf.Abs(playerBullets[j].transform.position.y) > camHeight/2 || Mathf.Abs(playerBullets[j].transform.position.x) > camWidth/2) 
            {
                Destroy(playerBullets[j]);
                playerBullets.RemoveAt(j);
            }
        } 

        //enemy bullets
        for (int i = enemyBullets.Count - 1; i >= 0; i--)
        {
            if (Mathf.Abs(enemyBullets[i].transform.position.y) > camHeight / 2 || Mathf.Abs(enemyBullets[i].transform.position.x) > camWidth / 2)
            {
                Destroy(enemyBullets[i]);
                enemyBullets.RemoveAt(i);
            }
            else if (CircleCollision(player, enemyBullets[i]))
            {
                if (PlayerController.Instance.ParryActive) 
                {
                    enemyBullets[i].GetComponent<SpriteRenderer>().color = Color.blue;
                    playerBullets.Add(enemyBullets[i]);
                    enemyBullets.RemoveAt(i);
                    PlayerController.Instance.ParryTimer = PlayerController.Instance.ParryLockout;
                    ScoreScript.Instance.UpdateScore(5);
                }
                else 
                {
                    Destroy(enemyBullets[i]);
                    enemyBullets.RemoveAt(i);
                    PlayerController.Instance.GetComponent<ObjectInfo>().Health--;
                    PlayerController.Instance.GetComponent<ObjectInfo>().Hurt();
                    HealthScript.Instance.UpdateHealth(1);
                }
                
            }
        }

        //win condition
        if (enemies.Count <= 0) 
        {
            gameObject.GetComponent<GameOverScript>().GameOver(true);
            Time.timeScale = 0;
        }

    }


    bool CircleCollision(GameObject objA, GameObject objB)
    {
        return (objA.GetComponent<ObjectInfo>().Radius + objB.GetComponent<ObjectInfo>().Radius) > (Mathf.Sqrt(Mathf.Pow(objB.transform.position.x - objA.transform.position.x, 2) + Mathf.Pow(objB.transform.position.y - objA.transform.position.y, 2)));
    }
}
