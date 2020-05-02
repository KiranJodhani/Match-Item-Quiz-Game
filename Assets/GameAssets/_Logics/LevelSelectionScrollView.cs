using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class LevelSelectionScrollView : MonoBehaviour {

	public Transform LookTarget;
	public Camera uiCam;
	Transform rotator;
	public LevelSelector LS;
	
	int seq = 0;
	bool okDrag = false;
	public  bool isRoll = false;
	Vector3 mousePos;
	string HittedObject;
	public bool IsLevelButton=false;

	public SoundManager SM;
	void Start()
	{
		rotator = transform;
		
		
	}
	
	void OnDoneRollEffect()
	{
		isRoll = false;
	}
	void Roll()
	{
		if (isRoll) return;
		isRoll = true;
		float dist = mousePos.x - Input.mousePosition.x;
		float sign = Mathf.Sign(dist);
		if (Mathf.Abs (dist) < 4f);
//		print ("Level No : " + seq);
		int t = seq + (int)sign;
		//seq = (t + 3) % 3;
		seq = (t + 5) % 5;
		//Vector3 rot = new Vector3(0f, 120f * t, 0f);
		Vector3 rot = new Vector3(0f, 72f * t, 0f);
		TweenParms tparms = new TweenParms().Prop("eulerAngles", rot).Ease(EaseType.EaseInOutQuad).Id("myTween");
		tparms.OnComplete(OnDoneRollEffect);
		HOTween.Kill("myTween");
		HOTween.To(rotator, 0.5f, tparms);
	}
	
	public bool IsCursorOnUI(Vector3 point)
	{
		if (uiCam != null)
		{
			Ray inputRay = uiCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			//			HittedObject=hit.transform.name;
			if (Physics.Raycast(inputRay, out hit, Mathf.Infinity, 1 << uiCam.gameObject.layer))
			{
				
				return true;
				
			}
		}
		return false;
	}
	
	public Transform[] LevelButtons; 

	public bool CanGoBack;
	public void SetBackOn()
	{
		CanGoBack = true;
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if(CanGoBack)
			{
				SM.PlayClickSound();

				CanGoBack=false;
			}//GoBackAnimation();
		}
		
		if (Input.GetMouseButtonDown(0) && !IsCursorOnUI(Input.mousePosition)  && !IsLevelButton )
		{
			okDrag = true;
			mousePos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0) && !IsCursorOnUI(Input.mousePosition) && !IsLevelButton )
		{
			if (okDrag)
			{
				SM.PlaySwipeSound();
				Roll();
				okDrag = false;
			}
		}
		
		if (isRoll)
		{
			foreach (Transform LButton in LevelButtons) 
			{
				LButton.LookAt(LookTarget);
			}
		}
	}
}
