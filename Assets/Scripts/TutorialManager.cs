using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System;

public class TutorialManager : MonoBehaviour
{
    [Header("Image Referance")]
    public GameObject[] tutorialImage;
    public GameObject tutorialImagesItems;

    private int tutorialAnimationDuration = 5;

    int tutorialImageCount = 0;

    int tutorialNumber = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("tutorialNumber") == false)
        {
            PlayerPrefs.SetInt("tutorialNumber", tutorialNumber);
        }
        if (PlayerPrefs.GetInt("tutorialNumber") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("tutorialNumber") == 0)
        {
            tutorialImageCount = tutorialImagesItems.transform.childCount;

            tutorialImage = new GameObject[tutorialImageCount];

            for (int i = 0; i < tutorialImageCount; i++)
            {
                tutorialImage[i] = tutorialImagesItems.transform.GetChild(i).gameObject;

                // Tutorial Animation  Dotween & color
                tutorialImage[i].transform.DOScale(1.5f, 1).SetLoops(-1);
                tutorialImage[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.35f);

                Invoke("DestoroyerObject", tutorialAnimationDuration);
            }
        }
    }

    private void DestoroyerObject()
    {
        Destroy(tutorialImagesItems);
        PlayerPrefs.SetInt("tutorialNumber", tutorialNumber + 1);
    }
}
