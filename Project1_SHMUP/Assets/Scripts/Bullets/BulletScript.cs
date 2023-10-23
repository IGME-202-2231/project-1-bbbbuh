using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField]
    float bulletSpeed;
    Vector3 velocity;
    Vector3 direction;

    Camera cam;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * bulletSpeed * Time.deltaTime;
        transform.position += velocity;
    }
}
