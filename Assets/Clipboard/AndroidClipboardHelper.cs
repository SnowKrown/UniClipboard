using UnityEngine;

namespace ClipboardHelper
{
	internal class AndroidClipboardHelper
	{
		public static void SetClipboard (string exportData)	
		{
			if (Application.platform == RuntimePlatform.Android) 
			{
				AndroidJavaClass jc = new AndroidJavaClass ("JavaClipboardClass");
				jc.CallStatic ("SetCopyBufferString", exportData);
			}
		}

		public static string GetClipboard ()
		{
			string retText = "";
			if (Application.platform == RuntimePlatform.Android) 
			{
				AndroidJavaClass unityPlayer = new AndroidJavaClass("JavaClipboardClass");
				AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				retText = activity.Call <string> ("GetCopyBufferString");
			}
			return retText;
		}
	}
}
