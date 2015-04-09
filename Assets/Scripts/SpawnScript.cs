using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// array of tunnel prefabs
	public GameObject[] tunnelCollection;

	private int counter;
	private byte[] spawnOrder;
	private int[] fixedTunnels = new int[] {0,1,0,2,0,3};
	public int i = 0;


	/* IMPORTANT: need to find the right time that corresponds to the camera speed.
	   otherwise evetually there will be TOO MANY clones. */
	// in seconds
	private const float spawnTime = 0.7f;

	// current tunnel height (this will vary in the future)
	public float tunnelHeight = 5f; // was 5.64 - changed for fixing other bug

	// this is the coordinate for the next instantiation
	private Vector3 positionForNextRightTunnel;
	private Vector3 positionForNextLeftTunnel;

	// delta from the screen's center X
	private const float delta = 1.65f;

	// Use this for initialization
	void Start () {
		counter = 0;
		//spawnOrder = FileReader.readFile ();
		//spawnOrder = new int[] {0, 0, 0, 0};
		positionForNextRightTunnel = new Vector3 (transform.position.x + delta, transform.position.y);
		positionForNextLeftTunnel = new Vector3 (transform.position.x - delta, transform.position.y);

		Spawn ();
	}


	/*
	 * Jonathan Yaniv:
	 * 
	 * I have set the spawner prefab to be a child of the camera, and added a field 
	 * for each side (left / right) for the position of the next tunnel.
	 * This way we just increase the Y of each of these fields by the Height of 
	 * the previous tunnel.
	 * 
	 * This allows us to add different sized tunnels for eac side seperately, and avoids 
	 * integers overflows.
	 * 
	 */
	void Spawn(){
		// Instantiate both left and right tunnels.
		GameObject chosenTunnel = getNextTunnel ();
		chosenTunnel.tag = "LeftTunnel";
		Instantiate (chosenTunnel, positionForNextLeftTunnel, Quaternion.identity);
		chosenTunnel.tag = "RightTunnel";
		//flipOnYAxis (chosenTunnel);
		Instantiate (chosenTunnel, positionForNextRightTunnel, Quaternion.identity);
		chosenTunnel.tag = "RightTunnel";
		// Update the next position
		positionForNextLeftTunnel.y += tunnelHeight;
		positionForNextRightTunnel.y += tunnelHeight;

		// respawn in spawnTime seconds
		Invoke ("Spawn", spawnTime);
	}

	/*
	 * Here will be the logic of choosing the next tunnel.
	 * We only need to write it under this function without changing the rest of the code.
	 * 
	 * Currently it's random.
	 */
	GameObject getNextTunnel() {
		// random way
		//return tunnelCollection[Random.Range(0, tunnelCollection.Length)];

		// by the file
		//return tunnelCollection[(byte)(spawnOrder [counter++] - '0')];

		//fixed internally
		if(i < fixedTunnels.Length){
		return tunnelCollection [fixedTunnels[i++]];
		}
		i = 0;
		return tunnelCollection [fixedTunnels[i]];
	}
	
	void flipOnYAxis(GameObject tunnel) {
		Vector3 temp = tunnel.transform.localScale;
		temp.x = 1;
		temp.y *= -1;
		temp.z = 1;
		tunnel.transform.localScale = temp;
	}

	void flipOnXAxis(GameObject tunnel) {
		Vector3 temp = tunnel.transform.localScale;
		temp.x *= -1;
		temp.y = 1;
		temp.z = 1;
		tunnel.transform.localScale = temp;
	}

	void resetScale(GameObject tunnel) {
		Vector3 temp = tunnel.transform.localScale;
		temp.x = 1;
		temp.y = 1;
		temp.z = 1;
		tunnel.transform.localScale = temp;
	}
}