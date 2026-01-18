using UnityEngine;
using UnityEngine.Events;

public class MyEventTrigger : MonoBehaviour
{
    // Ez az event meg fog jelenni az Inspectorban
    public UnityEvent myEvent;
    public bool checkTrigger = false;

    // Ezt hívod meg, amikor szeretnéd triggerelni az eseményt
    public void TriggerEvent()
    {
        // Ha nem null, meghívja az összes Listener-t
        myEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkTrigger && collision.tag == "Player")
        {
            TriggerEvent();
            this.enabled = false;
        }
    }
}
