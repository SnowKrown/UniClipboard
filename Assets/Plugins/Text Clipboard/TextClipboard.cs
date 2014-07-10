using UnityEngine;
using System.Collections;
using ClipboardHelper;

public class TextClipboard
{
	private static IClipboardHelper myClipboard;

	public static void SetText (string text)
	{
		SetUp ();
		myClipboard.SetClipboard (text);
	}

	public static string GetText ()
	{
		SetUp ();
		return myClipboard.GetClipboard ();
	}

	private static void SetUp ()
	{
		if (myClipboard == null)
			SetMyClipboard (Application.platform);
	}

	private static void SetMyClipboard (RuntimePlatform platform)
	{
		switch (platform)
		{
		case RuntimePlatform.Android:
			myClipboard = new AndroidClipboardHelper ();
			break;
		case RuntimePlatform.IPhonePlayer:
			myClipboard = new iOSClipboardHelper ();
		break;
		default:
			myClipboard = new PCClipboardHelper ();
			break;
		}
	}
}

public interface IClipboardHelper
{
	void SetClipboard (string text);
	string GetClipboard ();
}
