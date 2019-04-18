using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public static View instance;

    public GUISkin gs;
    private Vector2 _whScale;
    public Vector2 whScale
    {
        get { return _whScale; }
        set { _whScale = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _whScale = new Vector2(Screen.width / 1136.0f, Screen.height / 640.0f);
    }

    public bool GUIButton(string s, float w, float h)
    {
        return GUILayout.Button(s, gs.GetStyle("Button"), GUILayout.Width(w * _whScale.x), GUILayout.Height(h * _whScale.y));
    }

    public void GUILabel(string s)
    {
        GUILayout.Label(s, gs.GetStyle("Label"));
    }
}
