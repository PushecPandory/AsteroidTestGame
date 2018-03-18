using UnityEngine;

namespace TestGame.GameScene
{
	public class BulletCollider : MonoBehaviour 
	{
		private BulletController _bulletController;

		public void Init(BulletController bulletController)
		{
			_bulletController = bulletController;
		}

		protected void OnTriggerEnter2D(Collider2D col)
		{
			_bulletController.PushBackToPool();
		}
	}
}

