using UnityEngine;

public class ObjectParenting : MonoBehaviour
{

    public GameObject parentObj;

    public GameObject childObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void SetParent()
    {
        childObj.transform.position = Vector3.zero;
        childObj.transform.parent = parentObj.transform;
    }
}
