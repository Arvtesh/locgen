using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTree : ILocTreeGroup
	{
		/// <summary>
		/// Returns global settings for the localization data in this instance. Read only.
		/// </summary>
		ILocTreeSettings Settings { get; }
	}
}
