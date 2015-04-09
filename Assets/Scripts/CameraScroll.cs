using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour
{
	Hashtable ht = new Hashtable();

	// Jonathan Yaniv: Do we need those two fields?
//	public Transform tunnelL;
//	public Transform tunnelR;

	void Awake()
	{
		ht.Add("y", 15f);
		ht.Add ("speed", 2f); // old speed is 6f
		ht.Add("easetype", "linear");
	}
	void Start()
	{

	}
	void Update()
	{


	}
	public void Stop(){ // this is called when the user has lost
		iTween.Pause();
	}
	public void CameraSroll()
	{
		iTween.MoveBy(gameObject, ht);
		ScoreManager.score = ScoreManager.score + 1; // score is being generated according to screen progress
	}

	public void Restarter()
	{
		Application.LoadLevel(1); // start level 1 all over again
	}
}
