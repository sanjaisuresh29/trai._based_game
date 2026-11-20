using UnityEditor;
using UnityEngine;

public class OnlyonObject : MonoBehaviour
{
   // bool ontime = false;

    float timer = 3;

    public Drawwithmouse DLine;

    private bool startMovement = false;
    private Vector3[] positions;
    private int moveIndex = 0;
    [SerializeField] private float speed = 5f;

    private void Start()
    {
        Time.timeScale = 0.5f;

        Time.fixedDeltaTime *= Time.timeScale; 
    }
    private void OnMouseDown()
    {
       

        if(timer > 0) {
            Debug.Log("ok");

            DLine.Startline(transform.position);

        }
        
    }

    private void OnMouseDrag()
    {
        if(timer > 0)
        {
            DLine.UpdateLine();
            applyslowmo(0.3f);
        }
       
    }

    private void OnMouseUp()
    {
        if(timer > 0)
        {
            positions = DLine.EndLine();
            moveIndex = 0;
            startMovement = true;
            resumetime();
        }
       
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        //if(timer > 0)
        {
            if (startMovement == true)
            {
                Vector3 target = positions[moveIndex];
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) < 0.05f)
                {
                    moveIndex++;
                    if (moveIndex >= positions.Length)
                    {
                        startMovement = false;
                        timer = 3;
                    }
                }
            }
        }
            

        
    }

    public void applyslowmo(float scale)
    {
        Time.timeScale = scale;

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void resumetime()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }
}
