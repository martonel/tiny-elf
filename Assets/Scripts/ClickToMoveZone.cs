using UnityEngine;

public class ClickToMoveZone : MonoBehaviour
{
    public Transform player;          // A player Transform-je

    public bool playerInside = false;
    public Vector3 targetPosition;
    public PlayerMovement playerMovement;
    public bool isMoving = true;

    private void Start()
    {
        if(player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
        else
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
        
        if (!playerMovement.moveAvailable || playerMovement.ladderUp)
        {
            return;
        }
        // Ha bent van a player a triggerben
        if (playerInside)
        {
            // Ha rákattintunk bal egérgombbal
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    targetPosition = new Vector3(mouseWorldPos.x, player.position.y, player.position.z);
                    isMoving = true;
                }
            }
            if (isMoving)
            {
                playerMovement.SetTarget(targetPosition);
                if (Vector3.Distance(player.position, targetPosition) < 0.05f)
                {
                    Debug.Log("move");
                    isMoving = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bele kattintok" + other.tag);
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    public void SetIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }
}
