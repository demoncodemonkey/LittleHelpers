using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
namespace demoncodemonkey.LittleHelpers
{
#endif

	public static class StringExtensionMethods
	{
		public static bool IsEmpty(this string @this)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			return @this.Length == 0;
		}

		public static bool IsNotEmpty(this string @this)
		{
			return !@this.IsEmpty();
		}

		public static bool IsNullOrEmpty(this string @this)
		{
			return string.IsNullOrEmpty(@this);
		}

		public static bool IsNotNullAndNotEmpty(this string @this)
		{
			return !@this.IsNullOrEmpty();
		}

		/// <summary>
		/// Returns true if the current string contains the specified substring. Case insensitive match.
		/// </summary>
		public static bool ContainsIgnoreCase(this string @this, string substring)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (substring.IsNull())
				throw new ArgumentNullException("substring is null");
			if (substring.IsEmpty())
				return false;
			return @this.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static bool EqualsIgnoreCase(this string @this, string target)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (target.IsNull())
				throw new ArgumentNullException("target is null");
			return @this.Equals(target, StringComparison.CurrentCultureIgnoreCase);
		}

		public static bool IsInIgnoreCase(this string @this, IEnumerable<string> list)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (list.IsNull())
				throw new ArgumentNullException("list is null");
			return list.Any(x => x.EqualsIgnoreCase(@this));
		}
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
