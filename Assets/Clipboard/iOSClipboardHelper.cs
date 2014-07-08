﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace ClipboardHelper
{
	internal static class iOS
	{
	    [DllImport("__Internal")]
	    private static extern void _SetClipboard(string value);

	    [DllImport("__Internal")]
	    private static extern string _GetClipboard();

		public static void SetClipboard(string value)
		{
			_SetClipboard(value);
		}

		public static string GetClipboard()
		{
			return _GetClipboard();
		}
	}
}
