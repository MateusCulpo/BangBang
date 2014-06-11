using UnityEngine;
using System.Collections;

public class InterfaceController : MonoBehaviour
{
	void OnEnable()
	{
		TouchController.onTouchParameterEvent += HandleonTouchParameterEvent;
	}

	void HandleonTouchParameterEvent (RaycastHit obj)
	{
		if(obj.transform.name.Equals("next"))
		{
			Director.loadLevel(LEVEL_SCENE.MENU_ENEMY);
		}
		else if(obj.transform.name.Equals("restart"))
		{
			Director.loadLevel(EnemyStatic.enemyStatic.id);
		}
	}
}
