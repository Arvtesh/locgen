using System;
using System.Collections.Generic;
using System.Linq;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public class LocTreeGroup : LocTreeItem
	{
		#region data

		public const string InvalidIdText = "Invalid item identifier";
		public const string ItemNotMatchText = "Item with identifier '{0}' already exists but its name or type ({1}/{2}) does not match the new item";

		private Dictionary<string, LocTreeGroup> _groups = new Dictionary<string, LocTreeGroup>();
		private Dictionary<string, LocTreeUnit> _units = new Dictionary<string, LocTreeUnit>();

		#endregion

		#region interface

		public IEnumerable<LocTreeGroup> Groups => _groups.Values;
		public IEnumerable<LocTreeUnit> Units => _units.Values;

		public IEnumerable<LocTreeUnit> UnitsRecursive
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

		public LocTreeGroup(LocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		public LocTreeText AddText(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is LocTreeText textUnit)
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

		public LocTreeTexture AddTexture(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is LocTreeTexture textureUnit)
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

		public LocTreeAudio AddAudio(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			if (_units.TryGetValue(id, out var unit))
			{
				if (unit.Name == name && unit is LocTreeAudio audioUnit)
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

		public LocTreeGroup AddGroup(string id, string name)
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

		public bool TryGetUnit(string id, out LocTreeUnit unit)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(InvalidIdText, nameof(id));
			}

			return _units.TryGetValue(id, out unit);
		}

		public bool TryGetGroup(string id, out LocTreeGroup group)
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
