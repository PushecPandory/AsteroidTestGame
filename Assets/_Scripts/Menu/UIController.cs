using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestGame.MenuScene
{
	public class UIController : MenuSceneController
	{
		[SerializeField]
		private Button _selectOnStartButton;
		[SerializeField]
		private Text _highScoreText;

		public override void Init(MenuSceneManager sceneManager) 
		{
			base.Init(sceneManager);

			SelectButtonOnShow();
			LoadHighScoreFromFile();
		}

		private void SelectButtonOnShow()
		{
			EventSystem.current.SetSelectedGameObject(null);
			_selectOnStartButton.GetComponent<Button>().Select();
		}

		public void OnPlayButton()
		{
			Dispatcher.Broadcast(EventNames.CHANGE_SCENE_TO_GAME);
		}

		public void OnExitButton()
		{
			Application.Quit();
		}

		private void LoadHighScoreFromFile()
		{
			ScoreData scoreData = MainManager.Instance.BinFileIO.Load<ScoreData>(FilePaths.HIGH_SCORE);

			if (scoreData != null)
			{
				_highScoreText.text = scoreData.HighScore.ToString();
			}
			else
			{
				Debug.LogWarning("File " + FilePaths.HIGH_SCORE + " don't exist!");
			}
		}
	}
}

