package com.pp.test;

import android.app.Activity;
import android.content.Context;
import android.content.ClipboardManager;
import android.content.ClipData;
import com.unity3d.player.UnityPlayer;

public class Clipboard 
{
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
				} catch (Exception e)
				{
					
				}
				
			}
		});
	}

	static public void SetCopyBufferString(final String text) 
	{
		runSafe(new Runnable()
		{
			@Override
			public void run()
			{
				final Activity activty = com.unity3d.player.UnityPlayer.currentActivity;
				android.content.ClipboardManager clipboard = (android.content.ClipboardManager) activty.getSystemService(Context.CLIPBOARD_SERVICE);
				clipboard.setPrimaryClip(ClipData.newPlainText(null, text));
			}
		});
	}
}
