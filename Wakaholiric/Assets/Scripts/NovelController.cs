using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NovelController : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] Text messageName;
    public GameObject character1 = null;
    public GameObject character2 = null;

    // 1文字の表示にかかる時間
    [SerializeField][Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;
    
    // メッセージ保存
    public string[] textMessage;
    // ファイルの中身全部
    public string[,] textWords;

    // 行の長さ
    private int rowLength;
    // 列の長さ
    private int columnLength;

    // 現在の行
    private int currentLine = 0;
    // 現在の文字列
    private string currentMessage = string.Empty;

    // 表示にかかる時間
    private float timeUntilDisplay = 0;
    // 文字列の表示を開始した時間
    private float timeElapsed = 1;
    // 表示中の文字数
    private int lastUpdateCharacter = -1;

    public bool IsCompleteDisplayText{
        get{return Time.time > timeElapsed + timeUntilDisplay;}
    }

    // Start is called before the first frame update
    void Start()
    {
        loadText();
        loadNext();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();

        // クリックから経過した時間が想定表示時間の何％かを確認し、表示文字数を出す。
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentMessage.Length);

        if( displayCharacterCount != lastUpdateCharacter ){
            message.text = currentMessage.Substring(0,displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }

    void getInput() {
        if(IsCompleteDisplayText) {
            if (currentLine < textWords.Length && Input.GetKeyDown(KeyCode.Space)) {
                loadNext();
            }else if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("Shooting");
            }
        }else{
            if(Input.GetKeyDown(KeyCode.Space)) {
                timeUntilDisplay = 0;
            }
        }
    }
    void loadNext() {
        loadNextName();
        loadNextText();
        currentLine++;
    }

    void loadNextName() {
        messageName.text = textWords[currentLine,columnLength-2];
    }
    void loadNextText(){
        currentMessage = textWords[currentLine,columnLength-1];

        timeUntilDisplay = currentMessage.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;

        lastUpdateCharacter = -1;
    }

    void loadText() {
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("Test", typeof(TextAsset)) as TextAsset;
        Debug.Log(textasset);
        string TextLines = textasset.text;
        // ファイルを1次元配列へ
        textMessage = TextLines.Split('\n');
        // 列の長さ
        columnLength = textMessage[0].Split('\t').Length;
        // 行の長さ
        rowLength = textMessage.Length;

        // 行列の設定(ファイルの中身を2次元配列へ)
        textWords = new string[rowLength, columnLength];

        for(int i = 0; i < rowLength; i++) {
            // 一次的に1行のメッセージを1次元配列へ保存
            string[] tmpTxt = textMessage[i].Split('\t');
            for(int j = 0; j < (i==rowLength-1 ? 1 : columnLength); j++) {
                // 保存した要素を順次textWordsに格納
                textWords[i,j]  = tmpTxt[j];
                // チェック
                Debug.Log(textWords[i,j]);
            }
        }
    }
}
