using UnityEngine;
using System.Collections;
using ClipboardHelper;

public static class Clipboard
{
	public static string Value
	{
		set
		{
			Debug.Log ("Set clipboard value " + value);

			if (Application.platform == RuntimePlatform.IPhonePlayer)
				iOS.SetClipboard(value);
			else if (Application.platform == RuntimePlatform.Android)
				AndroidClipboardHelper.SetClipboard (value);
			else
				PC.Clipboard = value;
		}

		get
		{
			if (Application.platform == RuntimePlatform.IPhonePlayer)
				return iOS.GetClipboard();
			else if (Application.platform == RuntimePlatform.Android)
				return AndroidClipboardHelper.GetClipboard ();
			else
				return PC.Clipboard;
		}
	}
}
