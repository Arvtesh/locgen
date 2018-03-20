using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LocTreeAudio : LocTreeUnit
	{
		#region data
		#endregion

		#region interface

		public string SrcPath { get; set; }
		public string TargetPath { get; set; }

		public LocTreeAudio(LocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion
	}
}
