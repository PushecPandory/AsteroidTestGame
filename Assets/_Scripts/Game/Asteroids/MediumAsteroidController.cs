namespace TestGame.GameScene
{
	public class MediumAsteroidController : AsteroidController, ITriggerBullets 
	{
		public override void OnContactWithBullet()
		{
			SpawnSmallerAsteroids(EventNames.SPAWN_SMALL_ASTEROID);
			base.OnContactWithBullet();
		}
	}
}

