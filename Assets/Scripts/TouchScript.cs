using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour
{
	private GameObject finger1GO, finger2GO;
	private Touch touch1, touch2;
	private CameraScroll scrollRef;

	public bool onTunnelL, onTunnelR, gameStarted = false;
	public GameObject resetButton;
	bool gameHasEnded = false;
	
	void Start () 
	{
		scrollRef = Camera.main.GetComponent<CameraScroll>();

		finger1GO = GameObject.FindGameObjectWithTag("Finger1");
		finger2GO = GameObject.FindGameObjectWithTag("Finger2");

		finger1GO.SetActive(false);
		finger2GO.SetActive(false);


	}

	void scorePoints(){
		if (gameStarted){
			if(!gameHasEnded){
				ScoreManager.score = ScoreManager.score + 1; // score is being generated according to screen progress
			}
		}
	}

	void Update ()
	{
		if (onTunnelL && onTunnelR) // Game has started, raise flag and start Scrolling
		{
			scrollRef.ScrollCamera();
			gameStarted = true;
		}

		Cast (); // call the cast function, which checks for fingers colliding with tunnels

		int numTouches = Input.touchCount; // get number of fingers on screen
		scorePoints ();
		if(gameStarted == true){ // if game has started, if you let go of one tunnel game has ended
			if(!onTunnelL || !onTunnelR){
				gameHasEnded = true;
				resetButton.SetActive(true);
				scrollRef.Stop(); //User lost, stop scrolling & scoring


			}
			if(numTouches != 2){ // if game started, and you raise one of your fingers, game ended
				gameHasEnded = true;
				resetButton.SetActive(true);
				scrollRef.Stop();//User lost, stop scrolling & scoring
			}
		}

		if (numTouches == 0)
		{
			finger1GO.SetActive(false);
			finger2GO.SetActive(false);
		}

		if (numTouches > 0)
		{
			for(int i = 0; numTouches > i; i++)
			{

				Touch touch = Input.GetTouch(i);

				if (touch.fingerId == 0)
				{
					Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
					finger1GO.SetActive(true);
					finger1GO.transform.position = touchPos;
				}

				if (touch.fingerId == 1)
				{
					Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
					finger2GO.SetActive(true);
					finger2GO.transform.position = touchPos;
				}

			}
    	 }
	}

	/*
	 *This is a helper function which uses Ray casting to evaluate if user's fingers are on tunnels or not
	 *If user is on tunnel, it should notify and change variable onTunnelX to true. otherwise False.
	 * 
	 */
	void Cast()                                                                                                                                        
	{
		for (int i = 0; i < Input.touchCount; ++i)
		{
			Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
			Vector2 touchPos = new Vector2(test.x, test.y);
			onLeft(touchPos);
			onRight(touchPos);
			//Debug.Log("Position of touch:" + touchPos);
		}
	}
	/*
	 * Helps Cast()
	 * */
	void onLeft(Vector2 touchPos){
		Collider2D tempL;
		if (tempL = Physics2D.OverlapPoint (touchPos)) {
			if(tempL.CompareTag("LeftTunnel")){
			Debug.Log ("Hit Left tunnel");
			onTunnelL = true;
			}
		}
		else{
			onTunnelL = false;
		}
	}
	/*
	 * Helps Cast()
	 * */
	void onRight(Vector2 touchPos){
		Collider2D tempR;
		if (tempR = Physics2D.OverlapPoint (touchPos)) {
			if(tempR.CompareTag("RightTunnel")){
				Debug.Log ("Hit Right tunnel");
				onTunnelR = true;
			}
		}
		else{
			onTunnelR = false;
		}
	}
}


