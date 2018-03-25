using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public bool active;
    public GameObject[] objects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            Invoke("Move", 5);
            active = false;
        }
	}
    private void Move()
    {
        //objects[0].transform.localPosition = new Vector2();
        transform.position = transform.position + new Vector3(+92.414f, 0,0);
    } 
}
