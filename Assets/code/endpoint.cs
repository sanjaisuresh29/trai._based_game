using UnityEngine;

public class endpoint : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject j;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        for(int i = 0; i > objects.Length; i++)
        {
            if (objects[i].transform.position.x > j.transform.position.y)
            {

            }
        }

    }
}
