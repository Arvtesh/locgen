using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeItem
	{
		/// <summary>
		/// Returns unique identifier of the item. Read only.
		/// </summary>
		string Id { get; }

		/// <summary>
		/// Returns the item name. Read only.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets or sets item comment string.
		/// </summary>
		string Notes { get; set; }
	}
}
