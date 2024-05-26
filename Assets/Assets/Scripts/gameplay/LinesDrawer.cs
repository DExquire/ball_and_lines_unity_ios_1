using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
    private Camera camera;

    [Header("Line parameters")]
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    public Gradient lineColor;

    public float linePointsMinDist = 0.1f;
    public float lineWidth = 0.1f;

    private Line curLine;
    
    private int cantDrawOverLayerMask;

    private void Start()
    {
        cantDrawOverLayerMask = LayerMask.GetMask("CantDrawOver");
        camera = Camera.main;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginDrawLine();
        }

        if (curLine != null)
        {
            DrawLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDrawLine();
        }
    }

    private void BeginDrawLine()
    {
        curLine = Instantiate(linePrefab, transform).GetComponent<Line>();

        
        curLine.SetLineWidth(lineWidth);
        curLine.SetLineColor(lineColor);
        curLine.SetPointsMinDistance(linePointsMinDist);
        curLine.UsePhysics(false);
    }

    private void DrawLine()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePos, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayerMask);

        if (hit.collider)
        {
            StopDrawLine();
        }
        else
        {
            curLine.AddPoint(mousePos);
        }
    }

    private void StopDrawLine()
    {
        if (curLine != null)
        {
            if (curLine.PointsCount < 2)
            {
                Destroy(curLine.gameObject);
            }
            else
            {
                curLine.UsePhysics(true);
                curLine = null;
            }
        }
    }

}