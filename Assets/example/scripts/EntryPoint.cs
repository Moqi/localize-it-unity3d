using UnityEngine;
using System.Collections;
using LocalizeIt;

public class EntryPoint : MonoBehaviour
{
    void Awake ()
    {
        EntryPoint.Localize = new LocalizeItStorage ();
      
        var manifest = Resources.Load<TextAsset> ("localize_it/manifest").text;
        var locales = SimpleJSON.JSON.Parse (manifest) ["locales"].AsArray;
        string path = "localize_it/{0}/locale";
        for (int i = 0; i < locales.Count; i++) {
            var localeId = locales [i].Value;
            var localeSource = Resources.Load<TextAsset> (string.Format (path, localeId)).text;
            Localize.AddLocaleSource (localeSource, localeId);
        }

        Localize.SetLocale ("en-US");
        Debug.Log (Localize.Get("button_name"));
        Localize.SetLocale ("ru-RU");
        Debug.Log (Localize.Get("button_name"));
        this.gameObject.AddComponent<GuiExample> ();
    }

    public static LocalizeItStorage Localize;
}