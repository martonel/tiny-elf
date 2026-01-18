using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    public Data data;
    public List<GameObject> items;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Data>();
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(data.items[i]);
        }
    }
}
