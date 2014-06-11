using UnityEngine;
using System.Collections;
using System;

public class CombatScore : MonoBehaviour
{
	/// <summary>
	/// Occurs when count duel begin event. (Start duel again)
	/// </summary>
	public static event Action countDuelBeginEvent;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		TouchController.onTouchParameterEvent += HandleonTouchEvent;
		CombatController.combatScoreEvent += HandlecombatScoreEvent;
	}
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		TouchController.onTouchParameterEvent -= HandleonTouchEvent;
		CombatController.combatScoreEvent -= HandlecombatScoreEvent;
	}
	/// <summary>
	/// Handleons the touch event.
	/// </summary>
	/// <param name="obj">Object.</param>
	void HandleonTouchEvent ( RaycastHit obj )
	{
		// Start again e play Animation
		if( obj.transform.name.Equals("Play(Clone)") || obj.transform.name.Equals("Play") )
		{
			countDuelBeginEvent();
			Destroy(obj.transform.gameObject);
		}
		else if(obj.transform.name.Equals("Home"))
		{
			Director.loadLevel(LEVEL_SCENE.MENU);
		}
	}
	/// <summary>
	/// Handlecombats the score event.(noImplementations)
	/// </summary>
	void HandlecombatScoreEvent ()
	{
		// Play animation e update UI
	}
}
