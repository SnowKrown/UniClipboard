package com.pp.textClipboard;

import android.app.Activity;
import android.content.Context;
import android.content.ClipboardManager;
import android.content.ClipData;

public class ClipboardAndroid
{
	private static ClipboardManager myClipboard;
	private static Activity activity;
    
	static public void SetCopyBufferString (final String text)
	{
		Setup ();
		ClipData myClip;
		myClip = ClipData.newPlainText("text", text);
		myClipboard.setPrimaryClip(myClip);
	}
    
	static public String GetCopyBufferString ()
	{
		Setup ();
		ClipData abc = myClipboard.getPrimaryClip();
		ClipData.Item item = abc.getItemAt (0);
		return item.getText().toString();
	}
	
	static private void Setup ()
	{
		if (activity == null)
			activity = com.unity3d.player.UnityPlayer.currentActivity;
		
		if (myClipboard == null)
			myClipboard = (ClipboardManager)activity.getSystemService(Context.CLIPBOARD_SERVICE);
	}
}
