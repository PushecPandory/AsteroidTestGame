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