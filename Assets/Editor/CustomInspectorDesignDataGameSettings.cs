using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace TestGame.GameScene
{
	[CustomEditor(typeof(DesignDataGameSettings))]
	public class CustomInspectorDesignDataGameSettings : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("UPDATE ON PLAY: PLAYER DATA"))
			{
				try
				{
					GameSceneManager.Instance.Dispatcher.Broadcast(EventNames.UPDATE_PLAYER_DESIGN_DATA);
				}
				catch (InvalidOperationException ex)
				{
					Debug.LogError("You can use \"UPDATE ON PLAY: PLAYER DATA\" only on playmode! " + ex);
				}
			}

			if (GUILayout.Button("UPDATE ON PLAY: BULLETS DATA"))
			{
				try
				{
					GameSceneManager.Instance.Dispatcher.Broadcast(EventNames.UPDATE_BULLETS_DESIGN_DATA);
				}
				catch (InvalidOperationException ex)
				{
					Debug.LogError("You can use \"UPDATE ON PLAY: BULLETS DATA\" only on playmode! " + ex);
				}
			}

			if (GUILayout.Button("UPDATE ON PLAY: ASTEROIDS DATA"))
			{
				try
				{
					GameSceneManager.Instance.Dispatcher.Broadcast(EventNames.UPDATE_ASTEROIDS_DESIGN_DATA);
				}
				catch (InvalidOperationException ex)
				{
					Debug.LogError("You can use \"UPDATE ON PLAY: ASTEROIDS DATA\" only on playmode! " + ex);
				}
			}
		}
	}
}

