using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public enum LocTreeSourceType
	{
		/// <summary>
		/// 
		/// </summary>
		Auto,

		/// <summary>
		/// 
		/// </summary>
		Json,

		/// <summary>
		/// 
		/// </summary>
		Xml,

		/// <summary>
		/// 
		/// </summary>
		Xliff12,

		/// <summary>
		/// 
		/// </summary>
		Xliff20,
	}

	/// <summary>
	/// 
	/// </summary>
	public static class LocTree
	{
		/// <summary>
		/// 
		/// </summary>
		public static ILocTreeReader CreateReader(LocTreeSourceType fileType = LocTreeSourceType.Auto)
		{
			switch (fileType)
			{
				case LocTreeSourceType.Xliff20:
					return new Impl.XliffTreeReader();

				case LocTreeSourceType.Json:
					return new Impl.JsonTreeReader();

				default:
					throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public static ILocTreeSet CreateSet()
		{
			return new Impl.LocTreeSet();
		}

		/// <summary>
		/// 
		/// </summary>
		public static ILocTree Create(string id, string name)
		{
			return new Impl.LocTree(id, name);
		}
	}
}
