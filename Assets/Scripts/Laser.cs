using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	// Start is called before the first frame update
	public static float bottomY = -20f;
	void Update()
	{
		if (transform.position.y < bottomY)
		{
			Destroy(this.gameObject);

			//	Get	a	reference	to	the	ApplePicker	component	of	Main	Camera
			UFO apScript = Camera.main.GetComponent<UFO>();//	b
			 //	Call	the	public	LaserDestroyed()	method	of	apScript
			apScript.LaserDestroyed();
		}
	}

}
