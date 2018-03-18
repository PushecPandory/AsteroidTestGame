namespace TestGame.GameScene
{
	public class MediumAsteroidsPoolController : GameObjectsPoolContoller 
	{
		public override void Init(GameSceneManager sceneManager)
		{
			SpawnEventName = EventNames.SPAWN_MEDIUM_ASTEROID;
			base.Init(sceneManager);
		}			
	}
}

