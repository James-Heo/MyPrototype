using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Set in	Inspector")]
    //	Prefab for instantiating pick ups
    public GameObject pickupPrefab;

    //	Speed at which the pickup moves
    public float speed = 1f;

    //	Distance where pickup turns around
    public float leftAndRightEdge = 10f;

    //attempt to make pickup move up and down
    //public float upAndDownEdge = 8f;
    
    //	Chance	that the pickup	will change directions
    public float chanceToChangeDirections = 0.1f;

    //	Rate at which pickups will be instantiated
    public float secondsBetweenPickupSpawns = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void SpawnPickup()
    {                                                                                                                                                                                                       //	b
        GameObject pickup = Instantiate<GameObject>(pickupPrefab);//c
        pickup.transform.position = transform.position;//d
        Invoke("SpawnPickup", secondsBetweenPickupSpawns);//e
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

        //attempted to make it go up and down as well, though only diagnal resulted
        //pos.y += speed * Time.deltaTime;
        //transform.position = pos;

        //if (pos.y < -upAndDownEdge)
        //{
        //    speed = Mathf.Abs(speed);
        //}
        //else if (pos.x > upAndDownEdge)
        //{
        //    speed = -Mathf.Abs(speed);
        //}
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //	Change	direction
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
