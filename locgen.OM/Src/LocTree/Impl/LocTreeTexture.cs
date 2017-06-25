using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeTexture"/>.
	/// </summary>
	internal sealed class LocTreeTexture : LocTreeUnit, ILocTreeTexture
	{
		#region data
		#endregion

		#region interface

		public LocTreeTexture(ILocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion

		#region ILocTreeTexture

		public string SrcPath { get; set; }
		public string TargetPath { get; set; }

		#endregion
	}
}
