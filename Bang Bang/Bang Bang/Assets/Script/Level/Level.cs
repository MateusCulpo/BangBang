using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
	public static LEVEL_SCENE currentLevel;
	
	public static string LevelScene( LEVEL_SCENE level )
	{

		currentLevel = level;

		switch( currentLevel )
		{
		case LEVEL_SCENE.MENU :
		{
			return "Menu";
			break;
		}
		case LEVEL_SCENE.CREDITS:
		{
			return "Creditos";
			break;
		}
		case LEVEL_SCENE.GALLERY:
		{
			return "Gallery";
			break;
		}
		case LEVEL_SCENE.MENU_ENEMY:
		{
			return "Menu Enemy";
			break;
		}
		case LEVEL_SCENE.TWO_PLAYERS:
		{
			return "Two Players";
			break;
		}
		default :
		{
			return "Menu";
			break;
		}
		}
	}

	public static string LevelScene( int id )
	{
		switch(id)
		{
		case 0:
		{
			return "Enemy1";
			break;
		}
		case 1:
		{
			return "Enemy2";
			break;
		}
		case 2:
		{
			return "Enemy3";
			break;
		}
		case 3:
		{
			return "Enemy4";
			break;
		}
		case 4:
		{
			return "Enemy5";
			break;
		}
		case 5:
		{
			return "Enemy6";
			break;
		}
		case 6:
		{
			return "Enemy7";
			break;
		}
		case 7:
		{
			return "Enemy8";
			break;
		}
		case 8:
		{
			return "Enemy9";
			break;
		}
		case 9:
		{
			return "Enemy10";
			break;
		}
		default :
		{
			return "Menu";
			break;
		}
		}
	}
}
