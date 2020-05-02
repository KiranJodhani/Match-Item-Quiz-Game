using UnityEngine;
using System.Collections;

public class LevelSelectionManager : MonoBehaviour {

	// Use this for initialization
	public GameObject PlayAreaGO;
	public GameObject LevelSelectionGO;
	public GameObject SplashScreenGO;
	public SplashScreenAnimation SSA;

	public float[] LevelAngles;
	public GameObject LevelsParent;
	public float AngleFactor=2;
	public  LevelManagement LM;

	public LevelMakeOver  LMO;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	public bool canGoBack=false;
	public void SetBackOn()
	{
		canGoBack = true;

	}
	                   
	void Update () 
	{
	if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(canGoBack)
			{
				OffTheLevelCollider ();
				SplashScreenGO.SetActive (true);
				gameObject.SetActive (false);
				SSA.PlayButtonInAnimation ();
				canGoBack=false;
			}
		}
	}

	void OnEnable()
	{
				ActionFromLevelSelection ("Start");
		//OnTheLevelCollider ();
		//Level checking here
		}


	public void ActionFromLevelSelection(string Action)
	{
		if (Action == "Start") 
		{
		//	OffTheLevelCollider();
			SSA.ResetPlayerAnimation();
			OnPlayButtonClicked ();

		}
		else if (Action == "Home") 
		{
		OffTheLevelCollider ();
		SplashScreenGO.SetActive (true);
		gameObject.SetActive (false);
		SSA.PlayButtonInAnimation ();
			//GoogleAnalytics.instance.LogScreen("SplashScreen");
		}
		else if (Action == "UnLock2") 
		{
			LM.UnlockLevel2();
		}
		else if (Action == "UnLock3") 
		{
			LM.UnlockLevel3();
		}
		else if (Action == "UnLock4") 
		{
			LM.UnlockLevel4();
		}
		else if (Action == "UnLock5") 
		{
			LM.UnlockLevel5();
		}
	}
 	void OnPlayButtonClicked()
	{
		Vector3 TempAngle = LevelsParent.transform.localEulerAngles;
		if (TempAngle.y > LevelAngles [0] - AngleFactor && TempAngle.y < LevelAngles [0] + AngleFactor)
		{
			float Speed=1;
			//GoogleAnalytics.instance.LogScreen("PlayArea_Level1");
			GoToPlayArea(Speed);
			LMO.SetBackGround(0);
//			print("Level 1");

		}
		else if (TempAngle.y > LevelAngles [1] - AngleFactor && TempAngle.y < LevelAngles [1] + AngleFactor)
		{
			if(LM.IsLevelSaved[0]==true)
			{
				float Speed=2f;
				//GoogleAnalytics.instance.LogScreen("PlayArea_Level2");
				GoToPlayArea(Speed);
				LMO.SetBackGround(1);
	///		print("Level 2");
			}
		} 
		else if (TempAngle.y > LevelAngles [2] - AngleFactor && TempAngle.y < LevelAngles [2] + AngleFactor)
		{
			if(LM.IsLevelSaved[1]==true)
			{
				float Speed=3;
				//GoogleAnalytics.instance.LogScreen("PlayArea_Level3");
				GoToPlayArea(Speed);
				LMO.SetBackGround(2);
		//		print("Level 2");
			}
		}
		else if (TempAngle.y > LevelAngles [3] - AngleFactor && TempAngle.y < LevelAngles [3] + AngleFactor)
		{
			if(LM.IsLevelSaved[2]==true)
			{
				float Speed=4;
				//GoogleAnalytics.instance.LogScreen("PlayArea_Level4");
				GoToPlayArea(Speed);
				LMO.SetBackGround(3);
			//	print("Level 2");
			}
		}
		else if (TempAngle.y > LevelAngles [4] - AngleFactor && TempAngle.y < LevelAngles [4] + AngleFactor)
		{
			if(LM.IsLevelSaved[3]==true)
			{
				float Speed=5;
				//GoogleAnalytics.instance.LogScreen("PlayArea_Level5");
				GoToPlayArea(Speed);
				LMO.SetBackGround(4);
				//print("Level 2");
			}
		}

	}
	public PlayAreaManager PAM;
	public GameObject GameObjectPrefab;

	void GoToPlayArea(float FinalSpeed)
	{
		SplashScreenGO.SetActive(false);
		LevelSelectionGO.SetActive (false);
		PlayAreaGO.SetActive (true);
		GameObject GO_TO_DELETE = GameObject.Find ("GameSystem");
		Destroy (GO_TO_DELETE);
		GameObject Temp=Instantiate(GameObjectPrefab) as GameObject;
		Temp.name="GameSystem";
		Temp.transform.parent = PlayAreaGO.transform;
	
//		Instantiate(GameObjectPrefab);
		PAM.StartTheGame (FinalSpeed);
	}
	public Transform[] LevelCollider;

	void OffTheLevelCollider()
	{
		for (int i = 0; i < LevelCollider.Length; i++) {
			LevelCollider[i].GetComponent<Collider>().enabled=false;		
		}
	}

	void OnTheLevelCollider()
	{
		for (int i = 0; i < LevelCollider.Length; i++) {
			LevelCollider[i].GetComponent<Collider>().enabled=true;		
		}
	}
	/***************************************************************************************************************************/
	/***************************************************************************************************************************/
//	public GameObject[] BackGrounds;
//
//	public Material ClothMat;
//	public Texture[] ClothTex;
//
//	void SetBackGround(int LevelNo)
//	{
//		for (int i = 0; i < BackGrounds.Length; i++) {
//			BackGrounds[i].SetActive(false);		
//		}
//		BackGrounds [LevelNo].SetActive (true);
//
//		ClothMat.mainTexture = ClothTex [LevelNo];
//	}



	/***************************************************************************************************************************/
	/***************************************************************************************************************************/
}
