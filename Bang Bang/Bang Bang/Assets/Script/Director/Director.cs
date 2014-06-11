using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour
{
	public static GAME_MODE gameMode;

	public static void loadLevel( LEVEL_SCENE level)
	{
		Application.LoadLevel(Level.LevelScene(level));
	}
	public static void loadLevel( GAME_MODE game_mode, LEVEL_SCENE level )
	{
		gameMode = game_mode;
		Application.LoadLevel(Level.LevelScene(level));
	}
	public static void loadLevel(int id)
	{
		Application.LoadLevel(Level.LevelScene(id));
	}
}
