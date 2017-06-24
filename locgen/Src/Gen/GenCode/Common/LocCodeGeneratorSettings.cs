using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocCodeGeneratorSettings"/>.
	/// </summary>
	internal sealed class LocCodeGeneratorSettings : LocGeneratorSettings, ILocCodeGeneratorSettings
	{
		#region data

		private const string _defaultResourceManagerClassName = "ResourceManager";
		private const string _defaultResourceManagerGetStringMethodName = "GetString";
		private const string _defaultResourceManagerGetObjectMethodName = "GetObject";

		private string _resourceManagerClassName = _defaultResourceManagerClassName;
		private string _resourceManagerGetStringMethodName = _defaultResourceManagerGetStringMethodName;
		private string _resourceManagerGetObjectMethodName = _defaultResourceManagerGetObjectMethodName;

		#endregion

		#region ILocCodeGeneratorSettings

		public string TargetNamespace { get; set; }

		public bool GenerateLocKeys { get; set; }

		public bool StaticAccess { get; set; }

		public string ResourceManagerClassRef
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
