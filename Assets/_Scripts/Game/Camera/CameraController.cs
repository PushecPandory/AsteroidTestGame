using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.GameScene
{
	public class CameraController : BaseGameSceneController 
	{
		private const int NATIVE_SCREEN_WIDTH = 1920;
		private const int NATIVE_SCREEN_HEIGHT = 1080;
		private const float NATIVE_ORTOGRAPHIC_SIZE = 5.4f;

		public Camera Camera { private set; get; }
		public float AspectRatio { private set; get; }

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			Camera = this.GetComponent<Camera>();
			AspectRatio = (float)Screen.width / Screen.height;
		}
	}
}

