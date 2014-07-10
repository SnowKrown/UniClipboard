using UnityEngine;
using System.Collections;

public class UIClipboardSample : MonoBehaviour 
{
	private string dataToSave = "";

	private void OnGUI () 
	{
		GUI.color = Color.green;
		dataToSave = GUILayout.TextField (dataToSave, GUILayout.MinWidth (500), GUILayout.MinHeight (100));

		if (GUILayout.Button ("Save to clipboard", GUILayout.MinWidth (120), GUILayout.MinHeight (60)))
			TextClipboard.SetText (dataToSave);

	}
}
