using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
	public class PlayerInput : MonoBehaviour 
	{
		[HideInInspector] public bool Up = false;
		[HideInInspector] public bool Left = false;
		[HideInInspector] public bool Right = false;
		[HideInInspector] public bool Shoot = false;

		[HideInInspector] public bool PrevUp = false;
		[HideInInspector] public bool PrevLeft = false;
		[HideInInspector] public bool PrevRight = false;
		[HideInInspector] public bool PrevShoot = false;

		public void UpdateInput()
		{
			PrevUp = Up;
			PrevLeft = Left;
			PrevRight = Right;
			PrevShoot = Shoot;

			//Keyboard //IF STAND_ALONE OR UNITY_EDITOR
			Up = Input.GetKey(KeyCode.UpArrow);
			Left = Input.GetKey(KeyCode.LeftArrow);
			Right = Input.GetKey(KeyCode.RightArrow);
			Shoot = Input.GetKey(KeyCode.Space);
		}
	}
}

