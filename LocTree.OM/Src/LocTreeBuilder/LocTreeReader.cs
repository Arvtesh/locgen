using System;
using System.Collections.Generic;
using System.IO;

namespace locgen
{
	public enum LocTreeSourceType
	{
		Auto,
		Json,
		Xml,
		Xliff12,
		Xliff20
	}

	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	public abstract class LocTreeReader : IDisposable
	{
		#region data

		private readonly string _name;

		#endregion

		#region interface

		protected LocTreeReader(string name)
		{
			_name = name;
		}

		public static LocTreeReader Create(LocTreeSourceType fileType = LocTreeSourceType.Auto)
		{
			switch (fileType)
			{
				case LocTreeSourceType.Xliff20:
					return new XliffTreeReader();

				case LocTreeSourceType.Json:
					return new JsonTreeReader();

				default:
					throw new NotImplementedException();
			}
		}

		public void Read(LocTreeSet treeSet, Stream stream)
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

		protected abstract void ReadInternal(LocTreeSet treeSet, Stream stream);

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
