using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //Store all Gameobjects in an array like this
        GameObject[] itemArray = Resources.LoadAll<GameObject>("items");

        GameObject itemToSpawn = itemArray[Random.Range(0, itemArray.Length)];

        GameObject newRoom = Instantiate(itemToSpawn, transform.position + new Vector3(0, 1, 0.5f), Quaternion.identity);
    }
}
