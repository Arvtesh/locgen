using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeText : ILocTreeUnit
	{
		/// <summary>
		/// Returns text for this unit using neutral language. Read only.
		/// </summary>
		string SrcValue { get; set; }

		/// <summary>
		/// Returns localized text for this unit (using the target language). Read only.
		/// </summary>
		string TargetValue { get; set; }
	}
}
