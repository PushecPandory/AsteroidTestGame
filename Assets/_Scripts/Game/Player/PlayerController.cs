using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace TestGame.GameScene
{
	public class PlayerController : BaseGameSceneController, ITriggerBullets, ITriggerAsteroids
	{
		public enum PlayerState
		{
			Disabled,
			Alive,
			Dying
		}
			
		//==============================================================================
		#region FIELDS_AND_ACCESSORS //=================================================
		//==============================================================================

		[SerializeField]
		private TriggerScreenBorders _triggerScreenBorders;
		[SerializeField]
		private TriggerBullets _triggerBullets;
		[SerializeField]
		private TriggerAsteroids _triggerAsteroids;
		[SerializeField]
		private PlayerView _playerView;

		private PlayerState _currentState;
		private PlayerBehaviourBase _currentBehaviour;
		private PlayerDisabledBehaviour _playerDisabledBehaviour;
		private PlayerAliveBehaviour _playerAliveBehaviour;
		private PlayerDyingBehaviour _playerDyingBehaviour;

		public PlayerInput PlayerInput { private set; get; }
		public Rigidbody2D Rigidbody { private set; get; }
		public PlayerMoving PlayerMoving { private set; get; }
		public PlayerShooting PlayerShooting { private set; get; }
		public PlayerView PlayerView { get { return _playerView; } }

		public PlayerState CurrentState
		{
			set 
			{
				if (_currentBehaviour != null)
				{
					_currentBehaviour.OnExitStateBehaviour();
				}
				_currentState = value;
				_currentBehaviour = AssignProperPlayerBehaviour(_currentState);
				_currentBehaviour.OnEnterStateBehaviour();
			}
			get 
			{
				return _currentState;
			}
		}

		//==============================================================================
		#endregion //===================================================================
		//==============================================================================

		public override void Init(GameSceneManager sceneManager)
		{
			base.Init(sceneManager);
			AssignReferences();
			AssertReferences();
			SetDesignDataSettings();
			InitializeModules();

			CurrentState = PlayerState.Disabled;

			#if UNITY_EDITOR
			Dispatcher.AddHandler(EventNames.UPDATE_PLAYER_DESIGN_DATA, SetDesignDataSettings);
			#endif
		}

		#if UNITY_EDITOR
		protected void OnDestroy()
		{	
			try
			{
				Dispatcher.RemoveHandler(EventNames.UPDATE_PLAYER_DESIGN_DATA, SetDesignDataSettings);
			}
			catch (NullReferenceException ex)
			{
				Debug.Log(Messages.DispatcherWasDestroyedFirst + ex);
			}
		}
		#endif

		protected void Update()
		{
			PlayerInput.UpdateInput();
			_currentBehaviour.OnUpdate(); //FIX!!!
		}

		protected void FixedUpdate()
		{
			_currentBehaviour.OnFixedUpdate();
		}

		public void OnContactWithBullet()
		{
			_currentBehaviour.OnContactWithBullet();
		}

		public void OnContactWithAsteroid()
		{
			_currentBehaviour.OnContactWithBullet();
		}

		//==============================================================================
		#region PRIVATE_METHODS //======================================================
		//==============================================================================

		private void SetRigidbodyDesignSettingsData()
		{
			DesignDataGameSettings data = GameSceneManager.Instance.DesignDataGameSettings;
			Rigidbody.drag = data.PlayerLinearDrag;
		}

		private PlayerBehaviourBase AssignProperPlayerBehaviour(PlayerState currentState)
		{
			PlayerBehaviourBase behaviour;

			if (currentState == PlayerState.Disabled)
			{
				behaviour = _playerDisabledBehaviour;
			}
			else if (currentState == PlayerState.Alive)
			{
				behaviour = _playerAliveBehaviour;
			}
			else if (currentState == PlayerState.Dying)
			{
				behaviour = _playerDyingBehaviour;
			}
			else
			{
				Debug.LogError("Trying to assign invalid state behaviour!");
				behaviour = _playerDisabledBehaviour;
			}

			return behaviour;
		}

		private void AssignReferences()
		{
			Rigidbody = this.GetComponent<Rigidbody2D>();
			PlayerInput = this.GetComponent<PlayerInput>();
			PlayerMoving = this.GetComponent<PlayerMoving>();
			PlayerShooting = this.GetComponent<PlayerShooting>();
			_playerDisabledBehaviour = this.GetComponent<PlayerDisabledBehaviour>();
			_playerAliveBehaviour = this.GetComponent<PlayerAliveBehaviour>();
			_playerDyingBehaviour = this.GetComponent<PlayerDyingBehaviour>();
		}

		private void AssertReferences()
		{
			//From SerializedField
			Assert.IsNotNull<TriggerScreenBorders>(_triggerScreenBorders);
			Assert.IsNotNull<TriggerBullets>(_triggerBullets);
			Assert.IsNotNull<TriggerAsteroids>(_triggerAsteroids);
			Assert.IsNotNull<PlayerView>(PlayerView);

			//From GetComponent<>();
			Assert.IsNotNull<Rigidbody2D>(Rigidbody);
			Assert.IsNotNull<PlayerInput>(PlayerInput);
			Assert.IsNotNull<PlayerMoving>(PlayerMoving);
			Assert.IsNotNull<PlayerShooting>(PlayerShooting);
			Assert.IsNotNull<PlayerDisabledBehaviour>(_playerDisabledBehaviour);
			Assert.IsNotNull<PlayerAliveBehaviour>(_playerAliveBehaviour);
			Assert.IsNotNull<PlayerDyingBehaviour>(_playerDyingBehaviour);
		}

		private void SetDesignDataSettings(object obj = null)
		{
			SetRigidbodyDesignSettingsData();
			PlayerMoving.SetMovingDesignSettingsData();
		}

		private void InitializeModules()
		{
			_triggerScreenBorders.Init(this.transform);
			_triggerBullets.Init(this);
			_triggerAsteroids.Init(this);

			PlayerMoving.Init(this);
			PlayerShooting.Init(this);
			_playerDisabledBehaviour.Init(this);
			_playerAliveBehaviour.Init(this);
			_playerDyingBehaviour.Init(this);
		}

		//==============================================================================
		#endregion //===================================================================
		//==============================================================================
	}
}