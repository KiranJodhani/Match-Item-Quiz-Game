using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class PlayAreaButtons : MonoBehaviour {


	public	Sequence InSeq2 ;
	public Sequence InSeq;
	public AnimationCurve JellyCurve;
	public Vector3 TargetScale;
	public float ScaleFactor=1.1f;

	public PlayAreaManager PAM;
	public SoundManager SM;
	// Use this for initialization
	void Start ()
	{
		TargetScale = transform.localScale * ScaleFactor;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown()
	{
		SM.PlayClickSound ();
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
		
		
		if (gameObject.name == "Share")
		{

			PAM.FromPlayArea(gameObject.name);

		}
		else if (gameObject.name == "Pause")
		{

						PAM.FromPlayArea(gameObject.name);

		}
		else if (gameObject.name == "LogOutButton")
		{
			//FB.Logout();
			gameObject.SetActive(false);
			
		}
	}
}
