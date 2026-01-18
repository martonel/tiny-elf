using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class endPanel : MonoBehaviour
{

    public List<Animator> starAnims;

    public List<Animator> itemPicturesAnims;
    public Animator mainPictureAnim;
    public Animator animalPictureAnim;


    public int levelNumber = 0;
    private Data data;

    public LevelElements levelElements;

    [Header("Sound")]
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Data>();
        levelElements = GameObject.FindGameObjectWithTag("LevelManager").GetComponent <LevelElements>();
    }

    public void CheckStars()
    {
        int n = 3 * levelNumber;
        bool star1 = levelElements.GetStar1Finded();
        bool star2 = levelElements.GetStar2Finded();
        bool star3 = levelElements.GetStar3Finded();

        CheckItems();

        data.stars[n] = star1;
        data.stars[n + 1] = star2;
        data.stars[n + 2] = star3;


        if (star2 && !star1 && !star3)
        {
            starAnims[1].Play("starUpAnim2");
            mainPictureAnim.Play("mainItemFindAnim");

        }
        else if (star2 && star1 && !star3)
        {
            Debug.Log("12");
            StartCoroutine(StarsUp1());
        }
        else if (!star1 && star2 && star3)
        {
            Debug.Log("23");
            StartCoroutine(StarsUp2());
        }
        else if (star1 && star2 && star3)
        {
            Debug.Log("123");
            StartCoroutine(StarsUp3());
        }
        if (data.levelNumber < levelNumber + 1)
        {
            data.levelNumber = levelNumber + 1;
        }
    }

    private void CheckItems()
    {
        if (itemPicturesAnims.Count == 3)
        {
            bool item1IsFinded = levelElements.GetItem(0);
            bool item2IsFinded = levelElements.GetItem(1);
            bool item3IsFinded = levelElements.GetItem(2);

            if(item1IsFinded && item2IsFinded && item3IsFinded)
            {
                return;
            }
            if (item1IsFinded)
            {
                itemPicturesAnims[0].Play("itemFindAnim");
            }
            if (item2IsFinded)
            {
                itemPicturesAnims[1].Play("itemFindAnim");
            }
            if (item3IsFinded)
            {
                itemPicturesAnims[2].Play("itemFindAnim");
            }
        }
    }


    private IEnumerator StarsUp1()
    {
        audioSource1.Play();
        starAnims[0].Play("starUpAnim2");
        for (int i = 0; i < itemPicturesAnims.Count; i++)
        {
            itemPicturesAnims[i].Play("itemFindAnim");
        }

        
        yield return new WaitForSeconds(0.3f);
        starAnims[1].Play("starUpAnim2");
        mainPictureAnim.Play("mainItemFindAnim");
    }
    private IEnumerator StarsUp2()
    {
        audioSource1.Play();
        starAnims[1].Play("starUpAnim2");
        mainPictureAnim.Play("mainItemFindAnim");
        yield return new WaitForSeconds(0.3f);
        audioSource2.Play();
        starAnims[2].Play("starUpAnim2");
        animalPictureAnim.Play("mainItemFindAnim");
    }
    private IEnumerator StarsUp3()
    {
        audioSource1.Play();
        starAnims[0].Play("starUpAnim2");
        for (int i = 0; i < itemPicturesAnims.Count; i++)
        {
            itemPicturesAnims[i].Play("itemFindAnim");
        }
        yield return new WaitForSeconds(0.3f);
        audioSource2.Play();
        starAnims[1].Play("starUpAnim2");
        mainPictureAnim.Play("mainItemFindAnim");
        yield return new WaitForSeconds(0.3f);
        audioSource3.Play();

        starAnims[2].Play("starUpAnim2");
        animalPictureAnim.Play("mainItemFindAnim");

    }




}
