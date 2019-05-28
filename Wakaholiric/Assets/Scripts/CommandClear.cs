using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandClear : ICommand
{
    public string Tag {
        get { return "clear"; }
    }

    public void Command(Dictionary<string, string> command) {
        var scenario = ScenarioManager.Instance;
        //scenario.clear();
    }
}
