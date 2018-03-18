using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestGame.GameScene
{
	public class GameObjectsPoolContoller : BaseGameSceneController
	{
		[SerializeField]
		private GameObject _prefab;

		private Stack<GameObject> _pool;
		protected string SpawnEventName;

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			_pool = new Stack<GameObject>();
			Dispatcher.AddHandler(SpawnEventName, OnSpawn);
		}			

		protected void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(SpawnEventName, OnSpawn);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		public GameObject PopFromPool()
		{
			GameObject item;

			if (_pool.Count == 0)
			{
				item = Instantiate<GameObject>(original: _prefab, parent: this.transform);
			}
			else
			{
				item = _pool.Pop();
				item.SetActive(true);
			}

			return item;
		}

		public void PushToPool(GameObject item)
		{
			_pool.Push(item);
			item.SetActive(false);
		}

		public virtual void OnSpawn(object spawnTransformObject)
		{
			Transform spawn = (Transform)spawnTransformObject;
			GameObject go = PopFromPool();
			go.transform.position = spawn.position;
			go.transform.rotation = spawn.rotation;
			ObjectFromPool controller = go.GetComponent<ObjectFromPool>();
			controller.OnPopFromPool(this);
		}
	}
}

