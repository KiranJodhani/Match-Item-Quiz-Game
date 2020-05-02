using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	// Use this for initialization

	public bool IsSoundOn=true;
	public Material[] SoundMatArray;
	public GameObject SoundButtons;
	public GameObject SoundButtonPauseScreen;
	public AudioClip ClickSound;
	public AudioClip SwipeSound;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OffTheSound()
	{

		SoundButtons.GetComponent<Renderer>().sharedMaterial = SoundMatArray [0];
		SoundButtonPauseScreen.GetComponent<Renderer>().sharedMaterial = SoundMatArray [0];
		AudioListener.volume = 0;
		IsSoundOn = false;
	}

	public void OnTheSound()
	{
		AudioListener.volume = 1;
		IsSoundOn = true;
		SoundButtons.GetComponent<Renderer>().sharedMaterial = SoundMatArray [1];
		SoundButtonPauseScreen.GetComponent<Renderer>().sharedMaterial = SoundMatArray [1];
	}

	public void PlayClickSound()
	{
		GetComponent<AudioSource>().PlayOneShot (ClickSound);
	}

	public void PlaySwipeSound()
	{
		GetComponent<AudioSource>().PlayOneShot(SwipeSound);
	}
}
