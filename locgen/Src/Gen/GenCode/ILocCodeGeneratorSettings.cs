using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public enum CodeGenType
	{
		/// <summary>
		/// 
		/// </summary>
		None,

		/// <summary>
		/// 
		/// </summary>
		Csharp,

		/// <summary>
		/// 
		/// </summary>
		CsharpUnity3d,

		/// <summary>
		/// 
		/// </summary>
		Cpp,
	}

	/// <summary>
	/// 
	/// </summary>
	public interface ILocCodeGeneratorSettings : ILocGeneratorSettings
	{
		/// <summary>
		/// Gets or sets name of the namespace for the generated file.
		/// </summary>
		string TargetNamespace { get; set; }

		/// <summary>
		/// If <c>true</c> constants class is generated.
		/// </summary>
		bool GenerateLocKeys { get; set; }

		/// <summary>
		/// If <c>true</c> all localization items should have static access.
		/// </summary>
		bool StaticAccess { get; set; }

		/// <summary>
		/// Gets or sets name of the resource manager class.
		/// </summary>
		string ResourceManagerClassRef { get; set; }

		/// <summary>
		/// Gets or sets name of the GetString() method of the resource manager class specified with <see cref="ResourceManagerClassRef"/>.
		/// </summary>
		string ResourceManagerGetStringMethod { get; set; }

		/// <summary>
		/// Gets or sets name of the GetObject() method of the resource manager class specified with <see cref="ResourceManagerClassRef"/>.
		/// </summary>
		string ResourceManagerGetObjectMethod { get; set; }
	}
}
