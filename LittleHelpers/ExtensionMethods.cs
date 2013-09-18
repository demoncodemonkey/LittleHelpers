using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace demoncodemonkey.LittleHelpers
{
	public static class ExtensionMethods
	{
		#region Objects

		public static bool IsNull<T>(this T @this)
		{
			return @this == null;
		}

		public static bool IsNotNull<T>(this T @this)
		{
			return !@this.IsNull();
		}

		public static bool IsIn<T>(this T @this, IEnumerable<T> list)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (list.IsNull())
				throw new ArgumentNullException("list is null");
			return list.Any(x => x.Equals(@this));
		}

		public static bool IsNotIn<T>(this T @this, IEnumerable<T> list)
		{
			return !@this.IsIn(list);
		}

		static void Swap<T>(ref T valueA, ref T valueB)
		{
			T temp = valueA;
			valueA = valueB;
			valueB = temp;
		}

		#endregion

		#region Strings

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

		#endregion

		#region IEnumerable

		public static bool IsEmpty<T>(this IEnumerable<T> @this)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			return @this.Count() == 0;
		}

		public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
		{
			return !@this.IsEmpty();
		}

		public static string CombineItemContents<T>(this IEnumerable<T> @this, string separator = ", ")
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (separator.IsNull())
				throw new ArgumentNullException("separator is null");
			var itemsContents = @this.GetItemsContents().ToList();
			if (itemsContents.IsEmpty())
				return "Empty list";
			return string.Join(separator, itemsContents);
		}

		public static IEnumerable<string> GetItemsContents<T>(this IEnumerable<T> @this)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			foreach (T item in @this)
				yield return item.ToString();
		}

		#endregion

		#region IComparable

		public static bool IsBetween<T>(this T value, T min, T max)
			where T : IComparable<T>
		{
			if (min.CompareTo(max) > 0)
				Swap(ref min, ref max);
			return (value.CompareTo(min) >= 0) && (value.CompareTo(max) <= 0);
		}

		public static bool IsNotBetween<T>(this T value, T min, T max)
			where T : IComparable<T>
		{
			return !value.IsBetween(min, max);
		}

		#endregion
	}
}
