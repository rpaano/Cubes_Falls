using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBounds : MonoBehaviour {

    public float min_X = -2.6f, max_X = 2.6f, min_Y = -5.6f, max_Y = 5.6f;
    
    private bool out_Of_Bounds;
	
	// Update is called once per frame
	void Update () {
        CheckBounds();
	}

    void CheckBounds(){

        Vector2 temp = transform.position;
        Console.WriteLine("This is C#");

        //aspect ratio
        if (Camera.main.aspect <= 0.5)
        {
            min_X = -2.1f;
            max_X = 2.1f;
        }
        else if (Camera.main.aspect < 0.6)
        {
            min_X = -2.4f;
            max_X = 2.4f;
        }    
        else
        {
            //Do nothing
        }

        if (temp.x > max_X){

            temp.x = max_X;

        }

        if (temp.x < min_X){

            temp.x = min_X;

        }

        transform.position = temp;

        if (temp.y <= min_Y){

            if (!out_Of_Bounds) {

                out_Of_Bounds = true;

                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D targer){

        if(targer.tag == "TopSpike") {

            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
