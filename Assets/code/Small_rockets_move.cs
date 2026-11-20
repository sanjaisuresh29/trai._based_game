using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Small_rockets_move : MonoBehaviour
{
    public Vector2 minpos;
    public Vector2 maxpos;

    public GameObject[] rocckets;

    public float speed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    void assignlocation()
    {
        int xvalue = Random.Range(-8, 8);
        int yvalue = Random.Range(-4, 4);

        Vector2 xny = new Vector2(xvalue, yvalue);

        Vector2 direction = xny - rb.position;

        direction.Normalize();


        float rotateamount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateamount * 250;

        rb.linearVelocity = transform.up * speed;

        if (direction.x <= xny.x && direction.y <= xny.y)
        {
            Vector3 rota = new Vector2(this.transform.position.x + 5, this.transform.position.y);

            Vector3 zrot = new Vector3(0, 0, 45);
            transform.RotateAround(rota, zrot, 25 * Time.deltaTime);
        }
    }
}
