using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace ClipboardHelper
{
	internal class iOSClipboardHelper : IClipboardHelper
	{
	    [DllImport("__Internal")]
	    private static extern void _SetClipboard(string value);

	    [DllImport("__Internal")]
	    private static extern string _GetClipboard();

		public void SetClipboard(string value)
		{
			_SetClipboard(value);
		}

		public string GetClipboard()
		{
			return _GetClipboard();
		}
	}
}
