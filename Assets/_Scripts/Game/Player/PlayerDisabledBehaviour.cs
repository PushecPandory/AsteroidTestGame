using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class PlayerDisabledBehaviour : PlayerBehaviourBase
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
			Controller.PlayerView.SetDisabledView();
		}

		public override void OnExitStateBehaviour() 
		{
			Controller.Dispatcher.RemoveHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
		}

		public void OnStartNewRound(object obj)
		{
			Controller.CurrentState = PlayerController.PlayerState.Alive;
		}
	}
}

