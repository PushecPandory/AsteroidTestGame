using UnityEngine;
using System;
using TestGame.Main;
using System.IO;

namespace TestGame.GameScene
{
	public class ScoreController : BaseGameSceneController 
	{
		public ScoreData ScoreData { private set; get; }

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			ScoreData = new ScoreData();
			LoadHighScroreFromFile();
			Dispatcher.AddHandler(EventNames.ADD_SCORE, OnAddScore);
			Dispatcher.AddHandler(EventNames.SUM_UP_SCORE, OnSumUpScore);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.ADD_SCORE, OnAddScore);
				Dispatcher.RemoveHandler(EventNames.SUM_UP_SCORE, OnSumUpScore);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public void OnAddScore(object obj)
		{
			ScoreData.CurrentScore += (int)obj;
			Dispatcher.Broadcast(EventNames.UPDATE_SCORE_IN_UI, ScoreData.CurrentScore);
		}

		private void LoadHighScroreFromFile()
		{
			if (File.Exists(FilePaths.HIGH_SCORE))
			{
				ScoreData.HighScore = MainManager.Instance.BinFileIO.Load<ScoreData>(FilePaths.HIGH_SCORE).HighScore;
			}
			else
			{
				ScoreData.HighScore = 0;
			}
		}

		public void OnSumUpScore(object obj)
		{
			if (ScoreData.CurrentScore > ScoreData.HighScore)
			{
				ScoreData.HighScore = ScoreData.CurrentScore;
				MainManager.Instance.BinFileIO.Save<ScoreData>(ScoreData, FilePaths.HIGH_SCORE);
			}
			Dispatcher.Broadcast(EventNames.UPDATE_SCORES_IN_SUMMARY_PANEL, ScoreData);
		}
	}
}