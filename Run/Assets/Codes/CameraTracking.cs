using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

    public Transform character;
    public float x, y;
    

	// Use this for initialization
	void Start () {
        character = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(character.position.x+x, 0, -10);
		
	}
}
