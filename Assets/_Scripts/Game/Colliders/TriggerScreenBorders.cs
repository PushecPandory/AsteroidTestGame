﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGame.Main;
using UnityEngine.Assertions;

namespace TestGame
{
	public class TriggerScreenBorders : MonoBehaviour 
	{
		public Transform ControllerTransform { private set; get; }
		public float ColliderRadius { private set; get; }

		public void Init(Transform controllerTransform)
		{
			ControllerTransform = controllerTransform;
			ColliderRadius = this.GetComponent<CircleCollider2D>().radius;
		}
	}
}

