using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : SingletonMonoBehaviourFast<CommandController>
{
    // 文字を解析しながら呼び出すコマンド
    private readonly List<ICommand> m_commandList = new List<ICommand>() {
        new CommandUpdateImage(), //name=オブジェクト名 image=イメージ名
        new CommandJumpNextScenario(), // fileName=シナリオ名
    };

    // 文字列の表示が完了したタイミングで呼ばれる処理
    private List<IPreCommand> m_preCommandList = new List<IPreCommand>();

    // 画像のロードなど重い処理用
    public void PreloadCommand(string line) {
        var dic = CommandAnalytics(line);
        foreach( var command in m_preCommandList ){
            if ( command.Tag == dic["tag"])
                command.PreCommand(dic);
        }
    }

    // コマンドのロード
    public bool LoadCommand(string line){
        // 渡されたlineからコマンドを解析
        var dic = CommandAnalytics(line);
        // コマンドリストに設定されているコマンドを確認
        foreach( var command in m_commandList ){
            // m_commandListのTag要素に設定されている文字列だった場合、true
            if(command.Tag == dic["tag"]){
                command.Command(dic);
                return true;
            }
        }
        // コマンドリストに設定されているものがなかった場合、false
        return false;
    }

    // コマンドの解析
    private Dictionary<string, string> CommandAnalytics(string line){
        // Dictionary型のcommandを作成
        Dictionary<string, string> command = new Dictionary<string, string>();

        // 正規表現にてコマンド名を取得しtagを付けて追加
        var tag = Regex.Match(line, "@(\\S+)\\s");
        command.Add("tag", tag.Groups[1].ToString());

        // パラメータ記法の設定
        Regex regex = new Regex("(\\S+)=(\\S+)");
        // コマンドのパラメータを取得
        var matches = regex.Matches(line);
        // 取得したパラメータをcommandに追加
        foreach( Match match in matches) {
            command.Add(match.Groups[1].ToString(), match.Groups[2].ToString());
        }

        return command;
    }

#region UNITY_CALLBACK
    new void Awake(){
        base.Awake();
        // PreCommandを取得
        foreach( var command in m_commandList ){
            if(command is IPreCommand) {
                m_preCommandList.Add((IPreCommand)command); 
            }
        }
    }
#endregion
}
