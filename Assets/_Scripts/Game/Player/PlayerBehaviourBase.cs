using UnityEngine;

namespace TestGame.GameScene
{
	public class PlayerBehaviourBase : MonoBehaviour, IPlayerStateBehaviour, ITriggerBullets, ITriggerAsteroids
	{
		protected PlayerController Controller;

		public virtual void Init(PlayerController controller)
		{
			Controller = controller;
		}

		public virtual void OnUpdate() {}
		public virtual void OnFixedUpdate() {}
		public virtual void OnEnterStateBehaviour() {}
		public virtual void OnExitStateBehaviour() {}

		public virtual void OnContactWithBullet() {}
		public virtual void OnContactWithAsteroid() {}
	}
}

