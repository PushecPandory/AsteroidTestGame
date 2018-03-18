using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;


namespace TestGame.GameScene
{
	public class TeleporterToOppositeBorder : MonoBehaviour 
	{
		[SerializeField]
		private Transform _oppositeBorder;
		private float _triggerBoxOffset;
		private float _epsilonOffset = 0.1f;

		public void Init()
		{
			BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();

			if (this.gameObject.CompareTag(Tags.LEFT_BORDER))
			{
				_triggerBoxOffset = -(boxCollider.size.x / 2);
			}
			else if (this.gameObject.CompareTag(Tags.RIGHT_BORDER))
			{
				_triggerBoxOffset = (boxCollider.size.x / 2);
			}
			else if (this.gameObject.CompareTag(Tags.TOP_BORDER))
			{
				_triggerBoxOffset = (boxCollider.size.y / 2);
			}
			else if (this.gameObject.CompareTag(Tags.BOTTOM_BORDER))
			{
				_triggerBoxOffset = -(boxCollider.size.y / 2);
			}
		}

		public void SetPosition(float cameraOrtographicSize, float offset)
		{
			if (this.gameObject.CompareTag(Tags.LEFT_BORDER) || this.gameObject.CompareTag(Tags.RIGHT_BORDER))
			{
				this.transform.position = new Vector2(offset + _triggerBoxOffset, this.transform.position.y);
			}
			else if (this.gameObject.CompareTag(Tags.TOP_BORDER) || this.gameObject.CompareTag(Tags.BOTTOM_BORDER))
			{
				this.transform.position = new Vector2(this.transform.position.x, offset + _triggerBoxOffset);
			}
		}

		public void SetScale(float cameraOrtographicSize, float aspectRatio)
		{
			if (this.gameObject.CompareTag(Tags.LEFT_BORDER) || this.gameObject.CompareTag(Tags.RIGHT_BORDER))
			{
				this.transform.localScale = new Vector2(this.transform.localScale.x, cameraOrtographicSize * 2);
			}
			else if (this.gameObject.CompareTag(Tags.TOP_BORDER) || this.gameObject.CompareTag(Tags.BOTTOM_BORDER))
			{
				this.transform.localScale = new Vector2(cameraOrtographicSize * 2 * aspectRatio, this.transform.localScale.y);
			}			
		}

		protected void OnTriggerEnter2D(Collider2D collider)
		{
			TriggerScreenBorders trigger = collider.GetComponent<TriggerScreenBorders>();
			Vector2 newPosition = Vector2.zero;

			if (trigger != null)
			{
				if (this.gameObject.CompareTag(Tags.LEFT_BORDER))
				{
					newPosition.x = _oppositeBorder.transform.position.x + _triggerBoxOffset - trigger.ColliderRadius - _epsilonOffset;
					newPosition.y = trigger.ControllerTransform.position.y;
				}
				else if (this.gameObject.CompareTag(Tags.RIGHT_BORDER))
				{
					newPosition.x = _oppositeBorder.transform.position.x + _triggerBoxOffset + trigger.ColliderRadius + _epsilonOffset;
					newPosition.y = trigger.ControllerTransform.position.y;
				}
				else if (this.gameObject.CompareTag(Tags.TOP_BORDER))
				{
					newPosition.x = trigger.ControllerTransform.position.x;
					newPosition.y = _oppositeBorder.transform.position.y + _triggerBoxOffset + trigger.ColliderRadius + _epsilonOffset;
				}
				else if (this.gameObject.CompareTag(Tags.BOTTOM_BORDER))
				{
					newPosition.x = trigger.ControllerTransform.position.x;
					newPosition.y = _oppositeBorder.transform.position.y + _triggerBoxOffset - trigger.ColliderRadius - _epsilonOffset;
				}
					
				trigger.ControllerTransform.position = newPosition;
			}
		}
	}
}

