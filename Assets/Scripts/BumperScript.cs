using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		// considering the location of the bumper, it can only collide with tunnels.
		// so there's no need for logic here.
		Destroy (other.gameObject);
	}
}
