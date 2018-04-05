using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D enemyBody;
    public float enemySpeed;
    bool isGround;
    Transform groundCheck;
    const float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool moveRight;

	// Use this for initialization
	void Start () {
        enemyBody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
	}
	
	void Update () {
     
    }
    private void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        enemyBody.velocity = (moveRight) ? new Vector2(-enemySpeed, 0) : new Vector2(enemySpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D theobject)
    {
        if (theobject.gameObject.tag == "Trap")
        {         
            transform.localScale = (moveRight) ? new Vector2(-1, 1) : new Vector2(1, 1);
            moveRight = !moveRight;
        }
    }
}
