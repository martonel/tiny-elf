using UnityEngine;
using System.Collections;

public class GuardPatrol : MonoBehaviour
{
    [Header("References")]
    public Transform targetPosA;
    public Transform targetPosB;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float stopDistance = 0.1f;

    public Transform currentTarget;
    private bool isMove = false;
    private bool goingToA = true;

    private bool isEnd = false;
    public bool isFinalAnimation = false;

    private void Start()
    {
        currentTarget = targetPosA;
        StartCoroutine(IdleThenStart());
    }

    public void StartAgain()
    {
        StartCoroutine(IdleThenStart());
    }

    private IEnumerator IdleThenStart()
    {
        yield return new WaitForSeconds(5f);
        if (!isEnd)
        {
            anim.Play("guardStart");
        }
    }

    // EZT HÍVJA AZ ANIMÁCIÓ EVENT
    public void StartWalk()
    {
        if (!isEnd)
        {
            // 180 fokos fordulat Y tengelyen
            Vector3 rot = transform.eulerAngles;
            rot.y += 180f;
            transform.eulerAngles = rot;

            isMove = true;
            anim.Play("guardWalkStartAnim");
        }
    }

    private void Update()
    {
        if (isFinalAnimation)
        {
            return;
        }
        if (isEnd)
            return;

        if (!isMove) return;

        Vector3 targetPos = new Vector3(
            currentTarget.position.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        if (Mathf.Abs(transform.position.x - targetPos.x) <= stopDistance)
        {
            Debug.Log("reach the target");
            anim.Play("guardWalkEndAnim");
            isMove = false;
            StartCoroutine(WaitAndReverse());
        }
    }

    private IEnumerator WaitAndReverse()
    {
        goingToA = !goingToA;
        currentTarget = goingToA ? targetPosA : targetPosB;
        yield return new WaitForSeconds(7f);
        // Target váltás
        
        if (!isEnd && !isFinalAnimation)
        {
            anim.Play("guardStart");
        }
    }

    public void endGame()
    {
        Debug.Log("endGame");
        isEnd = true;
        anim.Play("guardCatch");
    }

    public void guardSuprised()
    {
        if(currentTarget == goingToA && isMove == false)
        {
            anim.Play("guardSuprised");
        }
    }

    public void SetFinalAnimation(bool isFinale)
    {
        isFinalAnimation = isFinale;
    }
}
