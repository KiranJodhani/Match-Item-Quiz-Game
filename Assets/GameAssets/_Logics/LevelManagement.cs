using UnityEngine;
using System.Collections;

public class LevelManagement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnEnable()
	{
		GetSavedData ();
		//Get CurrentData

	}

	public string LevelString;
	public string[] SavedLevel;
	public TextMesh CoinText;

	public GameObject[] Level2ShowCase;
	public GameObject[] Level3ShowCase;
	public GameObject[] Level4ShowCase;
	public GameObject[] Level5ShowCase;

	public bool[] IsLevelSaved;

	public int SavedCoins=0;


	public void UnlockLevel2()
	{
		SavedCoins -= 500;
		PlayerPrefs.SetInt ("SavedCoin", SavedCoins);
		PlayerPrefs.Save ();
		IsLevelSaved[0]=true;
		CoinText.text = SavedCoins.ToString ();

		LevelString=PlayerPrefs.GetString("SavedLevel");

		LevelString =LevelString+"Level2#";
		PlayerPrefs.SetString ("SavedLevel", LevelString);
		PlayerPrefs.Save ();

		for(int i = 0 ; i < Level2ShowCase.Length ; i++)
		{
			Level2ShowCase[i].SetActive(false);
		}

		GetSavedData ();
	}

	public void UnlockLevel3()
	{
		SavedCoins -= 1000;
		PlayerPrefs.SetInt ("SavedCoin", SavedCoins);
		PlayerPrefs.Save ();
		IsLevelSaved[1]=true;
		CoinText.text = SavedCoins.ToString ();

		LevelString =LevelString+"Level3#";
		PlayerPrefs.SetString ("SavedLevel", LevelString);
		PlayerPrefs.Save ();

		for(int i = 0 ; i < Level3ShowCase.Length ; i++)
		{
			Level3ShowCase[i].SetActive(false);
		}
		GetSavedData ();
	}

	public void UnlockLevel4()
	{
		SavedCoins -= 2000;
		PlayerPrefs.SetInt ("SavedCoin", SavedCoins);
		PlayerPrefs.Save ();
		IsLevelSaved[2]=true;
		CoinText.text = SavedCoins.ToString ();

		LevelString =LevelString+"Level4#";
		PlayerPrefs.SetString ("SavedLevel", LevelString);
		PlayerPrefs.Save ();

		for(int i = 0 ; i < Level4ShowCase.Length ; i++)
		{
			Level4ShowCase[i].SetActive(false);
		}
		GetSavedData ();
	}

	public void UnlockLevel5()
	{
		print("called");
		SavedCoins -= 3500;
		PlayerPrefs.SetInt ("SavedCoin", SavedCoins);
		PlayerPrefs.Save ();
		IsLevelSaved[3]=true;
		CoinText.text = SavedCoins.ToString ();

		LevelString =LevelString+"Level5#";
		PlayerPrefs.SetString ("SavedLevel", LevelString);
		PlayerPrefs.Save ();

		for(int i = 0 ; i < Level5ShowCase.Length ; i++)
		{
			Level5ShowCase[i].SetActive(false);
		}
		GetSavedData ();
	}


//	void CheckCoinAvailibility()
//	{
//
//	}
	void GetSavedData()
	{
		//PlayerPrefs.DeleteAll ();

		if (PlayerPrefs.HasKey ("SavedCoin"))
		{
			print("exist");
			SavedCoins=PlayerPrefs.GetInt("SavedCoin");
			CoinText.text=SavedCoins.ToString();
		}
		else
		{
//			print("not exist");
			PlayerPrefs.SetInt("SavedCoin",0);
			PlayerPrefs.Save();
			SavedCoins=PlayerPrefs.GetInt("SavedCoin");
			CoinText.text=SavedCoins.ToString();
		}


		if (PlayerPrefs.HasKey ("SavedLevel"))
		{
			//PlayerPrefs.DeleteKey("SavedLevel");
			LevelString=PlayerPrefs.GetString("SavedLevel");
		}
		else
		{
			PlayerPrefs.SetString("SavedLevel","Level1#");
			PlayerPrefs.Save();
//			print("No Data Found ");
//			print("Initial Data Saved : " +PlayerPrefs.GetString("SavedLevel"));
			LevelString=PlayerPrefs.GetString("SavedLevel");
		}


	

		SavedLevel=LevelString.Split('#');

		foreach (string LevelSt in SavedLevel)
		{
			if(LevelSt=="Level1")
			{
			//	print("Level1 Unlocked");
			}
			else if(LevelSt=="Level2")
			{
			//	print("Level2 Unlocked");
				IsLevelSaved[0]=true;
				for(int i = 0 ; i < Level2ShowCase.Length ; i++)
				{
					Level2ShowCase[i].SetActive(false);
				}



			}
			else if(LevelSt=="Level3")
			{
				IsLevelSaved[1]=true;
				for(int i = 0 ; i < Level3ShowCase.Length ; i++)
				{
					Level3ShowCase[i].SetActive(false);
				}


			}
			else if(LevelSt=="Level4")
			{
				IsLevelSaved[2]=true;
				for(int i = 0 ; i < Level4ShowCase.Length ; i++)
				{
					Level4ShowCase[i].SetActive(false);
				}

			}
			else if(LevelSt=="Level5")
			{
				IsLevelSaved[3]=true;
				for(int i = 0 ; i < Level5ShowCase.Length ; i++)
				{
					Level5ShowCase[i].SetActive(false);
				}

			}


			if(SavedCoins<500)
			{
				if(IsLevelSaved[0]==false)
				{

						for(int i =0; i<Level2ShowCase.Length;i++)
						{
							Level2ShowCase[i].SetActive(true);
						}
						Level2ShowCase[Level2ShowCase.Length-1].SetActive(false);
				}
				else if(IsLevelSaved[1]==false)
				{
					
					for(int i =0; i<Level3ShowCase.Length;i++)
					{
						Level3ShowCase[i].SetActive(true);
					}
					Level3ShowCase[Level3ShowCase.Length-1].SetActive(false);
				}
				else if(IsLevelSaved[2]==false)
				{
					
					for(int i =0; i<Level4ShowCase.Length;i++)
					{
						Level4ShowCase[i].SetActive(true);
					}
					Level4ShowCase[Level4ShowCase.Length-1].SetActive(false);
				}
				else if(IsLevelSaved[3]==false)
				{
					
					for(int i =0; i<Level5ShowCase.Length;i++)
					{
						Level5ShowCase[i].SetActive(true);
					}
					Level5ShowCase[Level5ShowCase.Length-1].SetActive(false);
				}

			}
			else if(SavedCoins>=500 && SavedCoins<1000 )
			{
				if(IsLevelSaved[0]==false)
				{
					//ShowLevel2 Unlock Option
					for(int i =0; i<Level2ShowCase.Length;i++)
					{
						Level2ShowCase[i].SetActive(true);
					}
					Level2ShowCase[Level2ShowCase.Length-2].SetActive(false);
				}
				 if(IsLevelSaved[1]==false)
				{
					
					for(int i =0; i<Level3ShowCase.Length;i++)
					{
						Level3ShowCase[i].SetActive(true);
					}
					Level3ShowCase[Level3ShowCase.Length-1].SetActive(false);
				}
				 if(IsLevelSaved[2]==false)
				{
					
					for(int i =0; i<Level4ShowCase.Length;i++)
					{
						Level4ShowCase[i].SetActive(true);
					}
					Level4ShowCase[Level4ShowCase.Length-1].SetActive(false);
				}
				 if(IsLevelSaved[3]==false)
				{
					
					for(int i =0; i<Level5ShowCase.Length;i++)
					{
						Level5ShowCase[i].SetActive(true);
					}
					Level5ShowCase[Level5ShowCase.Length-1].SetActive(false);
				}

			}
			else if(SavedCoins>=1000 && SavedCoins<2000)
			{
				if(IsLevelSaved[0]==false)
				{
					//ShowLevel2 Unlock Option
					for(int i =0; i<Level2ShowCase.Length;i++)
					{
						Level2ShowCase[i].SetActive(true);
					}
					Level2ShowCase[Level2ShowCase.Length-2].SetActive(false);
				}

				if(IsLevelSaved[1]==false)
				{
					//ShowLevel3 locked
					for(int i =0; i<Level3ShowCase.Length;i++)
					{
						Level3ShowCase[i].SetActive(true);
					}
					Level3ShowCase[Level3ShowCase.Length-1].SetActive(false);
				}
				 if(IsLevelSaved[2]==false)
				{
					
					for(int i =0; i<Level4ShowCase.Length;i++)
					{
						Level4ShowCase[i].SetActive(true);
					}
					Level4ShowCase[Level4ShowCase.Length-1].SetActive(false);
				}
				 if(IsLevelSaved[3]==false)
				{
					
					for(int i =0; i<Level5ShowCase.Length;i++)
					{
						Level5ShowCase[i].SetActive(true);
					}
					Level5ShowCase[Level5ShowCase.Length-1].SetActive(false);
				}

			} 
			else if(SavedCoins>=2000 && SavedCoins<3500)
			{

				if(IsLevelSaved[0]==false)
				{
					//ShowLevel2 Unlock Option
					for(int i =0; i<Level2ShowCase.Length;i++)
					{
						Level2ShowCase[i].SetActive(true);
					}
					Level2ShowCase[Level2ShowCase.Length-2].SetActive(false);
				}
				
				if(IsLevelSaved[1]==false)
				{
					//ShowLevel3 Unlock Option
					for(int i =0; i<Level3ShowCase.Length;i++)
					{
						Level3ShowCase[i].SetActive(true);
					}
					Level3ShowCase[Level3ShowCase.Length-2].SetActive(false);
				}
				if(IsLevelSaved[2]==false)
				{
					//ShowLevel3 Unlock Option
					for(int i =0; i<Level4ShowCase.Length;i++)
					{
						Level4ShowCase[i].SetActive(true);
					}
					Level4ShowCase[Level4ShowCase.Length-2].SetActive(false);
				}
				 if(IsLevelSaved[3]==false)
				{
					
					for(int i =0; i<Level5ShowCase.Length;i++)
					{
						Level5ShowCase[i].SetActive(true);
					}
					Level5ShowCase[Level5ShowCase.Length-1].SetActive(false);
				}

			}
			else if(SavedCoins>=3500)
			{
				if(IsLevelSaved[0]==false)
				{
					//ShowLevel2 Unlock Option
					for(int i =0; i<Level2ShowCase.Length;i++)
					{
						Level2ShowCase[i].SetActive(true);
					}
					Level2ShowCase[Level2ShowCase.Length-2].SetActive(false);
				}
				
				if(IsLevelSaved[1]==false)
				{
					//ShowLevel3 Unlock Option
					for(int i =0; i<Level3ShowCase.Length;i++)
					{
						Level3ShowCase[i].SetActive(true);
					}
					Level3ShowCase[Level3ShowCase.Length-2].SetActive(false);
				}
				if(IsLevelSaved[2]==false)
				{
					//ShowLevel3 Unlock Option
					for(int i =0; i<Level4ShowCase.Length;i++)
					{
						Level4ShowCase[i].SetActive(true);
					}
					Level4ShowCase[Level4ShowCase.Length-2].SetActive(false);
				}
				if(IsLevelSaved[3]==false)
				{
					//ShowLevel3 Unlock Option
					for(int i =0; i<Level5ShowCase.Length;i++)
					{
						Level5ShowCase[i].SetActive(true);
					}
					Level5ShowCase[Level5ShowCase.Length-2].SetActive(false);
				}

			}
		}
	}
}
