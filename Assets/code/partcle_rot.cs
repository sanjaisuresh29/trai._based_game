using UnityEngine;

public class partcle_rot : MonoBehaviour
{
    public Transform parent;

    public Transform child;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        child.rotation = parent.rotation;
    }
}
