using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestGame.GameScene
{
	public class AudioController : BaseGameSceneController 
	{
		[SerializeField]
		private AudioSource _shipSounds;
		[SerializeField]
		private AudioSource _asteroidSounds;

		[SerializeField]
		private AudioClip _destroyShip;
		[SerializeField]
		private AudioClip _respawnShip;
		[SerializeField]
		private AudioClip _shoot;
		[SerializeField]
		private AudioClip _destroyAsteroid;

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);

			Dispatcher.AddHandler(EventNames.SHOOT_SOUND, OnShoot);
			Dispatcher.AddHandler(EventNames.RESPAWN_SHIP_SOUND, OnRespawnShip);
			Dispatcher.AddHandler(EventNames.DESTROY_SHIP_SOUND, OnDestroyShip);
			Dispatcher.AddHandler(EventNames.DESTROY_ASTEROID_SOUND, OnDestroyAsteroid);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.SHOOT_SOUND, OnShoot);
				Dispatcher.RemoveHandler(EventNames.RESPAWN_SHIP_SOUND, OnRespawnShip);
				Dispatcher.RemoveHandler(EventNames.DESTROY_SHIP_SOUND, OnDestroyShip);
				Dispatcher.RemoveHandler(EventNames.DESTROY_ASTEROID_SOUND, OnDestroyAsteroid);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public void OnShoot(object obj)
		{
			_shipSounds.clip = _shoot;
			_shipSounds.Play();
		}

		public void OnRespawnShip(object obj)
		{
			_shipSounds.clip = _respawnShip;
			_shipSounds.Play();
		}

		public void OnDestroyShip(object obj)
		{
			_shipSounds.clip = _destroyShip;
			_shipSounds.Play();
		}

		public void OnDestroyAsteroid(object obj)
		{
			_asteroidSounds.clip = _destroyAsteroid;
			_asteroidSounds.Play();
		}
	}
}