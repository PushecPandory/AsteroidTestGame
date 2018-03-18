using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class GameFlowController : BaseGameSceneController 
	{
		private readonly string StartNewRoundAction = "StartNewRound";
		private readonly string EndGameAction = "EndGame";

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);

			Dispatcher.AddHandler(EventNames.PLAYER_WAS_KILLED, OnPlayerWasKilled);
			Dispatcher.AddHandler(EventNames.PLAYER_LIFES_COUNT_AFTER_DEATH, OnPlayerLifesCountAfterDeath);

			Invoke(StartNewRoundAction, sceneManager.DesignDataGameSettings.TimeGapOnGameStart);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.PLAYER_WAS_KILLED, OnPlayerWasKilled);
				Dispatcher.RemoveHandler(EventNames.PLAYER_LIFES_COUNT_AFTER_DEATH, OnPlayerLifesCountAfterDeath);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		private void StartNewRound()
		{
			Dispatcher.Broadcast(EventNames.START_NEW_ROUND);
		}

		private void EndGame()
		{
			Dispatcher.Broadcast(EventNames.SUM_UP_SCORE);
			Dispatcher.Broadcast(EventNames.ENABLE_SUMMARY_PANEL);
		}

		public void OnPlayerLifesCountAfterDeath(object lifesCount)
		{
			if ((int)lifesCount > 0)
			{
				Invoke(StartNewRoundAction, GameSceneManager.DesignDataGameSettings.TimeGapBetweenRounds);
			}
			else
			{
				Invoke(EndGameAction, GameSceneManager.DesignDataGameSettings.TimeGapBetweenRounds);
			}
		}

		public void OnPlayerWasKilled(object obj)
		{
			Dispatcher.Broadcast(EventNames.STOP_SPAWNING_ASTEROIDS);
			Dispatcher.Broadcast(EventNames.DISABLE_ACTIVE_BULLETS);
			Dispatcher.Broadcast(EventNames.DISABLE_ACTIVE_ASTEROIDS);
		}
	}
}

