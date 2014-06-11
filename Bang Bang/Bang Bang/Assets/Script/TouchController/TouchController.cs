using UnityEngine;
using System.Collections;
using System;

public class TouchController : MonoBehaviour
{
	public static event Action<RaycastHit> onTouchParameterEvent;
	public static event Action onTouchEvent;
	public static event Action leftTouchEvent;
	public static event Action rightTouchEvent;

	private Vector2 positionTouch;

	private int idTouch;

	private float modify = 5.0f;

	public static SIDE side;

	void Update()
	{
		if(Input.touches.Length <= 1)
		{
			foreach (var touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Began)
				{
					this.idTouch = touch.fingerId;
					this.positionTouch = touch.position;

					if(touch.position.x <= Screen.width/2)
						side = SIDE.LEFT;
					else if(touch.position.x > Screen.height/2)
						side = SIDE.RIGHT;

					if(onTouchEvent != null)
						onTouchEvent();
				}

				RaycastHit _hit;
				
				Ray _ray = GameObject.Find("Main Camera").camera.ScreenPointToRay(touch.position);

				if (Physics.Raycast(_ray, out _hit, 100.0f))
				{
					if(touch.phase == TouchPhase.Began)
					{
						if(onTouchParameterEvent != null)
							onTouchParameterEvent(_hit);
					}
				}
	
				if (touch.phase == TouchPhase.Moved)
				{
					if(rightTouchEvent != null & leftTouchEvent != null)
					{
						if(this.idTouch != -1)
						{
							if(touch.position.x > this.positionTouch.x + modify)
							{
								rightTouchEvent();
							}
							if(touch.position.x < this.positionTouch.x - modify)
							{
								leftTouchEvent();
							}

							this.idTouch = -1;
						}
					}
				}
			}
		}
	}
}
