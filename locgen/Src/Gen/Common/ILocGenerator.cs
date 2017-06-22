using System;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocGenerator : IDisposable
	{
		/// <summary>
		/// Returns the generator name. Read only.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Generates the code.
		/// </summary>
		void Generate(ILocTree data, CancellationToken cancellationToken);
	}
}
