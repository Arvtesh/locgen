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

		protected abstract void ReadInternal(ILocTreeSet treeSet, Stream stream);

		#endregion

		#region ILocTreeBuilder

		public string Name { get; }

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
