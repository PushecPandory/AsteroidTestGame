using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestGame.Main
{
	public class Dispatcher 
	{
		private Dictionary<string, Action<object>> _dict;

		public Dispatcher()
		{
			_dict = new Dictionary<string, Action<object>>();
		}

		public void AddHandler(string actionName, Action<object> action)
		{
			if (_dict.ContainsKey(actionName))
			{
				_dict[actionName] += action;
			}
			else 
			{
				_dict.Add(actionName, action);
			}
		}

		public void RemoveHandler(string actionName, Action<object> action)
		{
			if (_dict.ContainsKey(actionName))
			{
				_dict[actionName] -= action;
			}
		}

		public void Broadcast(string actionName, object obj = null)
		{
			if (_dict.ContainsKey(actionName) && _dict[actionName] != null)
			{
				_dict[actionName](obj);
			}
		}
	}
}

