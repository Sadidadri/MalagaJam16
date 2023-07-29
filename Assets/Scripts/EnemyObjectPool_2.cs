using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool2 : MonoBehaviour
{
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private LevelingSystem levelingSystem;

    public static EnemyObjectPool2 SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

void Awake()
{
    SharedInstance = this;
}

void Start()
{
    pooledObjects = new List<GameObject>();
    GameObject tmp;
    for(int i = 0; i < amountToPool; i++)
    {
        tmp = Instantiate(objectToPool);
        tmp.GetComponent<EnemyScript>().scoreUI = scoreUI;
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
    }
}

public GameObject GetPooledObject()
{
    for(int i = 0; i < amountToPool; i++)
    {
        if(!pooledObjects[i].activeInHierarchy)
        {
            return pooledObjects[i];
        }
    }
    return null;
}
}
