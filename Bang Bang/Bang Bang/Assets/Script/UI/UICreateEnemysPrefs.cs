using UnityEngine;
using System.Collections;

public class UICreateEnemysPrefs : MonoBehaviour 
{
	public GameObject UIPrefabsTableEnemy;

	private EnemyList enemyList;

	void Start()
	{
		this.createWatchList();
	}

	private void createWatchList()
	{
		this.enemyList = GameObject.Find("EnemyList").GetComponent<EnemyList>();
		
		this.enemyList.CreateList();
		
		for(int i = 0; i < enemyList.listEnemy.Count; i++ )
		{
			GameObject _UITableEnemy = Instantiate( UIPrefabsTableEnemy, UIPrefabsTableEnemy.transform.position, UIPrefabsTableEnemy.transform.rotation )  as GameObject;
			
			UIInfoEnemyPrefs _info = _UITableEnemy.GetComponent<UIInfoEnemyPrefs>();

			_info.id = enemyList.listEnemy[i].id;
			_info.name.text = enemyList.listEnemy[i].name.ToString();
			_info.price.text = enemyList.listEnemy[i].value.ToString();
			
			if(enemyList.listEnemy[i].lose) 
			{
				_info.Figure.sprite = enemyList.listEnemy[i].imageUnlocked;
				_info.play.SetActive(true);
			}
			else 
			{
				_info.Figure.sprite = enemyList.listEnemy[i].imageLocked;
				_info.play.SetActive(false);
			}
			
			for(int j = 0; j < enemyList.listEnemy[i].stars; j++)
			{
				_info.Starts[j].sprite = _info.startUnlock;
			}
			
			_UITableEnemy.transform.parent = transform;
			
			_UITableEnemy.transform.localPosition = new Vector3 ( i * 15, _UITableEnemy.transform.localPosition.y, _UITableEnemy.transform.localPosition.z );
		}
	}
}
