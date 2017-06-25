using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// A generic <see cref="ILocTree"/> item.
	/// </summary>
	public interface ILocTreeItem
	{
		/// <summary>
		/// Returns unique identifier of the item. Read only.
		/// </summary>
		string Id { get; }

		/// <summary>
		/// Returns the original item name. Read only.
		/// </summary>
		string OriginalName { get; }

		/// <summary>
		/// Returns the item name. Read only.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Returns the item path (for exmaple <c>xxx/yyy/zzz</c>). Read only.
		/// </summary>
		string Path { get; }

		/// <summary>
		/// Gets or sets item comment string.
		/// </summary>
		string Notes { get; set; }
	}
}
