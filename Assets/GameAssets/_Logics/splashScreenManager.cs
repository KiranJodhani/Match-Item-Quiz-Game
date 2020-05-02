using UnityEngine;
using System.Collections;

public class splashScreenManager : MonoBehaviour 
{

	public SplashScreenAnimation SSA;
	public SoundManager SM;
	public GameObject HelpScreenGO;
	public GameObject LevelSelectionGO;
	public LevelMakeOver LMO;

		public GameObject CanvasX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	public MoneyMaker MM;
public	void ActionToDo(string Action)
	{

		if (Action == "1Help")
		{
			SSA.OffTheCollider ();
			SSA.ButtonOuts ();
			Invoke("ActivateHelpScreen",2f);
		}
		else if (Action == "4Sound") 
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
		else if (Action == "0Play")
		{
			SSA.OffTheCollider ();
			SSA.ButtonOuts ();
			RevenueManager.Instance.ShowInterstitialAd ();
			Invoke("ActivateLevelSeleScreen",3f);
		} 
		else if (Action == "2More") 
		{
			Application.OpenURL("https://apps.apple.com/us/developer/kiran-jodhani/id1037477448");
		}
		else if (Action == "3RateUs")
		{
			Application.OpenURL("market://search?q=pub:photongames");
		} 
		else if (Action == "OK") 
		{
			SSA.PlayButtonInAnimation();
		}
	}

	public HelpScreenManager HSM;
	public LevelSelectionManager LSM;

	void ActivateHelpScreen()
	{
				CanvasX.SetActive (true);
		HelpScreenGO.SetActive (true);
		HSM.SetCanBackOn ();
	}

	void ActivateLevelSeleScreen()
	{
		LevelSelectionGO.SetActive (true);
		LSM.SetBackOn ();
	}

	void OnEnable()
	{
		LMO.SetBackGround (0);
	}
}
