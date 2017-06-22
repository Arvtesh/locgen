using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocConfig
	{
		/// <summary>
		/// 
		/// </summary>
		SourceFileType SourceFileType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		string SourceFilePath { get; set; }

		/// <summary>
		/// 
		/// </summary>
		CodeGenType CodeGenType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		ILocCodeGeneratorSettings CodeGenSettings { get; }

		/// <summary>
		/// 
		/// </summary>
		ResGenType ResGenType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		ILocResGeneratorSettings ResGenSettings { get; }
	}
}
