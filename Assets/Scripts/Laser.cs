using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in	Inspector")]
    public GameObject prefabLaser;

    [Header("Set Dynamically")]
    public Vector3 UFO;
    public GameObject laser;
    private Rigidbody laserRigidbody;
    void OnMouseDown()
    {
        //	Instantiate	a	Projectile
        laser = Instantiate(prefabLaser) as GameObject;
        
        //	Set	it	to	isKinematic	for	now
        laser.GetComponent<Rigidbody>().isKinematic = true;

        laserRigidbody = laser.GetComponent<Rigidbody>();//	a
        laserRigidbody.isKinematic = false;
    }

}
