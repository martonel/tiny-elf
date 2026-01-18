using UnityEngine;
using UnityEngine.Events;

public class ClickEvent : MonoBehaviour
{
    public bool isDestroyable = false;

    private Collider2D col;
    public UnityEvent myEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();

    }

    void Update()
    {
        // Egér kattintás
        if (Input.GetMouseButtonDown(0))
        {
            CheckPosition(Input.mousePosition);
        }

        // Touch (mobil)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckPosition(Input.GetTouch(0).position);
        }
    }


    void CheckPosition(Vector2 screenPosition)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (col.OverlapPoint(worldPosition))
        {
            TriggerEvent();
            if (isDestroyable)
            {
                DestroyObj();

            }
        }
    }

    // Ezt hívod meg, amikor szeretnéd triggerelni az eseményt
    public void TriggerEvent()
    {
        // Ha nem null, meghívja az összes Listener-t
        myEvent?.Invoke();
    }



    public void DestroyObj()
    {
        Destroy(this.gameObject);

    }
}
