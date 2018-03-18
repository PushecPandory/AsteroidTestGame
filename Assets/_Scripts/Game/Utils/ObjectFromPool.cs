using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestGame.GameScene
{
	public class ObjectFromPool : MonoBehaviour 
	{
		private bool _wasInitialized = false;
		protected GameObjectsPoolContoller PoolController;

		public virtual void Init(GameObjectsPoolContoller poolController)
		{
			PoolController = poolController;
		}
			
		public virtual void OnPopFromPool(GameObjectsPoolContoller bulletPoolController)//
		{
			if (!_wasInitialized)
			{
				_wasInitialized = true;
				Init(bulletPoolController);
			}
		}

		public virtual void PushBackToPool()
		{
			if (PoolController != null)
			{
				PoolController.PushToPool(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}