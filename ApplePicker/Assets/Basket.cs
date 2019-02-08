using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
	// Use this for initialization
	void Start ()
	{
        // find a reference to ScoreCounter
	    GameObject scoreGO = GameObject.Find("ScoreCounter");
        // get the text component from the GameObject
	    scoreGO = scoreGO.GetComponent<Text>();
        //set starting num of pts to 0
	    scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		//get current screen pos of mouse
	    Vector3 mousePos2D = Input.mousePosition;
	    mousePos2D.z = -Camera.main.transform.position.z;
        //convert point from 2D screen space into 3D game world space
	    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //move x pos of basket to x pos of mouse
	    Vector3 pos = this.transform.position;
	    pos.x = mousePos3D.x;
	    this.transform.position = pos;
	}

    void OnCollisionEnter(Collision coll)
    {
        // find out what hits the basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
            // parse the text of the scoreGT into int
            int score = int.Parse(scoreGT.text);
            //add pts for catching apple
            score += 100;
            // convert score back to string and display it
            scoreGT.text = score.ToString();
        }
    }
}
