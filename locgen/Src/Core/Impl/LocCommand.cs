using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace locgen.Impl
{
	/// <summary>
	/// A generic command.
	/// </summary>
	public abstract class LocCommand : ILocCommand
	{
		#region data

		private readonly CancellationTokenSource _tokenSource;

		#endregion

		#region interface

		protected LocCommand()
			: this(new CancellationTokenSource())
		{
		}

		protected LocCommand(CancellationTokenSource cancelSource)
		{
			_tokenSource = cancelSource;
		}

		protected abstract void ExecuteInternal(CancellationToken cancelToken);

		#endregion

		#region ILocCommand

		public void Execute()
		{
			ExecuteAsync().Wait();
		}

		public Task ExecuteAsync()
		{
			if (_tokenSource != null)
			{
				var token = _tokenSource.Token;
				return Task.Run(() => ExecuteInternal(token), token);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public void Cancel()
		{
			_tokenSource.Cancel();
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			_tokenSource.Cancel();
		}

		#endregion

		#region implementation
		#endregion
	}
}
