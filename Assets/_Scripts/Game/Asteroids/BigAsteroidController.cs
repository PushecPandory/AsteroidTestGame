using UnityEngine;

namespace TestGame.GameScene
{
	public class BigAsteroidController : AsteroidController, ITriggerBullets
	{
		public override void OnContactWithBullet()
		{
			SpawnSmallerAsteroids(EventNames.SPAWN_MEDIUM_ASTEROID);
			base.OnContactWithBullet();
		}

		protected override void SetAsteroidMovement()
		{
			float linearSpeed = UnityEngine.Random.Range(MinLinearSpeed, MaxLinearSpeed);
			float radius = GameSceneManager.Instance.CameraController.Camera.orthographicSize;
			Vector2 targetPoint = UnityEngine.Random.insideUnitCircle * radius;
			Vector2 startPoint = this.transform.position;
			Vector2 direction = targetPoint - startPoint;
			Rigidbody.velocity = direction.normalized * linearSpeed;
			Rigidbody.angularVelocity = UnityEngine.Random.Range(MinAngularSpeed, MaxAngularSpeed);
		}
	}
}

