using System;
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
        var objectName = command["obj"];
        var obj = Array.Find<GameObject>(GameObject.FindGameObjectsWithTag("Layer"), item => item.name == objectName);
        obj.GetComponent<Layer>().UpdateTexture(null);
    }
}
