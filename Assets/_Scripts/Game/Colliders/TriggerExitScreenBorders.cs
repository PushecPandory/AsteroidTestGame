using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
	public class TriggerExitScreenBorders : MonoBehaviour 
	{
		[SerializeField]
		private GameObject _triggerScreenBordersGameObject;

		private bool _wasActivated = false;

		protected void OnTriggerExitCollider2D(Collider2D col)
		{
			if (!_wasActivated)
			{
				_wasActivated = true;
				_triggerScreenBordersGameObject.SetActive(true);
			}
		}
	}
}

