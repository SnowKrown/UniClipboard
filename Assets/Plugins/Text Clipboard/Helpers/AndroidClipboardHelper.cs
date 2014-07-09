﻿using UnityEngine;

namespace ClipboardHelper
{
	internal class AndroidClipboardHelper : IClipboardHelper
	{
		private const string PLUGIN_NAME = "com.pp.textClipboard.ClipboardAndroid";

		public void SetClipboard (string exportData)	
		{
			if (Application.platform == RuntimePlatform.Android) 
			{
				AndroidJavaClass jc = new AndroidJavaClass (PLUGIN_NAME);
				jc.CallStatic ("SetCopyBufferString", exportData);
			}
		}

		public string GetClipboard ()
		{
			string retText = "";
			if (Application.platform == RuntimePlatform.Android) 
			{
				AndroidJavaClass unityPlayer = new AndroidJavaClass(PLUGIN_NAME);
				AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				retText = activity.Call <string> ("GetCopyBufferString");
			}
			return retText;
		}

		static void runOnUiThread() 
		{
			AndroidJavaClass jc = new AndroidJavaClass(PLUGIN_NAME);
			jc.CallStatic("GetCopyBufferString");
		}
	}
}
