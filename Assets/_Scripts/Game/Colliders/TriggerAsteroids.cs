using UnityEngine;

namespace TestGame.GameScene
{
	public class TriggerAsteroids : MonoBehaviour 
	{
		private ITriggerAsteroids _triggerAsteroidsInterface;

		public void Init(ITriggerAsteroids triggerAsteroidsInterface)
		{
			_triggerAsteroidsInterface = triggerAsteroidsInterface;
		}

		protected void OnTriggerEnter2D(Collider2D collider)
		{
			_triggerAsteroidsInterface.OnContactWithAsteroid();
		}
	}
}

