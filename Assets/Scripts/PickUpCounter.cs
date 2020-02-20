using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCounter : MonoBehaviour
{
	[Header("Set in	Inspector")]
	public GameObject pickupPrefab;
	public int numPickups;
	public List<GameObject> pickupList;

	void Start()
	{
		//pickupList = new List<GameObject>();

		//for (int i = 0; i < numPickups; i--)
		//{
		//	GameObject tPickupGO = Instantiate<GameObject>(pickupPrefab);
		//	Vector3 pos = Vector3.zero;
		//	tPickupGO.transform.position = pos;
		//	pickupList.Add(tPickupGO);
		//}
	}


	public void PickUpDestroyed() 
	{ 
	int pickupIndex = pickupList.Count - 1;
	//	Get	a	reference	to	that pick up GameObject
	GameObject tPickupGO = pickupList[pickupIndex];
	//	Remove	the	pickup	from	the	list	and	destroy	the	GameObject
	pickupList.RemoveAt(pickupIndex);
		Destroy(tPickupGO);

		//	If	there	are	no more pick ups, the goal should become active
		if (pickupList.Count == 0)
		{
			this.gameObject.SetActive(true);
		}
	}

	
	// Update is called once per frame
	void Update()
    {
        
    }
}
