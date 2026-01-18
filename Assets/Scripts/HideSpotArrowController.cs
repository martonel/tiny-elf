using UnityEngine;

public class HideSpotArrowController : MonoBehaviour
{

    public Animator arrowAnim;

    public void ArrowAnimUp()
    {
        arrowAnim.Play("buttonUp");
    }

    public void SetArrowAnimator(Animator animator)
    {
        this.arrowAnim = animator;
    }
}
