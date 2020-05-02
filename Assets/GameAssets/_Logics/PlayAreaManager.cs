using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayAreaManager : MonoBehaviour
{

	
	
	public GameObject PlayAreaGO;
	public GameObject SplashScreenGO;


	public GameObject LifeBar;
	public Vector3 CurrentScale;
	public float XFactor=0.01f;
	public float Speed;	
	public GameObject MainPlayer;
	public int AnimationNo=0;

	
	public GameObject PauseScreen;
	public PauseAndGOControler PAGC;
	public Sequence InSeq;
	public AnimationCurve LifeCurve;
	int counter=0;

	public bool IsActive=false;

	//public GameObject MoneyMaker;
	void OnEnable()
	{
		//ApplovinInit.Instance.ShowFullAd ();
	//	MoneyMaker.SendMessage ("CreateFullscreenButtons");
	}
	// Use this for initialization
	void Start () 
	{
		
		TempSpeed=Speed;
	}

	public GameObject LevelSelectionScreenGO;
	public LevelSelectionManager LSM;
	public void StartTheGame(float RSpeed)
	{
		//GoogleAnalytics.instance.LogScreen ("PlayArea" + RSpeed.ToString ());
		IsActive = true;
		CurrentScale = LifeBar.transform.localScale;
		CurrentScale.y = -0.6f;
		LifeBar.transform.localScale = CurrentScale;
		Speed = RSpeed;

			StartLifeBar ();
			Invoke ("PlayGreet1Animation", 0.01f);
			Invoke ("PlayGreet2Animation", 2);
			Invoke ("PlayIdleAnimation", 4);

		CurrentCoin=PlayerPrefs.GetInt("SavedCoin");
		CoinText.text=CurrentCoin.ToString();
	}
	
	// Update is called once per fra
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			TempAction="Pause";
			GoToPauseScreen(TempAction);
		}
	}
	
	

	
	void GoToSplashScreen()
	{

		IsActive = false;
		PlayAreaGO.SetActive (false);
		SplashScreenGO.SetActive (true);

	}
	
		
	public	float TempSpeed=0;
	public GameObject[] UnCommonButtons;
	public GameObject GameOverLable;
	public TextMesh GameoverTextMesh;
	//public FaceBookSharing FS;
	void GoToPauseScreen(string Action)
	{
		PlayAreaGO.SetActive (false);
		PauseScreen.SetActive (true);
		PAGC.PauseObjectsIn_M ();

		if(Action=="Pause")
		{
			//GoogleAnalytics.instance.LogScreen("PauseScreen");
		TempSpeed = Speed;
		Speed = 0;
	
			UnCommonButtons[0].SetActive(true);
			UnCommonButtons[1].SetActive(true);
			GameOverLable.SetActive(false);
			UnCommonButtons[2].SetActive(false);
			UnCommonButtons[3].SetActive(false);
			UnCommonButtons[4].SetActive(false);
			PAGC.CanResumeOn();
		}
		else if(Action=="Pause")
		{

		}
		else 
		{
			PlayerPrefs.SetInt("SavedCoin",CurrentCoin);
			PlayerPrefs.Save();

			UnCommonButtons[0].SetActive(false);
			UnCommonButtons[1].SetActive(false);
			UnCommonButtons[2].SetActive(true);
			UnCommonButtons[3].SetActive(true);
			UnCommonButtons[4].SetActive(true);
			GameOverLable.SetActive(true);
			GameoverTextMesh.text=CurrentCoin.ToString();
			PAGC.CanHomeOn();
			//GoogleAnalytics.instance.LogScreen("GameOver");
		}
	}

	public void ResumeTheGame()
	{	
		Speed = TempSpeed;
		StartLifeBar ();
		//GoogleAnalytics.instance.LogScreen("PlayArea_Level"+Speed.ToString());
		if(AnimationNo==1 ||AnimationNo==2 || AnimationNo==3)
		{
			PlayGreet1Animation();
		}
//		else if(AnimationNo==2)
//		{
//			PlayGreet2Animation();
//		}
//		else if(AnimationNo==3)
//		{
//			PlayIdleAnimation();
//		}
		else if(AnimationNo==4)
		{
			PlayIdle2Animation();
		}
		else if(AnimationNo==5)
		{
			PlaySit1Animation();
		}
		else if(AnimationNo==6)
		{
			PlaySit2Animation();
		}
		else if(AnimationNo==7)
		{
			PlayWakeUpAnimation();
		}
		else if(AnimationNo==8)
		{
			PlayDieAnimation();
		}
		else if(AnimationNo==9)
		{
			PlayRefuseAnimation();
		}
		else if(AnimationNo==10)
		{
			PlayYesAnimation();
		}

	}

	public void ReloadTheGame ()
	{
		Speed = TempSpeed;
		CurrentScale = LifeBar.transform.localScale;
		CurrentScale.y = -0.6f;
		LifeBar.transform.localScale = CurrentScale;
		StartTheGame (Speed);
		//GoogleAnalytics.instance.LogScreen("PlayArea_Level"+Speed.ToString());
	}


	public void StartLifeBar()
	{

	if(Speed>0)
		{

		if (IsActive == true) 
		{
//				print("sp:"+Speed);
			CurrentScale = LifeBar.transform.localScale;

			

			if (CurrentScale.y < (-XFactor)) 
			{

				CurrentScale.y += XFactor*Speed;
				InSeq = new Sequence (new SequenceParms ().Loops (1));
				InSeq.Append (HOTween.To (LifeBar.transform, 0.9f, new TweenParms ().Prop ("localScale", CurrentScale).Ease (LifeCurve)));
				InSeq.Play ();
				Invoke ("StartLifeBar", 1f);
				
				if (CurrentScale.y > -0.3f) 
				{
					if (AnimationNo != 5) 
					{
						PlaySit1Animation ();
					}
				}
				
				if (CurrentScale.y > -0.2f)
				{
					if (AnimationNo != 6) 
					{
						PlaySit2Animation ();
					}
				}
				
			} 
			else 
			{
				print ("Game Over");
				PlayDieAnimation ();
				string TempAction="GameOver";
				GoToPauseScreen(TempAction);
				//GoogleAnalytics.instance.LogScreen("GameOver");
			}
			
		}

		else 
		{	
			CurrentScale = LifeBar.transform.localScale;
			CurrentScale.y = -0.6f;
			LifeBar.transform.localScale = CurrentScale;
		}
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
		AnimationNo = -1;
		MainPlayer.GetComponent<Animation>().Play("refuse_01");
	}
	
	void PlayYesAnimation()
	{
		AnimationNo = 0;
		MainPlayer.GetComponent<Animation>().Play("nod_01");
	}
public	string TempAction;
	public FaceBookSharing FBS;
	public GameObject FBScreenGO;
	//public TextMesh StatusText;

	float TempSpeed2;
	void GoToFBScreen()
	{
		TempSpeed2=Speed;
		Speed=0;
		FBScreenGO.SetActive (true);

	}

	public void DisableShareScreen()
	{
		Speed = TempSpeed2;
		FBScreenGO.SetActive (false);
		StartLifeBar ();
		if(AnimationNo==1 ||AnimationNo==2 || AnimationNo==3)
		{
			PlayGreet1Animation();
		}
	}
	public void FromPlayArea(string Action)
	{
		 if(Action=="Pause")
		{	
			TempAction="Pause";
			//GoogleAnalytics.instance.LogScreen ("PauseScreen");
			GoToPauseScreen(TempAction);
		} 
		else if(Action=="Share")
		{
			TempAction="Sharing";
			//FBS.TakeCurrentScreenShots();
			Invoke("GoToFBScreen",0.1f);
			//FBS.ShareThisApp();
		}
	}

	public void IncreaseHeath(float Healt_I)
	{
		InSeq.Rewind ();
		CurrentScale = LifeBar.transform.localScale;
		CurrentScale.y -= Healt_I + 0.1f;
		LifeBar.transform.localScale = CurrentScale;

		if (CurrentScale.y < -0.6f) 
		{
			CurrentScale = LifeBar.transform.localScale;
			CurrentScale.y = -0.6f;
			LifeBar.transform.localScale = CurrentScale;
		}


		if(AnimationNo>=5)
		{
			if (CurrentScale.y <= -0.3f) 
			{
				if(AnimationNo!=7)
				{
					PlayWakeUpAnimation();

				}
			}
		}

	}

	public void DecreaseHealth(float Health_D)
	{
		InSeq.Rewind ();
		CurrentScale = LifeBar.transform.localScale;
		CurrentScale.y += Health_D;
		LifeBar.transform.localScale = CurrentScale;
		
		 if(AnimationNo<=4)
		{
			PlayRefuseAnimation();	
		}
		if (CurrentScale.y >0) 
		{
			print ("Game Over");
			PlayDieAnimation ();
			string TempAction="GameOver";
			GoToPauseScreen(TempAction);

		}


	}

	public int CurrentCoin;
	public TextMesh CoinText;

	public void IncreaseCoin(int Coin)
	{
		Coin = Coin * 10;
		CurrentCoin += Coin;
		CoinText.text=CurrentCoin.ToString();

		if(AnimationNo<=4)
		{
			PlayYesAnimation();	
		}
	}
}
