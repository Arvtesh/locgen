using System;
using System.Collections;
using System.Collections.Generic;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeSet"/>.
	/// </summary>
	internal sealed class LocTreeSet : ILocTreeSet
	{
		#region data

		private Dictionary<string, ILocTree> _trees = new Dictionary<string, ILocTree>();

		#endregion

		#region interface
		#endregion

		#region ILocTreeSet

		public ILocTree Add(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(LocTreeGroup.InvalidIdText, nameof(id));
			}

			if (_trees.TryGetValue(id, out var tree))
			{
				if (tree.Name == name)
				{
					return tree;
				}
				else
				{
					throw new InvalidOperationException(string.Format(LocTreeGroup.ItemNotMatchText, id, tree.Name, "tree"));
				}
			}
			else
			{
				var result = new LocTree(id, name);
				_trees.Add(id, result);
				return result;
			}
		}

		#endregion

		#region IEnumerable

		public IEnumerator<ILocTree> GetEnumerator()
		{
			return _trees.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _trees.Values.GetEnumerator();
		}

		#endregion
	}
}
