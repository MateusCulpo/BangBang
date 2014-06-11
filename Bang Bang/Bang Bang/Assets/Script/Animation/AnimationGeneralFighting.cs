using UnityEngine;
using System.Collections;

public class AnimationGeneralFighting : AnimationObject
{
	/// <summary>
	/// Plaies the window.
	/// </summary>
	public void PlayWin()
	{
		Anim.SetInteger("Animator", 1);
	}
	/// <summary>
	/// Plaies the lose.
	/// </summary>
	public void PlayLose()
	{
		Anim.SetInteger("Animator", 2);
	}
	/// <summary>
	/// Plaies the main animation.
	/// </summary>
	public void PlayMainAnimation()
	{
		Anim.SetInteger("Animator", 0);
	}
}
