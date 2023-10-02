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
        velocity = direction * speed * Time.deltaTime;
        objectPosition += velocity;
        
        //leave space for movement validation
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
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        if (newDirection != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + (direction * 2));
    }
}

