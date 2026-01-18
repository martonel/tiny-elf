using System;
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemNumber = 0;

    private Animator playerAnimator;
    public string getItemAnimName = "getItem";
    private Data data;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        try
        {
            data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Data>();
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void FindMainItem()
    {
        Debug.Log("getItem");
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null)
        {
            LevelElements levelElements = levelManagerObj.GetComponent<LevelElements>();
            if (levelElements != null)
            {
                levelElements.findMainItem();
            }
        }
        End();
    }

    public void FindAnimal()
    {
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null)
        {
            LevelElements levelElements = levelManagerObj.GetComponent<LevelElements>();
            if (levelElements != null)
            {
                levelElements.findAnimal();
            }
        }
        End();
    }

    public void FindItem(int itemNumber) {
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null)
        {
            LevelElements levelElements = levelManagerObj.GetComponent<LevelElements>();
            if (levelElements != null)
            {
                levelElements.findItem(itemNumber);
            }
        }
        End();
    }


    public void FindItemWithTime(int number)
    {
        StartCoroutine(findItemWithTime(number));
    }
    public IEnumerator findItemWithTime(int itemNumber)
    {
        yield return new WaitForSeconds(3.0f);
        FindItem(itemNumber);
    }

    private void End()
    {

        if (playerAnimator != null)
        {
            //todo késõbb visszatenni
            //playerAnimator.Play(getItemAnimName);
        }
        if (data != null)
        {
            data.items[itemNumber] = true;
        }
        //todo késõbb kivenni
        Destroy(this.gameObject);
    }
}
