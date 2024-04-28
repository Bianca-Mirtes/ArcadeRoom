using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class MachineController : MonoBehaviour
{
    private Process p;
    private string gamePath;

    public void setGamePath(string path)
    {
        gamePath = path; 
    }

    public string getGamePath()
    {
        return gamePath;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")){
            if(FindObjectOfType<GameController>().getGameMode() == 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    p = new Process();
                    p.StartInfo.UseShellExecute = true;
                    string textoComBarrasInvertidas = gamePath;
                    string textoComBarras = Regex.Replace(textoComBarrasInvertidas, @"T:\\", "/");
                    p.StartInfo.FileName = textoComBarras;
                    p.Start();
                }
            }
        }
    }
}
