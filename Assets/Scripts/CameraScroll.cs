using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour
{
	Hashtable ht = new Hashtable();

	void Awake()
	{
		ht.Add("y", 15f);
		ht.Add ("speed", 6f);
		ht.Add("easetype", "linear");
	}
	void Start()
	{

	}
	void Update()
	{


	}
	public void CameraSroll()
	{
		iTween.MoveBy(gameObject, ht);
	}

	public void Restarter()
	{
		Application.LoadLevel(0);
	}
}
