using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngineInternal;

public class GameController : MonoBehaviour
{
    public List<GameObject> arcades;
    private GameObject currentMachine;

    public GameObject MainMenu;
    private int gameMode = -1;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.GetComponent<Animator>().Play("FadeIn");
    }

    public int getGameMode()
    {
        return gameMode;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AdmMode()
    {
        MainMenu.GetComponent<Animator>().Play("FadeOut");
        gameMode = 0;
    }

    public void ActiveArcadeMenu(GameObject machine)
    {
        MainMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "O que deseja: ";
        MainMenu.transform.GetChild(2).gameObject.SetActive(false);
        MainMenu.transform.GetChild(3).gameObject.SetActive(false);
        MainMenu.transform.GetChild(4).gameObject.SetActive(true);
        MainMenu.transform.GetChild(5).gameObject.SetActive(true);
        currentMachine = machine;
        MainMenu.GetComponent<Animator>().Play("FadeIn");
    }

    public void PlayerMode()
    {
        MainMenu.GetComponent<Animator>().Play("FadeOut");
        gameMode = 1;

    }

    public void AddGameMachine(string name, string path, GameObject parent)
    {
        
    }
    
    public void RemoveGameMachine()
    {
        arcades.Remove(currentMachine);
        Destroy(currentMachine);
    }

}
