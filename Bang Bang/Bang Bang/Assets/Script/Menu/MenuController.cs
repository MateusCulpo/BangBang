using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	void OnEnable()
	{
		TouchController.onTouchParameterEvent += HandleonTouchParameterEvent;
	}

	void OnDisable()
	{
		TouchController.onTouchParameterEvent -= HandleonTouchParameterEvent;
	}

	void HandleonTouchParameterEvent (RaycastHit obj)
	{
		if(obj.transform.name.Equals("One Player"))
		{
			Director.loadLevel(GAME_MODE.ONE ,LEVEL_SCENE.MENU_ENEMY);
		}
		else if(obj.transform.name.Equals("Two Player"))
		{
			Director.loadLevel(GAME_MODE.TWO ,LEVEL_SCENE.TWO_PLAYERS);
		}
		else if(obj.transform.name.Equals("Creditos"))
		{
			print("Creditos");
		}
		else if(obj.transform.name.Equals("Gallery"))
        {
			print("Gallery");
		}
	}
}
