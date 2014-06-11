using UnityEngine;
using System.Collections;

public class EarnStars : MonoBehaviour 
{
	public static int getStars( int victoryEnemy)
	{
		if(victoryEnemy == 0)
			return 3;
		else if(victoryEnemy >= 1 && victoryEnemy < 3)
			return 2;
		else
			return 1;
	}
}
