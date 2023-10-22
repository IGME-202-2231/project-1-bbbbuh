using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //singleton
    public static EnemyManager Instance { get; private set; }
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

    //lists
    List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> EnemyList { get { return enemyList; } set { enemyList = value; } }

    List<GameObject> enemyBulletList = new List<GameObject>();
    public List<GameObject> EnemyBulletList { get { return enemyBulletList; } set { enemyBulletList = value; } }

    //enemies
    [SerializeField]
    GameObject meleeEnemy;
    [SerializeField]
    GameObject burstEnemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyList.Add(Instantiate(meleeEnemy, new Vector3(-2, 4, 0), Quaternion.identity));
        enemyList.Add(Instantiate(meleeEnemy, new Vector3(-6, 0, 0), Quaternion.identity));
        enemyList.Add(Instantiate(meleeEnemy, new Vector3(8, 3, 0), Quaternion.identity));
        enemyList.Add(Instantiate(meleeEnemy, new Vector3(5, -3, 0), Quaternion.identity));
        enemyList.Add(Instantiate(burstEnemy, new Vector3(-5, -6, 0), Quaternion.identity));
        enemyList.Add(Instantiate(burstEnemy, new Vector3(5, -6, 0), Quaternion.identity));
        enemyList.Add(Instantiate(burstEnemy, new Vector3(-5, 6, 0), Quaternion.identity));
        enemyList.Add(Instantiate(burstEnemy, new Vector3(5, 6, 0), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
