using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LocalizeIt;
using JsonFx;

public class EntryPoint : MonoBehaviour
{
    void Awake ()
    {
        EntryPoint.Localize = new LocalizeItStorage ();

        var manifestSource = Resources.Load<TextAsset> ("localize_it/manifest").text;
        var manifest = JSON.Parse (manifestSource);
        var locales = (string[])manifest ["locales"];

        string path = "localize_it/{0}/locale";
        for (int i = 0; i < locales.Length; i++) {
            var localeId = locales [i];
            var localeSource = Resources.Load<TextAsset> (string.Format (path, localeId)).text;
            Localize.AddLocaleSource (localeSource, localeId);
        }

        Localize.SetLocale ("ru-RU");
        this.gameObject.AddComponent<GuiExample> ();
    }

    public static LocalizeItStorage Localize;
}