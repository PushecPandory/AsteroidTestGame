using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TestGame.GameScene
{
	[CustomEditor(typeof(CameraController))]
	public class CustomInspectorCameraController : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			CameraController cameraController = (CameraController)target;

//			if (GUILayout.Button("UPDATE"))
//			{
//				cameraController.InspectorUpdateCamera();
//			}
		}
	}
}

