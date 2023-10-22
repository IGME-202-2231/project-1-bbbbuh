using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    Vector3 velocity;
    Vector3 direction;

    private void Start()
    {
        direction = new Vector3(Mathf.Cos((transform.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad), 0);
        direction.Normalize();
        Debug.Log(transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * bulletSpeed * Time.deltaTime;
        transform.position += velocity;
    }
}
