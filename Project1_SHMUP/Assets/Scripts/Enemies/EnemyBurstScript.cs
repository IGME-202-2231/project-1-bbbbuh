using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstScript : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;
    [SerializeField]
    float speed;
    [SerializeField]
    float timeBetweenFire;
    [SerializeField]
    float stopTime;

    float timer;

    bool moving = true;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (moving)
        {
            if (transform.position.y > CollisionManager.Instance.CamHeight / 2 - 1)
            {
                direction = 0;
            }
            else if (transform.position.y < -CollisionManager.Instance.CamHeight / 2 + 1)
            {
                direction = 1;
            }
            else if (transform.position.x < -CollisionManager.Instance.CamWidth / 2 + 1)
            {
                direction = 2;
            }
            else if (transform.position.x > CollisionManager.Instance.CamWidth / 2 - 1)
            {
                direction = 3;
            }

            if (direction == 0)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction == 1)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (direction == 2)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (direction == 3)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }



        //fire timer
        timer += Time.deltaTime;
        if ((timer > timeBetweenFire && moving) || (timer > stopTime && !moving))
        {
            timer = 0;
            if (!moving)
            {
                direction = Random.Range(0, 4);
                timeBetweenFire = Random.Range(1, 4);
            }
            else
            {
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 0)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 45)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 90)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 135)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 180)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, -135)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, -90)));
                EnemyManager.Instance.EnemyBulletList.Add(Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, -45)));
            }
            moving = !moving;
        }
    }
}
