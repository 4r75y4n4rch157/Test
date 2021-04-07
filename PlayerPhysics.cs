using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponant (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour
{
    public LayerMask collisionMask;
    [HideInInspector]
    public bool grounded;
    private BoxCollider collider;
    private Vector3 boxSize;
    private Vector3 boxCenter;
    private float skin = .005f;
    ray ray;
    RaycastHit hit;

    void Start() 
    {
        collider = GetComponant<BoxCollider>();
        boxSize = collider.size;
        boxCenter = collider.center;
    }

    public void Move(Vector2 moveAmount)
    {
        float deltaY = moveAmount.y;
        float deltaX = moveAmount.x;
        Vector2 p = transform.position;
        grounded = false;
        
        for (int i = 0; i <= 3; i ++)
        {
            float dir = Mathf.Sign(deltaY);
            float x = (p.x + c.x - s.x/2) + s.x/2 * i;
            float y = p.y + c.y + s.y/2 * dir;

            ray = new Ray(new Vector2(x, y), new Vector2(0, dir));

            if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask)
            {//calculating distance between player and ground
                float dst = Vector3.Distance (ray.origin, hit.point);

                //never touch anything
                if (dst > skin)
                {
                    deltaY = -dst +skin;
                }
                else
                {
                    deltaY = 0;
                }
                griounded = true;
                break;
            }
        }
    }

    Vector2 finalTransform = new Vector2(deltaX, deltaY);

    transform.Translate(finalTransform);
}
