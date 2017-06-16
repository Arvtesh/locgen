using System;
using System.Collections.Generic;
using System.IO;

namespace locgen.Impl
{
	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	internal abstract class LocTreeBuilder : ILocTreeBuilder
	{
		#region data
		#endregion

		#region interface

		protected LocTreeBuilder(string name)
		{
			Name = name;
		}

		protected abstract ILocTree[] ReadInternal(Stream stream);

		#endregion

		#region ILocTreeBuilder

		public string Name { get; }

		public ILocTree[] Read(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}

			return ReadInternal(stream);
		}

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
