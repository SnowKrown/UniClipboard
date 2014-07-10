using UnityEngine;

namespace ClipboardHelper
{
	internal class AndroidClipboardHelper : IClipboardHelper
	{
#if UNITY_ANDROID
		private const string PLUGIN_NAME = "com.pp.textClipboard.ClipboardAndroid";

		public void Call_SetClipboard (string exportData)	
		{
			AndroidJavaClass jc = new AndroidJavaClass (PLUGIN_NAME);
			jc.CallStatic ("SetCopyBufferString", exportData);
		}

		public string Call_GetClipboard ()
		{
			string retText = "";
			AndroidJavaClass unityPlayer = new AndroidJavaClass(PLUGIN_NAME);
			AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			retText = activity.Call <string> ("GetCopyBufferString");
			return retText;
		}

		static void runOnUiThread() 
		{
			AndroidJavaClass jc = new AndroidJavaClass(PLUGIN_NAME);
			jc.CallStatic("GetCopyBufferString");
		}
#endif

		public void SetClipboard (string text)
		{
#if UNITY_ANDROID
			Call_SetClipboard (text);
#endif
		}

		public string GetClipboard ()
		{
			string ret = "";
#if UNITY_ANDROID
			ret = Call_GetClipboard ();
#endif
			return ret;
		}
	}
}
