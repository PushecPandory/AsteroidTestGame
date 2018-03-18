using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Main
{
    /// <summary>
	/// CoreSingleton is a base class for core systems which are managing scenes (should be one per scene) and for MainManager (which is persistent - not destroyed on load).
    /// Provides static accessor "Instance", Init on Awake and Exit on OnDestroy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour, IInit where T : MonoBehaviour, IInit
    {       
        private static T _instance;
        private static object _lock = new object();

        protected Singleton() { } //Protected constructor to ensure it will be a singleton.

        public static T Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
						MakeThisSingletonAndInit();
                    }

                    return _instance;
                }
            }
        }

        private static void MakeThisSingletonAndInit()
        {
            T[] list = FindObjectsOfType(typeof(T)) as T[];

            if (list.Length == 0)
            {
#if UNITY_EDITOR
                Debug.LogWarning(WarningMessage.ThereIsNo<T>());
#endif
            }
            else
            {
                _instance = list[0];
                _instance.Init();
            }
        }

        public virtual void Init()
		{
			//to override
        }

        public virtual void Exit()
        {
			//to override
        }

        protected void Awake()
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            Exit();
            _instance = null;
        }
    }
}
