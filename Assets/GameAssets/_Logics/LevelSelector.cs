using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class LevelSelector : MonoBehaviour 
{
	public	Sequence InSeq ;
	public AnimationCurve JellyCurve;
	public Vector3 TargetScale;
	public float ScaleFactor=1.1f;

	public LevelSelectionScrollView LSSV;
	public LevelSelectionManager LSM;
	public SoundManager SM;
	public Transform LevelParent;
	// Use this for initialization
	void Start () 
	{
		TargetScale = transform.localScale * ScaleFactor;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void DownEvent()
	{
		LSSV.IsLevelButton = true;
		InSeq = new Sequence (new SequenceParms ().Loops (-1));
		InSeq.Append (HOTween.To (transform, 1, new TweenParms ().Prop ("localScale", TargetScale).Ease (JellyCurve)));
		InSeq.Play ();
	}

	void UpEvent()
	{
		LSSV.IsLevelButton = false;
		InSeq.Rewind ();
	}


	void OnMouseDown()
	{
				if (gameObject.name != "Start" && gameObject.name != "Home") 
				{
						if (LevelParent.localEulerAngles.y > 178 && LevelParent.localEulerAngles.y < 181) 
						{
							DownEvent();		
						}

				} 
				else if (gameObject.name != "Start" || gameObject.name != "Home") 
					{
						DownEvent();
					}
		}

	void OnMouseUp()
	{
		if (gameObject.name != "Start" && gameObject.name != "Home")
		{
		if (LevelParent.localEulerAngles.y > 178 && LevelParent.localEulerAngles.y < 181) 
			{
				UpEvent();
			}
		}
		else if (gameObject.name != "Start" || gameObject.name != "Home") 
		{
			UpEvent();
		}
	}

	void OnMouseUpAsButton()
	{
		if (gameObject.name != "Start" && gameObject.name != "Home")
		{
			if (LevelParent.localEulerAngles.y > 178 && LevelParent.localEulerAngles.y < 181)
			{
						SM.PlayClickSound ();
						UpEvent();
						LSM.ActionFromLevelSelection (gameObject.name);
			}
		}
		else if (gameObject.name != "Start" || gameObject.name != "Home") 
		{
			SM.PlayClickSound ();
			UpEvent();
			LSM.ActionFromLevelSelection (gameObject.name);
		}
	}
}
