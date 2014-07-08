using UnityEngine;
using System.Collections;
using ClipboardHelper;

public static class Clipboard
{
	public static string value
	{
		set
		{
#if UNITY_IOS && !UNITY_EDITOR
			iOS.SetClipboard(value);
#elif UINITY_ANDROID && !UNITY_EDITOR
			AndroidClipboardHelper.SetClipboard (value);
#else
			PC.Clipboard = value;
#endif
		}

		get
		{
#if UNITY_IOS && !UNITY_EDITOR
			return iOS.GetClipboard();
#elif UINITY_ANDROID && !UNITY_EDITOR
			return AndroidClipboardHelper.GetClipboard ();
#else
			return PC.Clipboard;
#endif
		}
	}
}
