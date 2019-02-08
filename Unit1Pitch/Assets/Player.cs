using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Vector3 jump;
	public float speed = 1f;
	Rigidbody rb;
	public bool ready = false;
	public bool ground;
    // Start is called before the first frame update
    void Start()
    {
		jump = new Vector3(0f, 5f, 0f);//x,y,z jump distance
		rb = GetComponent<Rigidbody>();
    }
	private void OnCollisionEnter(Collision col)//wait for collision with ground
	{
		ground = true;
		speed = 5f;
	}
	// Update is called once per frame
	void Update()
    {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		if (pos.y >= -10)
		{
			if (Input.GetKeyDown(KeyCode.LeftAlt))//wait for l alt to start game
			{
				ready = true;
			}
			if (ready)//ready must be true to start
			{
				transform.position = pos;
				if (Input.GetKeyDown(KeyCode.Space) && ground)//if hit space jump
				{
					speed = 4f;
					rb.AddForce(jump, ForceMode.Impulse);
					ground = false;
				}
			}
		}
		else//if fall off ready is false and game resets
		{
			ready = false;
			pos = new Vector3(-4f, 1f, 0f);
			transform.position = pos;
		}
	}
}