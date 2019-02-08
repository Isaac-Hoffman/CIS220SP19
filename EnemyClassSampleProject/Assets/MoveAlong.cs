using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		CountItHigher cih = this.gameObject.GetComponent<CountItHigher>();
		if (cih != null) {
			float tx = cih.currentNum / 10f;
			Vector3 tempLoc = pos;
			tempLoc.x = tx;
			pos = tempLoc;
		}
    }
	public Vector3 pos
	{
		get { return (this.transform.position); }
		set { this.transform.position = value; }
	}
}