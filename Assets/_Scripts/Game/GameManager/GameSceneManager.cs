using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using UnityEngine.Assertions;
using System;

namespace TestGame.GameScene
{
	public class GameSceneManager : Singleton<GameSceneManager>
	{
		[SerializeField]
		private DesignDataGameSettings _designDataGameSettings;
		[SerializeField]
		private UIController _UIController;
		[SerializeField]
		private CameraController _cameraController;
		[SerializeField]
		private PlayerController _playerController;
		[SerializeField]
		private ScreenBordersController _screenBordersController;
		[SerializeField]
		private BigAsteroidsSpawnController _bigAsteroidsSpawnController;
		[SerializeField]
		private BigAsteroidsPoolController _bigAsteroidsPoolController;
		[SerializeField]
		private MediumAsteroidsPoolController _mediumAsteroidsPoolController;
		[SerializeField]
		private SmallAsteroidsPoolController _smallAsteroidsPoolController;
		[SerializeField]
		private BulletsPoolController _bulletsPoolController;
		[SerializeField]
		private AudioController _audioController;

		private MainManager _mainManager;

		public Dispatcher Dispatcher { private set; get; }
		public ScoreController ScoreController { private set; get; }
		public LifesController LifesController { private set; get; }
		public GameFlowController GameFlowController { private set; get; }

		public DesignDataGameSettings DesignDataGameSettings { private set { _designDataGameSettings = value; } get { return _designDataGameSettings; } }
		public UIController UIController { private set { _UIController = value; } get { return _UIController; } }
		public CameraController CameraController { private set { _cameraController = value; } get { return _cameraController; } }
		public PlayerController PlayerController { private set { _playerController = value; } get { return _playerController; } }
		public ScreenBordersController ScreenBordersController { private set { _screenBordersController = value; } get { return _screenBordersController; } }
		public BigAsteroidsSpawnController BigAsteroidsSpawnController { private set { _bigAsteroidsSpawnController = value; } get { return _bigAsteroidsSpawnController; } }
		public BigAsteroidsPoolController BigAsteroidsPoolController { private set { _bigAsteroidsPoolController = value; } get { return _bigAsteroidsPoolController; } }
		public MediumAsteroidsPoolController MediumAsteroidsPoolController { private set { _mediumAsteroidsPoolController = value; } get { return _mediumAsteroidsPoolController; } }
		public SmallAsteroidsPoolController SmallAsteroidsPoolController { private set { _smallAsteroidsPoolController = value; } get { return _smallAsteroidsPoolController; } }
		public BulletsPoolController BulletsPoolController { private set { _bulletsPoolController = value; } get { return _bulletsPoolController; } }
		public AudioController AudioController { private set { _audioController = value; } get { return _audioController; } }

		public override void Init()
		{
			base.Init();
			_mainManager = MainManager.Instance;
			Dispatcher = new Dispatcher();

			AssignReferences();
			AssertReferences();

			Dispatcher.AddHandler(Main.EventNames.CHANGE_SCENE_TO_MENU, OnChangeSceneToMenu);
			Dispatcher.AddHandler(Main.EventNames.CHANGE_SCENE_TO_GAME, OnChangeSceneToGame);
			InitializeModules();
		}

		protected override void OnDestroy()
		{
			try
			{
				Dispatcher.RemoveHandler(Main.EventNames.CHANGE_SCENE_TO_MENU, OnChangeSceneToMenu);
				Dispatcher.RemoveHandler(Main.EventNames.CHANGE_SCENE_TO_GAME, OnChangeSceneToGame);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}

		private void AssignReferences()
		{
			ScoreController = this.GetComponent<ScoreController>();
			LifesController = this.GetComponent<LifesController>();
			GameFlowController = this.GetComponent<GameFlowController>();
		}

		private void AssertReferences()
		{
			Assert.IsNotNull<GameFlowController>(GameFlowController);
			Assert.IsNotNull<UIController>(UIController);
			Assert.IsNotNull<ScoreController>(ScoreController);
			Assert.IsNotNull<LifesController>(LifesController);
			Assert.IsNotNull<CameraController>(CameraController);
			Assert.IsNotNull<PlayerController>(PlayerController);
			Assert.IsNotNull<ScreenBordersController>(ScreenBordersController);
			Assert.IsNotNull<BigAsteroidsSpawnController>(BigAsteroidsSpawnController);
			Assert.IsNotNull<BigAsteroidsPoolController>(BigAsteroidsPoolController);
			Assert.IsNotNull<MediumAsteroidsPoolController>(MediumAsteroidsPoolController);
			Assert.IsNotNull<SmallAsteroidsPoolController>(SmallAsteroidsPoolController);
			Assert.IsNotNull<BulletsPoolController>(BulletsPoolController);
			Assert.IsNotNull<AudioController>(AudioController);
		}

		private void InitializeModules()
		{
			GameFlowController.Init(this);
			UIController.Init(this);
			ScoreController.Init(this);
			LifesController.Init(this);
			CameraController.Init(this);
			PlayerController.Init(this);
			ScreenBordersController.Init(this);
			BigAsteroidsSpawnController.Init(this);
			BigAsteroidsPoolController.Init(this);
			MediumAsteroidsPoolController.Init(this);
			SmallAsteroidsPoolController.Init(this);
			BulletsPoolController.Init(this);
			AudioController.Init(this);
		}

		public void OnChangeSceneToMenu(object obj)
		{
			_mainManager.ChangeSceneTo(SceneNames.MENU_SCENE);
		}

		public void OnChangeSceneToGame(object obj)
		{
			_mainManager.ChangeSceneTo(SceneNames.GAME_SCENE);
		}
	}
}

