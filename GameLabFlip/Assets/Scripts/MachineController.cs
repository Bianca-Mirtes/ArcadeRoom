using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class MachineController : MonoBehaviour
{
    private Process p;
    public string gameName;
    public string path;

    private void Start()
    {
        transform.parent.GetComponent<SectionController>().setGameName(gameName);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")){
            if (Input.GetKeyDown(KeyCode.E))
            {
                p = new Process();
                p.StartInfo.UseShellExecute = true;
                string textoComBarrasInvertidas = path;
                string textoComBarras = Regex.Replace(textoComBarrasInvertidas, @"T:\\", "/");
                p.StartInfo.FileName = textoComBarras;
                p.Start();
            }
        }
    }
}
