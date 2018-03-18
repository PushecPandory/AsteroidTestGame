using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Main
{
	public static class EventNames
	{
		public const string CHANGE_SCENE_TO_MENU = "CHANGE_SCENE_TO_MENU";
		public const string CHANGE_SCENE_TO_GAME = "CHANGE_SCENE_TO_GAME";
	}
}

namespace TestGame.MenuScene
{
	public static class EventNames
	{
		public const string CHANGE_SCENE_TO_MENU = "CHANGE_SCENE_TO_MENU";
		public const string CHANGE_SCENE_TO_GAME = "CHANGE_SCENE_TO_GAME";
	}
}

namespace TestGame.GameScene
{
	public static class EventNames
	{
		public const string ADD_SCORE = "ADD_SCORE";
		public const string UPDATE_SCORE_IN_UI = "UPDATE_SCORE_IN_UI";
		public const string LOSE_LIFE = "LOSE_LIFE";
		public const string UPDATE_LIFES_IN_UI = "UPDATE_LIFES_IN_UI";
		public const string KILL_PLAYER = "KILL_PLAYER";
		public const string START_NEW_ROUND = "START_NEW_ROUND";
		public const string PLAYER_WAS_KILLED = "PLAYER_WAS_KILLED";
		public const string PLAYER_LIFES_COUNT_AFTER_DEATH = "PLAYER_LIFES_COUNT_AFTER_DEATH";
		public const string ENABLE_SUMMARY_PANEL = "ENABLE_SUMMARY_PANEL";
		public const string SUM_UP_SCORE = "SUM_UP_SCORE";
		public const string UPDATE_SCORES_IN_SUMMARY_PANEL = "UPDATE_SCORES_IN_SUMMARY_PANEL";

		public const string SPAWN_BULLET = "SPAWN_BULLET";
		public const string SPAWN_BIG_ASTEROID = "SPAWN_BIG_ASTEROID";
		public const string SPAWN_MEDIUM_ASTEROID = "SPAWN_MEDIUM_ASTEROID";
		public const string SPAWN_SMALL_ASTEROID = "SPAWN_SMALL_ASTEROID";
		public const string DISABLE_ACTIVE_BULLETS = "DISABLE_ACTIVE_BULLETS";
		public const string DISABLE_ACTIVE_ASTEROIDS = "DISABLE_ACTIVE_ASTEROIDS";
		public const string STOP_SPAWNING_ASTEROIDS = "STOP_SPAWNING_ASTEROIDS";

		public const string UPDATE_PLAYER_DESIGN_DATA = "UPDATE_PLAYER_DESIGN_DATA";
		public const string UPDATE_BULLETS_DESIGN_DATA = "UPDATE_BULLETS_DESIGN_DATA";
		public const string UPDATE_ASTEROIDS_DESIGN_DATA = "UPDATE_ASTEROIDS_DESIGN_DATA";

		public const string DESTROY_SHIP_SOUND = "DESTROY_SHIP_SOUND";
		public const string RESPAWN_SHIP_SOUND = "RESPAWN_SHIP_SOUND";
		public const string SHOOT_SOUND = "SHOOT_SOUND";
		public const string DESTROY_ASTEROID_SOUND = "DESTROY_ASTEROID_SOUND";
	}	
}