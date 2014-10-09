using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Texture backgroundTexture;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		
		if(GUI.Button(new Rect(Screen.width * .25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "Play Game")) {
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(Screen.width * .25f, Screen.height * 0.62f, Screen.width * 0.5f, Screen.height * 0.1f), "Exit")) {
			print ("Clicked");
		}
	}
}
