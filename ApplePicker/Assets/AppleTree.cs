using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    //class level variables (inspector variables)
    //prefab for instantiating apples
    public GameObject applePrefab;
    //speed at which the AppleTree moves
    public float speed = 1f;
    //distance where AppleTree turns
    public float leftAndRightEdge = 10f;
    //chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    //reate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;
	// Use this for initialization
	void Start () {
		//dropping apples every second
	    Invoke("DropApple", 2f);
	}

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
	
	// Update is called once per frame
	void Update (){
        //basic movement across screen
	    Vector3 pos = transform.position;   //save current position
	    pos.x += speed * Time.deltaTime;
	    transform.position = pos;

        //changing direction
	    if (pos.x < (-leftAndRightEdge +1))
	    {
	        speed = Mathf.Abs(speed); //move right Abs = absoulut value
	    }
	    else if (pos.x > (leftAndRightEdge - 1))
	    {
	        speed = -Mathf.Abs(speed);
	    }
	}

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
