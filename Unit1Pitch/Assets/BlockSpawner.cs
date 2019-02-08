using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
	public int newBlock;
	public int i;
	public GameObject LargeBlock;
	public GameObject MediumBlock;
	public GameObject SmallBlock;
	public Vector3 scale;
	public float origin;
	public float nextBlock;
	public Vector3 scalePrev;
	GameObject[] blocks = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
		Vector3 pos = transform.position;
		origin = pos.x;
		scale = transform.localScale;
		scalePrev =  new Vector3 (10f, 0f, 0f);
		nextBlock = origin;
		blocks[0] = LargeBlock;
		blocks[1] = MediumBlock;
		blocks[2] = SmallBlock;
		System.Random num = new System.Random();
		//Was trying to have the scene randomly generate the blocks for the level
		//would add more for loop iterations but unity begins to missplace
		//objects after 5 or 6, rarely from the start it may
		//missplace them. Not sure if the for loop iterates too
		//quickly for unity, but all objects spawn in and 
		//unity consol displays the correct x coordinats, name,
		//and attributes such as scale for the spawned object
		//but then the x position of the object is different than
		//it says it is in the console. The goal was to space 
		//each block 3 units apart in the game which is why
		//origin is the center of the start block (X = 0),
		//scale is the x scale for the current block
		//scalePrev is the scale of the previous block
		//nextBlock is the x coordinate that the new block
		//should be placed at. Outside the loop is only
		//initializing from the start block position
		//and in the for loop uses the previously instantiated block
		//to get the right half of the block (for distance to edge of previous block) 
		//plus 3 (for the space between blocks) and the new block to be instantiated
		//(to get the distance from left edge to center)
		//I have to get these values because unity positions blocks based on 
		//their center, so a block with scale x = 10 at world cooridinate x = 0 will
		//have 5 units on the left (-5 to 0) and 5 on the right (0 to 5), like the start block.
		//taking the x scale of the block and dividing it by 2 gives you the right half of the previous block plus 3
		//spaces between blocks plus the left half of the new block to place their centers with 3 spaces of
		//room between their edges. But the console is still logging the coordinates correctly
		//but unity is not placing the objects on the x coordinate it logs, it is sometimes more or less.
		for (i = 0; i < 11; i++)
		{
			newBlock = num.Next(0, 3);
			Instantiate<GameObject>(blocks[newBlock]);
			scale = blocks[newBlock].transform.localScale;
			nextBlock = nextBlock + ((scale.x / 2) + 3 + (scalePrev.x / 2));
			scalePrev = blocks[newBlock].transform.localScale;
			blocks[newBlock].transform.position = new Vector3(nextBlock, 0f, 0f);
			Debug.Log(scale);
			Debug.Log(scalePrev);
			Debug.Log(blocks[newBlock]);
			Debug.Log(nextBlock);
		}
	}

    // Update is called once per frame
    void Update()
    {
    }
}
