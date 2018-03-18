using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.GameScene
{
	public interface IPlayerStateBehaviour 
	{
		void OnUpdate();
		void OnFixedUpdate();
		void OnEnterStateBehaviour();
		void OnExitStateBehaviour();
	}
}

