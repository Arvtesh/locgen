using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeUnit : ILocTreeItem
	{
		/// <summary>
		/// Returns text for this unit using neutral language. Read only.
		/// </summary>
		string SrcValue { get; }

		/// <summary>
		/// Returns localized text for this unit (for the target language). Read only.
		/// </summary>
		string TargetValue { get; }
	}
}
