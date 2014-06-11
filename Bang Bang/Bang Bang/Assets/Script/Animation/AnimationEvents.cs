using UnityEngine;
using System;
using System.Collections;

public class AnimationEvents : MonoBehaviour
{
	/// <summary>
	/// Occurs when start duel event.
	/// </summary>
	public static event Action startDuelEvent; 
	/// <summary>
	/// Occurs when can shoot event.
	/// </summary>
	public static event Action canShootEvent; 

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		CombatController.stopThreadsEvent += HandlestopThreadsEvent;
	}
	/// <summary>
	/// Handlestops the threads event.
	/// </summary>
	void HandlestopThreadsEvent ()
	{
		this.StopAllCoroutines();
	}
	/// <summary>
	/// Counts the time.
	/// </summary>
	/// <returns>The time.</returns>
	IEnumerator countTime()
	{
		canShootEvent();

		yield return new WaitForSeconds(UnityEngine.Random.Range(0, 6));

		startDuelEvent();

		Destroy(this.gameObject);
	}
}
