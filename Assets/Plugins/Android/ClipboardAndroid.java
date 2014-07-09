package com.pp.textClipboard;

import java.util.logging.Logger;

import android.app.Activity;
import android.content.Context;
import android.content.ClipboardManager;
import android.content.ClipData;
import android.os.Bundle;
import android.util.Log;

import com.fuuzu.meat.UnityPlayerNativeActivity;
import com.unity3d.player.UnityPlayer;

public class ClipboardAndroid extends UnityPlayerNativeActivity
{
	public static ClipboardAndroid myInstance;
	public static ClipboardAndroid shared()
	{
		if(myInstance == null)
			myInstance = new ClipboardAndroid();
		return myInstance;
	}
	
	protected void onCreate(Bundle savedInstanceState) 
	{
	    super.onCreate(savedInstanceState);
	    myInstance = new ClipboardAndroid();
	  }
	
    static protected void runSafe (final Runnable r)
	{
		com.unity3d.player.UnityPlayer.currentActivity.runOnUiThread (new Runnable()
        {
			@Override
			public void run()
			{
				try
				{
					r.run();
				} 
				catch (Exception e)
				{
					
				}
				
			}
		});
	}

    
	public String GetCopyBufferString () 
	{
		String retText = "";
		final Activity activty = com.unity3d.player.UnityPlayer.currentActivity;
		android.content.ClipboardManager clipboard = (android.content.ClipboardManager) activty.getSystemService(Context.CLIPBOARD_SERVICE);
		ClipData clip = clipboard.getPrimaryClip();	

		if (clip != null && clip.getItemCount() > 0) 
		{
			ClipData.Item item = clip.getItemAt(0);
			retText = item.getText ().toString ();
		}
		
		return retText;
	}

	static public void SetCopyBufferString (final String text) 
	{
		runSafe(new Runnable()
		{
			@Override
			public void run()
			{
				final Activity activity = com.unity3d.player.UnityPlayer.currentActivity;
				android.content.ClipboardManager clipboard = (android.content.ClipboardManager) activity.getSystemService(Context.CLIPBOARD_SERVICE);
				clipboard.setPrimaryClip (ClipData.newPlainText(null, text));
			}
		});
	}
}