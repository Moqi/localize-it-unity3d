using System;
using System.Collections.Generic;
using UnityEngine;

public class JSON
{
    public static Dictionary<string, object> Parse(string _source)
    {
        var reader = new JsonFx.Json.JsonReader ();
        return (Dictionary<string, object>) reader.Read (_source);
    }
}