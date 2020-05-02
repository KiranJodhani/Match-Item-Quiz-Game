using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class ExitPopUpManager : MonoBehaviour {

	public GameObject[] Buttons;
	
	Sequence PopUpDownSeq;
	
	public AnimationCurve PopUpCurve;
	public AnimationCurve PopDownCurve;
	
	public Transform TargetScale;
	public Transform MainPopupWindow;
	public GameObject PopUpCollider;
	
	public bool CanPopupExit = false;
	
	public static bool IsShownOnce=false;

	public static bool canExit=false;
	void OffTheButton()
	{
		for(int i = 0 ; i < Buttons.Length;i++)
		{
			Buttons[i].GetComponent<Collider>().enabled=false;
		}
	}
	
	
	void OnTheButton()
	{
		for(int i = 0 ; i < Buttons.Length;i++)
		{
			Buttons[i].GetComponent<Collider>().enabled=true;
		}
	}
	
public 	void PlayExitPopUpAnimation()
	{
		PopUpCollider.SetActive (true);
		CanPopupExit = true;
		PopUpDownSeq = new Sequence (new SequenceParms ().Loops (1));
		PopUpDownSeq.Append(HOTween.To(MainPopupWindow,0.5f, new TweenParms().Prop("localScale",TargetScale.localScale).Ease(PopUpCurve)));
		PopUpDownSeq.Play();
		Invoke ("OnTheButton", 0.5f);
	}
	
	void PlayPopDownAnimation()
	{
		OffTheButton ();
		PopUpCollider.SetActive (false);
		PopUpDownSeq = new Sequence (new SequenceParms ().Loops (1));
		PopUpDownSeq.Append(HOTween.To(MainPopupWindow,0.5f, new TweenParms().Prop("localScale",Vector3.zero).Ease(PopDownCurve)));
		PopUpDownSeq.Play();
	}
	
	void ExitTheGame()
	{
		Application.Quit();
		print ("Exit");
	}

	public void FromExitPopUp(string Action)
	{
		if(Action=="YesToExit")
		{

			Invoke("ExitTheGame",0.49f);
			//Application.OpenURL("https://play.google.com/store/apps/details?id=com.photongames.matchitem");
		}
		PlayPopDownAnimation ();
	
	}
	// Use this for initialization
	void Start () 
	{
//		if(!IsShownOnce)
//		{
//			Invoke ("PlayPopUpAnimation", 1);
//			IsShownOnce=true;
//		}
	}
	
	void Update()
	{
		//		if(CanPopupExit)
		//		{
		//			if(Input.GetKeyUp(KeyCode.Escape))
		//			{
		//				PlayPopDownAnimation ();
		//				Invoke ("DestroyAfterAnimation", 2);
		//				CanPopupExit=false;
		//			}
		//		}
	}
	

}
