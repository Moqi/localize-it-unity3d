using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

namespace LocalizeIt
{
    public class LocalizeItStorage
    {
        private string mCurrentLocaleId;
        Dictionary<string, SimpleJSON.JSONNode> mLocales = new Dictionary<string, SimpleJSON.JSONNode> ();

        public string Get(string _id)
        {
            if (Storage[_id] != null)
                return Storage [_id].Value;

            Debug.LogWarning (string.Format("LocalizeIt: Undefined value for key: {0}", _id));
            return "";
        }

        public void AddLocaleSource(string _source, string _localeId)
        {
            var source = SimpleJSON.JSON.Parse (_source);
            mLocales.Add (_localeId, source);

        }

        public void SetLocale(string _localeId)
        {
            if (!mLocales.ContainsKey (_localeId))
                throw new KeyNotFoundException (string.Format("LocalizeId: Undefined localeId: {0}", _localeId));
            mCurrentLocaleId = _localeId;
            Storage = mLocales [_localeId];
        }

        SimpleJSON.JSONNode Storage;
    }
}