using UnityEngine;
using System.Collections;

public class LevelMakeOver : MonoBehaviour {

	/***************************************************************************************************************************/
	/***************************************************************************************************************************/
	public GameObject[] BackGrounds;
	
	public Material ClothMat;
	public Texture[] ClothTex;
	
public	void SetBackGround(int LevelNo)
	{
		for (int i = 0; i < BackGrounds.Length; i++) {
			BackGrounds[i].SetActive(false);		
		}
		BackGrounds [LevelNo].SetActive (true);
		
		ClothMat.mainTexture = ClothTex [LevelNo];
	}
	
	void Start()
	{
	}
	
	/***************************************************************************************************************************/
	/***************************************************************************************************************************/
}
