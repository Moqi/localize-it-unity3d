using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GuiExample : MonoBehaviour
{
    int mCurrentLangIndex = 0;
    string mUserName = "Alexi Smallrus";
    GUIStyle centerStyle;

    void Start()
    {
        mCurrentLangIndex = Array.IndexOf(EntryPoint.Localize.AvailableLocales, EntryPoint.Localize.CurrentLocaleId);
        centerStyle = new GUIStyle ();
        centerStyle.alignment = TextAnchor.MiddleCenter;
        centerStyle.normal.textColor = Color.white;
    }


    void OnGUI ()
    {
        // Make a background box
        mUserName = GUI.TextField (new Rect (10, 20, 240, 20), mUserName);
        GUI.Box (new Rect (10, 50, 240, 200), EntryPoint.Localize.Get ("current_language"));

        if (GUI.Button (new Rect (40, 80, 180, 20), EntryPoint.Localize.Get ("switch_language_button_name")))
            SwitchLanguage ();

        GUI.Label (new Rect (40, 110, 180, 20), EntryPoint.Localize.Get ("description", new Dictionary<string, string>(){{"userName", mUserName}}), centerStyle);
    }

    void SwitchLanguage()
    {
        mCurrentLangIndex++;
        var locales = EntryPoint.Localize.AvailableLocales;
        if (mCurrentLangIndex >= locales.Length)
            mCurrentLangIndex = 0;
        EntryPoint.Localize.SetLocale (locales [mCurrentLangIndex]);
    }
}