using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public GameObject scan;
    public TextMeshProUGUI gameName;
    public Material blueScan;
    public Material redScan;
    public int stateSection = 0;

    public void ChangeScan(int value)
    {
        if (value == 0)
        {
            scan.GetComponent<MeshRenderer>().material = blueScan;
            scan.tag = "BlueScan";
        }
        if(value == 1)
        {
            scan.GetComponent<MeshRenderer>().material = redScan;
            scan.tag = "RedScan";
        }
    }

    public int GetStateSection()
    {
        return stateSection;
    }

    public void SetStateSection(int value)
    {
        stateSection = value;
    }


    private void OnMouseEnter()
    {
        if(FindObjectOfType<GameController>().getGameMode() == 0)
        {
            scan.SetActive(true);
        }
        else
        {
            scan.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        if (FindObjectOfType<GameController>().getGameMode() == 0)
        {
            scan.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (FindObjectOfType<GameController>().getGameMode() == 0)
        {
            if (scan.tag.Equals("RedScan"))
            {
                FindObjectOfType<GameController>().ActiveArcadeMenu(gameObject, "add");
            }

            if (scan.tag.Equals("BlueScan"))
            {
                FindObjectOfType<GameController>().ActiveArcadeMenu(gameObject, "rem");
            }
        }
    }
}
