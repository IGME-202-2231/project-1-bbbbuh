using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField]
    float bulletSpeed;
    Vector3 velocity;
    Vector3 direction;

    [SerializeField]
    Camera cam;
    float camHeight;
    float camWidth;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0).normalized;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * bulletSpeed * Time.deltaTime;
        transform.position += velocity;
    }
}
