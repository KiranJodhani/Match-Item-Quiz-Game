using UnityEngine;
using System.Collections;

public class PlayerAnimationControler : MonoBehaviour {

	// Use this for initialization
	public GameObject MainPlayer;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			MainPlayer.GetComponent<Animation>().Play("idle_00");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			MainPlayer.GetComponent<Animation>().Play("greet_00");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			MainPlayer.GetComponent<Animation>().Play("greet_01");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
		{
			MainPlayer.GetComponent<Animation>().Play("embar_00");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5))
		{
			MainPlayer.GetComponent<Animation>().Play("sit_02");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6))
		{
			MainPlayer.GetComponent<Animation>().Play("sit_03");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7))
		{
			MainPlayer.GetComponent<Animation>().Play("nod_01");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8))
		{
			MainPlayer.GetComponent<Animation>().Play("refuse_01");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9))
		{
			MainPlayer.GetComponent<Animation>().Play("liedown_00");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha0))
		{
			MainPlayer.GetComponent<Animation>().Play("crouchup_10");
		
		}

	}

	public void PlayIdleAnimation()
	{

	}
}
