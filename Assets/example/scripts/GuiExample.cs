using UnityEngine;
using System.Collections;
using System;

public class GuiExample : MonoBehaviour
{
    int mCurrentLangIndex = 0;

    void Start()
    {
        mCurrentLangIndex = Array.IndexOf(EntryPoint.Localize.AvailableLocales, EntryPoint.Localize.CurrentLocaleId);
    }

    void OnGUI ()
    {
        // Make a background box
        GUI.Box (new Rect (10, 10, 200, 90), EntryPoint.Localize.Get ("current_language"));

        if (GUI.Button (new Rect (20, 40, 180, 20), EntryPoint.Localize.Get ("switch_language_button_name")))
            SwitchLanguage ();

        if (GUI.Button (new Rect (20, 70, 180, 20), EntryPoint.Localize.Get ("just_button_name"))) {
            Debug.Log ("click to button 2");
        }
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