using UnityEngine;

public class droppItem : MonoBehaviour
{
    public GameObject item;
    private bool firstDrop = true;
    
    public void Dropp() {
        if (firstDrop)
        {
            Instantiate(item, this.transform.position, Quaternion.identity);
            firstDrop = false;
        }
    }
}
