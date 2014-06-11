using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyList : MonoBehaviour
{
	/// <summary>
	/// The list enemy.
	/// </summary>
	public List<Enemy> listEnemy;

	/// <summary>
	/// Creates the list.
	/// </summary>
	public void CreateList()
	{
		List<Enemy> _newList = new List<Enemy>();

		if(SaveSystem.hasObject("Enemy"))
		{
			ArrayList array = (ArrayList)SaveSystem.load("Enemy",  typeof(ArrayList));

			if(array.Count == listEnemy.Count)
			{
				foreach( Enemy enemy in array )
				{
					_newList.Add(enemy);
				}

				for(int i = 0; i < listEnemy.Count; i++)
				{
					listEnemy[i].lose = _newList[i].lose;
					listEnemy[i].stars = _newList[i].stars;
				}
			}
			else
				this.saveEnemys();
		}
		else 
		{
			this.saveEnemys();
		}
	}
	/// <summary>
	/// Saves the enemys.
	/// </summary>
	void saveEnemys()
	{
		ArrayList _list = new ArrayList();
		
		foreach( Enemy enemy in listEnemy)
		{
			_list.Add(enemy);
		}
		
		print(SaveSystem.save("Enemy", _list));
	}
}
