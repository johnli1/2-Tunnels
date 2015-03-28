using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Tunnels") {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy(other.gameObject);
		}
	}
}
