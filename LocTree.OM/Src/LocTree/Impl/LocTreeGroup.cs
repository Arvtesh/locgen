using System;
using System.Collections.Generic;
using System.Linq;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeGroup"/>.
	/// </summary>
	internal class LocTreeGroup : LocTreeItem, ILocTreeGroup
	{
		#region data

		public const string InvalidIdText = "Invalid item identifier";
		public const string ItemNotMatchText = "Item with identifier '{0}' already exists but its name or type ({1}/{2}) does not match the new item";

		private Dictionary<string, ILocTreeGroup> _groups = new Dictionary<string, ILocTreeGroup>();
		private Dictionary<string, ILocTreeUnit> _units = new Dictionary<string, ILocTreeUnit>();

		#endregion

		#region interface

		public LocTreeGroup(ILocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion

		#region ILocTreeGroup

		public IEnumerable<ILocTreeGroup> Groups => _groups.Values;
		public IEnumerable<ILocTreeUnit> Units => _units.Values;

		public IEnumerable<ILocTreeUnit> UnitsRecursive
		{
			get
			{
				foreach (var unit in _units.Values)
				{
					yield return unit;
				}

				foreach (var group in _groups.Values)
				{
					foreach (var gu in group.UnitsRecursive)
					{
						yield return gu;
					}
				}
			}
		}

		public ILocTreeText AddText(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is ILocTreeText textUnit)
				{
					return textUnit;
				}
				else
				{
					throw new InvalidOperationException(string.Format(ItemNotMatchText, id, unit.Name, "text"));
				}
			}
			else
			{
				var result = new LocTreeText(this, id, name);
				_units.Add(id, result);
				return result;
			}
		}

		public ILocTreeTexture AddTexture(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is ILocTreeTexture textureUnit)
				{
					return textureUnit;
				}
				else
				{
					throw new InvalidOperationException(string.Format(ItemNotMatchText, id, unit.Name, "texture"));
				}
			}
			else
			{
				var result = new LocTreeTexture(this, id, name);
				_units.Add(id, result);
				return result;
			}
		}

		public ILocTreeAudio AddAudio(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is ILocTreeAudio audioUnit)
				{
					return audioUnit;
				}
				else
				{
					throw new InvalidOperationException(string.Format(ItemNotMatchText, id, unit.Name, "audio"));
				}
			}
			else
			{
				var result = new LocTreeAudio(this, id, name);
				_units.Add(id, result);
				return result;
			}
		}

		public ILocTreeGroup AddGroup(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_groups.TryGetValue(id, out var group))
			{
				if (group.Name == name)
				{
					return group;
				}
				else
				{
					throw new InvalidOperationException(string.Format(ItemNotMatchText, id, group.Name, "group"));
				}
			}
			else
			{
				var result = new LocTreeGroup(this, id, name);
				_groups.Add(id, result);
				return result;
			}
		}

		public bool TryGetUnit(string id, out ILocTreeUnit unit)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			return _units.TryGetValue(id, out unit);
		}

		public bool TryGetGroup(string id, out ILocTreeGroup group)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			return _groups.TryGetValue(id, out group);
		}

		#endregion

		#region implementation
		#endregion
	}
}
