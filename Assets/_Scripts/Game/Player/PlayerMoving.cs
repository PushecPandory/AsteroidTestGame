using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.GameScene
{
	public class PlayerMoving : MonoBehaviour 
	{
		private PlayerController _controller;
		private PlayerInput _input;

		private float _playerRotationSpeed;
		private float _playerMovingAcceleration;
		private float _playerMaxMovingSpeed;

		public void Init(PlayerController controller)
		{
			_controller = controller;
			_input = controller.PlayerInput;
		}

		public void SetMovingDesignSettingsData()
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			_playerRotationSpeed = data.PlayerRotationSpeed;
			_playerMovingAcceleration = data.PlayerMovingAcceleration;
			_playerMaxMovingSpeed = data.PlayerMaxMovingSpeed;
		}

		public void LinearMoving()
		{
			if (_input.Up)
			{
				MoveForward();
			}
				
			ClampLinearSpeed ();
		}

		public void AngularMoving()
		{
			if (_input.Left && _input.Right)
			{
				Rotate(0f);
			}
			else if (_input.Left)
			{
				Rotate(_playerRotationSpeed);
			}
			else if (_input.Right)
			{
				Rotate(-_playerRotationSpeed);
			}
			else
			{
				Rotate(0f);
			}
		}

		private void MoveForward()
		{
			_controller.Rigidbody.AddForce(_controller.Rigidbody.transform.up * _playerMovingAcceleration);
		}

		private void Rotate(float rotationSpeed)
		{
			_controller.Rigidbody.angularVelocity = rotationSpeed;
		}

		private void ClampLinearSpeed()
		{
			if (_controller.Rigidbody.velocity.magnitude > _playerMaxMovingSpeed)
			{
				_controller.Rigidbody.velocity = _controller.Rigidbody.velocity.normalized * _playerMaxMovingSpeed;
			}
		}
	}
}