using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class FaceBookSharing : MonoBehaviour
{
//	#region FB.Init() example
	
//	public bool isInit = false;
//	//public bool isPendingReq=false;
//	public GameObject LogOutButton;

//	public void ShareThisApp()
//	{

//		Invoke ("ShareAfterSS", 0.1f);
//	}

//	/*************************************************************************************/
//	public int width = Screen.width;
//	public int height = Screen.height;
//	public Texture2D ScreenShotImage;
//	public TextMesh StatusText;

//public	void TakeCurrentScreenShots()
//	{
//		if(ScreenShotImage)
//		{
//			Destroy(ScreenShotImage);
//		}
		
//		StartCoroutine(ScreenshotTaker());
//	}
//	byte[] screenshot;
//	private IEnumerator ScreenshotTaker() 
//	{
//		yield return new WaitForEndOfFrame();
		
//		width = Screen.width;
//		height = Screen.height;
//		ScreenShotImage = new Texture2D(width, height, TextureFormat.RGB24, false);
//		// Read screen contents into the texture
//		ScreenShotImage.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//		ScreenShotImage.Apply();
//		 screenshot = ScreenShotImage.EncodeToPNG();
//	}
//	/*************************************************************************************/
//	public bool PendingSS=false;
//	void ShareAfterSS()
//	{
//		StatusText.text="Please Wait...";
//		if(FB.IsLoggedIn)
//		{
//					var wwwForm = new WWWForm();
//					wwwForm.AddBinaryData("image", screenshot, "Match_Item.png");
//			wwwForm.AddField("Match Item  https://play.google.com/store/apps/details?id=com.photongames.matchitem ", "Look I Collect this much coins, What About you ??");
//					FB.API("me/photos", Facebook.HttpMethod.POST, Callback, wwwForm);
////			gt.text="Post success";
//			//Debug.Log("publish response: " + result.Text);
//			StatusText.text="Sharing Completed.";
//		//	PAM.CurrentCoin=PlayerPrefs.GetInt("SavedCoin");
//			PAM.CurrentCoin += 20;
//			PlayerPrefs.SetInt("SavedCoin",PAM.CurrentCoin);
//			PlayerPrefs.Save();
//			CoinText.text=PAM.CurrentCoin.ToString();
//			PendingSS=false;
//			Invoke ("ResetShareScreen", 2);
					
//		}
//		else
//		{
//			CallFBLogin();
//			PendingSS=true;
//		}
//	}
//	public void CallFBInit()
//	{
//		FB.Init(OnInitComplete, OnHideUnity);
//	}
	
//	private void OnInitComplete()
//	{
//		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
//		isInit = true;
//		LogOutButton.SetActive (FB.IsLoggedIn);

//	}
	
//	private void OnHideUnity(bool isGameShown)
//	{
//		Debug.Log("Is game showing? " + isGameShown);
//	}
	
//	#endregion
	
//	#region FB.Login() example
	
//	private void CallFBLogin()
//	{
//		FB.Login("email,publish_actions", LoginCallback);
//	}

//	void SharingFailed ()
//	{
//		StatusText.text="Sharing Failed !!";
//		Invoke ("DisableShareBG", 2);
//	}


//	void DisableShareBG()
//	{
//		StatusText.text="";
//		PAM.DisableShareScreen ();
//	}
////	void LoginCallback(FBResult result)
////	{
////		if (result.Error != null)
////			lastResponse = "Error Response:\n" + result.Error;
////		else if (!FB.IsLoggedIn)
////		{
////			lastResponse = "Login cancelled by Player";
////			SharingFailed();
////		}
////		else
////		{
////			lastResponse = "Login was successful!";
////			LogOutButton.SetActive(true);
////			if(PendingSS)
////			{
////				ShareAfterSS();
////			}
////			else if(isFriendReq)
////			{
////				RequestToSelectedFriend();
////			}
////		}
//////		else
//////		{
//////			SharingFailed();
//////		}
//	//}
	
//	//private void CallFBLogout()
//	//{
//	//	FB.Logout();
//	//}
//	//#endregion
	
//	//#region FB.PublishInstall() example

//	////public GUIText gt;
//	//private void CallFBPublishInstall()
//	//{
//	//	//gt.text="Insatll";
//	//	FB.PublishInstall(PublishComplete);
//	//}

////	int currentCoin;
//	public TextMesh CoinText;
//	public PlayAreaManager PAM;

//	void PublishComplete(FBResult result)
//	{
//	//	gt.text="Publish completed"+result.Text;
//		Debug.Log("publish response: " + result.Text);
//		StatusText.text="Sharing Completed.";
//	//	currentCoin=PlayerPrefs.GetInt("SavedCoin");
	
//		PAM.CurrentCoin += 20;
//		PlayerPrefs.SetInt("SavedCoin",PAM.CurrentCoin);
//		PlayerPrefs.Save();
//		CoinText.text=PAM.CurrentCoin.ToString();
//		PendingSS=false;
//		Invoke ("ResetShareScreen", 2);

//	}
//	void ResetShareScreen()
//	{
//		StatusText.text="";
//		Invoke("DisableShareBG",0);
//		//PAM.DisableShareScreen ();
//	}
	
//	#endregion
	
//	#region FB.AppRequest() Friend Selector
	
//	public string FriendSelectorTitle = "Match Item from Photon Game";
//	public string FriendSelectorMessage = "Play this game for free";
//	public string FriendSelectorFilters = "[\"all\",\"app_users\",\"app_non_users\"]";
//	public string FriendSelectorData = "{}";
//	public string FriendSelectorExcludeIds = "";
//	public string FriendSelectorMax = "";
//	public bool isFriendReq=false;
//	public void RequestToSelectedFriend()
//	{
					
//		if(FB.IsLoggedIn)
//		{
//					try
//						{
//							CallAppRequestAsFriendSelector();
//							status = "Friend Selector called";

//						}
//						catch (Exception e)
//						{
//							status = e.Message;
//						}
//			isFriendReq=false;
//		}
//		else
//		{
//			CallFBLogin();
//			isFriendReq=true;
//		}
//	}

//	public void CallAppRequestAsFriendSelector()
//	{
//		// If there's a Max Recipients specified, include it
//		int? maxRecipients = null;
//		if (FriendSelectorMax != "")
//		{
//			try
//			{
//				maxRecipients = Int32.Parse(FriendSelectorMax);
//			}
//			catch (Exception e)
//			{
//				status = e.Message;
//			}
//		}
		
//		// include the exclude ids
//		string[] excludeIds = (FriendSelectorExcludeIds == "") ? null : FriendSelectorExcludeIds.Split(',');
		
//		FB.AppRequest(
//			FriendSelectorMessage,
//			null,
//			FriendSelectorFilters,
//			excludeIds,
//			maxRecipients,
//			FriendSelectorData,
//			FriendSelectorTitle,
//			Callback
//			);
//	}
//	#endregion
	
//	#region FB.AppRequest() Direct Request
	
//	public string DirectRequestTitle = "";
//	public string DirectRequestMessage = "Herp";
//	private string DirectRequestTo = "";
	
//	private void CallAppRequestAsDirectRequest()
//	{
//		if (DirectRequestTo == "")
//		{
//			throw new ArgumentException("\"To Comma Ids\" must be specificed", "to");
//		}
//		FB.AppRequest(
//			DirectRequestMessage,
//			DirectRequestTo.Split(','),
//			"",
//			null,
//			null,
//			"",
//			DirectRequestTitle,
//			Callback
//			);
//	}
	
//	#endregion
	
//	#region FB.Feed() example
	
//	public string FeedToId = "";
//	public string FeedLink = "";
//	public string FeedLinkName = "";
//	public string FeedLinkCaption = "";
//	public string FeedLinkDescription = "";
//	public string FeedPicture = "";
//	public string FeedMediaSource = "";
//	public string FeedActionName = "";
//	public string FeedActionLink = "";
//	public string FeedReference = "";
//	public bool IncludeFeedProperties = false;
//	private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]>();
	
//	private void CallFBFeed()
//	{
//		Dictionary<string, string[]> feedProperties = null;
//		if (IncludeFeedProperties)
//		{
//			feedProperties = FeedProperties;
//		}
//		FB.Feed(
//			toId: FeedToId,
//			link: FeedLink,
//			linkName: FeedLinkName,
//			linkCaption: FeedLinkCaption,
//			linkDescription: FeedLinkDescription,
//			picture: FeedPicture,
//			mediaSource: FeedMediaSource,
//			actionName: FeedActionName,
//			actionLink: FeedActionLink,
//			reference: FeedReference,
//			properties: feedProperties,
//			callback: Callback
//			);
//	}
	
//	#endregion
	
//	#region FB.Canvas.Pay() example
	
//	public string PayProduct = "";
	
//	private void CallFBPay()
//	{
//		FB.Canvas.Pay(PayProduct);
//	}
	
//	#endregion
	
//	#region FB.API() example
	
//	public string ApiQuery = "";
	
//	private void CallFBAPI()
//	{
//		FB.API(ApiQuery, Facebook.HttpMethod.GET, Callback);
//	}
	
//	#endregion
	
//	#region FB.GetDeepLink() example
	
//	private void CallFBGetDeepLink()
//	{
//		FB.GetDeepLink(Callback);
//	}
	
//	#endregion
	
//	#region FB.AppEvent.LogEvent example
	
//	public float PlayerLevel = 1.0f;
	
//	public void CallAppEventLogEvent()
//	{
//		var parameters = new Dictionary<string, object>();
//		parameters[Facebook.FBAppEventParameterName.Level] = "Player Level";
//		FB.AppEvents.LogEvent(Facebook.FBAppEventName.AchievedLevel, PlayerLevel, parameters);
//		PlayerLevel++;
//	}
	
//	#endregion
	
//	#region FB.Canvas.SetResolution example
	
//	public string Width = "800";
//	public string Height = "600";
//	public bool CenterHorizontal = true;
//	public bool CenterVertical = false;
//	public string Top = "10";
//	public string Left = "10";
	
//	public void CallCanvasSetResolution()
//	{
//		int width;
//		if (!Int32.TryParse(Width, out width))
//		{
//			width = 800;
//		}
//		int height;
//		if (!Int32.TryParse(Height, out height))
//		{
//			height = 600;
//		}
//		float top;
//		if (!float.TryParse(Top, out top))
//		{
//			top = 0.0f;
//		}
//		float left;
//		if (!float.TryParse(Left, out left))
//		{
//			left = 0.0f;
//		}
//		if (CenterHorizontal && CenterVertical)
//		{
//			FB.Canvas.SetResolution(width, height, false, 0, FBScreen.CenterVertical(), FBScreen.CenterHorizontal());
//		} 
//		else if (CenterHorizontal) 
//		{
//			FB.Canvas.SetResolution(width, height, false, 0, FBScreen.Top(top), FBScreen.CenterHorizontal());
//		} 
//		else if (CenterVertical)
//		{
//			FB.Canvas.SetResolution(width, height, false, 0, FBScreen.CenterVertical(), FBScreen.Left(left));
//		}
//		else
//		{
//			FB.Canvas.SetResolution(width, height, false, 0, FBScreen.Top(top), FBScreen.Left(left));
//		}
//	}
	
//	#endregion
	
//	#region GUI
	
//	private string status = "Ready";
	
//	private string lastResponse = "";
//	//public GUIStyle textStyle = new GUIStyle();
//	private Texture2D lastResponseTexture;
	
//	private Vector2 scrollPosition = Vector2.zero;
//	#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
//	int buttonHeight = 60;
//	int mainWindowWidth = Screen.width - 30;
//	int mainWindowFullWidth = Screen.width;
//	#else
//	int buttonHeight = 24;
//	int mainWindowWidth = 500;
//	int mainWindowFullWidth = 530;
//	#endif
	
////	private int TextWindowHeight
////	{
////		get
////		{
////			#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
////			return IsHorizontalLayout() ? Screen.height : 85;
////			#else
////			return Screen.height;
////			#endif
////		}
////	}
	
//	void Awake()
//	{
//		CallFBInit ();
////		textStyle.alignment = TextAnchor.UpperLeft;
////		textStyle.wordWrap = true;
////		textStyle.padding = new RectOffset(10, 10, 10, 10);
////		textStyle.stretchHeight = true;
////		textStyle.stretchWidth = false;
		
//		FeedProperties.Add("key1", new[] { "valueString1" });
//		FeedProperties.Add("key2", new[] { "valueString2", "http://www.facebook.com" });
//	}
	
////	void OnGUI()
////	{
////		if (IsHorizontalLayout())
////		{
////			GUILayout.BeginHorizontal();
////			GUILayout.BeginVertical();
////		}
////		GUILayout.Space(5);
////		GUILayout.Box("Status: " + status, GUILayout.MinWidth(mainWindowWidth));
////		
////		#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
////		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
////		{
////			scrollPosition.y += Input.GetTouch(0).deltaPosition.y;
////		}
////		#endif
////		
////		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MinWidth(mainWindowFullWidth));
////		GUILayout.BeginVertical();
////		GUI.enabled = !isInit;
////		if (Button("FB.Init"))
////		{
////			CallFBInit();
////			status = "FB.Init() called with " + FB.AppId;
////		}
////		
////		GUILayout.BeginHorizontal();
////		
////		GUI.enabled = isInit;
////		if (Button("Login"))
////		{
////			CallFBLogin();
////			status = "Login called";
////		}
////		
////		#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
////		GUI.enabled = FB.IsLoggedIn;
////		if (Button("Logout"))
////		{
////			CallFBLogout();
////			status = "Logout called";
////		}
////		GUI.enabled = isInit;
////		#endif
////		GUILayout.EndHorizontal();
////		
////		#if UNITY_IOS || UNITY_ANDROID
////		if (Button("Publish Install"))
////		{
////			CallFBPublishInstall();
////			status = "Install Published";
////		}
////		#endif
////		
////		GUI.enabled = FB.IsLoggedIn;
////		GUILayout.Space(10);
////		LabelAndTextField("Title (optional): ", ref FriendSelectorTitle);
////		LabelAndTextField("Message: ", ref FriendSelectorMessage);
////		LabelAndTextField("Exclude Ids (optional): ", ref FriendSelectorExcludeIds);
////		LabelAndTextField("Filters (optional): ", ref FriendSelectorFilters);
////		LabelAndTextField("Max Recipients (optional): ", ref FriendSelectorMax);
////		LabelAndTextField("Data (optional): ", ref FriendSelectorData);
////		if (Button("Open Friend Selector"))
////		{
////			try
////			{
////				CallAppRequestAsFriendSelector();
////				status = "Friend Selector called";
////			}
////			catch (Exception e)
////			{
////				status = e.Message;
////			}
////		}
////		GUILayout.Space(10);
////		LabelAndTextField("Title (optional): ", ref DirectRequestTitle);
////		LabelAndTextField("Message: ", ref DirectRequestMessage);
////		LabelAndTextField("To Comma Ids: ", ref DirectRequestTo);
////		if (Button("Open Direct Request"))
////		{
////			try
////			{
////				CallAppRequestAsDirectRequest();
////				status = "Direct Request called";
////			}
////			catch (Exception e)
////			{
////				status = e.Message;
////			}
////		}
////		GUILayout.Space(10);
////		LabelAndTextField("To Id (optional): ", ref FeedToId);
////		LabelAndTextField("Link (optional): ", ref FeedLink);
////		LabelAndTextField("Link Name (optional): ", ref FeedLinkName);
////		LabelAndTextField("Link Desc (optional): ", ref FeedLinkDescription);
////		LabelAndTextField("Link Caption (optional): ", ref FeedLinkCaption);
////		LabelAndTextField("Picture (optional): ", ref FeedPicture);
////		LabelAndTextField("Media Source (optional): ", ref FeedMediaSource);
////		LabelAndTextField("Action Name (optional): ", ref FeedActionName);
////		LabelAndTextField("Action Link (optional): ", ref FeedActionLink);
////		LabelAndTextField("Reference (optional): ", ref FeedReference);
////		GUILayout.BeginHorizontal();
////		GUILayout.Label("Properties (optional)", GUILayout.Width(150));
////		IncludeFeedProperties = GUILayout.Toggle(IncludeFeedProperties, "Include");
////		GUILayout.EndHorizontal();
////		if (Button("Open Feed Dialog"))
////		{
////			try
////			{
////				CallFBFeed();
////				status = "Feed dialog called";
////			}
////			catch (Exception e)
////			{
////				status = e.Message;
////			}
////		}
////		GUILayout.Space(10);
////		
////		#if UNITY_WEBPLAYER
////		LabelAndTextField("Product: ", ref PayProduct);
////		if (Button("Call Pay"))
////		{
////			CallFBPay();
////		}
////		GUILayout.Space(10);
////		#endif
////		
////		LabelAndTextField("API: ", ref ApiQuery);
////		if (Button("Call API"))
////		{
////			status = "API called";
////			CallFBAPI();
////		}
////		GUILayout.Space(10);
////		if (Button("Take & upload screenshot"))
////		{
////			status = "Take screenshot";
////			
////			StartCoroutine(TakeScreenshot());
////		}
////		
////		if (Button("Get Deep Link"))
////		{
////			CallFBGetDeepLink();
////		}
////		#if UNITY_IOS || UNITY_ANDROID
////		if (Button("Log FB App Event"))
////		{
////			status = "Logged FB.AppEvent";
////			CallAppEventLogEvent();
////		}
////		#endif
////		
////		#if UNITY_WEBPLAYER
////		GUILayout.Space(10);
////		
////		LabelAndTextField("Game Width: ", ref Width);
////		LabelAndTextField("Game Height: ", ref Height);
////		GUILayout.BeginHorizontal();
////		GUILayout.Label("Center Game:", GUILayout.Width(150));
////		CenterVertical = GUILayout.Toggle(CenterVertical, "Vertically");
////		CenterHorizontal = GUILayout.Toggle(CenterHorizontal, "Horizontally");
////		GUILayout.EndHorizontal();
////		GUILayout.BeginHorizontal();
////		LabelAndTextField("or set Padding Top: ", ref Top);
////		LabelAndTextField("set Padding Left: ", ref Left);
////		GUILayout.EndHorizontal();
////		if (Button("Set Resolution"))
////		{
////			status = "Set to new Resolution";
////			CallCanvasSetResolution();
////		}
////		#endif
////		
////		GUILayout.Space(10);
////		
////		GUILayout.EndVertical();
////		GUILayout.EndScrollView();
////		
////		if (IsHorizontalLayout())
////		{
////			GUILayout.EndVertical();
////		}
////		GUI.enabled = true;
////		
////		var textAreaSize = GUILayoutUtility.GetRect(640, TextWindowHeight);
////		
////		GUI.TextArea(
////			textAreaSize,
////			string.Format(
////			" AppId: {0} \n Facebook Dll: {1} \n UserId: {2}\n IsLoggedIn: {3}\n AccessToken: {4}\n AccessTokenExpiresAt: {5}\n {6}",
////			FB.AppId,
////			(isInit) ? "Loaded Successfully" : "Not Loaded",
////			FB.UserId,
////			FB.IsLoggedIn,
////			FB.AccessToken,
////			FB.AccessTokenExpiresAt,
////			lastResponse
////			), textStyle);
////		
////		if (lastResponseTexture != null)
////		{
////			var texHeight = textAreaSize.y + 200;
////			if (Screen.height - lastResponseTexture.height < texHeight)
////			{
////				texHeight = Screen.height - lastResponseTexture.height;
////			}
////			GUI.Label(new Rect(textAreaSize.x + 5, texHeight, lastResponseTexture.width, lastResponseTexture.height), lastResponseTexture);
////		}
////		
////		if (IsHorizontalLayout())
////		{
////			GUILayout.EndHorizontal();
////		}
////	}
	
//	void Callback(FBResult result)
//	{
//		lastResponseTexture = null;
//		// Some platforms return the empty string instead of null.
//		if (!String.IsNullOrEmpty(result.Error))
//			lastResponse = "Error Response:\n" + result.Error;
//		else if (!ApiQuery.Contains("/picture"))
//			lastResponse = "Success Response:\n" + result.Text;
//		else
//		{
//			lastResponseTexture = result.Texture;
//			lastResponse = "Success Response:\n";
//		}
//	}
	
////	private IEnumerator TakeScreenshot() 
////	{
////		yield return new WaitForEndOfFrame();
////		
////		var width = Screen.width;
////		var height = Screen.height;
////		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
////		// Read screen contents into the texture
////		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
////		tex.Apply();
////		byte[] screenshot = tex.EncodeToPNG();
////		
////		var wwwForm = new WWWForm();
////		wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
////		wwwForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");
////		
////		FB.API("me/photos", Facebook.HttpMethod.POST, Callback, wwwForm);
////	}
	
////	private bool Button(string label)
////	{
////		return GUILayout.Button(
////			label, 
////			GUILayout.MinHeight(buttonHeight), 
////			GUILayout.MaxWidth(mainWindowWidth)
////			);
////	}
	
////	private void LabelAndTextField(string label, ref string text)
////	{
////		GUILayout.BeginHorizontal();
////		GUILayout.Label(label, GUILayout.MaxWidth(150));
////		text = GUILayout.TextField(text);
////		GUILayout.EndHorizontal();
////	}
////	
////	private bool IsHorizontalLayout()
////	{
////		#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
////		return Screen.orientation == ScreenOrientation.Landscape;
////		#else
////		return true;
////		#endif
////	}
	
	//#endregion
}
