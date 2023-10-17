using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    float radius = 1.0f;

    [SerializeField]
    SpriteRenderer sRenderer;

    [SerializeField]
    Vector2 rectSize = Vector2.one;

    [SerializeField]
    bool useRendererBounds = true;

    bool circleMode = false;

    bool isColliding = false;

    public Vector2 RectMin 
    {
        get {return (Vector2)transform.position - (rectSize/2); }

    }

    public Vector2 RectMax
    {
        get {return (Vector2)transform.position + (rectSize/2); }
        
    }

    public float Radius {get {return radius;}}

    public bool IsColliding { get { return isColliding; } set { isColliding = value; } }

    public bool CircleMode { get { return circleMode; } set { circleMode = value; }}

    // Update is called once per frame
    void Update()
    {
        if (isColliding) 
        {
            sRenderer.color = Color.red;
        }
        else 
        {
            sRenderer.color = Color.white;
        }

        if (useRendererBounds) 
        {
            rectSize = sRenderer.bounds.extents * 2;
        }
    }
}