using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public enum ResGenType
	{
		/// <summary>
		/// 
		/// </summary>
		None,

		/// <summary>
		/// 
		/// </summary>
		ResX,

		/// <summary>
		/// 
		/// </summary>
		Json,
	}

	/// <summary>
	/// 
	/// </summary>
	public interface ILocResGeneratorSettings : ILocGeneratorSettings
	{
	}
}
