using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandMoveScene : ICommand
{
    public string Tag {
        get { return "scn";}
    }

    public void Command(Dictionary<string, string> command) {
        var scene = command["scene"];
        SceneManager.LoadScene(scene);
    }
}
