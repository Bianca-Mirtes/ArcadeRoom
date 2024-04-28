using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngineInternal;

public class GameController : MonoBehaviour
{
    private GameObject currentMachine;
    private int gameMode = -1;

    public GameObject MainMenu;
    public GameObject AddMenu;
    public GameObject RemoveMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.GetComponent<Animator>().Play("FadeIn");
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
