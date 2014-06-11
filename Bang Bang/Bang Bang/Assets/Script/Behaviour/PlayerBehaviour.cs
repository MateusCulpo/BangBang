using UnityEngine;
using System.Collections;

public class PlayerBehaviour : GeneralBehaviour 
{
	public SIDE side;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		this.canShoot = true;
		this.victorys = 0;
	}
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	protected override void OnEnable()
	{
		base.OnEnable();
		TouchController.onTouchEvent += HandleonTouchEvent;
	}
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	protected override void OnDisable()
	{
		base.OnDisable();
		TouchController.onTouchEvent -= HandleonTouchEvent;
	}
	/// <summary>
	/// Handleons the touch event.
	/// </summary>
	void HandleonTouchEvent ()
	{
		if(Director.gameMode == GAME_MODE.TWO)
		{
			if(this.canShoot && this.side == TouchController.side)
			{
				startEventShoot();
			}
		}
		else if(Director.gameMode == GAME_MODE.ONE)
		{
			if (this.canShoot)
				startEventShoot();
		}
	}
}
