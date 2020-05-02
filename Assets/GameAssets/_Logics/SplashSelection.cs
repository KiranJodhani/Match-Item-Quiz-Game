using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class SplashSelection : MonoBehaviour {

	public AnimationCurve JellyCurve;
	public Vector3 TargetSccale;
	public float ScaleFactor = 1.5f;
	public splashScreenManager SSM;
	public	Sequence InSeq ;
	public bool IsHome;
	public bool IsLevelButton;
	public GameObject HelpScreenGO;
	public GameObject LevelSelectionGO;
	public SoundManager SM;
	// Use this for initialization

	bool CanBackToHome;
	void Start () 
	{
		TargetSccale = transform.localScale * ScaleFactor;
		CanBackToHome = true;
	}




	void OnMouseDown()
	{

		if(!InputManager.EnableInput)
		{
			return;
		}
		if (gameObject.name == "OK")
		{
						IsHome = true;
		}

		InSeq = new Sequence (new SequenceParms ().Loops (-1));
		InSeq.Append(HOTween.To(transform,1, new TweenParms().Prop("localScale",TargetSccale).Ease(JellyCurve)));
		InSeq.Play();

	}

	void OnMouseUpAsButton()
	{


		if (!InputManager.EnableInput)
		{
			return;
		}
		//print ("Cl");
		SM.PlayClickSound ();
		InSeq.Rewind ();
		SSM.ActionToDo (gameObject.name);

			if (gameObject.name == "OK")
				{		
					IsHome=false;

					HelpScreenGO.SetActive(false);
				}

			
	}

	void OnMouseUp()
	{

		if(!InputManager.EnableInput)
		{
			return;
		}

		IsHome = false;
		InSeq.Rewind ();
	}
}
