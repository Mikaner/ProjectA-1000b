using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NovelController : MonoBehaviour
{
    public GameObject message;
    public GameObject messageName;
    public GameObject character1 = null;
    public GameObject character2 = null;
    public string[] textMessage;
    public string[,] textWords;

    private int rowLength;
    private int columnLength;
    private int lineNumber;

    // Start is called before the first frame update
    void Start()
    {
        lineNumber = 0;
        loadText();
    }

    // Update is called once per frame
    void Update()
    {
        Text serif = message.GetComponent<Text>();
        Text tokingName = messageName.GetComponent<Text>();
        getInput(tokingName, serif);
    }

    void getInput(Text tokingName, Text serif) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            nextMessage(tokingName, serif);
        }
    }

    void nextMessage(Text tokingName, Text serif) {
        lineNumber++;
        tokingName.text = textWords[lineNumber,columnLength-2];
        serif.text = textWords[lineNumber,columnLength-1];
    }

    void loadText() {
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("Test", typeof(TextAsset)) as TextAsset;
        Debug.Log(textasset);
        string TextLines = textasset.text;
        // Line Model
        textMessage = TextLines.Split('\n');
        // Max column number
        columnLength = textMessage[0].Split('\t').Length;
        // Max line number
        rowLength = textMessage.Length;

        textWords = new string[rowLength, columnLength];

        for(int i = 0; i < rowLength; i++) {
            string[] tmpTxt = textMessage[i].Split('\t');
            for(int j = 0; j < (i==rowLength-1 ? 1 : columnLength); j++) {
                textWords[i,j]  = tmpTxt[j];
                Debug.Log(textWords[i,j]);
            }
        }
    }
}
