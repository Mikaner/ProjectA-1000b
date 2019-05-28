using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandClear : ICommand
{
    public string Tag {
        get { return "clear"; }
    }

    public void Command(Dictionary<string, string> command) {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Layer"))
        {
            item.GetComponent<RawImage>().texture = null;
        }
    }
}
