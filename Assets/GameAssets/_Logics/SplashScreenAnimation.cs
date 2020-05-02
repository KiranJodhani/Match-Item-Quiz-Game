using UnityEngine;
using System.Collections;
using Holoville.HOTween;
//using AppLift;
public class SplashScreenAnimation : MonoBehaviour {

	// Use this for initialization
	public AnimationCurve InCurve;

	public Transform Player;
	public Transform PlayerT;
	public Transform PlayerT2;
	public Transform PlayerI;
	void Start () 
	{
	//	AppBrain.Init ();
	//	WelComePlayer ();
	}
	void OnEnable()
	{
		WelComePlayer ();
	}
	public void WelComePlayer()
	{
		Sequence WalkSeq = new Sequence (new SequenceParms ().Loops (1));
		WalkSeq.Append(HOTween.To(Player,1, new TweenParms().Prop("localPosition",PlayerT.localPosition).Ease(InCurve)));
		WalkSeq.Append(HOTween.To(Player,1, new TweenParms().Prop("localEulerAngles",PlayerT.localEulerAngles).Ease(InCurve)));
		WalkSeq.Play();
		Invoke ("Animation2", 2.5f);
		PlayTitleAnimation ();
		PlayButtonInAnimation ();
		OffTheCollider ();
	}

public	void ResetPlayerAnimation()
	{
		Player.transform.localPosition = PlayerI.transform.localPosition;
		Player.transform.localEulerAngles = PlayerI.transform.localEulerAngles;
		Player.transform.localScale = PlayerI.transform.localScale;
		Title.transform.localEulerAngles = Vector3.zero;
		RotationSeq.Kill ();
	}
	// Update is called once per frame

	public SoundManager SM;
		bool CanQuite;
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyUp (KeyCode.Escape) && InputManager.EnableInput) 
			{
			ExitScreen.Instance.ShowHideExitScreen();
			}
		}

	void Animation2()
	{
		Sequence WalkSeq = new Sequence (new SequenceParms ().Loops (1));
		WalkSeq.Append(HOTween.To(Player,3, new TweenParms().Prop("localPosition",PlayerT2.localPosition).Ease(InCurve)));
		WalkSeq.Play();

		Sequence ScaleSeq = new Sequence (new SequenceParms ().Loops (1));
		ScaleSeq.Append(HOTween.To(Player,3, new TweenParms().Prop("localScale",PlayerT2.localScale).Ease(InCurve)));
		ScaleSeq.Play();

		Invoke ("PlayIdleAnimation", 3);
	
	}

	void PlayIdleAnimation()
	{
		Player.GetComponent<Animation>().Play("idle_10");
	}

	public Transform[] Buttons;
	public Transform[] ButtonsInitial;
	public Transform[] ButtonTarget;
	public Transform Title;

	public AnimationCurve TitleCurve;
	public AnimationCurve ButtonInCurve;
	public AnimationCurve ButtonOutCurve;
	Sequence RotationSeq ;

	void PlayTitleAnimation()
	{
		 RotationSeq = new Sequence (new SequenceParms ().Loops (-1));
		RotationSeq.Append(HOTween.To(Title,5, new TweenParms().Prop("localEulerAngles",new Vector3(0, 0, 3)).Ease(TitleCurve)));
		RotationSeq.AppendInterval (0);
		RotationSeq.Play();
	}


	public void PlayButtonInAnimation()
	{

		Sequence InSeq = new Sequence (new SequenceParms ().Loops (1));
		InSeq.Append(HOTween.To(Buttons[0],1, new TweenParms().Prop("localPosition",ButtonTarget[0].localPosition).Ease(ButtonInCurve)));
		InSeq.Play();
		Invoke ("PlayButton2Animation", 0.5f);

	}

	public void PlayButton2Animation()
	{
		for (int i = 1; i<3; i++) {
			Sequence InSeq = new Sequence (new SequenceParms ().Loops (1));
			InSeq.Append(HOTween.To(Buttons[i],1, new TweenParms().Prop("localPosition",ButtonTarget[i].localPosition).Ease(ButtonInCurve)));
			InSeq.Play();	
		}
		Invoke ("PlayButton3Animation", 0.5f);
	}

	public void PlayButton3Animation()
	{
		for (int i = 3; i< 5; i++) {
			Sequence InSeq = new Sequence (new SequenceParms ().Loops (1));
			InSeq.Append(HOTween.To(Buttons[i],1, new TweenParms().Prop("localPosition",ButtonTarget[i].localPosition).Ease(ButtonInCurve)));
			InSeq.Play();	

		}

		Invoke ("OnTheCollider", 1f);
	}

public	void OffTheCollider()
	{
		InputManager.EnableInput = false;
		for (int i = 0; i < 5; i++) {
			Buttons[i].GetComponent<Collider>().enabled=false;		
		}
	}

public void OnTheCollider()
	{
		InputManager.EnableInput = true;
		for (int i = 0; i < 5; i++) {
			Buttons[i].GetComponent<Collider>().enabled=true;		
		}
	}


	public void ButtonOuts()
	{

		Sequence OutSeq = new Sequence (new SequenceParms ().Loops (1));
		OutSeq.Append (HOTween.To (Buttons [0], 1, new TweenParms ().Prop ("localPosition", ButtonsInitial [0].localPosition).Ease (ButtonOutCurve)));
		OutSeq.Play();
		Invoke ("PlayButton2OutAnimation", 0.5f);
			
		//}
	}

	void PlayButton2OutAnimation()
	{
		for (int i = 1; i<3; i++) {
			Sequence InSeq = new Sequence (new SequenceParms ().Loops (1));
			InSeq.Append(HOTween.To(Buttons[i],1, new TweenParms().Prop("localPosition",ButtonsInitial[i].localPosition).Ease(ButtonOutCurve)));
			InSeq.Play();	
		}
		Invoke ("PlayButton3OutAnimation", 0.5f);
	}

	public void PlayButton3OutAnimation()
	{
		for (int i = 3; i< 5; i++) {
			Sequence InSeq = new Sequence (new SequenceParms ().Loops (1));
			InSeq.Append(HOTween.To(Buttons[i],1, new TweenParms().Prop("localPosition",ButtonsInitial[i].localPosition).Ease(ButtonOutCurve)));
			InSeq.Play();	
		}

	}


}
