using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class UIController : BaseGameSceneController 
	{
		[SerializeField]
		private Text _scoreText;
		[SerializeField]
		private Text _lifesText;
		[SerializeField]
		private GameObject _summaryPanel;
		[SerializeField]
		private Text _summaryCurrentScoreText;
		[SerializeField]
		private Text _summaryHighScoreText;
		[SerializeField]
		private Button _selectOnStartButton;

		public override void Init (GameSceneManager sceneManager)
		{
			base.Init (sceneManager);

			_summaryPanel.SetActive(false);

			Dispatcher.AddHandler(EventNames.UPDATE_SCORE_IN_UI, OnUpdateScoreText);
			Dispatcher.AddHandler(EventNames.UPDATE_LIFES_IN_UI, OnUpdateLifesText);
			Dispatcher.AddHandler(EventNames.UPDATE_SCORES_IN_SUMMARY_PANEL, OnUpdateScoresInSummaryPanel);
			Dispatcher.AddHandler(EventNames.ENABLE_SUMMARY_PANEL, OnEnableSummaryPanel);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.UPDATE_SCORE_IN_UI, OnUpdateScoreText);
				Dispatcher.RemoveHandler(EventNames.UPDATE_LIFES_IN_UI, OnUpdateLifesText);
				Dispatcher.RemoveHandler(EventNames.UPDATE_SCORES_IN_SUMMARY_PANEL, OnUpdateScoresInSummaryPanel);
				Dispatcher.RemoveHandler(EventNames.ENABLE_SUMMARY_PANEL, OnEnableSummaryPanel);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public void OnUpdateScoreText(object obj)
		{
			_scoreText.text = ((int)obj).ToString();
		}

		public void OnUpdateLifesText(object obj)
		{
			_lifesText.text = ((int)obj).ToString();
		}

		public void OnUpdateScoresInSummaryPanel(object scoreData)
		{
			ScoreData data = (ScoreData)scoreData;

			_summaryCurrentScoreText.text = data.CurrentScore.ToString();
			_summaryHighScoreText.text = data.HighScore.ToString();
		}

		public void OnEnableSummaryPanel(object obj)
		{
			_summaryPanel.SetActive(true);
            Cursor.visible = true;
			SelectButtonOnShow();
		}

		public void OnRestartButton()
		{
			Dispatcher.Broadcast(Main.EventNames.CHANGE_SCENE_TO_GAME);
		}

		public void OnExitButton()
		{
			Dispatcher.Broadcast(Main.EventNames.CHANGE_SCENE_TO_MENU);
		}

		private void SelectButtonOnShow()
		{
			EventSystem.current.SetSelectedGameObject(null);
			_selectOnStartButton.GetComponent<Button>().Select();
		}
	}
}
