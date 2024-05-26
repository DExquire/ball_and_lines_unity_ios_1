using UnityEngine;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    [Header("Components")]
    //[SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LineRenderer trailRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;
    [SerializeField] private Rigidbody2D rigidBody;

    [Header("Line Settings")]
    [SerializeField] private float pointsMinDistance = 0.1f;
    private float circleColliderRadius;

    [HideInInspector] public List<Vector2> Points { get; private set; } = new List<Vector2>();
    [HideInInspector] public int PointsCount { get; private set; } = 0;

    private void Start()
    {
        //circleColliderRadius = lineRenderer.startWidth * 0.5f;
        circleColliderRadius = trailRenderer.startWidth * 0.5f;
        edgeCollider.edgeRadius = circleColliderRadius;
    }

    public void AddPoint(Vector2 newPoint)
    {
        if (PointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        Points.Add(newPoint);
        PointsCount++;

        AddCircleCollider(newPoint);

        UpdateLineRenderer();
        UpdateEdgeCollider();
    }

    public Vector2 GetLastPoint()
    {
        if (PointsCount > 0)
        {
            return Points[PointsCount - 1];
        }

        return Vector2.zero;
    }

    public void UsePhysics(bool usePhysics)
    {
        rigidBody.isKinematic = !usePhysics;
    }

    public void SetLineColor(Gradient colorGradient)
    {
        //lineRenderer.colorGradient = colorGradient;
        trailRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
       // lineRenderer.startWidth = width;
        trailRenderer.startWidth = width;
     //   lineRenderer.endWidth = width;
        trailRenderer.endWidth = width;
        circleColliderRadius = width * 0.5f;
        edgeCollider.edgeRadius = circleColliderRadius;
    }

    private void AddCircleCollider(Vector2 position)
    {
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = position;
        circleCollider.radius = circleColliderRadius;
    }

    private void UpdateLineRenderer()
    {
     //   lineRenderer.positionCount = PointsCount;
        trailRenderer.positionCount = PointsCount;
       // lineRenderer.SetPosition(PointsCount - 1, GetLastPoint());
        trailRenderer.SetPosition(PointsCount - 1, GetLastPoint());
    }

    private void UpdateEdgeCollider()
    {
        if (PointsCount > 1)
        {
            edgeCollider.points = Points.ToArray();
        }
    }
}
