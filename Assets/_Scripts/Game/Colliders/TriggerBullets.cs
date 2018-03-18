using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
	public class TriggerBullets : MonoBehaviour 
	{
		private ITriggerBullets _triggerBulletsInterface;

		public void Init(ITriggerBullets triggerBulletsInterface)
		{
			_triggerBulletsInterface = triggerBulletsInterface;
		}

		protected void OnTriggerEnter2D(Collider2D collider)
		{
			_triggerBulletsInterface.OnContactWithBullet();
		}
	}
}

