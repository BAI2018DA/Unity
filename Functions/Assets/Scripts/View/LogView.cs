using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogView : MonoBehaviour
{
    static List<string> logList = new List<string>();
    // Start is called before the first frame update

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 + 10, 10, Screen.width / 2 - 20, Screen.height - 20));
        foreach(string s in logList)
        {
            View.instance.GUILabel(s);
        }
        GUILayout.EndArea();
    }

    public static void Add(string s)
    {
        logList.Add(s);
    }
    public static void Clear()
    {
        logList.Clear();
    }
}
