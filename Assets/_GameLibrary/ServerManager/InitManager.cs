using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class InitManager : MonoBehaviour
{
    public MainResponse MainResponseInstance;
   
    public static string ServerURL =
        "https://sheets.googleapis.com/v4/spreadsheets/1Rcaj5TKA-VoLo4olCCNEBXvE_YYm5KCgNkuEaF4r2VU/values/Sheet1!A2:Z999?key=AIzaSyAP5QlsW0G-tnYAZ5Cx8aZvl_wYzOKZWy4";

	public static string ServerURL_Actual =
       "https://sheets.googleapis.com/v4/spreadsheets/1Rcaj5TKA-VoLo4olCCNEBXvE_YYm5KCgNkuEaF4r2VU/values/Sheet2!A2:Z999?key=AIzaSyAP5QlsW0G-tnYAZ5Cx8aZvl_wYzOKZWy4";
    // Use this for initialization
    // Use this for initialization

    [Header("#### GAME DETAILS ######")]
    public string BundleID;
    public string Platform;
    public string AdmobAppID;
    public string BannerID;
    public string InterstitialID;
    public static InitManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    
    public void OnDataRecieved(string Response)
    {
        MainResponseInstance = JsonUtility.FromJson<MainResponse>(Response);
        if (MainResponseInstance.values.Length > 0)
        {
            var DataObject = JSONNode.Parse(Response);
            for (int i = 0; i < MainResponseInstance.values.Length; i++)
            {
                MainResponseInstance.values[i].number = DataObject["values"][i][0].Value;
                MainResponseInstance.values[i].platform = DataObject["values"][i][1].Value;
                MainResponseInstance.values[i].game_name = DataObject["values"][i][2].Value;
                MainResponseInstance.values[i].bundleID = DataObject["values"][i][3].Value;
                MainResponseInstance.values[i].admob_appID = DataObject["values"][i][4].Value;
                MainResponseInstance.values[i].banner = DataObject["values"][i][5].Value;
                MainResponseInstance.values[i].interstitial = DataObject["values"][i][6].Value;
            }

            for (int i = 0; i < MainResponseInstance.values.Length; i++)
            {
                if (MainResponseInstance.values[i].bundleID==BundleID && MainResponseInstance.values[i].platform==Platform)
                {
                    AdmobAppID = MainResponseInstance.values[i].admob_appID;
                    BannerID = MainResponseInstance.values[i].banner;
                    InterstitialID = MainResponseInstance.values[i].interstitial;

                    RevenueManager revenueManagerTemp = gameObject.GetComponent<RevenueManager>();
                    if (Platform=="i")
                    {
                        revenueManagerTemp.iOSAppID = AdmobAppID;
                        revenueManagerTemp.iOSBannerID = BannerID;
                        revenueManagerTemp.iOSInterstitialID = InterstitialID;
                    }
                    else
                    {
                        revenueManagerTemp.AndroidAppID = AdmobAppID;
                        revenueManagerTemp.AndroidBannerID = BannerID;
                        revenueManagerTemp.AndroidInterstitialID = InterstitialID;
                    }
                }
            }
        }       
    }

    void Start ()
    {
        StartCoroutine(InitServerCo());    
    }

    IEnumerator InitServerCo()
    {
        UnityWebRequest www = UnityWebRequest.Get(ServerURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            OnDataRecieved(www.downloadHandler.text);
        }
        RevenueManager.Instance.InitAdmob();
    }
}

[System.Serializable]
public class MainResponse
{
    public string range;
    public string majorDimension;
    public MainResponseValues[] values;
}

[System.Serializable]
public class MainResponseValues
{
    public string number;
    public string platform;
    public string game_name;  
    public string bundleID;
    public string admob_appID;
    public string banner;
    public string interstitial;
}



/*
{
editor check
get data
if data recieved and found then set data
else set default data
}
 */
