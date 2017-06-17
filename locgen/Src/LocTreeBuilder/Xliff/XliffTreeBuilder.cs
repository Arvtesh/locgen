using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Localization.Xliff.OM;
using Localization.Xliff.OM.Core;
using Localization.Xliff.OM.Serialization;

namespace locgen.Impl
{
	/// <summary>
	/// A XLIFF tree builder.
	/// </summary>
	internal sealed class XliffTreeBuilder : LocTreeBuilder
	{
		#region data
		#endregion

		#region interface

		public XliffTreeBuilder()
			: base("XLIFF")
		{
		}

		#endregion

		#region LocTreeBuilder

		protected override ILocTree[] ReadInternal(Stream stream)
		{
			var reader = new XliffReader();
			var doc = reader.Deserialize(stream);
			var files = doc.Files;
			var result = new ILocTree[files.Count];

			for (int i = 0; i < result.Length; ++i)
			{
				result[i] = ReadTree(files[i]);
			}

			return result;
		}

		#endregion

		#region implementation

		private ILocTree ReadTree(Localization.Xliff.OM.Core.File file)
		{
			var tree = new LocTree(file.Id, file.Id);

			ReadNotes(tree, file);

			foreach (var c in file.Containers)
			{
				if (c is Unit u)
				{
					ReadUnit(tree, u);
				}
				else if (c is Group g)
				{
					ReadGroup(tree, g);
				}
			}

			return tree;
		}

		private void ReadUnit(ILocTreeGroup group, Unit xlfUnit)
		{
			var unit = group.AddUnit(xlfUnit.Id, xlfUnit.Name);

			ReadSrcValue(unit, xlfUnit);
			ReadTargetValue(unit, xlfUnit);
			ReadNotes(unit, xlfUnit);
		}

		private void ReadGroup(ILocTreeGroup group, Group xlfGroup)
		{
			var childGroup = group.AddGroup(xlfGroup.Id, xlfGroup.Name);

			ReadNotes(childGroup, xlfGroup);

			foreach (var c in xlfGroup.Containers)
			{
				if (c is Unit u)
				{
					ReadUnit(childGroup, u);
				}
				else if (c is Group g)
				{
					ReadGroup(childGroup, g);
				}
			}
		}

		private void ReadSrcValue(ILocTreeUnit unit, Unit xlfUnit)
		{
			var segments = xlfUnit.Resources;
			var segmentsCount = segments.Count;

			if (segmentsCount > 0)
			{
				var result = new StringBuilder(256);

				for (int i = 0; i < segmentsCount; ++i)
				{
					var segmentText = segments[i].Source.Text;

					if (i > 0)
					{
						result.AppendLine();
					}

					for (int j = 0; j < segmentText.Count; ++j)
					{
						if (j > 0)
						{
							result.AppendLine();
						}

						result.Append(segmentText[j].ToString());
					}
				}

				unit.SrcValue = result.ToString();
			}
		}

		private void ReadTargetValue(ILocTreeUnit unit, Unit xlfUnit)
		{
			var segments = xlfUnit.Resources;
			var segmentsCount = segments.Count;

			if (segmentsCount > 0)
			{
				var result = new StringBuilder(256);

				for (int i = 0; i < segmentsCount; ++i)
				{
					var segmentTarget = segments[i].Target;

					if (segmentTarget != null)
					{
						var segmentText = segmentTarget.Text;

						if (i > 0)
						{
							result.AppendLine();
						}

						for (int j = 0; j < segmentText.Count; ++j)
						{
							if (j > 0)
							{
								result.AppendLine();
							}

							result.Append(segmentText[j].ToString());
						}
					}
				}

				unit.TargetValue = result.ToString();
			}
		}

		private void ReadNotes(ILocTreeItem item, INoteContainer xlfNotes)
		{
			if (xlfNotes.HasNotes)
			{
				var notesList = xlfNotes.Notes;

				if (notesList.Count > 1)
				{
					var notes = new StringBuilder(256);
					var first = true;

					foreach (var note in notesList)
					{
						if (first)
						{
							first = false;
						}
						else
						{
							notes.AppendLine();
						}

						notes.Append(note.Text);
					}

					item.Notes = notes.ToString();
				}
				else
				{
					item.Notes = notesList[0].Text;
				}
			}
		}

		#endregion
	}
}
