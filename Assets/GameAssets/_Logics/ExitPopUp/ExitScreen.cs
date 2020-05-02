using UnityEngine;
using System.Collections;

public class ExitScreen : MonoBehaviour {

	public GameObject ExitScreenCam;

	public static ExitScreen Instance;

	void Awake()
	{
		Instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		//ShowHideExitScreen ();
	}

	public void ShowHideExitScreen()
	{
		if(ExitScreenCam.activeSelf)
		{
			InputManager.EnableInput=true;
			ExitScreenCam.SetActive(false);
		}
		else
		{
			InputManager.EnableInput=false;
			ExitScreenCam.SetActive(true);
		}
	}

	public void ExitScreenAction(string Action)
	{
		if(Action=="Yes")
		{
			Application.Quit();
		}
		ShowHideExitScreen ();
	}

}
