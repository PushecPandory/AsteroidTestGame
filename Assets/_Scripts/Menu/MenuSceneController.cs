using UnityEngine;
using TestGame.Main;

namespace TestGame.MenuScene
{
	public class MenuSceneController : MonoBehaviour 
	{
		protected MainManager MainManager = null;
		protected Dispatcher Dispatcher = null;
		protected MenuSceneManager MenuSceneManager = null;

		public virtual void Init(MenuSceneManager sceneManager) 
		{
			MenuSceneManager = sceneManager;
			MainManager = MainManager.Instance;
			Dispatcher = MenuSceneManager.Dispatcher;
		}
	}
}

