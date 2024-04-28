using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngineInternal;

public class GameController : MonoBehaviour
{
    public List<GameObject> arcades;
    private GameObject currentMachine;
    private int gameMode = -1;
    private bool ExistSave = false;

    public GameObject MainMenu;
    public GameObject AddMenu;
    public GameObject RemoveMenu;
    public GameObject SaveMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.GetComponent<Animator>().Play("FadeIn");
        if(PlayerPrefs.GetInt("Room") == 1)
        {
            ExistSave = true;
        }
        if (ExistSave)
        {
            foreach (GameObject arcade in arcades)
            {
                if (!PlayerPrefs.GetString(arcade.name).Equals("empty"))
                {
                    arcade.transform.GetChild(2).gameObject.SetActive(false);
                    arcade.transform.GetChild(3).gameObject.SetActive(true);
                    string save = PlayerPrefs.GetString(arcade.name);
                    string[] partes = save.Split('#');
                    arcade.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = partes[0];
                    arcade.transform.GetChild(3).GetComponent<MachineController>().setGamePath(partes[1]);
                    arcade.transform.GetChild(0).gameObject.SetActive(true);
                    arcade.GetComponent<SectionController>().ChangeScan(0);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            AddMenu.SetActive(false);
            RemoveMenu.SetActive(false);
            MainMenu.SetActive(true);
            MainMenu.GetComponent<Animator>().Play("FadeIn");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SaveMenu.SetActive(true);
            SaveMenu.GetComponent<Animator>().Play("FadeIn");
        }
    }

    public void SaveRoom()
    {
        // salvar as configs daa maquinas, o nome do jogo e o path
        foreach (GameObject arcade in arcades)
        {
            if(arcade.GetComponent<SectionController>().GetStateSection() == 1)
            {
                string name = arcade.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text;
                string path = arcade.transform.GetChild(3).GetComponent<MachineController>().getGamePath();
                PlayerPrefs.SetString(arcade.name, name + "#" + path);
            }
            if(arcade.GetComponent<SectionController>().GetStateSection() == 0)
            {
                PlayerPrefs.SetString(arcade.name, "empty");
            }
        }
        SaveMenu.GetComponent<Animator>().Play("FadeOut");
        PlayerPrefs.SetInt("Room", 1);
        ExistSave = true;
        PlayerPrefs.Save();
    }


    public int getGameMode()
    {
        return gameMode;
    }

    public void AdmMode()
    {
        MainMenu.GetComponent<Animator>().Play("FadeOut");
        gameMode = 0;
    }

    public void ActiveArcadeMenu(GameObject machine, string action)
    {
        MainMenu.SetActive(false);
        if (action.Equals("add"))
        {
            AddMenu.SetActive(true);
            AddMenu.GetComponent<Animator>().Play("FadeIn");
        }
        if (action.Equals("rem"))
        {
            RemoveMenu.SetActive(true);
            RemoveMenu.GetComponent<Animator>().Play("FadeIn");
        }
        currentMachine = machine;
    }

    public void PlayerMode()
    {
        MainMenu.GetComponent<Animator>().Play("FadeOut");
        gameMode = 1;

    }
    public void AddGameMachine()
    {
        AddMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Jogo: ";

        AddMenu.transform.GetChild(2).gameObject.SetActive(false);
        AddMenu.transform.GetChild(3).gameObject.SetActive(false);

        AddMenu.transform.GetChild(4).gameObject.SetActive(true);
        AddMenu.transform.GetChild(5).gameObject.SetActive(true);

        AddMenu.transform.GetChild(6).gameObject.SetActive(true);
        AddMenu.transform.GetChild(7).gameObject.SetActive(true);
        AddMenu.transform.GetChild(8).gameObject.SetActive(true);
    }

    public void sendGameInfos()
    {
        currentMachine.GetComponent<SectionController>().SetStateSection(1);
        currentMachine.transform.GetChild(2).gameObject.SetActive(false); // desativa a holografia
        currentMachine.transform.GetChild(3).gameObject.SetActive(true); // ativa a machine de vdd

        // transfere as infos do jogo
        string name = AddMenu.transform.GetChild(6).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text;
        currentMachine.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
        string path = AddMenu.transform.GetChild(7).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text;
        currentMachine.transform.GetChild(3).GetComponent<MachineController>().setGamePath(path);
        // aqui vai a textura da machine no futuro

        currentMachine.transform.GetChild(0).gameObject.SetActive(true); // ativa o text do titulo do jogo
        currentMachine.GetComponent<SectionController>().ChangeScan(0); // muda o scan
        AddMenu.GetComponent<Animator>().Play("FadeOut");
        AddMenu.SetActive(false);
    }

    public void RemoveGameMachine()
    {
        RemoveMenu.GetComponent<Animator>().Play("FadeOut");
        currentMachine.GetComponent<SectionController>().SetStateSection(0);
        currentMachine.transform.GetChild(0).gameObject.SetActive(false);
        currentMachine.transform.GetChild(2).gameObject.SetActive(true);
        currentMachine.transform.GetChild(3).gameObject.SetActive(false);
        currentMachine.GetComponent<SectionController>().ChangeScan(1);

        AddMenu.transform.GetChild(6).GetComponent<TMP_InputField>().text = "";
        AddMenu.transform.GetChild(7).GetComponent<TMP_InputField>().text = "";

        AddMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "O que deseja fazer: ";

        AddMenu.transform.GetChild(2).gameObject.SetActive(true);
        AddMenu.transform.GetChild(3).gameObject.SetActive(true);

        AddMenu.transform.GetChild(4).gameObject.SetActive(false);
        AddMenu.transform.GetChild(5).gameObject.SetActive(false);

        AddMenu.transform.GetChild(6).gameObject.SetActive(false);
        AddMenu.transform.GetChild(7).gameObject.SetActive(false);
        AddMenu.transform.GetChild(8).gameObject.SetActive(false);
        RemoveMenu.SetActive(false);
    }
}
