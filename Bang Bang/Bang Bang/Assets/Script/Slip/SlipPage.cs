using UnityEngine;
using System.Collections;

public class SlipPage : MonoBehaviour
{
	private EnemyList enemyList;

	private int IDList;
	private float distace = 15;
	
	private Transform myTransform;
	private Vector3 lastTransform;
	private float lastTransform_x;
	
	private bool move = false;

	public static int idCharge;
	
	void OnEnable()
	{
		TouchController.leftTouchEvent += HandleleftTouchEvent;
		TouchController.rightTouchEvent += HandlerightTouchEvent;
	}
	
	void OnDisable()
	{
		TouchController.leftTouchEvent -= HandleleftTouchEvent;
		TouchController.rightTouchEvent -= HandlerightTouchEvent;
	}

	void Start()
	{
		this.IDList = 0;

		this.enemyList = GameObject.Find("EnemyList").GetComponent<EnemyList>();

		this.myTransform = transform;

		if ( idCharge <= enemyList.listEnemy.Count )
		{
			this.myTransform.position = new Vector3(idCharge * -distace, this.myTransform.position.y, this.myTransform.position.z);
			this.IDList = idCharge;
		}

		idCharge = 0;
	}
	
	void Update()
	{
		if(this.move)
		{
			if(this.distace > 0)
			{
				if(this.myTransform.position.x > this.lastTransform_x) 
				{
					this.move = false;
					this.myTransform.position = this.lastTransform;
				}
				else
				{
					this.myTransform.position = Vector3.Slerp( new Vector3(this.myTransform.position.x, this.myTransform.position.y, this.myTransform.position.z), 
					                                          new Vector3(this.myTransform.position.x + distace, this.myTransform.position.y, this.myTransform.position.z), 2 * Time.deltaTime);
				}
			}
			else if(this.distace < 0)
			{
				if(this.myTransform.position.x < this.lastTransform_x)
				{
					this.move = false;
					this.myTransform.position = this.lastTransform;
				}
				else
				{
					this.myTransform.position = Vector3.Slerp( new Vector3(this.myTransform.position.x, this.myTransform.position.y, this.myTransform.position.z), 
					                                          new Vector3(this.myTransform.position.x + distace, this.myTransform.position.y, this.myTransform.position.z ), 2 * Time.deltaTime);
				}
			}
		}
	}
	
	void HandlerightTouchEvent ()
	{
		if(!this.move)
		{
			this.IDList--;
			
			if(this.IDList >= 0) 
			{
				this.distace = 15;
				this.lastTransform = this.myTransform.position;
				this.lastTransform = new Vector3( lastTransform.x + distace, lastTransform.y, lastTransform.z );
				this.lastTransform_x = this.myTransform.transform.position.x + distace;
				this.move = true;
			}
			else
			{
				this.IDList = 0;
			}
		}
		
	}
	
	void HandleleftTouchEvent ()
	{
		if(!this.move)
		{
			IDList++;
			
			if(this.IDList < enemyList.listEnemy.Count)
			{
				this.distace = -15;
				this.lastTransform = this.myTransform.position;
				this.lastTransform = new Vector3( lastTransform.x + distace, lastTransform.y, lastTransform.z);
				this.lastTransform_x = this.myTransform.transform.position.x + distace;
				this.move = true;
			}
			else
			{
				this.IDList = this.enemyList.listEnemy.Count - 1;
			}
		}
	}
}
