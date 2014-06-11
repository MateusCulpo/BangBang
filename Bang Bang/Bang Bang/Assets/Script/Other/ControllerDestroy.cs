using UnityEngine;
using System.Collections;

public class ControllerDestroy : MonoBehaviour {
	void Update ()
	{
		Destroy( this.gameObject, 0.4f);
	}
}
