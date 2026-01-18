using UnityEngine;

public class TriggerAnimPlay : MonoBehaviour
{
    public string upAnimName;
    public string downAnimName;
    public Animator anim;
    public bool isOnce = false;
    public bool isFirst = true;
    public string tag = "Player";

    public bool isDestroyable = false;

    [Header("levelItemSettings")]
    public bool isLevelItemRequired = false;
    public int levelItemNumber = 0;

    private void Start()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkLevelItemRequired())
        {
            return;
        }
        Debug.Log("major " + collision.tag + this.gameObject.name);
        if (isFirst)
        {
            //Debug.Log(collision.tag);
            if (collision.tag == tag)
            {
                if (upAnimName != null)
                {
                    anim.Play(upAnimName);
                }
                if (isOnce)
                {
                    isFirst = false;
                }
            }
            if (isDestroyable)
            {
                //DestroyObj();
            }
        }
    }

    private bool checkLevelItemRequired()
    {
        if (isLevelItemRequired)
        {
            LevelElements levelElements = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelElements>();
            if (levelElements != null)
            {
                Debug.Log(" check: " + levelElements.getLevelItem(levelItemNumber));
                return levelElements.getLevelItem(levelItemNumber);
            }
        }
        return true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!checkLevelItemRequired())
        {
            return;
        }
        //Debug.Log("kilép");
        if (collision.tag == tag)
        {
            if (downAnimName != null && isFirst)
            {
                anim.Play(downAnimName);
            }
        }
    }

    public void DestroyObj()
    {
        Destroy(this);
    }

    public void ArrowDown()
    {
        Debug.Log("megnyomta a gombot!");
    }

}
