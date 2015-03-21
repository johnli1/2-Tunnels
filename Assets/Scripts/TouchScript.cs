using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour
{
	private GameObject finger1GO, finger2GO;
	private Touch touch1, touch2;
	private CameraScroll scrollRef;

	public bool onTunnelL, onTunnelR;
	public GameObject resetButton;
	public bool onSecondR, onSecondL;

	
	void Start () 
	{
		scrollRef = Camera.main.GetComponent<CameraScroll>();

		finger1GO = GameObject.FindGameObjectWithTag("Finger1");
		finger2GO = GameObject.FindGameObjectWithTag("Finger2");

		finger1GO.SetActive(false);
		finger2GO.SetActive(false);


	}

	void Update ()
	{
		if (onTunnelL && onTunnelR)
		{
		
			scrollRef.CameraSroll();
		}

		int numTouches = Input.touchCount;

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
	public 	void OnTriggerExit2Dchild()
	{
		resetButton.SetActive(true);
	}
}


