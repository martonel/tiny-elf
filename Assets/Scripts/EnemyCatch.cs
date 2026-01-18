using UnityEngine;

public class EnemyCatch : MonoBehaviour
{

    public Animator exclamationMarkAnim;


    [Header("optionalAssets")]
    public GuardPatrol guardPatrol;

    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                if (!movement.isHiding)
                {
                    exclamationMarkAnim.Play("exclamationMarkAnimUp");
                    if(guardPatrol != null)
                    {
                        guardPatrol.endGame();
                        audioSource.Play();
                    }


                    collision.gameObject.GetComponent<PlayerCatch>().PlayerCatched();
                    movement.enabled = false;
                }
                else
                {
                    Debug.Log("player hideing");
                }
            }    
        }
    }
}
