using UnityEngine;

namespace TestGame.GameScene
{
	public class ScreenBordersController : BaseGameSceneController 
	{
		[SerializeField]
		private TeleporterToOppositeBorder LeftBorder;
		[SerializeField]
		private TeleporterToOppositeBorder RightBorder;
		[SerializeField]
		private TeleporterToOppositeBorder TopBorder;
		[SerializeField]
		private TeleporterToOppositeBorder BottomBorder;

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			InitializeTeleportersToOppositeBorder();
			SetBordersScaleAndPosition(sceneManager);
		}

		private void InitializeTeleportersToOppositeBorder()
		{
			LeftBorder.Init();
			RightBorder.Init();
			TopBorder.Init();
			BottomBorder.Init();
		}

		private void SetBordersScaleAndPosition(GameSceneManager sceneManager)
		{
			float cameraOrtographicSize = sceneManager.CameraController.Camera.orthographicSize;
			float aspectRatio = sceneManager.CameraController.AspectRatio;

			float xAxisOffset = cameraOrtographicSize * aspectRatio;
			float yAxisOffset = cameraOrtographicSize;

			LeftBorder.SetPosition(cameraOrtographicSize, -xAxisOffset);
			RightBorder.SetPosition(cameraOrtographicSize, xAxisOffset);
			TopBorder.SetPosition(cameraOrtographicSize, yAxisOffset);
			BottomBorder.SetPosition(cameraOrtographicSize, -yAxisOffset);

			LeftBorder.SetScale(cameraOrtographicSize, aspectRatio);
			RightBorder.SetScale(cameraOrtographicSize, aspectRatio);
			TopBorder.SetScale(cameraOrtographicSize, aspectRatio);
			BottomBorder.SetScale(cameraOrtographicSize, aspectRatio);
		}
	}
}