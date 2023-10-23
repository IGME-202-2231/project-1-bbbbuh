using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    float radius;

    float timer = 0;
    bool hurtAnim = false;

    public int Health { get { return health; } set { health = value; } }

    public float Radius { get { return radius; } set { radius = value; } }

    bool onCooldown = false;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Update()
    {
        if (hurtAnim) 
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                hurtAnim = false;
                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    

    public void Hurt()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        hurtAnim = true;
    }
}
