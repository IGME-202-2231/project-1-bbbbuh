using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed;

    float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);



    }
    
}
