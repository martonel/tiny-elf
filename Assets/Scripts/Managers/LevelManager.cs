using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Data data;
    public List<GameObject> levels;
    public List<GameObject> stars;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Data>();
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].GetComponent<Button>().interactable = true;
            if (i == data.levelNumber)
            {
                break;
            }
        }
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].SetActive(data.stars[i]);
        }
    }
}
