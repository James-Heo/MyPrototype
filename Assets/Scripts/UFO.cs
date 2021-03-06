﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
	[Header("Set in	Inspector")]
	//	Prefab	for	instantiating	apples
	public GameObject laserPrefab;
	// Start is called before the first frame update
	void Start()
    {
		Invoke("DropLaser", 2f);
    }

	public void LaserDestroyed()
	{
		//	Destroy	all	of	the	falling	lasers
		GameObject[] tLaserArray = GameObject.FindGameObjectsWithTag("Laser"); //	b
		foreach (GameObject tGO in tLaserArray)
		{
			Destroy(tGO);
		}
	}

	void DropLaser()
	{
		GameObject laser = Instantiate<GameObject> (laserPrefab);
		laser.transform.position = transform.position;
		Invoke("DropLaser", 2f);
	}

	// Update is called once per frame
	void Update()
	{
		//	Get	the	current	screen	position	of	the	mouse	from	Input
		Vector3 mousePos2D = Input.mousePosition;//	a//	The	Camera's	z	position	sets	how	far	to	push	the	mouse	into	3D
		mousePos2D.z = -Camera.main.transform.position.z;//	b
														 //	Convert	the	point	from	2D	screen	space	into	3D	game	world	space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		//	Move	the	x	position	of	this	Basket	to	the	x	position	of	the	Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}
}
