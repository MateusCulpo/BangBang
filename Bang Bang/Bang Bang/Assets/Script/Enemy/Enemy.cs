using UnityEngine;
using System.Collections;
[System.Serializable]
public class Enemy 
{
	/// <summary>
	/// The identifier.
	/// </summary>
	public int id;
	/// <summary>
	/// The name.
	/// </summary>
	public string name;
	/// <summary>
	/// The value.
	/// </summary>
	public string value;
	/// <summary>
	/// The shoot time.
	/// </summary>
	public float shootTime;
	/// <summary>
	/// The image locked.
	/// </summary>
	public Sprite imageLocked;
	/// <summary>
	/// The image unlocked.
	/// </summary>
	public Sprite imageUnlocked;
	/// <summary>
	/// The objects.
	/// </summary>
	public GameObject objects;

	/// <summary>
	/// The lose.
	/// </summary>
	public bool lose;

	/// <summary>
	/// The stars.
	/// </summary>
	public int stars;


	/// <summary>
	/// Initializes a new instance of the <see cref="Enemy"/> class.
	/// </summary>
	public Enemy()
	{
		this.id = 0;
		this.name = "";
		this.value = "";
		this.shootTime = 0.0f;
		this.imageLocked = null;
		this.imageUnlocked = null;
		this.objects = null;
		this.lose = false;
		this.stars = 0;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Enemy"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="value">Value.</param>
	/// <param name="shootTime">Shoot time.</param>
	/// <param name="imageLocked">Image locked.</param>
	/// <param name="imageUnlocked">Image unlocked.</param>
	/// <param name="objects">Objects.</param>
	/// <param name="lose">If set to <c>true</c> lose.</param>
	/// <param name="stars">Stars.</param>
	public Enemy (string name, string value, float shootTime, Sprite imageLocked, Sprite imageUnlocked, GameObject objects, bool lose, int stars)
	{
		this.name = name;
		this.value = value;
		this.shootTime = shootTime;
		this.imageLocked = imageLocked;
		this.imageUnlocked = imageUnlocked;
		this.objects = objects;
		this.lose = lose;
		this.stars = stars;
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="Enemy"/> class.
	/// </summary>
	/// <param name="lose">If set to <c>true</c> lose.</param>
	/// <param name="stars">Stars.</param>
	public Enemy (bool lose, int stars)
	{
		this.lose = lose;
		this.stars = stars;
	}
}
