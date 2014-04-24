using UnityEngine;
using System.Collections;

public class GuiExample : MonoBehaviour {

	void Start () {
	
	}

    void OnGUI () {
        // Make a background box
        GUI.Box(new Rect(10,10,200,90), EntryPoint.Localize.Get("menu_title"));

        if(GUI.Button(new Rect(20,40,180,20), EntryPoint.Localize.Get("button_name"))) {
            Debug.Log ("click to button 1");
        }

        if(GUI.Button(new Rect(20,70,180,20), EntryPoint.Localize.Get("another_button_name"))) {
            Debug.Log ("click to button 2");
        }
    }
	
	void Update () {
	
	}
}
