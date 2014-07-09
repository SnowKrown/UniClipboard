using UnityEngine;

namespace ClipboardHelper
{
	internal class AndroidClipboardHelper : IClipboardHelper
	{
		private const string PLUGIN_NAME = "com.pp.textClipboard.ClipboardAndroid";
		private static AndroidJavaClass javaClass;
		private AndroidJavaObject activity;

		public AndroidClipboardHelper ()
		{
#if UNITY_ANDROID
			javaClass = new AndroidJavaClass (PLUGIN_NAME);
			activity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
#endif
		}

		public void SetClipboard (string exportData)	
		{
			javaClass.CallStatic ("SetCopyBufferString", exportData);
		}

		public string GetClipboard ()
		{
			string retText = "";
			retText = activity.Call <string> ("GetCopyBufferString");
			return retText;
		}

		static void runOnUiThread() 
		{
			javaClass.CallStatic ("GetCopyBufferString");
		}
	}
}
