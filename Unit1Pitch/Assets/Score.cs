using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
	[Header("Set Dynamically")]
	public GameObject Player;
	public float score;
	public Text text;
    // Start is called before the first frame update
    void Start()
    {
		score = 0;
		GameObject scoreText = GameObject.Find("ScoreCount");
		text = scoreText.GetComponent<Text>();
		text.text = "0";
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = Player.transform.position;
		score = pos.x;
		text.text = "Score: " + score.ToString();
    }
}
