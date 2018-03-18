using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class LifesController : BaseGameSceneController 
	{
		private int _lifes;

		public int Lifes
		{
			private set 
			{
				_lifes = value;
				Dispatcher.Broadcast(EventNames.UPDATE_LIFES_IN_UI, Lifes);
			}
			get
			{
				return _lifes;
			}
		}

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			SetDesignDataSettings ();
			Dispatcher.AddHandler(EventNames.PLAYER_WAS_KILLED, OnPlayerWasKilled);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.PLAYER_WAS_KILLED, OnPlayerWasKilled);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public void OnPlayerWasKilled(object obj)
		{
			Lifes -= 1;
			Dispatcher.Broadcast(EventNames.PLAYER_LIFES_COUNT_AFTER_DEATH, Lifes);
		}

		private void SetDesignDataSettings()
		{
			Lifes = GameSceneManager.DesignDataGameSettings.LifesOnGameStart;
		}
	}
}