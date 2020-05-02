using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class popUpSelection : MonoBehaviour 
{

	public AnimationCurve JellyCurve;
	public Vector3 TargetSccale;
	public float ScaleFactor = 1.5f;
	public	Sequence TouchSeq22 ;
	public Color DefaultColor;
	public Color TouchColor;
	public Vector3 DefaultScale;

	public CustomPopUpManager CPUM;
	

	
	void Start () 
	{
		DefaultScale = transform.localScale;
		TargetSccale = transform.localScale * ScaleFactor;
		
	}
	
	
	
	void OnMouseDown()
	{
		
		
		TouchSeq22 = new Sequence (new SequenceParms ().Loops (-1));
		TouchSeq22.Append(HOTween.To(transform,1, new TweenParms().Prop("localScale",TargetSccale).Ease(JellyCurve)));
		TouchSeq22.Play();
		transform.localScale = TargetSccale;
		transform.GetComponent<Renderer>().material.color = TouchColor;
	}
	
	void OnMouseUpAsButton()
	{
		
		TouchSeq22.Rewind ();
		transform.localScale = DefaultScale;
		transform.GetComponent<Renderer>().material.color = DefaultColor;
		CPUM.FromPopUpWindow (gameObject.name);
		SM.PlayClickSound ();
	}
	public SoundManager SM;

	void OnMouseUp()
	{
		
		TouchSeq22.Rewind ();
		TouchSeq22.Kill ();
		transform.localScale = DefaultScale;
		transform.GetComponent<Renderer>().material.color = DefaultColor;
		
	}
}
