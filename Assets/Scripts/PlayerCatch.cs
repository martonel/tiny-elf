using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public Animator blackAnim;
    public Animator playerAnim;
    public string playerCatchAnim = "";
    public void PlayerCatched()
    {
        if(playerCatchAnim != "")
        {
            playerAnim.Play(playerCatchAnim);
        }
        else
        {
            playerAnim = GetComponent<Animator>();
            playerAnim.Play("idleAnim");
        }
        if (blackAnim != null)
        {
            Debug.Log("name: " + blackAnim.gameObject.transform.name);
            blackAnim.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Debug.Log("pos: " + blackAnim.gameObject.transform.position +  " - " + this.transform.position);

            blackAnim.Play("levelEndAnim");
        }
    }
}
