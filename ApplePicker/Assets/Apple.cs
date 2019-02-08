using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //static means only one variable fo all apples
    public static float bottomY = -20f;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y < bottomY)
	    {
	        Destroy(this.gameObject);//if past the bottom destroys apple
	        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
	        apScript.AppleDestroyed();
	    }
	}
}
