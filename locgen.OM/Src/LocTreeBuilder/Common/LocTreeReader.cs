using System;
using System.Collections.Generic;
using System.IO;

namespace locgen.Impl
{
	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	internal abstract class LocTreeReader : ILocTreeReader
	{
		#region data

		private readonly string _name;

		#endregion

		#region interface

		protected LocTreeReader(string name)
		{
			_name = name;
		}

		protected abstract void ReadInternal(ILocTreeSet treeSet, Stream stream);

		#endregion

		#region ILocTreeBuilder

		public void Read(ILocTreeSet treeSet, Stream stream)
		{
			if (treeSet == null)
			{
				throw new ArgumentNullException(nameof(treeSet));
			}

			if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}

			ReadInternal(treeSet, stream);
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
