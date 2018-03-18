using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.GameScene
{
	public class BulletController : ObjectFromPool
	{
		[SerializeField]
		private TriggerScreenBorders _triggerScreenBorders;
		[SerializeField]
		private BulletCollider _bulletCollider;

		private float _timer;
		private float _livingTime;
		private float _linearSpeed;
		private Rigidbody2D _rigidbody;

		public override void Init(GameObjectsPoolContoller poolController)
		{
			base.Init(poolController);
			_rigidbody = this.GetComponent<Rigidbody2D>();
			_triggerScreenBorders.Init(this.transform);
			_bulletCollider.Init(this);
			SetDesignDataSettings();

			#if UNITY_EDITOR
			PoolController.Dispatcher.AddHandler(EventNames.UPDATE_BULLETS_DESIGN_DATA, SetDesignDataSettings);
			#endif
		}

		protected void OnDestroy()
		{
			GameSceneManager.Instance.Dispatcher.RemoveHandler(EventNames.DISABLE_ACTIVE_BULLETS, OnDisableActiveBullets);

			#if UNITY_EDITOR
			try
			{
				PoolController.Dispatcher.RemoveHandler(EventNames.UPDATE_BULLETS_DESIGN_DATA, SetDesignDataSettings);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
			#endif
		}

		public override void OnPopFromPool(GameObjectsPoolContoller poolController)
		{
			base.OnPopFromPool(poolController);
			GameSceneManager.Instance.Dispatcher.AddHandler(EventNames.DISABLE_ACTIVE_BULLETS, OnDisableActiveBullets);
			_timer = _livingTime;
			_rigidbody.velocity = this.transform.up * _linearSpeed;
		}

		public override void PushBackToPool()
		{
			GameSceneManager.Instance.Dispatcher.RemoveHandler(EventNames.DISABLE_ACTIVE_BULLETS, OnDisableActiveBullets);
			base.PushBackToPool();
		}

		public void OnDisableActiveBullets(object obj)
		{
			PushBackToPool();
		}

		public void Update()
		{
			_timer -= Time.deltaTime;

			if (_timer < 0)
			{	
				PushBackToPool();
			}
		}
			
		private void SetDesignDataSettings(object obj = null)
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			_livingTime = data.BulletLivingTime;
			_linearSpeed = data.BulletLinearSpeed;
		}
	}
}