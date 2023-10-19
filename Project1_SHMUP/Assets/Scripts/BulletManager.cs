using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //shooting
    [SerializeField]
    GameObject bullet;
    bool canFire = true;
    float timer = 0f;

    [SerializeField]
    float timeBetweenFire;

    List<GameObject> bulletList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //shooting
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire) 
        {
            canFire = false;
            bulletList.Add(Instantiate(bullet, PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation));
            foreach (GameObject obj in bulletList) {
                Debug.Log("bullet");
            }
        }
    }
}
