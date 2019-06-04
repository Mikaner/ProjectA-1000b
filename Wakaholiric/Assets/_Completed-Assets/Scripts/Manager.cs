using UnityEngine;

namespace CompletedAssets
{
	public class Manager : MonoBehaviour
	{
		// Playerプレハブ
		public GameObject player;
	
		// タイトル
		private GameObject title;
        private GameObject cleartext;

        public bool flg = false;

		void Start ()
		{
			// Titleゲームオブジェクトを検索し取得する
			title = GameObject.Find ("Title");
            cleartext = GameObject.Find("ClearText");
            cleartext.SetActive(false);
        }

		void Update ()
		{
			// ゲーム中ではなく、Xキーが押されたらtrueを返す。
			if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X) && flg==false) {
				GameStart ();
			}
		}

		void GameStart ()
		{
			// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
			title.SetActive (false);
            cleartext.SetActive(false);
			Instantiate (player, player.transform.position, player.transform.rotation);
		}

		public void GameOver ()
		{
			FindObjectOfType<Score> ().Save ();
			// ゲームオーバー時に、タイトルを表示する
			title.SetActive (true);
		}

        public void GameClear ()
        {
            FindObjectOfType<Score> ().Save ();
            cleartext.SetActive(true);
            flg = true;
            FindObjectOfType<Emitter> ().Destroy();
        }

		public bool IsPlaying ()
		{
            // ゲーム中かどうかはタイトルの表示/非表示で判断する
            return (title.activeSelf == false);
            //return flg==false;
		}
	}
}