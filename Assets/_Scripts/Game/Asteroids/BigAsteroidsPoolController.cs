namespace TestGame.GameScene
{
	public class BigAsteroidsPoolController : GameObjectsPoolContoller 
	{
		public override void Init(GameSceneManager sceneManager)
		{
			SpawnEventName = EventNames.SPAWN_BIG_ASTEROID;
			base.Init(sceneManager);
		}		
	}
}