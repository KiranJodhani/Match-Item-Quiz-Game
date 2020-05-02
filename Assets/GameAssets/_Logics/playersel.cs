using UnityEngine;
using System.Collections;

public class playersel : MonoBehaviour 
{
	public Material mat;
	public Texture tex;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		mat.mainTexture=tex;
	}
}
