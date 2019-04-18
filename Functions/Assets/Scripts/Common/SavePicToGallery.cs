using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
public class SavePicToGallery
{
#if UNITY_IOS	
	[DllImport("__Internal")]
    private static extern bool saveToGallery( string path );	
#endif
    public static event System.Action<bool> SaveFinished;
    public static IEnumerator Save(string filePath)
    {
        LogView.Add("Save existing file to gallery " + filePath);
#if UNITY_IOS		
        string iosPath = Application.persistentDataPath + "/" + filePath;			
		saveToGallery( iosPath );				
        yield return new WaitForSeconds(.5f);		
		UnityEngine.iOS.Device.SetNoBackupFlag( iosPath );			
#elif UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass obj = new AndroidJavaClass("soulworker.xml.congyu.xmllibrary.UnityCallAndroid");
            int startIdx = filePath.LastIndexOf("/");
            if (startIdx == -1)
                startIdx = 0;
            else
                startIdx = startIdx + 1;
            int endIdx = filePath.LastIndexOf(".");
            string saveName = filePath.Substring(startIdx, endIdx - startIdx);
            LogView.Add("savePicToGallery " + saveName);
            obj.CallStatic("savePicToGallery", saveName);
            yield return new WaitForSeconds(.5f);
        }
#else
        yield return new WaitForSeconds(.5f);
        XMLDebug.Log("Screenshots only available in iOS/Android mode!");
#endif
    }

    public static void CallBackFun(bool suc)
    {
        SaveFinished(suc);
    }
}
