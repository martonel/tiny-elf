using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelElements : MonoBehaviour
{

    public List<bool> items;
    public bool mainItem;
    public bool animal;
    public Animator endAnim;

    public Animator itemStarAnim;
    public Animator mainItemStarAnim;
    public Animator animalStarAnim;

    public Animator upperPanelAnim;

    public List<Animator> itemAnims;
    public Animator mainItemAnim;
    public Animator animalAnim;

    [Header("Level number")]
    public int levelNumber;

    private bool isStar1Finded = false;
    private bool isStar2Finded = false;
    private bool isStar3Finded = false;

    [Header("LevelItems")]
    public List<bool> levelItems;
    public int levelItemsCount;

    [Header("Sound")]
    public AudioSource audioSource;


    private bool isAnimalFinished = false;


    public void findMainItem()
    {
        mainItem = true;
        audioSource.Play();

        if (endAnim != null)
        {
            endAnim.Play("exitAnimUp");
        }
        upperPanelAnim.Play("upperPanelDown");

        StartCoroutine(mainItemAnimCourutine());
        StartCoroutine(MainItemStarAnimCourutine());
        isStar2Finded = true;
    }

    public void findItem(int index)
    {
        Debug.Log("find item");
        items[index] = true;
        upperPanelAnim.Play("upperPanelDown");

        bool allItemIsFinded = true;

        StartCoroutine(ItemAnimCourutine(index));
        for (int i = 0; i < items.Count; i++)
        {
            if (!items[i])
            {
                allItemIsFinded = false;
            }
        }
        if (allItemIsFinded)
        {
            audioSource.Play();
            StartCoroutine(ItemStarAnimUpCourutine());
            isStar1Finded = true;
        }
    }

    public void findAnimal()
    {
        animal = true;
        audioSource.Play();

        upperPanelAnim.Play("upperPanelDown");
        StartCoroutine(animalItemAnimCourutine());

        StartCoroutine(AnimalStarAnimCourutine());
        isStar3Finded = true;

    }

    private IEnumerator ItemStarAnimUpCourutine()
    {
        yield return new WaitForSeconds(1.0f);
        itemStarAnim.Play("starUpAnim");
    }

    private IEnumerator MainItemStarAnimCourutine()
    {
        yield return new WaitForSeconds(1.0f);
        mainItemStarAnim.Play("starUpAnim");
    }
    private IEnumerator AnimalStarAnimCourutine()
    {
        yield return new WaitForSeconds(1.0f);
        animalStarAnim.Play("starUpAnim");
    }

    private IEnumerator ItemAnimCourutine(int index)
    {
        yield return new WaitForSeconds(0.5f);
        itemAnims[index].Play("itemFindAnim");
    }
    private IEnumerator mainItemAnimCourutine()
    {
        yield return new WaitForSeconds(0.5f);
        mainItemAnim.Play("mainItemFindAnim");
    }

    private IEnumerator animalItemAnimCourutine()
    {
        yield return new WaitForSeconds(0.5f);
        animalAnim.Play("mainItemFindAnim");
    }

    public bool GetStar1Finded()
    {
        return isStar1Finded;
    }
    public bool GetStar2Finded()
    {
        return isStar2Finded;
    }
    public bool GetStar3Finded()
    {
        return isStar3Finded;
    }

    public bool GetItem(int number)
    {
        return items[number];
    }

    public void setLevelItem(int number)
    {
        Debug.Log("number : " +  number);
        levelItems[number] = true;
    }

    public bool getLevelItem(int number)
    {
        return levelItems[number];
    }
}
