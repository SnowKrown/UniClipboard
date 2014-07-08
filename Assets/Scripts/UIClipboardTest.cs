using UnityEngine;
using System.Collections;

public class UIClipboardTest : MonoBehaviour 
{	
	private string text = "";

	private void OnGUI () 
	{
		text = GUILayout.TextField (text, GUILayout.MinWidth (500), GUILayout.MinHeight (100));

		if (GUILayout.Button ("Save to clipboard", GUILayout.MinWidth (120), GUILayout.MinHeight (60)))
			Clipboard.value = text;
	}
}
