using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{

    public static ObjectPoolingManager instance;

    [SerializeField] public GameObject objectPrefab; //The PREFAB of the thing we need a pool of. Not an Instance from the scene
    public int amount = 10;

    public List<GameObject> objects;

    public void Awake()
    {
        instance = this;

        objects = new List<GameObject>(amount);

        for (int i = 0; i < amount; i++)
        {
            GameObject objectInstance = Instantiate(objectPrefab);
            objectInstance.transform.SetParent(transform);
            objectInstance.SetActive(false);

            objects.Add(objectInstance);
        }
    }

    // Update is called once per frame
    public GameObject GetTheObject()
    {
        foreach (GameObject thing in objects)
        {
            if (!thing.activeInHierarchy)
            {
                thing.SetActive (true);
                return thing;
            }
        }
        GameObject objectInstance = Instantiate(objectPrefab);
        objectInstance.transform.SetParent(transform);
        objects.Add(objectInstance);
        return objectInstance;
    }
}
