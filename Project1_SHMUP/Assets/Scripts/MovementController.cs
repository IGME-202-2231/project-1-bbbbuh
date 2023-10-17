using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //fields
    Vector3 objectPosition = Vector3.zero;
    
    [SerializeField]
    float speed = 1.0f;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Camera cam;
    float camHeight;
    float camWidth;

    //shooting
    Vector3 mousePos;
    [SerializeField]
    GameObject bullet;
    bool canFire = true;
    float timer = 0f;
    [SerializeField]
    float timeBetweenFire;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
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
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        if (newDirection != Vector3.zero) 
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + (direction * 2));
    }
}

