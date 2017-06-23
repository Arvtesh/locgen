﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A C# code generator.
	/// </summary>
	internal sealed class CsharpCodeGenerator : LocCodeGenerator
	{
		#region data
		#endregion

		#region interface

		public CsharpCodeGenerator(ILocCodeGeneratorSettings settings)
			: base(CodeGenType.Csharp.ToString(), settings)
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken)
		{
			WriteFileHeader(file, cancellationToken);
			WriteData(file, data, cancellationToken);
		}

		protected override string GetTargetFileExtension()
		{
			return ".generated.cs";
		}

		#endregion

		#region implementation

		private void WriteFileHeader(StreamWriter file, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			file.WriteLine("// <auto-generated>");
			file.WriteLine("// This code was generated with locgen. Do not edit.");
			file.WriteLine("// " + DateTime.Now.ToString(@"yyyy\/MM\/dd HH:mm"));
			file.WriteLine("// ");
			file.WriteLine("// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.");
			file.WriteLine("// </auto-generated>");
		}

		private void WriteData(StreamWriter file, ILocTree data, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			file.WriteLine("using System;");
			file.WriteLine("using System.Resources;");
			file.WriteLine();

			if (string.IsNullOrEmpty(Settings.TargetNamespace))
			{
				WriteLocTree(file, data, cancellationToken, 0);
			}
			else
			{
				file.WriteLine("namespace " + Settings.TargetNamespace);
				file.WriteLine('{');
				WriteLocTree(file, data, cancellationToken, 1);
				file.WriteLine('}');
			}
		}

		private void WriteLocTree(StreamWriter file, ILocTree tree, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			WriteLocNotes(file, tree, identLevel);

			if (Settings.StaticAccess)
			{
				WriteIdent(file, identLevel, "public static struct " + tree.Name);
				WriteIdent(file, identLevel, "{");
			}
			else
			{
				WriteIdent(file, identLevel, "public partial struct " + tree.Name);
				WriteIdent(file, identLevel, "{");

				WriteIdent(file, identLevel + 1, $"private readonly {Settings.ResourceManagerClassRef} _resourceManager;");
				file.WriteLine();
				WriteIdent(file, identLevel + 1, $"public {tree.Name}({Settings.ResourceManagerClassRef} resourceManager) {{ _resourceManager = resourceManager; }}");
				file.WriteLine();
			}

			WriteLocGroupContent(file, tree, cancellationToken, identLevel + 1);
			WriteIdent(file, identLevel, "}");

			if (Settings.GenerateLocKeys)
			{
				file.WriteLine();

				WriteLocNotes(file, tree, identLevel);
				WriteIdent(file, identLevel, "public static class " + tree.Name + "Keys");
				WriteIdent(file, identLevel, "{");
				WriteLocGroupContentKeys(file, tree, cancellationToken, identLevel + 1);
				WriteIdent(file, identLevel, "}");
			}
		}

		private void WriteLocGroupContent(StreamWriter file, ILocTreeGroup group, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			foreach (var item in group.Groups)
			{
				WriteLocGroup(file, item, cancellationToken, identLevel);
				file.WriteLine();
			}

			foreach (var item in group.Units)
			{
				WriteLocUnit(file, item, cancellationToken, identLevel);
				file.WriteLine();
			}
		}

		private void WriteLocGroupContentKeys(StreamWriter file, ILocTreeGroup group, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			foreach (var item in group.Groups)
			{
				WriteLocGroupKeys(file, item, cancellationToken, identLevel);
				file.WriteLine();
			}

			foreach (var item in group.Units)
			{
				WriteLocUnitKeys(file, item, cancellationToken, identLevel);
				file.WriteLine();
			}
		}

		private void WriteLocGroup(StreamWriter file, ILocTreeGroup group, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (Settings.StaticAccess)
			{
				WriteLocNotes(file, group, identLevel);
				WriteIdent(file, identLevel, $"public static class {group.Name}");
				WriteIdent(file, identLevel, "{");

				WriteLocGroupContent(file, group, cancellationToken, identLevel + 1);

				WriteIdent(file, identLevel, "}");
			}
			else
			{
				var groupClassName = GetGroupClassName(group.Name);

				WriteIdent(file, identLevel, $"public struct {groupClassName}");
				WriteIdent(file, identLevel, "{");

				WriteIdent(file, identLevel + 1, $"private readonly {Settings.ResourceManagerClassRef} _resourceManager;");
				file.WriteLine();
				WriteIdent(file, identLevel + 1, $"internal {groupClassName}({Settings.ResourceManagerClassRef} resourceManager) {{ _resourceManager = resourceManager; }}");
				file.WriteLine();

				WriteLocGroupContent(file, group, cancellationToken, identLevel + 1);
				WriteIdent(file, identLevel, "}");
				file.WriteLine();

				WriteLocNotes(file, group, identLevel);
				WriteIdent(file, identLevel, $"public {groupClassName} {group.Name} {{ get {{ return new {groupClassName}(_resourceManager); }} }}");
			}
		}

		private void WriteLocGroupKeys(StreamWriter file, ILocTreeGroup group, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			WriteLocNotes(file, group, identLevel);
			WriteIdent(file, identLevel, $"public static class {group.Name}");
			WriteIdent(file, identLevel, "{");

			WriteLocGroupContentKeys(file, group, cancellationToken, identLevel + 1);
			WriteIdent(file, identLevel, "}");
		}

		private void WriteLocUnit(StreamWriter file, ILocTreeUnit unit, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			WriteLocNotes(file, unit, identLevel);

			if (Settings.StaticAccess)
			{
				WriteIdent(file, identLevel, $"public static string {unit.Name} {{ get {{ return {Settings.ResourceManagerClassRef}.{Settings.ResourceManagerGetStringMethod}(\"{unit.Id}\"); }} }}");
			}
			else
			{
				WriteIdent(file, identLevel, $"public string {unit.Name} {{ get {{ return _resourceManager.{Settings.ResourceManagerGetStringMethod}(\"{unit.Id}\"); }} }}");
			}
		}

		private void WriteLocUnitKeys(StreamWriter file, ILocTreeUnit unit, CancellationToken cancellationToken, int identLevel)
		{
			cancellationToken.ThrowIfCancellationRequested();

			WriteLocNotes(file, unit, identLevel);
			WriteIdent(file, identLevel, $"public const string {unit.Name} = \"{unit.Id}\";");
		}

		private void WriteLocNotes(StreamWriter file, ILocTreeItem item, int identLevel)
		{
			var hasNotes = !string.IsNullOrEmpty(item.Notes);

			WriteIdent(file, identLevel, "/// <summary>");

			if (item is ILocTreeText textUnit)
			{
				if (!string.IsNullOrEmpty(textUnit.SrcValue))
				{
					var first = true;

					foreach (var line in textUnit.SrcValue.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (first)
						{
							first = false;
							WriteIdent(file, identLevel, "/// " + item.Path + ": " + line);
						}
						else
						{
							WriteIdent(file, identLevel, "/// " + line);
						}
					}
				}
				else
				{
					WriteIdent(file, identLevel, "/// " + item.Path);
				}
			}
			else
			{
				WriteIdent(file, identLevel, "/// " + item.Path);
			}

			WriteIdent(file, identLevel, "/// </summary>");

			WriteIdent(file, identLevel, "/// <remarks>");
			WriteIdent(file, identLevel, "/// ItemId: " + item.Id);
			WriteIdent(file, identLevel, "/// OriginalName: " + item.OriginalName);

			if (hasNotes)
			{
				var first = true;

				foreach (var line in item.Notes.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (first)
					{
						first = false;
						WriteIdent(file, identLevel, "/// Notes: " + line);
					}
					else
					{
						WriteIdent(file, identLevel, "///        " + line);
					}
				}
			}

			WriteIdent(file, identLevel, "/// </remarks>");
		}

		private static string GetGroupClassName(string groupName)
		{
			return '_' + groupName + "_Proxy";
		}

		#endregion
	}
}
