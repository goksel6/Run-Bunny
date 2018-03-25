using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public bool active;
    public GameObject[] objects;
	void Start () {
		
	}

	void Update () {
        if (active)
        {
          
            Invoke("Move",5);
            active = false;
        }
	}
    private void Move()
    { 
        transform.position = transform.position + new Vector3(38.636f, 0, 0);
        for (int i = 0; i < 9; i++)
        {
            objects[i].SetActive(true);
        }
    } 
}
