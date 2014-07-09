using UnityEngine;
using System;
using System.Reflection;

namespace ClipboardHelper
{
	internal class PCClipboardHelper : IClipboardHelper
	{
		private static PropertyInfo m_systemCopyBufferProperty = null;
		private PropertyInfo P;

		public PCClipboardHelper ()
		{
			P = GetSystemCopyBufferProperty ();
		}

		public void SetClipboard (string text)
		{
			P.SetValue (null, text, null);
		}

		public string GetClipboard ()
		{
			return (string)P.GetValue (null, null);
		}

		private PropertyInfo GetSystemCopyBufferProperty ()
		{
			SetSystemCopyBufferProperty ();
			return m_systemCopyBufferProperty;
		}

		private void SetSystemCopyBufferProperty ()
		{
			if (m_systemCopyBufferProperty == null)
			{
				Type T = typeof (GUIUtility);
				m_systemCopyBufferProperty = T.GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.NonPublic);
			}
		}
	}
}
