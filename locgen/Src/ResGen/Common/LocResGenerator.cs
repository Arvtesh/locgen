﻿using System;
using System.Collections.Generic;
using System.Text;

namespace locgen.ResGen
{
	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	public abstract class LocResGenerator : ILocResGenerator
	{
		#region data
		#endregion

		#region interface

		protected LocResGenerator(string name)
		{
			Name = name;
		}

		#endregion

		#region IResCodeGenerator

		public string Name { get; }

		#endregion

		#region IDisposable

		public void Dispose()
		{
			// TODO
		}

		#endregion

		#region implementation
		#endregion
	}
}
