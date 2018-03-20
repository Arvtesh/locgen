using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
	internal sealed class LocCodeGeneratorSettings : LocGeneratorSettings
	{
		#region data

		private const string _defaultResourceManagerClassName = "ResourceManager";
		private const string _defaultResourceManagerGetStringMethodName = "GetString";
		private const string _defaultResourceManagerGetObjectMethodName = "GetObject";

		private string _resourceManagerClassName = _defaultResourceManagerClassName;
		private string _resourceManagerGetStringMethodName = _defaultResourceManagerGetStringMethodName;
		private string _resourceManagerGetObjectMethodName = _defaultResourceManagerGetObjectMethodName;

		#endregion

		#region interface

		public string TargetNamespace { get; set; }

		public bool GenerateLocKeys { get; set; }

		public bool StaticAccess { get; set; }

		public string ResourceManagerClass
		{
			get
			{
				return _resourceManagerClassName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_resourceManagerClassName = _defaultResourceManagerClassName;
				}
				else
				{
					_resourceManagerClassName = value;
				}
			}
		}

		public string ResourceManagerGetStringMethod
		{
			get
			{
				return _resourceManagerGetStringMethodName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_resourceManagerGetStringMethodName = _defaultResourceManagerGetStringMethodName;
				}
				else
				{
					_resourceManagerGetStringMethodName = value;
				}
			}
		}

		public string ResourceManagerGetObjectMethod
		{
			get
			{
				return _resourceManagerGetObjectMethodName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_resourceManagerGetObjectMethodName = _defaultResourceManagerGetObjectMethodName;
				}
				else
				{
					_resourceManagerGetObjectMethodName = value;
				}
			}
		}

		#endregion
	}
}
