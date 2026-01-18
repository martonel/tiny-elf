using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    public void changePosition(GameObject posObj)
    {
        this.gameObject.transform.position = posObj.transform.position;
    }

    public void changeCameraPosition(GameObject posObj)
    {
        this.gameObject.transform.position = new Vector3(posObj.transform.position.x, posObj.transform.position.y, -10f);
    }
}
