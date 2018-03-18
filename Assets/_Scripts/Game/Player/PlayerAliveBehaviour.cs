using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class PlayerAliveBehaviour : PlayerBehaviourBase
	{
		private float _playerRotationSpeed;
		private float _playerMovingAcceleration;
		private float _playerMaxMovingSpeed;

		public void OnDestroy()
		{
			try
			{
				Controller.Dispatcher.RemoveHandler(EventNames.KILL_PLAYER, OnKillPlayer);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public override void OnFixedUpdate()
		{
			Controller.PlayerMoving.LinearMoving();
			Controller.PlayerMoving.AngularMoving();
			Controller.PlayerShooting.Shooting();
		}

		public override void OnEnterStateBehaviour() 
		{
			Controller.Dispatcher.AddHandler(EventNames.KILL_PLAYER, OnKillPlayer);
			ResetPositionAndRotation();
			Controller.PlayerShooting.ResetPlayerShooting();
			Controller.PlayerView.SetAliveView(true);
			Controller.Dispatcher.Broadcast(EventNames.RESPAWN_SHIP_SOUND);
		}

		public override void OnExitStateBehaviour() 
		{
			Controller.PlayerView.SetAliveView(false);
			Controller.Dispatcher.RemoveHandler(EventNames.KILL_PLAYER, OnKillPlayer);
		}

		public override void OnContactWithBullet() 
		{
			OnKillPlayer();
		}

		public override void OnContactWithAsteroid() 
		{
			OnKillPlayer();
		}

		public void OnKillPlayer(object obj = null)
		{
			Controller.CurrentState = PlayerController.PlayerState.Dying;
			Controller.Dispatcher.Broadcast(EventNames.PLAYER_WAS_KILLED);
		}

		private void ResetPositionAndRotation()
		{
			Controller.transform.position = Vector2.zero;
			Controller.transform.rotation = Quaternion.identity;
		}
	}
}