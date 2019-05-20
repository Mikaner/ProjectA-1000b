using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public string[] scenarios;
    public Text uiText;

    int currentLine = 0;
    // Start is called before the first frame update
    void Start()
    {
        TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLine < scenarios.Length && Input.GetMouseButtonDown(0)) {
            TextUpdate();
        }
    }

    void TextUpdate() {
        uiText.text = scenarios[currentLine];
        currentLine ++;
    }
}
