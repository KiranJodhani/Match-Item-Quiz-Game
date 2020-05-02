using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayAreaController : MonoBehaviour {

	public	Sequence InSeq2 ;
	public Sequence InSeq;
	public AnimationCurve JellyCurve;
	public Vector3 TargetScale;
	public float ScaleFactor=1.1f;
	

	public GameObject PlayAreaGO;
	public GameObject SplashScreenGO;

	public GameObject LifeBar;
	public Vector3 CurrentScale;
	public float XFactor=0.01f;

	public GameObject MainPlayer;
	public int AnimationNo=0;
	public bool IsActive=false;
	public bool IsPause=false;

	public GameObject PauseScreen;
	public PauseAndGOControler PAGC;
	public PlayAreaManager PAM;
	// Use this for initialization
	void Start () 
	{

		//StartTheGame ();
	}

	public void StartTheGame()
	{
				TargetScale = transform.localScale * ScaleFactor;
				IsActive = true;
				if (gameObject.name == "Pause") 
				{
						StartLifeBar ();
						Invoke ("PlayGreet1Animation", 0.01f);
						Invoke ("PlayGreet2Animation", 2);
						Invoke ("PlayIdleAnimation", 4);
				}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	

	void OnMouseDown()
	{
		InSeq2 = new Sequence (new SequenceParms ().Loops (-1));
		InSeq2.Append(HOTween.To(transform,1, new TweenParms().Prop("localScale",TargetScale).Ease(JellyCurve)));
		InSeq2.Play();	
	}
	
	void OnMouseUp()
	{//print("call");
		InSeq2.Rewind ();
	}
	
	void OnMouseUpAsButton()
	{
		InSeq2.Rewind ();


		if (gameObject.name == "GoHome")
		{
			IsActive = false;
			GoToSplashScreen ();
		}
		else if (gameObject.name == "Pause")
		{

			IsPause=true;
			GoToPauseScreen();
		}
	}

	void GoToSplashScreen()
	{
		PlayAreaGO.SetActive (false);
		SplashScreenGO.SetActive (true);
	}

public	void ResumeTheGame()
	{
		IsPause = false;
	}
	void GoToPauseScreen()
	{
	PlayAreaGO.SetActive (false);
	PauseScreen.SetActive (true);
	PAGC.PauseObjectsIn_M ();
	}
	public AnimationCurve LifeCurve;

	int counter=0;
	public void StartLifeBar()
	{
		if (IsActive == true && IsPause==false) 
		{
						CurrentScale = LifeBar.transform.localScale;
						if (CurrentScale.y < (-XFactor)) {
//								counter++;
//								print ("counter: " + counter);
								CurrentScale.y += XFactor;
								InSeq = new Sequence (new SequenceParms ().Loops (1));
								InSeq.Append (HOTween.To (LifeBar.transform, 0.9f, new TweenParms ().Prop ("localScale", CurrentScale).Ease (LifeCurve)));
								InSeq.Play ();
								Invoke ("StartLifeBar", 1f);

								if (CurrentScale.y > -0.3f) {
										if (AnimationNo != 5) {
												PlaySit1Animation ();
										}
								}

								if (CurrentScale.y > -0.2f) {
										if (AnimationNo != 6) {
												PlaySit2Animation ();
										}
								}




						} 
					else 
					{
					print ("Game Over");
					PlayDieAnimation ();
					}

				}
		else 
				{
			CurrentScale = LifeBar.transform.localScale;
			CurrentScale.y = -0.6f;
			LifeBar.transform.localScale = CurrentScale;
				}
	}

	void PlayGreet1Animation()
	{	
		AnimationNo = 1;
		MainPlayer.GetComponent<Animation>().Play ("greet_00");
	}

	void PlayGreet2Animation()
	{
		AnimationNo = 2;
		MainPlayer.GetComponent<Animation>().Play("greet_01");
	}

	void PlayIdleAnimation()
	{
		AnimationNo = 3;
		MainPlayer.GetComponent<Animation>().Play("idle_00");
	}

	void PlayIdle2Animation()
	{
		AnimationNo = 4;
		MainPlayer.GetComponent<Animation>().Play("embar_00");
	}

	void PlaySit1Animation()
	{
		AnimationNo = 5;
		MainPlayer.GetComponent<Animation>().Play("sit_02");
	}

	void PlaySit2Animation()
	{
		AnimationNo = 6;
		MainPlayer.GetComponent<Animation>().Play("sit_03");
	}

	void PlayWakeUpAnimation()
	{
		AnimationNo = 7;
		MainPlayer.GetComponent<Animation>().Play("crouchup_10");
	}

	void PlayDieAnimation()
	{
		AnimationNo = 8;
		MainPlayer.GetComponent<Animation>().Play("liedown_00");
	}

	void PlayRefuseAnimation()
	{
		AnimationNo = 9;
		MainPlayer.GetComponent<Animation>().Play("refuse_01");
	}

	void PlayYesAnimation()
	{
		AnimationNo = 10;
		MainPlayer.GetComponent<Animation>().Play("nod_01");
	}

}
