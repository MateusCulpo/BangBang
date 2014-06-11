using UnityEngine;
using System.Collections;

public class MenuEnemyController : MonoBehaviour
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
		if(obj.transform.name.Equals("Play"))
		{
			UIInfoEnemyPrefs _UIinfo = obj.transform.parent.GetComponent<UIInfoEnemyPrefs>();

			EnemyList _list = GameObject.Find("EnemyList").GetComponent<EnemyList>();

			foreach( Enemy enemy in _list.listEnemy)
			{
				if(enemy.id == _UIinfo.id)
				{
					EnemyStatic.enemyStatic = enemy;
				}
			}
			Director.loadLevel(_UIinfo.id);
		}
		else if(obj.transform.name.Equals("Home"))
		{
			Director.loadLevel(LEVEL_SCENE.MENU);
		}
	}
}
