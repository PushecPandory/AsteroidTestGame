using UnityEngine;
using TestGame.Main;
using System;

namespace TestGame.MenuScene
{
	public class MenuSceneManager : Singleton<MenuSceneManager> 
	{
		[SerializeField]
		private UIController _UIController;

		private MainManager _mainManager;

		public Dispatcher Dispatcher { private set; get; }
		public UIController UIController { private set { _UIController = value; } get { return _UIController; } }

		public override void Init()
		{
			base.Init();
			_mainManager = MainManager.Instance;
			Dispatcher = new Dispatcher();
			_UIController.Init(this);

			//AssertReferencesAreNotNull();

			Dispatcher.AddHandler(EventNames.CHANGE_SCENE_TO_GAME, ChangeSceneToGame);
		}

		protected override void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(EventNames.CHANGE_SCENE_TO_GAME, ChangeSceneToGame);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
				
			base.OnDestroy();
		}

		public void ChangeSceneToGame(object obj)
		{
			_mainManager.ChangeSceneTo(SceneNames.GAME_SCENE);
		}
	}
}

