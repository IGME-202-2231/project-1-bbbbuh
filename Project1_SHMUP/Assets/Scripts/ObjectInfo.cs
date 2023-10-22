using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    float radius;

    public int Health { get { return health; } set { health = value; } }

    public float Radius { get { return radius; } set { radius = value; } }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
