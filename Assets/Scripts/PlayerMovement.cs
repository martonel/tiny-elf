using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 targetPosition;
    public float moveSpeed = 3f;      // Mozgási sebesség
    public Animator anim;
    public bool isMoving = false;

    public bool ladderUp = false;
    public string ladderUpAnimName = "ladderUpAnim";


    public bool isHiding = false;

    public bool moveAvailable = false;


    private GameObject hideSpot;
    private void Update()
    {
        if (!moveAvailable)
        {
            return;
        }

        if (isHiding)
        {
            return;
        }
        if (player == null)
        {
            Debug.LogError("Nincs beállítva a player");
            return;
        }

        // Ha van célpont, és nem ért oda
        if ((!ladderUp && Vector3.Distance(player.position, targetPosition) > 0.05f) ||
            (ladderUp && player.position.y != targetPosition.y))
        {
            if (targetPosition.x != 0 && targetPosition.y != 0)
            {
                // Mozgunk → animáció: WALK
                if (!isMoving)
                {
                    Debug.Log("Start Moving");
                    isMoving = true;
                    if (anim != null)
                    {
                        if (!ladderUp)
                        {
                            anim.Play("walkStart");
                        }
                        else
                        {
                            anim.Play(ladderUpAnimName);
                        }
                    }
                }

                if (!ladderUp)
                {
                    player.position = Vector3.MoveTowards(
                    player.position,
                    new Vector3(targetPosition.x, player.position.y, player.position.z),
                    moveSpeed * Time.deltaTime
                   );
                }
                else
                {
                    player.position = Vector3.MoveTowards(
                    player.position,
                    new Vector3(player.position.x, targetPosition.y, player.position.z),
                    moveSpeed * Time.deltaTime
                   );
                }
            }
        }
        else
        {
            // Megállt → animáció: IDLE
            if (isMoving)
            {
                isMoving = false;
                if (anim != null)
                {
                    if (!ladderUp)
                    {
                        anim.Play("walkEnd");
                    }
                    moveSpeed = 3.0f;
                    
                }
                ladderUp = false;
                
            }
            player.position = targetPosition;
        }

    }

    public void SetTarget(GameObject obj)
    {
        if (moveAvailable)
        {
            //Debug.Log("elindul a létrán");
            targetPosition = obj.transform.position;
            //player.rotation = Quaternion.Euler(0, 180, 0);
            ladderUp = true;
            moveSpeed = 1.7f;
        }
    }

    public void SetTarget(Vector3 target)
    {
        if (moveAvailable)
        {
            targetPosition = target;
            //Debug.Log("target beállítás");
            // ➤ Irányba fordulás
            if (targetPosition.x > player.position.x)
            {
                // Jobbra megy → Y rotation = 180
                player.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (targetPosition.x < player.position.x)
            {
                // Balra megy → Y rotation = 0
                player.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }


    public void Hide()
    {
        isHiding = true;
        this.transform.position = new Vector3(hideSpot.transform.position.x, transform.position.y, transform.position.z);
        targetPosition = this.transform.position;
    }

    public void UnHide()
    {
        isHiding = false;
    }

    public void SetHideSpot(GameObject spot)
    {
        hideSpot = spot;
    }

    public void StartMoving()
    {
        StartCoroutine(StartMovingCorutine());
    }

    public void StopMoving()
    {
        moveAvailable = false;
    }

    private IEnumerator StartMovingCorutine()
    {
        Debug.Log("start");
        yield return new WaitForSecondsRealtime(1.0f);

        Debug.Log("end");
        moveAvailable = true;
    }



    public void MoveToPos(GameObject pos) {
        transform.position = pos.transform.position;
        targetPosition = pos.transform.position;
        Debug.Log("target beállítás2");

    }


}
