using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.GameScene
{
	[CreateAssetMenu(
		menuName = "TestGame/DesignDataGameSettings", 
		fileName = "DesignDataGameSettings_ver_X.asset")]
	public class DesignDataGameSettings : ScriptableObject
	{
		[Header("Player")]
		public float PlayerRotationSpeed = 300;
		public float PlayerMovingAcceleration = 5;
		public float PlayerMaxMovingSpeed = 3;
		public float PlayerLinearDrag = 2f;
		public float ReloadingTime = 0.2f;

		[Header("Bullet")]
		public float BulletLivingTime = 3f;
		public float BulletLinearSpeed = 6f;

		[Header("Asteroid spawner")]
		public float SpawnerRotationSpeed = 30f;
		public float MinTimeToSpawnNextAsteroid = 1f;
		public float MaxTimeToSpawnNextAsteroid = 3f;

		[Header("Asteroid")]
		public float MinLinearSpeed = 1f;
		public float MaxLinearSpeed = 2f;
		public float MinAngularSpeed = 90f;
		public float MaxAngularSpeed = 180f;
		public int SmallerAsteroidsSpawnCount = 2;
		public int ScoreForAsteroid = 10;

		[Header("Lifes on game start")]
		public int LifesOnGameStart = 3;

		[Header("Game flow")]
		public float TimeGapOnGameStart = 2f;
		public float TimeGapBetweenRounds = 2f;
	}
}