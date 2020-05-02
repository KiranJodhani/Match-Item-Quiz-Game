using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class HelpScreenManager : MonoBehaviour 
{
	public Transform LookTarget;
	public Camera uiCam;
	Transform rotator;
	public SplashSelection SS;

	int seq = 0;
	bool okDrag = false;
	public  bool isRoll = false;
	Vector3 mousePos;
	string HittedObject;

	public SoundManager SM;
	
	void Start()
	{
		rotator = transform;
		//print ("Called");
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
		int t = seq + (int)sign;
		seq = (t + 3) % 3;
		//seq = (t + 5) % 5;
		Vector3 rot = new Vector3(0f, 120f * t, 0f);
		//Vector3 rot = new Vector3(0f, 72f * t, 0f);
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
	
	public Transform[] HelpButtons; 
	public bool CanGoToHome;

	public void SetCanBackOn()
	{
		CanGoToHome = true;
	}

	public GameObject HelpScreenGO;
	public SplashScreenAnimation  SSA;
		public GameObject CanvasX;
		public void GoBackFromHelp()
		{
				if (CanGoToHome) {
						CanGoToHome = false;
						HelpScreenGO.SetActive (false);
						CanvasX.SetActive (false);
						SSA.PlayButtonInAnimation ();
				}
		}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		   {
						GoBackFromHelp ();
			}
	

		if (Input.GetMouseButtonDown(0) && !IsCursorOnUI(Input.mousePosition) && !SS.IsHome )
		{
			okDrag = true;
			mousePos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0) && !IsCursorOnUI(Input.mousePosition) && !SS.IsHome)
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
			foreach (Transform HButton in HelpButtons) 
			{
				HButton.LookAt(LookTarget);
			}
		}
	}
}
