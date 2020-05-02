using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CustomPopUpManager : MonoBehaviour 
{
	public GameObject[] Buttons;

	Sequence PopUpDownSeq;

	public AnimationCurve PopUpCurve;
	public AnimationCurve PopDownCurve;

	public Transform TargetScale;
	public Transform MainPopupWindow;
	public GameObject PopUpCollider;

	public bool CanPopupExit = false;

	//public static bool IsExcecutedOne=false;
	void OffTheButton()
	{
		InputManager.EnableInput = false;
		for(int i = 0 ; i < Buttons.Length;i++)
		{
			Buttons[i].GetComponent<Collider>().enabled=false;
		}
	}


	void OnTheButton()
	{
		InputManager.EnableInput = true;
		for(int i = 0 ; i < Buttons.Length;i++)
		{
			Buttons[i].GetComponent<Collider>().enabled=true;
		}
	}

	void PlayPopUpAnimation()
	{
//		if(!InputManager.EnableInput)
//		{
//			return;
//		}
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


	public void FromPopUpWindow(string Action)
	{
		if(Action=="YesToPopUp")
		{
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.photongames.memorybooster");
		}
		PlayPopDownAnimation ();
		Invoke ("DestroyAfterAnimation", 2);
	}
	// Use this for initialization
	void Start () 
	{
		InputManager.EnableInput = false;
		Invoke ("PlayPopUpAnimation", 1);
	}
	
	void Update()
	{
		if(CanPopupExit)
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				PlayPopDownAnimation ();
				Invoke ("DestroyAfterAnimation", 2);
				CanPopupExit=false;
			}
		}
	}

	void DestroyAfterAnimation()
	{
		InputManager.EnableInput = true;
		Destroy (gameObject);
	}
}
