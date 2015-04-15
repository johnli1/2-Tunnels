using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// array of tunnel prefabs
	public GameObject[] tunnelCollectionL;
	public GameObject[] tunnelCollectionR;
	public GameObject Background;

	private int counter;
	private byte[] spawnOrder;
	private int[] fixedTunnelsL = new int[] {0,1,0,2,0,3};
	private int[] fixedTunnelsR = new int[] {0,1,0,2,0,3};
	public int i = 0;
	public int k = 0;
	public int j = 0;

	/* IMPORTANT: need to find the right time that corresponds to the camera speed.
	   otherwise evetually there will be TOO MANY clones. */
	// in seconds
	private const float spawnTime = 1f;

	// current tunnel height (this will vary in the future)
	public float tunnelHeight = 7f; // was 5.64 - changed for fixing other bug

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
		GameObject chosenTunnelL = getNextTunnelL ();
		GameObject chosenTunnelR = getNextTunnelR ();
		chosenTunnelL.tag = "LeftTunnel";
		Instantiate (chosenTunnelL, positionForNextLeftTunnel, Quaternion.identity);
		chosenTunnelR.tag = "RightTunnel";
		//flipOnYAxis (chosenTunnel);
		Instantiate (chosenTunnelR, positionForNextRightTunnel, Quaternion.identity);
		chosenTunnelR.tag = "RightTunnel";
		// Update the next position
		positionForNextLeftTunnel.y += tunnelHeight + 2.8f;
		positionForNextRightTunnel.y += tunnelHeight + 2.8f;
		Instantiate (Background, new Vector3 (0, j * 11, 0), Quaternion.identity);
		j++;
		// respawn in spawnTime seconds
		Invoke ("Spawn", spawnTime);
	}

	/*
	 * Here will be the logic of choosing the next tunnel.
	 * We only need to write it under this function without changing the rest of the code.
	 * 
	 * Currently it's random.
	 */
	GameObject getNextTunnelL() {
		// random way
		//return tunnelCollection[Random.Range(0, tunnelCollection.Length)];

		// by the file
		//return tunnelCollection[(byte)(spawnOrder [counter++] - '0')];

		//fixed internally
		if(i < fixedTunnelsL.Length){
		return tunnelCollectionL [fixedTunnelsL[i++]];
		}
		i = 0;
		return tunnelCollectionL [fixedTunnelsL[i]];
	}
	GameObject getNextTunnelR() {
		// random way
		//return tunnelCollection[Random.Range(0, tunnelCollection.Length)];
		
		// by the file
		//return tunnelCollection[(byte)(spawnOrder [counter++] - '0')];
		
		//fixed internally
		if(k < fixedTunnelsR.Length){
			return tunnelCollectionR [fixedTunnelsR[k++]];
		}
		k = 0;
		return tunnelCollectionR [fixedTunnelsR[k]];
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