using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public GameObject scan;
    public TextMeshProUGUI gameName;

    public void setGameName(string name)
    {
        gameName.text = name;
    }

    private void OnMouseEnter()
    {
        if(FindObjectOfType<GameController>().getGameMode() == 0)
        {
            scan.SetActive(true);
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
            FindObjectOfType<GameController>().ActiveArcadeMenu(gameObject);
        }
    }
}
