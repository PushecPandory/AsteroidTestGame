using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestGame.GameScene
{
	public class BigAsteroidsSpawnController : BaseGameSceneController 
	{
		[SerializeField]
		private Transform _spawnPointTransform;

		private float _cameraBordersOffset = 1f;
		private float _cameraOrtographicSize;
		private float _aspectRatio;

		private bool _isSpawningEnabled = false;
		private float _timer = 0f;
		private float _timeToSpawnNextAsteroid;
		private float _minTimeToSpawnNextAsteroid;
		private float _maxTimeToSpawnNextAsteroid;
		private float _spawnPointSpeed;

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);

			SetDesignDataSettings();
			GetDataAboutCameraSizeFromCamera();
			SetSpawnPointPositionOutsideCamera();
			this.GetComponent<Rigidbody2D>().angularVelocity = _spawnPointSpeed;

			Dispatcher.AddHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
			Dispatcher.AddHandler(EventNames.STOP_SPAWNING_ASTEROIDS, OnStopSpawningAsteroids);
		}

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.START_NEW_ROUND, OnStartNewRound);
				Dispatcher.RemoveHandler(EventNames.STOP_SPAWNING_ASTEROIDS, OnStopSpawningAsteroids);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		private void SetDesignDataSettings()
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			_minTimeToSpawnNextAsteroid = data.MinTimeToSpawnNextAsteroid;
			_maxTimeToSpawnNextAsteroid = data.MaxTimeToSpawnNextAsteroid;
			_spawnPointSpeed = data.SpawnerRotationSpeed;
		}

		private void GetDataAboutCameraSizeFromCamera()
		{
			_cameraOrtographicSize = GameSceneManager.CameraController.Camera.orthographicSize;
			_aspectRatio = GameSceneManager.CameraController.AspectRatio;
		}

		private void SetSpawnPointPositionOutsideCamera()
		{
			float posX = (_cameraOrtographicSize * _aspectRatio) + _cameraBordersOffset;
			float posY = _cameraOrtographicSize + _cameraBordersOffset;
			_spawnPointTransform.position = new Vector2(-posX, posY);
		}

		protected void Update() 
		{
			if (_isSpawningEnabled)
			{
				_timer += Time.deltaTime;
				if (_timer > _timeToSpawnNextAsteroid)
				{
					SpawnNextAsteroid();
				}
			}
		}

		public void OnStartNewRound(object obj)
		{
			_isSpawningEnabled = true;
			SpawnNextAsteroid();
		}

		public void OnStopSpawningAsteroids(object obj)
		{
			_isSpawningEnabled = false;
		}

		private void SpawnNextAsteroid()
		{
			_timer = 0f;
			_timeToSpawnNextAsteroid = UnityEngine.Random.Range(_minTimeToSpawnNextAsteroid, _maxTimeToSpawnNextAsteroid);
			Dispatcher.Broadcast(EventNames.SPAWN_BIG_ASTEROID, _spawnPointTransform);
		}
	}
}