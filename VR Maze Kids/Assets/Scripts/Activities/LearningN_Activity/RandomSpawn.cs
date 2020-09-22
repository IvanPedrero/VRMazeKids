using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawn : MonoBehaviour
{
    public GameObject apple;
    public GameObject[] appleList;
    public static int nApple;

    // Update is called once per frame
    void Update()
    {
        appleList = GameObject.FindGameObjectsWithTag("apple");
        if(appleList.Length == 0)
        {
            appleSpawn();
        }
        //Debug.Log(nApple);

    }

    public void appleSpawn()
    {
        nApple = Random.Range(0, 21);
        for (int i = 0; i < nApple; i++)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(12.12f, 16.35f), Random.Range(5.38f, 8f), Random.Range(0.5f, 0.5f));
            Instantiate(apple, randomSpawn, transform.rotation);
        }
       
    }
}
