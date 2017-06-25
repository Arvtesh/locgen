using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace locgen.Impl
{
	/// <summary>
	/// A JSON tree builder.
	/// </summary>
	internal sealed class JsonTreeBuilder : LocTreeBuilder
	{
		#region data
		#endregion

		#region interface

		public JsonTreeBuilder()
			: base(LocTreeSourceType.Json.ToString())
		{
		}

		#endregion

		#region LocTreeBuilder

		protected override void ReadInternal(ILocTreeSet treeSet, Stream stream)
		{
			using (var textStream = new StreamReader(stream))
			{
				using (var textStreamReader = new JsonTextReader(textStream))
				{
					var serializer = JsonSerializer.Create();
					var treeData = serializer.Deserialize<JsonDataTree>(textStreamReader);

					foreach (var file in treeData.Files)
					{
						var tree = treeSet.Add(file.Id, file.Name);
						ReadTree(tree, file);
					}
				}
			}
		}

		#endregion

		#region implementation

		private void ReadTree(ILocTree tree, JsonDataGroup jsonDataGroup)
		{
			tree.Notes = jsonDataGroup.Notes;

			foreach (var u in jsonDataGroup.Units)
			{
				ReadUnit(tree, u);
			}

			foreach (var g in jsonDataGroup.Groups)
			{
				ReadGroup(tree, g);
			}
		}

		private void ReadGroup(ILocTreeGroup group, JsonDataGroup groupData)
		{
			var childGroup = group.AddGroup(groupData.Id, groupData.Name);

			childGroup.Notes = groupData.Notes;

			foreach (var u in groupData.Units)
			{
				ReadUnit(childGroup, u);
			}

			foreach (var g in groupData.Groups)
			{
				ReadGroup(childGroup, g);
			}
		}

		private void ReadUnit(ILocTreeGroup group, JsonDataUnit u)
		{
			switch (u.Type)
			{
				case "text":
					{
						var unit = group.AddText(u.Id, u.Name);
						unit.Notes = u.Notes;
						unit.SrcValue = u.SrcValue;
						unit.TargetValue = u.TargetValue;
					}
					break;

				case "texture":
					{
						var unit = group.AddTexture(u.Id, u.Name);
						unit.Notes = u.Notes;
						unit.SrcPath = u.SrcPath;
						unit.TargetPath = u.TargetPath;
					}
					break;

				case "audio":
					{
						var unit = group.AddAudio(u.Id, u.Name);
						unit.Notes = u.Notes;
						unit.SrcPath = u.SrcPath;
						unit.TargetPath = u.TargetPath;
					}
					break;
			}
		}

		#endregion
	}
}
