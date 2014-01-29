using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

partial class cree_Industry : IComparable<cree_Industry>, IEquatable<cree_Industry>
{
	public int CompareTo(cree_Industry other)
	{
		return this.Name.CompareTo(other.Name);
	}

	public bool Equals(cree_Industry other)
	{
		return (this.ID == other.ID) && (this.Name == other.Name);
	}
}