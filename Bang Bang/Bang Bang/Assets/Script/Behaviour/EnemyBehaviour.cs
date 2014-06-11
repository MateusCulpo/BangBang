using UnityEngine;
using System.Collections;

public class EnemyBehaviour : GeneralBehaviour
{
	/// <summary>
	/// The enemy.
	/// </summary>
	public Enemy enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		this.enemy = new Enemy(EnemyStatic.enemyStatic.name, EnemyStatic.enemyStatic.value, EnemyStatic.enemyStatic.shootTime, 
		                       EnemyStatic.enemyStatic.imageLocked, EnemyStatic.enemyStatic.imageUnlocked,
		                       EnemyStatic.enemyStatic.objects, EnemyStatic.enemyStatic.lose, EnemyStatic.enemyStatic.stars);

		this.canShoot = true;
		this.victorys = 0;
	}
	/// <summary>
	/// Handlestarts the duel event.
	/// </summary>
	protected override void HandlestartDuelEvent ()
	{
		StartCoroutine( startTimeShoot ( enemy.shootTime ) );
	}
	/// <summary>
	/// Starts the time shoot.
	/// </summary>
	/// <returns>The time shoot.</returns>
	/// <param name="time">Time.</param>
	IEnumerator startTimeShoot( float time)
	{
		yield return new WaitForSeconds( time );
		startEventShoot();
	}
}
