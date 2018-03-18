using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class PlayerDyingBehaviour : PlayerBehaviourBase
	{
		public void OnDestroy()
		{
			try
			{
				Controller.Dispatcher.RemoveHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public override void OnEnterStateBehaviour() 
		{
			Controller.Dispatcher.AddHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
			Controller.PlayerView.SetDyingView(true);
			Controller.Dispatcher.Broadcast(EventNames.DESTROY_SHIP_SOUND);
		}

		public override void OnExitStateBehaviour() 
		{
			Controller.PlayerView.SetDyingView(false);
			Controller.Dispatcher.RemoveHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
		}

		public void OnStartNewRound(object obj)
		{
			Controller.CurrentState = PlayerController.PlayerState.Alive;
		}
	}
}

