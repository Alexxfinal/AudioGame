using UnityEngine;
using System.Collections.Generic;

public class GenericPool : MonoBehaviour {

    public static GenericPool current;
    public GameObject item;
    public bool willGrow = true;

    public int pooledAmount = 20;

    public List<GameObject> objs;


    void Awake()
    {
        current = this;
    }

    void Start()
    {

        objs = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(item);
            obj.transform.parent = transform;
            obj.SetActive(false);
            objs.Add(obj);
        }

    }
	
    public GameObject GetPooledObject()
    {
        //Loop through the list
        for (int i = 0; i < objs.Count; i++)
        {
            //Return an object that is active
            if (!objs[i].activeInHierarchy)
            {
                return objs[i];
            }

        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(item);
            obj.transform.parent = transform;
            objs.Add(obj);
            return obj;
        }
        //If no object available, return NUll
        return null;
    }

}
