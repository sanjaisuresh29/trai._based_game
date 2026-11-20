using UnityEngine;

public class Drawwithmouse : MonoBehaviour
{
    public LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField] private float minDistance = 0.1f;

    private void Start()
    {
        if (line == null)
            line = GetComponent<LineRenderer>();

        line.positionCount = 0;
        line.useWorldSpace = true;
    }

    
    public void Startline(Vector3 startPos)
    {
        line.positionCount = 1;
        line.SetPosition(0, startPos);
        previousPosition = startPos;
    }

   
    public void UpdateLine()
    {
        Vector3 currentpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentpos.z = 0;
        if(Vector3.Distance(previousPosition,currentpos) > minDistance)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentpos);
            previousPosition = currentpos;
        }
    }

   
    public Vector3[] EndLine()
    {
        Vector3[] points = new Vector3[line.positionCount];
        line.GetPositions(points);
        return points;
    }
}
