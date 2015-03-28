using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnTime = 1f;
	public float heightdiff = 5.64f;
	private int i = 0;
	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	void Spawn(){
		Instantiate (obj [Random.Range (0, obj.Length)], new Vector3(transform.position.x,transform.position.y + i*heightdiff,transform.position.z), Quaternion.identity);
		i++;
		Invoke ("Spawn", spawnTime);
	}
}
