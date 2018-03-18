using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestGame.Main
{
	public class MainManager : Singleton<MainManager>
	{
		public BinFileIO BinFileIO { private set; get; }

		public override void Init()
		{
			DontDestroyOnLoad(this.gameObject);
			BinFileIO = this.GetComponent<BinFileIO>();
			Cursor.visible = false;
		}

		public void ChangeSceneTo(string sceneName)
		{			
			Resources.UnloadUnusedAssets();
			System.GC.Collect();
			SceneManager.LoadScene(sceneName);
		}
	}
}

// BinFileIO -> SaveLoadBinaryFiles

// BaseSceneManager

// ExitPauseController = this.GetComponent<ExitPauseController>()Init(this);

// AssertReferencesAreNotNull();