using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformspawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int minimumCount = 3;
    [SerializeField]
    private int maximumCount = 5;
    [SerializeField]
    private GameObject prefab1, prefab2, prefab3;

    public float gold_speed = 0;
    // public Transform target;
    public Transform  SpawnPositionLeft;
    int whatToSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("player");
            Spawn();

        }
    }

    public int MinimumCount
    {
        get { return this.minimumCount; }
        set { this.minimumCount = value; }
    }
    public int MaximumCount
    {
        get { return this.maximumCount; }
        set { this.maximumCount = value; }
    }
    //public GameObject Prefab
    //{
    //    get { return this.prefab; }
    //    set { this.prefab = value; }
    //}

    public void Spawn()
    {

        GameObject gold_clone;
        print("spawn");
        //gold_clone = Instantiate(prefab1,SpawnPositionLeft.transform.position, SpawnPositionLeft.transform.rotation);
        //// gold_clone.GetComponent<Rigidbody2D>().velocity = direction * gold_speed;
        //print(gold_clone.transform.position);
        //print(SpawnPositionLeft.transform.position);


        whatToSpawn = Random.Range(1, 4);
        Debug.Log(whatToSpawn);

        switch(whatToSpawn)
        {
            case 1: gold_clone = Instantiate(prefab1, SpawnPositionLeft.transform.position, SpawnPositionLeft.transform.rotation);
                break;
            case 2:
                gold_clone = Instantiate(prefab2, SpawnPositionLeft.transform.position, SpawnPositionLeft.transform.rotation);
                break;
            case 3:
                gold_clone = Instantiate(prefab3, SpawnPositionLeft.transform.position, SpawnPositionLeft.transform.rotation);
                break;

        }


        //GameObject gold_clone2;
        //Vector2 direction2 = SpawnPositionMid.transform.position - transform.position;
        //gold_clone2 = Instantiate(this.prefab, this.transform.position, SpawnPositionMid.transform.rotation);
        //gold_clone2.GetComponent<Rigidbody2D>().velocity = direction2 * gold_speed;

        //GameObject gold_clone3;
        //Vector2 direction3 = SpawnPositionRight.transform.position - transform.position;
        //gold_clone3 = Instantiate(this.prefab, this.transform.position, SpawnPositionRight.transform.rotation);
        //gold_clone3.GetComponent<Rigidbody2D>().velocity = direction3 * gold_speed;
        //// Randomly pick the count of prefabs to spawn.
        //int count = Random.Range(this.MinimumCount, this.MaximumCount);
        //// Spawn them!
        //for (int i = 0; i < count; ++i)
        //{
        //    GameObject gold_clone;

        //    Vector2 direction = SpawnPositionLeft.transform.position - transform.position;
        //    gold_clone = Instantiate(this.prefab, this.transform.position, Quaternion.identity);

        //    gold_clone.GetComponent<Rigidbody2D>().velocity = direction * gold_speed;

        //    // bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        //}


    }
}