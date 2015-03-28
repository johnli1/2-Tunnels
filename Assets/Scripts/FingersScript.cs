using UnityEngine;
using System.Collections;

public class FingersScript : MonoBehaviour {

	public bool isTouchingL, isTouchingR;
	private TouchScript touchRef;

	// Use this for initialization
	void Awake()
	{
		touchRef = gameObject.GetComponentInParent<TouchScript>();
	}
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.onTunnelL = true;
		}
		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.onTunnelR = true;
		}
		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.onSecondL = true;
		}
		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.onSecondR = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Tunnels")
		{
			if(touchRef.onSecondL)
				return;

			touchRef.OnTriggerExit2Dchild();
			touchRef.onTunnelL = false;
		}

		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.OnTriggerExit2Dchild();
			touchRef.onTunnelL = false;
		}

		if(other.gameObject.tag == "Tunnels")
		{
			touchRef.OnTriggerExit2Dchild();
			touchRef.onTunnelR = false;
		}
		if(other.gameObject.tag == "Tunnels")
		{
			if(touchRef.onSecondR)
				return;
			
			touchRef.OnTriggerExit2Dchild();
			touchRef.onTunnelR = false;
		}
	}
}
