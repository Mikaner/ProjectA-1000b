using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandUpdateImage : ICommand, IPreCommand {
    public string Tag {
        get {return "img";}
    }

    public void PreCommand (Dictionary<string, string> command) {
        var fileName = command["image"];
        TextureresourceManager.Load(fileName);
    }

    public void Command(Dictionary<string, string> command) {
        var fileName = command["image"];
        var objectName = command["name"];

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Layer"))
        {
            Debug.Log(item.name);
        }

        var obj = Array.Find<GameObject>( GameObject.FindGameObjectsWithTag("Layer") ,item => item.name == objectName);

        if(fileName == "None"){
            obj.GetComponent<Layer>().UpdateTexture(null);
            return;
        }

        Debug.Log("obj\n"+obj);
        Debug.Log("objGC\n"+obj.GetComponent<Layer>());
        obj.GetComponent<Layer>().UpdateTexture( TextureresourceManager.Load(fileName));
    }
}
