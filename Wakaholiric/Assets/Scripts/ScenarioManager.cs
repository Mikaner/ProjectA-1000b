using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

[RequireComponent(typeof( TextController))]
public class ScenarioManager : SingletonMonoBehaviourFast<ScenarioManager>
{
    public string LoadFileName;

    private string [] m_scenarios;
    private int m_currentLine = 0;
    private bool m_isCallPreload = false;
    private TextController m_textController;
    private CommandController m_commandController;

    void RequestNextLine() {
        var currentText = m_scenarios[m_currentLine];

        m_textController.SetNextLine(CommandProcess(currentText));
        m_currentLine ++;
        m_isCallPreload = false;
    }

    public void UpdateLines(string fileName) {
        // 引数として渡されたfileNameを探してscenarioTextに格納
        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);

        // もしなかった場合は、errorLogを出して終了
        if (scenarioText == null ){
            Debug.LogError("Not found scenario file");
            Debug.LogError("Invalid ScenarioManager");
            enabled = false;
            return;
        }

        // 読み込んだファイルを@brで切ってm_scenariosに格納。また、現在の行を0に設定
        m_scenarios = scenarioText.text.Split(new string[]{"@br"}, System.StringSplitOptions.None);
        m_currentLine = 0;

        // メモリ開放
        Resources.UnloadAsset(scenarioText);
    }

    public string CommandProcess(string line) {
        var lineReader = new StringReader(line);
        var lineBuilder = new StringBuilder();
        var text = string.Empty;
        while( (text = lineReader.ReadLine()) != null ){
            // コメントアウトの処理
            var commentCharacterCount = text.IndexOf("//");
            if ( commentCharacterCount != -1 ){
                // 始めからコメントアウトまでの文字列を処理
                text = text.Substring(0, commentCharacterCount);
            }

            // 何か存在した場合
            if (! string.IsNullOrEmpty( text )) {
                // コマンドかどうか
                if( text[0]=='@' && m_commandController.LoadCommand(text))
                    continue;
                lineBuilder.AppendLine(text);
            }
        }

        return lineBuilder.ToString();
    }

#region UNITY__CALLBACK
    void Start(){
        m_textController = GetComponent<TextController>();
        m_commandController = GetComponent<CommandController>();

        UpdateLines(LoadFileName);
        RequestNextLine();
    }

    void Update () {
        if( m_textController.IsCompleteDisplayText ){
            if( m_currentLine < m_scenarios.Length ){
                if( !m_isCallPreload ){
                    // NullReferenceException
                    m_commandController.PreloadCommand(m_scenarios[m_currentLine]);
                    m_isCallPreload = true;
                }

                if( Input.GetMouseButtonDown(0)){
                    RequestNextLine();
                }
            }
        } else {
            if(Input.GetMouseButtonDown(0)) {
                m_textController.ForceCompleteDisplayText();
            }
        }
    }

#endregion
}
