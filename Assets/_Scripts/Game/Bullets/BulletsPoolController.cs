using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TestGame.GameScene
{
	public class BulletsPoolController : GameObjectsPoolContoller
	{
		public override void Init(GameSceneManager sceneManager)
		{
			SpawnEventName = EventNames.SPAWN_BULLET;
			base.Init(sceneManager);
		}		
	}
}