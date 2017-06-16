using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocCodeGeneratorSettings
	{
		/// <summary>
		/// Gets or sets the path for the generated file (including file name and extension).
		/// </summary>
		string TargetPath { get; set; }

		/// <summary>
		/// Gets or sets name of the namespace for the generated file.
		/// </summary>
		string TargetNamespace { get; set; }

		/// <summary>
		/// Gets or sets ident size (in spaces) for the generated file.
		/// </summary>
		int IdentSize { get; set; }

		/// <summary>
		/// If <c>true</c> constants class is generated.
		/// </summary>
		bool GenerateLocKeys { get; set; }

		/// <summary>
		/// Gets or sets name of the resource manager class.
		/// </summary>
		string ResourceManagerClassName { get; set; }

		/// <summary>
		/// Gets or sets name of the GetString() method of the resource manager class specified with <see cref="ResourceManagerClassName"/>.
		/// </summary>
		string ResourceManagerGetStringMethodName { get; set; }
	}
}
