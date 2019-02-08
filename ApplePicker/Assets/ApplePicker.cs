using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]

    public GameObject basketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;
    // Use this for initialization
    void Start ()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AppleDestroyed()
    {
        // destroy all falling apples
        //get index of last basket in basketlist
        int basketIndex = basketList.Count - 1;
        // get reference to that basket gameobject
        GameObject tBasketGO = basketList[basketIndex];
        //remove basket from the list and destroy game object
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
