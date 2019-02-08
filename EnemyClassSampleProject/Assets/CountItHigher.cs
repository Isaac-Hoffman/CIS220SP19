using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItHigher : MonoBehaviour
{
	private int _num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		print(nextNum);
    }
	public int nextNum
	{
		get {
			_num++; //increase num by 1
			return (_num); // return new value of num
		}
	}
	public int currentNum {
		get { return (_num); }
		set { _num = value; }
	}
}