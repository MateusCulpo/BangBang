using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SaveGame : MonoBehaviour 
{
	public static void saveGame( Enemy enemy_value, int stars_value)
	{
		ArrayList array = (ArrayList)SaveSystem.load("Enemy",  typeof(ArrayList));
		List<Enemy> _list = new List<Enemy>();

		foreach( Enemy enemy in array )
		{
			_list.Add(enemy);
		}

		for(int  i = 0; i <_list.Count; i++)
		{
			if(_list[i].id == enemy_value.id)
			{
				if(i < _list.Count)
					_list[i+1].lose = true;

				if(_list[i].stars < stars_value)
					_list[i].stars = stars_value;
			}
		}

		array.Clear();

		array = new ArrayList(_list);

		SaveSystem.save("Enemy", array);
	}

	public static List<Enemy> getListEnemys()
	{
		ArrayList array = (ArrayList)SaveSystem.load("Enemy",  typeof(ArrayList));
		List<Enemy> _list = new List<Enemy>();
		
		foreach( Enemy enemy in array )
		{
			_list.Add(enemy);
		}

		return _list;
	}
}
