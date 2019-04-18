using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GetPermission : MonoBehaviour
{
    string[] permissionArray = { Permission.ExternalStorageWrite };
    public static string FILE_NAME = "1.png";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePictureFinished(bool suc)
    {
        if (suc)
            LogView.Add("Save Success!");
        else
            LogView.Add("Save Failed!");
    }

    private void OnGUI()
    {
        if(View.instance.GUIButton("ScreenShot", 200, 60))
        {
            // 注意 android 不能带路径
            ScreenCapture.CaptureScreenshot(FILE_NAME);
            LogView.Add("ScreenShot Success!");
        }
        if(View.instance.GUIButton("SaveToGallery", 200, 60))
        {
            SavePicToGallery.SaveFinished += SavePictureFinished;
            StartCoroutine(SavePicToGallery.Save(Application.persistentDataPath + "/" + FILE_NAME));
            LogView.Add("SaveToGallery Complete!");
        }
        if (View.instance.GUIButton("Check", 200, 60))
        {
            foreach(string s in permissionArray)
            {
                if(Permission.HasUserAuthorizedPermission(s))
                {
                    LogView.Add(string.Format("{0} permission has been granted.", s));
                }
                else
                {
                    LogView.Add(string.Format("{0} permission has not been granted.", s));
                }
            }
        }
        if (View.instance.GUIButton("Request", 200, 60))
        {
            foreach (string s in permissionArray)
            {
                if (Permission.HasUserAuthorizedPermission(s))
                {
                    LogView.Add(string.Format("{0} permission has been granted.", s));
                }
                else
                {
                    LogView.Add(string.Format("Request {0} permission ...", s));
                    Permission.RequestUserPermission(s);
                }
            }
        }
    }
}
