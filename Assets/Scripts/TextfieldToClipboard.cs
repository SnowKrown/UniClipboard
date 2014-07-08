using UnityEngine;

public class TextfieldToClipboard : MonoBehaviour 
{
	[SerializeField]
	private float width = 300;

	private string myText = "";

	private void OnGUI ()
	{
		DrawWindow ();
	}

	private void DrawWindow ()
	{
		myText = GUILayout.TextField (myText, GUILayout.MinWidth (width));

		if (GUILayout.Button ("Copy to Clipboard", GUILayout.MinWidth (width)))
			UniClipboard.value = myText;
	}
}
