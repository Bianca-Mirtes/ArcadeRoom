using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Text.RegularExpressions;

public class MachineController : MonoBehaviour
{
    private Process p;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
