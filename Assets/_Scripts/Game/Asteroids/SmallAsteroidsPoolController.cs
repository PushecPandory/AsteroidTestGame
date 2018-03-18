using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.GameScene
{
	public class SmallAsteroidsPoolController : GameObjectsPoolContoller 
	{
		public override void Init(GameSceneManager sceneManager)
		{
			SpawnEventName = EventNames.SPAWN_SMALL_ASTEROID;
			base.Init(sceneManager);
		}	
	}
}

