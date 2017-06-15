using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocCommand : IDisposable
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		void Execute();

		/// <summary>
		/// Executes the command asynchronously.
		/// </summary>
		Task ExecuteAsync();

		/// <summary>
		/// Cancels the command execution.
		/// </summary>
		void Cancel();
	}
}
