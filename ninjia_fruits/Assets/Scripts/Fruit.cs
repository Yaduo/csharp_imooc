using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        CreateSlicedFruit();
    //    }
    //}

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in rbsOnSliced)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        FindObjectOfType<GameManager>().IncreaseScore();

        Destroy(gameObject);
        Destroy(inst.gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if(!b)
        {
            return;
        }

        CreateSlicedFruit();
    }
}
