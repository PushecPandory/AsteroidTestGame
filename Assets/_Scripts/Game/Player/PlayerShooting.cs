using UnityEngine;

namespace TestGame.GameScene
{
	public class PlayerShooting : MonoBehaviour 
	{
		[SerializeField]
		private Transform _spawnPoint;
		[SerializeField]
		private GameObject _bulletPrefab;

		private PlayerController _controller;
		private PlayerInput _input;

		private bool _reloaded;
		private float _reloadTimer;
		private float _reloadingTime;

		public void Init(PlayerController controller)
		{
			_controller = controller;
			_input = controller.PlayerInput;
			SetShootingDesignSettingsData();
		}

		public void Shooting()
		{
			if (_input.Shoot && _reloaded)
			{				
				ShootBullet();
			}

			if (!_reloaded)
			{
				_reloadTimer -= Time.deltaTime;
				if (_reloadTimer < 0)
				{
					_reloaded = true;
					_reloadTimer = _reloadingTime;
				}
			}
		}

		private void ShootBullet()
		{
			_reloaded = false;
			_controller.Dispatcher.Broadcast(EventNames.SPAWN_BULLET, _spawnPoint.transform);
			_controller.Dispatcher.Broadcast(EventNames.SHOOT_SOUND);
		}

		public void ResetPlayerShooting()
		{
			_reloadTimer = _reloadingTime;
			_reloaded = true;
		}

		public void SetShootingDesignSettingsData()
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			_reloadingTime = data.ReloadingTime;
		}
	}
}

