using UnityEngine;
using System.Collections;

public class AchievementsController : MonoBehaviour
{
	public enum Achievements
	{
		Enemy1 = 0,
		Enemy2 = 1,
		Enemy3 = 2,
		Enemy4 = 3,
		Enemy5 = 4,
		Enemy6 = 5,
		Enemy7 = 6,
		Enemy8 = 7,
		Enemy9 = 8,
		Enemy10 = 9
	}
	/// <summary>
	/// Sets the achievements.
	/// </summary>
	/// <param name="id">Identifier.</param>
	public static void setAchievements(int id)
	{
		SaveSystem.saveInt("achievement", id);
	}
	/// <summary>
	/// Hases the achievements.
	/// </summary>
	/// <returns><c>true</c>, if achievements was hased, <c>false</c> otherwise.</returns>
	public static bool hasAchievements()
	{
		if(SaveSystem.hasObject("achievement"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// Deletes the achievements.
	/// </summary>
	public static void deleteAchievements()
	{
		SaveSystem.deleteObject("achievement");
	}
	/// <summary>
	/// Plaies the achievement.
	/// </summary>
	public static void playAchievement()
	{
		int value = SaveSystem.loadInt("achievement");

		checkAchievement( value );

	}
	/// <summary>
	/// Checks the achievement.
	/// </summary>
	/// <param name="value">Value.</param>
	private static void checkAchievement( int value )
	{
		if(value >= (int)Achievements.Enemy1)
		{

		}
		if(value >=  (int)Achievements.Enemy2)
		{
			
		}
		if(value >=  (int)Achievements.Enemy3)
		{
			
		}
		if(value >=  (int)Achievements.Enemy4)
		{
			
		}
		if(value >=  (int)Achievements.Enemy5)
		{
			
		}
		if(value >=  (int)Achievements.Enemy6)
		{
			
		}
		if(value >=  (int)Achievements.Enemy7)
		{
			
		}
		if(value >=  (int)Achievements.Enemy8)
		{
			
		}
		if(value >=  (int)Achievements.Enemy9)
		{
			
		}
		if(value >=  (int)Achievements.Enemy10)
		{
			
		}
	}
}
