using UnityEngine;
using System.Collections;

public class AnimationObject : MonoBehaviour {
	/// <summary>
	/// The animation.
	/// </summary>
	private Animator anim;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	/// <summary>
	/// Gets or sets the animation.
	/// </summary>
	/// <value>The animation.</value>
	public Animator Anim {
		get {
			return this.anim;
		}
		set {
			anim = value;
		}
	}

}
