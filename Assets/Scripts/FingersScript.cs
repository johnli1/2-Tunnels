using UnityEngine;
using System.Collections;

public class FingersScript : MonoBehaviour {
	private TouchScript touchRef;
	void Start(){

	}
	void update()
	{

	}

}









/*using UnityEngine;
using System.Collections;

public class FingersScript : MonoBehaviour {

	public bool isTouchingL, isTouchingR;
	private TouchScript touchRef;
	private bool leftColliding = true;
	private bool rightColliding = true;
	private bool leftStarted = false;
	private bool rightStarted = false;
	private float currentTime;

	// Use this for initialization
	void Awake()
	{
		touchRef = gameObject.GetComponentInParent<TouchScript>();
	}
	void Start () 
	{
		currentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - currentTime > 0.4f) {
			if (!rightColliding || !leftColliding) {
				touchRef.OnTriggerExit2Dchild ();
				touchRef.onTunnelR = false;			
			}
			currentTime = Time.time;
		}
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("ENTER");

		Debug.Log (other.gameObject.tag);
		if (other.gameObject.CompareTag ("LeftTunnel")) {
			touchRef.onTunnelL = true;
			leftColliding = true;
		}
		if (other.gameObject.CompareTag ("RightTunnel")) {
			touchRef.onTunnelR = true;
			rightColliding = true;
		} 

	}
		/*
	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag("LeftTunnel") || col.gameObject.CompareTag("RightTunnel")){
			isColiding = true;
		}
		isColiding = false;
	}


	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.CompareTag("LeftTunnel")) {
			leftColliding = true;
		}

		if (other.gameObject.CompareTag("RightTunnel")) {
			rightColliding = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("EXIT");
			if (other.gameObject.CompareTag("LeftTunnel")) {
				leftColliding = false;
			}
			
			if (other.gameObject.CompareTag("RightTunnel")) {
				rightColliding = false;
			}
	}
}
*/