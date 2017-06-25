using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeItem"/>.
	/// </summary>
	internal abstract class LocTreeItem : ILocTreeItem
	{
		#region data

		private readonly ILocTreeItem _parent;
		private readonly string _id;
		private readonly string _originalName;
		private readonly string _name;
		private readonly string _path;

		#endregion

		#region interface

		protected LocTreeItem(ILocTreeItem parent, string id, string name)
		{
			_parent = parent;
			_id = id;
			_originalName = string.IsNullOrEmpty(name) ? id : name;
			_name = GetName(_originalName);
			_path = parent != null ? parent.Path + '/' + _name : _name;
		}

		#endregion

		#region ILocTreeItem

		public string Id => _id;
		public string OriginalName => _originalName;
		public string Name => _name;
		public string Path => _path;
		public string Notes { get; set; }

		#endregion

		#region implementation

		private static string GetName(string name)
		{
			var result = new StringBuilder(name.Length);
			var nextCharUpper = true;

			for (int i = 0; i < name.Length; ++i)
			{
				var c = name[i];

				if (char.IsLetterOrDigit(c))
				{
					if (nextCharUpper)
					{
						result.Append(char.ToUpperInvariant(c));
						nextCharUpper = false;
					}
					else
					{
						result.Append(char.ToLowerInvariant(c));
					}
				}
				else
				{
					nextCharUpper = true;
				}
			}

			return result.ToString();
		}

		#endregion
	}
}
