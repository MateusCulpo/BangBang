using System;
using UnityEngine;
using System.Collections;

public class GeneralBehaviour : MonoBehaviour
{
	/// <summary>
	/// Occurs when event shoot.
	/// </summary>
	public static event Action<string> eventShoot; /// Evento para poder atirar

	/// <summary>
	/// The animation.
	/// </summary>
	public AnimationGeneralFighting anim;

	/// <summary>
	/// The victorys.
	/// </summary>
	public int victorys;

	/// <summary>
	/// The can shoot.
	/// </summary>
	protected bool canShoot;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	protected virtual void OnEnable()
	{
		CombatController.blockShootEvent += HandleblockShootEvent;
		CombatBegin.resetSettings += HandleresetSettings;
		AnimationEvents.startDuelEvent += HandlestartDuelEvent;
		AnimationEvents.canShootEvent += HandlecanShootEvent;
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	protected virtual void OnDisable()
	{
		CombatController.blockShootEvent -= HandleblockShootEvent;
		CombatBegin.resetSettings -= HandleresetSettings;
		AnimationEvents.startDuelEvent -= HandlestartDuelEvent;
		AnimationEvents.canShootEvent -= HandlecanShootEvent;
	}

	/// <summary>
	/// Handlecans the shoot event.
	/// </summary>
	void HandlecanShootEvent ()
	{
		this.canShoot = true;
	}

	/// <summary>
	/// Handlestarts the duel event.
	/// </summary>
	/// 
	protected virtual void HandlestartDuelEvent ()
	{
		// implemetation
	}
	/// <summary>
	/// Handleresets the settings.
	/// </summary>
	/// 
	void HandleresetSettings ()
	{
		anim.PlayMainAnimation();
	}

	/// <summary>
	/// Handleblocks the shoot event.
	/// </summary>
	void HandleblockShootEvent ()
	{
		this.canShoot = false;
	}

	/// <summary>
	/// Shoot this instance.
	/// </summary>
	public void shoot()
	{
		anim.PlayWin();
		victorys++;
	}
	/// <summary>
	/// Lose this instance.
	/// </summary>
	public void lose()
	{
		anim.PlayLose();
	}
	/// <summary>
	/// Starts the event shoot.
	/// </summary>
	public void startEventShoot()
	{
		eventShoot(this.gameObject.tag);
	} 

	/// <summary>
	/// Gets or sets a value indicating whether this instance can shoot.
	/// </summary>
	/// <value><c>true</c> if this instance can shoot; otherwise, <c>false</c>.</value>
	public bool CanShoot
	{
		get 
		{
			return this.canShoot;
		}
		set 
		{
			canShoot = value;
		}
	}
}
