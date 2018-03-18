using UnityEngine;
using TestGame.Main;

namespace TestGame.GameScene
{
	public class BaseGameSceneController : MonoBehaviour
	{
		[HideInInspector] public MainManager MainManager = null;
		[HideInInspector] public Dispatcher Dispatcher = null;
		[HideInInspector] public GameSceneManager GameSceneManager = null;

		public virtual void Init(GameSceneManager sceneManager) 
		{
			GameSceneManager = sceneManager;
			MainManager = MainManager.Instance;
			Dispatcher = GameSceneManager.Dispatcher;
		}
	}
}