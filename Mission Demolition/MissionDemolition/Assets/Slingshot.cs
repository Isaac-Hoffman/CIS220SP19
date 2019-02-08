using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	[Header("Set in Inspector")]
	public GameObject prefabProjectile;
	public float velocityMult = 8f;
	[Header("Set dynamically")]
	public GameObject launchPoint;
	public Vector3 launchPos;
	public GameObject projectile;
	public bool aimingMode;
	private Rigidbody projectileRigidbody;
	void OnMouseEnter()
	{
		print("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}
	void OnMouseExit()
	{
		launchPoint.SetActive(false);
		print("Slingshot:OnMouseExit()");
	}
	void Awake()
	{
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPointTrans.position;
	}//end of awake method
	void OnMouseDown()
	{
		// player has presses mouse button while over the slingshot
		aimingMode = true;
		projectile = Instantiate(prefabProjectile) as GameObject;
		//start it at the launchPoint
		projectile.transform.position = launchPos;
		// set to iskinematic for now
		//projectile.GetComponent<Rigidbody>().isKinematic = true;
		projectileRigidbody = projectile.GetComponent<Rigidbody>();
		projectileRigidbody.isKinematic = true;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//if slingshot is not in aiming mode don't run the code
		if (!aimingMode) return; // bad code
    }
}
