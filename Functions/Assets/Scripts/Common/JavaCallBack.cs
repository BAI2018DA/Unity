using UnityEngine;
using System.Collections;

public class JavaCallBack : MonoBehaviour {

    void SavePicToGalleryMsg(string errorStr)
    {
        if (string.IsNullOrEmpty(errorStr))
        {
            LogView.Add("Save picture to gallery success!");
            SavePicToGallery.CallBackFun(true);
        }
        else
        {
            string msg = string.Format("Save picture to gallery failed! error msg:{0}", errorStr);
            LogView.Add(msg);
            SavePicToGallery.CallBackFun(false);
        }
    }
}
