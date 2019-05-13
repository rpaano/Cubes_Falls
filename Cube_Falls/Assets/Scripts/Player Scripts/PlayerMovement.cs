using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myBody;

    public float moveSpeed = 2f;


	// Use this for initialization
	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move(){

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPosition.x > 0)
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }

            if (touchPosition.x < 0)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }
        }
            
    }

    public void PlatformMove(float x){
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
