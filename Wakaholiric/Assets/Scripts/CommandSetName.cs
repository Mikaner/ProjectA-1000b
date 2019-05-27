using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandSetName : ICommand
{
    public string Tag {
        get { return "name"; }
    }

    public void Command(Dictionary<string, string> command) {
        var name = command["text"];

        Text obj = GameObject.Find("Name").GetComponent<Text>();
        obj.text = name;
    }
}
