/// <summary>
/// Name: CombatController
/// 
/// Desc:
/// Responsavel pelo controle do combate entre os adversarios, tem o objetivo de ter o controle de ambos os jogadores e disparar os eventos,
/// tambem criar os prefabs existente durante a scena de jogo
/// 		    
///
/// 
/// Date:12/05/2014
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using System;

public class CombatController : MonoBehaviour 
{
	/// <summary>
	/// Occurs when combatscoreevent, Event start begin combatScore
	/// </summary>
	public static event Action combatScoreEvent;
	/// <summary>
	/// Occurs when block shoot event, Block shoot player and Enemy
	/// </summary>
	public static event Action blockShootEvent; 
	/// <summary>
	/// Occurs when stop threads event, Stop all Coroutine running
	/// </summary>
	public static event Action stopThreadsEvent;

	/// <summary>
	/// GameObject playerOne and PlayerTwo
	/// </summary>
	public static GameObject 	playerOne,
								playerTwo;

	/// <summary>
	/// bang = prefabs start the duel
	/// combatScore = prefabs score game
	/// win = prefab of victory
	/// lose = the loser prefabs
	/// </summary>
	public Transform bang;
	public Transform combatscore;
	public Transform win;
	public Transform lose;

	/// <summary>
	/// The shooter: control shot event
	/// </summary>
	private bool shooter = false;
	/// <summary>
	/// Helps control with touch events
	/// </summary>
	private bool onShot = false;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		GeneralBehaviour.eventShoot += HandleeventShoot;
		AnimationEvents.startDuelEvent += HandlestartDuelEvent;
		AnimationEvents.canShootEvent += HandlecanShootEvent;
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		GeneralBehaviour.eventShoot -= HandleeventShoot;
		AnimationEvents.startDuelEvent -= HandlestartDuelEvent;
		AnimationEvents.canShootEvent -= HandlecanShootEvent;
	}
	/// <summary>
	/// can the shoot event.
	/// </summary>
	void HandlecanShootEvent ()
	{
		this.onShot = true;
	}
	/// <summary>
	/// starts the duel event.
	/// </summary>
	void HandlestartDuelEvent ()
	{
		this.shooter = true;

		Instantiate ( bang , bang.position, bang.rotation );
	}
	/// <summary>
	/// events the shoot.
	/// </summary>
	/// <param name="obj">Object.</param>
	void HandleeventShoot (string obj)
	{
		playerOne = GameObject.FindWithTag("PlayerOne");
		playerTwo = GameObject.FindWithTag("PlayerTwo");

		GeneralBehaviour _one = playerOne.GetComponent<GeneralBehaviour>();
		GeneralBehaviour _two = playerTwo.GetComponent<GeneralBehaviour>();

		if(this.onShot)
		{
			if(this.shooter)
			{
				this.shooter = false;

				if( obj == "PlayerOne")
				{
					_one.shoot();
					_two.lose();
					blockShootEvent();
				}
				else if (obj == "PlayerTwo")
				{
					_one.lose();
					_two.shoot();
					blockShootEvent();
				}

				this.checkVictorys(_one, _two);
			}
			else 
			{
				if(Director.gameMode == GAME_MODE.ONE)
				{
					if( obj.Equals("PlayerOne"))
						_one.CanShoot = false;
					else if (obj.Equals("playerTwo"))
						_two.CanShoot = false;
				}
				else 
				{
					stopThreadsEvent();

					this.shooter = false;

					if( obj == "PlayerOne")
					{
						_one.lose();
						_two.shoot();
						blockShootEvent();
					}
					else if (obj == "PlayerTwo")
					{
						_one.shoot();
						_two.lose();
						blockShootEvent();
					}

					this.checkVictorys(_one, _two);
				}
			}
		}
	}
	/// <summary>
	/// Checks the victorys.
	/// </summary>
	/// <param name="_one">_one.</param>
	/// <param name="_two">_two.</param>
	void checkVictorys(GeneralBehaviour _one, GeneralBehaviour _two)
	{
		if(_one.victorys < 5 && _two.victorys < 5)
		{
			StartCoroutine(wait(2, combatscore));
		}
		else
		{
			if(Director.gameMode == GAME_MODE.ONE)
			{
				if(_one.victorys >= 5)
				{
					SaveGame.saveGame(EnemyStatic.enemyStatic, EarnStars.getStars(_two.victorys));
					SlipPage.idCharge = EnemyStatic.enemyStatic.id + 1;
					StartCoroutine(wait(1, win));
				}
				else 
				{
					SlipPage.idCharge = EnemyStatic.enemyStatic.id;
					StartCoroutine(wait(1, lose));
				}
			}
			else
			{
				StartCoroutine(wait(1, win));
			}
		}
		this.onShot = false;
	}
	/// <summary>
	/// Wait the specified time and obj.
	/// </summary>
	/// <param name="time">Time.</param>
	/// <param name="obj">Object.</param>
	IEnumerator wait (float time, Transform obj)
	{
		yield return new WaitForSeconds( time );
		Instantiate(obj, obj.position, obj.rotation);
	}
}
