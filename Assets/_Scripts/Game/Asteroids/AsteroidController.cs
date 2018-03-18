using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace TestGame.GameScene
{
	public class AsteroidController : ObjectFromPool, ITriggerBullets
	{
		[SerializeField]
		private TriggerScreenBorders _triggerScreenBorders;
		[SerializeField]
		private TriggerBullets _triggerBullets;

		protected float MaxAngularSpeed;
		protected float MaxLinearSpeed;
		protected float MinAngularSpeed;
		protected float MinLinearSpeed;
		protected int SmallerAsteroidsSpawnCount;
		protected Rigidbody2D Rigidbody;
		private int _scoreForDestroyingThisAsteroid;

		public override void Init(GameObjectsPoolContoller poolController)
		{
			base.Init(poolController);
			Rigidbody = this.GetComponent<Rigidbody2D>();
			AssertReferences ();

			_triggerScreenBorders.Init(this.transform);
			_triggerBullets.Init(this);

			SetDesignDataSettings();

			#if UNITY_EDITOR
			PoolController.Dispatcher.AddHandler(EventNames.UPDATE_ASTEROIDS_DESIGN_DATA, SetDesignDataSettings);
			#endif
		}

		protected void OnDestroy()
		{
			try
			{
				PoolController.Dispatcher.RemoveHandler(EventNames.DISABLE_ACTIVE_ASTEROIDS, OnDisableActiveAsteroids);

				#if UNITY_EDITOR
				PoolController.Dispatcher.RemoveHandler(EventNames.UPDATE_ASTEROIDS_DESIGN_DATA, SetDesignDataSettings);
				#endif
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public void OnDisableActiveAsteroids(object obj)
		{
			PushBackToPool();
		}

		public virtual void OnContactWithBullet()
		{
			PoolController.Dispatcher.Broadcast(EventNames.ADD_SCORE, _scoreForDestroyingThisAsteroid);
			PoolController.Dispatcher.Broadcast(EventNames.DESTROY_ASTEROID_SOUND);
			PushBackToPool();
		}

		public override void OnPopFromPool(GameObjectsPoolContoller poolController)//
		{
			base.OnPopFromPool(poolController);
			GameSceneManager.Instance.Dispatcher.AddHandler(EventNames.DISABLE_ACTIVE_ASTEROIDS, OnDisableActiveAsteroids);
			SetAsteroidMovement();
		}

		public override void PushBackToPool()
		{
			GameSceneManager.Instance.Dispatcher.RemoveHandler(EventNames.DISABLE_ACTIVE_ASTEROIDS, OnDisableActiveAsteroids);
			base.PushBackToPool();
		}

		protected virtual void SetAsteroidMovement()
		{
			float linearSpeed = UnityEngine.Random.Range(MinLinearSpeed, MaxLinearSpeed);
			Vector2 direction = UnityEngine.Random.insideUnitCircle;
			Rigidbody.velocity = direction * linearSpeed;
			Rigidbody.angularVelocity = UnityEngine.Random.Range(MinAngularSpeed, MaxAngularSpeed);
		}

		protected void SpawnSmallerAsteroids(string eventNameForSpawning)
		{
			for (int i = 0; i < SmallerAsteroidsSpawnCount; ++i)
			{
				GameSceneManager.Instance.Dispatcher.Broadcast(eventNameForSpawning, this.transform);
			}
		}

		private void SetDesignDataSettings(object obj = null)
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			MinAngularSpeed = data.MinAngularSpeed;
			MaxAngularSpeed = data.MaxAngularSpeed;
			MinLinearSpeed = data.MinLinearSpeed;
			MaxLinearSpeed = data.MaxLinearSpeed;
			_scoreForDestroyingThisAsteroid = data.ScoreForAsteroid;
			SmallerAsteroidsSpawnCount = data.SmallerAsteroidsSpawnCount;
		}

		private void AssertReferences()
		{
			Assert.IsNotNull<TriggerScreenBorders>(_triggerScreenBorders);
			Assert.IsNotNull<TriggerBullets>(_triggerBullets);
			Assert.IsNotNull<Rigidbody2D>(Rigidbody);
		}
	}
}
