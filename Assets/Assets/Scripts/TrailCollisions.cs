using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class TrailCollisions : MonoBehaviour
{
    TrailRenderer myTrail;
    public EdgeCollider2D myCollider;
    public EdgeCollider2D validCollider;

    static List<EdgeCollider2D> unusedColliders = new();

    void Awake()
    {
        myTrail = GetComponent<TrailRenderer>();
        myCollider = GetValidCollider();
        myCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetColliderTrailsToPoint(myTrail, myCollider);
    }

    EdgeCollider2D GetValidCollider()
    {
        EdgeCollider2D validCollider;
        if(unusedColliders.Count > 0)
        {
            validCollider = unusedColliders[0];
            validCollider.enabled = true;
            unusedColliders.RemoveAt(0);
        }
        else
        {
            validCollider = new GameObject("TrailCollider", typeof(EdgeCollider2D)).GetComponent<EdgeCollider2D>();
        }
        return validCollider;
    }

    void SetColliderTrailsToPoint(TrailRenderer trail, EdgeCollider2D collider)
    {
        if(Input.GetMouseButton(0))
        {
            myCollider.enabled = true;
        }
        
        List<Vector2> points = new();
        for(int position = 0; position<trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }

    private void OnDestroy()
    {
        if(myCollider != null)
        {
            myCollider.enabled = false;
            unusedColliders.Add(myCollider);
        }
    }
}
