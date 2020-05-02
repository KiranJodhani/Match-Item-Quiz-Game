using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PauseAndGOControler : MonoBehaviour {

	// Use this for initialization
	public Transform[] PauseObjectsIn;
	public Transform[] PauseObjectsTaget;
	public Transform[] PauseObjectsInitial;
	public AnimationCurve InCurve;
	public AnimationCurve OutCurve;
	public	Sequence InSeqP ;

	public GameObject GameSystemGO;
	public GameObject GameSystemPrefab;
	public GameSystem GS;

	public FaceBookSharing FS;
	//public GameObject MoneyMaker;
	void Start () 
	{


		//PauseObjectsIn_M ();
	}
	
	// Update is called once per frame
	void ResumeByEscape()
	{
	PAM.ResumeTheGame ();
	}


	public bool CanGoToHome;
	public void SetHomeOn()
	{
		CanGoToHome = true;

	}
		void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		   {
			if(CanResume)
			{
				DisableCollider();
				PauseObjectsOut_M();
				Invoke("ActivatePlayArea",1f);
				Invoke("ResumeByEscape",1.2f);
				CanResume=false;
			}
			else if(CanGoToHome)
			{
				GameSystemGO=GameObject.Find("GameSystem");
				if(GameSystemGO)
				{
					Destroy(GameSystemGO);
				}
				DisableCollider();
				PauseObjectsOut_M();
				CanGoToHome=false;
				Invoke("GoToSplshScreen",1.2f);

			}

		}
	}
	public bool CanResume=false;


	public	void CanResumeOn()
	{
		Invoke ("CanResumeEnable", 1);

	}

	public void CanHomeOn()
	{
		Invoke ("CanHomeEnable", 1);
	}

	void CanHomeEnable()
	{
	
		CanGoToHome = true;	
	}

	void CanResumeEnable()
	{
		CanResume = true;
	}


public	void PauseObjectsIn_M()
	{
		//MoneyMaker.SendMessage ("CreateFullscreenButtons");
		for (int i = 0; i <PauseObjectsIn.Length; i++) 
		{
			//print("Called");
			InSeqP = new Sequence (new SequenceParms ().Loops (1));
			InSeqP.Append (HOTween.To(PauseObjectsIn[i], 1, new TweenParms ().Prop ("localPosition", PauseObjectsTaget[i].localPosition).Ease (InCurve)));
			InSeqP.Play ();
		}

		Invoke ("EnableCollider", 1);

		//Invoke ("CabGoBackOn", 1);
	}


public	void PauseObjectsOut_M()
	{
		for (int i = 0; i <PauseObjectsIn.Length; i++) 
		{
			//print("Called");
			InSeqP = new Sequence (new SequenceParms ().Loops (1));
			InSeqP.Append (HOTween.To(PauseObjectsIn[i], 1, new TweenParms ().Prop ("localPosition", PauseObjectsInitial[i].localPosition).Ease (OutCurve)));
			InSeqP.Play ();
		}
	}

	public GameObject PlayAreaScreenGO;
	public GameObject PauseScreenGO;
	public GameObject SpashScreenGO;
	public PlayAreaManager PAM;
	public SoundManager SM;
	public	string GlobleAction="";
	public void FromPauseScreen(string Action)
	{
		GlobleAction = Action;
		if(Action=="1Resume")
		{
			DisableCollider();
			PauseObjectsOut_M();
			Invoke("ActivatePlayArea",1.2f);

		}
		else if(Action=="2Reload")
		{

			DisableCollider();
			PauseObjectsOut_M();
			Invoke("ActivatePlayArea",1.2f);
		}
		else if(Action=="3Home")
		{
			DisableCollider();
			PauseObjectsOut_M();
			Invoke("GoToSplshScreen",1.2f);
		}
		else if(Action=="4Sounds")
		{
			if(SM.IsSoundOn)
			{
				SM.OffTheSound();
			}
			else
			{
				SM.OnTheSound();
			}
		}
		else if(Action=="5GameReq")
		{
			//FS.RequestToSelectedFriend();
		}
	}

	
	void EnableCollider()
	{
		for (int i = 0; i <PauseObjectsIn.Length; i++) 
		{
			PauseObjectsIn[i].GetComponent<Collider>().enabled=true;
		}
	}

	void DisableCollider()
	{
		for (int i = 0; i <PauseObjectsIn.Length; i++) 
		{
			PauseObjectsIn[i].GetComponent<Collider>().enabled=false;
		}
	}

	void ActivatePlayArea()
	{

		PlayAreaScreenGO.SetActive (true);
	
		if(GlobleAction=="1Resume")
		{
			PAM.ResumeTheGame ();
		}
		else if(GlobleAction=="2Reload")
		{	
			//GS.InitTheGameSystem();

			GameSystemGO=GameObject.Find("GameSystem");

			if(GameSystemGO)
			{
			Destroy(GameSystemGO);
			}

			GameObject Temp=Instantiate(GameSystemPrefab) as GameObject;
			Temp.name="GameSystem";
			Temp.transform.parent = PlayAreaScreenGO.transform;

			PAM.ReloadTheGame ();
		}
		else if(GlobleAction=="3Home")
		{
			GameSystemGO=GameObject.Find("GameSystem");
			if(GameSystemGO)
			{
				Destroy(GameSystemGO);
			}
			//Destroy(GameSystemGO);
		//	PAM.ResumeTheGame ();
		}
		PauseScreenGO.SetActive (false);
	}
	public int CoinToSave;

	void GoToSplshScreen()
	{
		CoinToSave = PAM.CurrentCoin;
		PlayerPrefs.SetInt("SavedCoin",CoinToSave);
		PlayerPrefs.Save();
		PauseScreenGO.SetActive (false);
		PlayAreaScreenGO.SetActive (false);
		SpashScreenGO.SetActive (true);

	}
}
