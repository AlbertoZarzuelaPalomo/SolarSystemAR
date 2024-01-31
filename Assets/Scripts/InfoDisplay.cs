using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    public GUISkin guiSkin;

    Rect windowRect = new Rect(0, 0, 400, 380);

    // Start is called before the first frame update
    void Start()
    {
        windowRect.x = (Screen.width - windowRect.width) / 2;
        windowRect.y = (Screen.height - windowRect.height) / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        GUI.skin = guiSkin;
        //windowRect = GUI.Window()
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");

    }
    void DoMyWindow(int windowID)
    {

        GUI.Box(new Rect(10, 50, 120, 250), "LORE IPSUM");
    }
}
