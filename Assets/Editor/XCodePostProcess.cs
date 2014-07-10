using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UniClipboard
{
	using Debug = UnityEngine.Debug;

	public static class PostProcess
	{
		[PostProcessBuild]
		public static void OnPostProcessBuild(BuildTarget target, string path)
		{
			var project = new UnityEditor.XCodeEditor.XCProject(path);

			string[] files = Directory.GetFiles (Application.dataPath, "TextClipboard.cs", SearchOption.AllDirectories);

			var projmodsPath = Path.Combine(Path.GetDirectoryName(files[0]), "Editor/textClipboard.projmods");

			project.ApplyMod(projmodsPath);
			List<string> targetGuids = new List<string>();
			targetGuids.Add(project.GetFile("TextClipboardIOS.mm").guid);

			foreach(var file in project.buildFiles)
			{
				if(!targetGuids.Contains((string)file.Value.data["fileRef"])) 
					continue;
				file.Value.AddCompilerFlag("-fobjc-arc");
			}

			project.Save();
		}
	}
}
