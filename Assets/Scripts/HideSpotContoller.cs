using UnityEngine;

public class HideSpotContoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerMovement playerMovement;
    public GameObject target;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("nincs player!");
        }
        else { 
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMovement != null && target !=null)
        {
            if(collision.tag == "Player")
            {
                playerMovement.SetHideSpot(target);
            }
        }
    }

}
