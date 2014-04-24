using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace LocalizeIt
{
    public class LocalizeItStorage
    {
        public string CurrentLocaleId {
            get;
            private set;
        }
        Dictionary<string, Dictionary<string, object>> mLocales = new Dictionary<string, Dictionary<string, object>> ();

        public string Get (string _id)
        {
            if (Storage.ContainsKey (_id))
                return (string)Storage [_id];

            Debug.LogWarning (string.Format ("LocalizeIt: Undefined value for key: \"{0}\". locale id: \"{1}\"", _id, CurrentLocaleId));
            return "undefined text";
        }

        public void AddLocaleSource (string _source, string _localeId)
        {
            var source = JSON.Parse (_source);
            mLocales.Add (_localeId, source);
        }

        public void SetLocale (string _localeId)
        {
            if (!mLocales.ContainsKey (_localeId))
                throw new KeyNotFoundException (string.Format ("LocalizeId: Undefined localeId: {0}", _localeId));
            CurrentLocaleId = _localeId;
            Storage = mLocales [_localeId];
        }

        public string[] AvailableLocales {
            get { return mLocales.Keys.ToArray (); }
        }

        Dictionary<string, object> Storage;
    }
}