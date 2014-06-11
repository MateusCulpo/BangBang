using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Combat begin.
/// </summary>
public class CombatBegin : MonoBehaviour 
{
	/// <summary>
	/// Occurs when reset settings (all Animations).
	/// </summary>
	public static event Action resetSettings; 

	/// <summary>
	/// The ready prefabs.
	/// </summary>
	public Transform ready;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		CombatScore.countDuelBeginEvent += HandlecountDuelBeginEvent;
	}
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		CombatScore.countDuelBeginEvent -= HandlecountDuelBeginEvent;
	}

	/// <summary>
	/// Handlecounts the duel begin event.
	/// </summary>
	void HandlecountDuelBeginEvent ()
	{
		resetSettings();
		Instantiate(ready, ready.position, ready.rotation);	
	}
}
