using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if !LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
namespace demoncodemonkey.LittleHelpers
{
#endif

	public static class Ensure
	{
		public static Verification<T> That<T>(T argument)
		{
			return new Verification<T>(argument);
		}
	}

	public class Verification<T>
	{
		internal T Object;

		public Verification(T argument)
		{
			Object = argument;
		}
	}

	public static class VerificationExtensionMethods
	{
		#region Verification

		/// <summary>
		/// Throws an ArgumentException if the argument is not null.
		/// </summary>
		public static Verification<T> IsNull<T>(this Verification<T> @this)
		{
			if (@this.Object.IsNull())
				return @this;
			throw new ArgumentException(string.Format("Argument is not null."));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is null.
		/// </summary>
		public static Verification<T> IsNotNull<T>(this Verification<T> @this)
		{
			if (@this.Object.IsNotNull())
				return @this;
			throw new ArgumentException(string.Format("Argument is null."));
		}

		/// <summary>
		/// Throws an ArgumentException if the string argument is not empty.
		/// </summary>
		public static Verification<string> IsEmpty(this Verification<string> @this)
		{
			if (@this.Object.IsEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is not empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the container argument is not empty.
		/// </summary>
		public static Verification<IEnumerable<T>> IsEmpty<T>(this Verification<IEnumerable<T>> @this)
		{
			if (@this.Object.IsEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is not empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the container argument is not empty.
		/// </summary>
		public static Verification<List<T>> IsEmpty<T>(this Verification<List<T>> @this)
		{
			if (@this.Object.IsEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is not empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the string argument is empty.
		/// </summary>
		public static Verification<string> IsNotEmpty(this Verification<string> @this)
		{
			if (@this.Object.IsNotEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the container argument is empty.
		/// </summary>
		public static Verification<IEnumerable<T>> IsNotEmpty<T>(this Verification<IEnumerable<T>> @this)
		{
			if (@this.Object.IsNotEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the container argument is empty.
		/// </summary>
		public static Verification<List<T>> IsNotEmpty<T>(this Verification<List<T>> @this)
		{
			if (@this.Object.IsNotEmpty())
				return @this;
			throw new ArgumentException(string.Format("Argument is empty."));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not equal to the specified value.
		/// </summary>
		public static Verification<T> IsEqualTo<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (@this.Object.Equals(value))
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not equal to '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is equal to the specified value.
		/// </summary>
		public static Verification<T> IsNotEqualTo<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (!@this.Object.Equals(value))
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is equal to '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not greater than the specified value.
		/// </summary>
		public static Verification<T> IsGreaterThan<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (@this.Object.CompareTo(value) > 0)
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not greater than '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not greater than or equal to the specified value.
		/// </summary>
		public static Verification<T> IsGreaterThanOrEqualTo<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (@this.Object.CompareTo(value) >= 0)
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not greater than or equal to '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not less than the specified value.
		/// </summary>
		public static Verification<T> IsLessThan<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (@this.Object.CompareTo(value) < 0)
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not less than '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not less than or equal to the specified value.
		/// </summary>
		public static Verification<T> IsLessThanOrEqualTo<T>(this Verification<T> @this, T value)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (value.IsNull())
				throw new ArgumentNullException("value is null");
			if (@this.Object.CompareTo(value) <= 0)
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not less than or equal to '{1}'.", @this.Object, value));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not in-between the specified values. [inclusive]
		/// </summary>
		public static Verification<T> IsBetween<T>(this Verification<T> @this, T valueMin, T valueMax)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (valueMin.IsNull())
				throw new ArgumentNullException("valueMin is null");
			if (valueMax.IsNull())
				throw new ArgumentNullException("valueMax is null");
			if (@this.Object.IsBetween<T>(valueMin, valueMax))
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is not between '{1}' and '{2}'.", @this.Object, valueMin, valueMax));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not in-between the specified values. [inclusive]
		/// </summary>
		public static Verification<T> IsNotBetween<T>(this Verification<T> @this, T valueMin, T valueMax)
			where T : IComparable<T>
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (valueMin.IsNull())
				throw new ArgumentNullException("valueMin is null");
			if (valueMax.IsNull())
				throw new ArgumentNullException("valueMax is null");
			if (!@this.Object.IsBetween<T>(valueMin, valueMax))
				return @this;
			throw new ArgumentException(string.Format("Argument '{0}' is between '{1}' and '{2}'.", @this.Object, valueMin, valueMax));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not in the specified collection of values.
		/// </summary>
		public static Verification<T> IsIn<T>(this Verification<T> @this, IEnumerable<T> values)
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (values.Any(x => x.IsNull()))
				throw new ArgumentNullException("values contains a null object");
			if ((values != null) && values.Contains(@this.Object))
				return @this;
			string valueContents = values.CombineItemContents();
			throw new ArgumentException(string.Format("Argument '{0}' is not in collection '{{{1}}}'.", @this.Object, valueContents));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is not in the specified collection of values.
		/// </summary>
		public static Verification<T> IsIn<T>(this Verification<T> @this, params T[] values)
		{
			return @this.IsIn(values.AsEnumerable());
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is in the specified collection of values.
		/// </summary>
		public static Verification<T> IsNotIn<T>(this Verification<T> @this, IEnumerable<T> values)
		{
			if (@this.Object.IsNull())
				throw new ArgumentNullException("@this.Object is null");
			if (values.Any(x => x.IsNull()))
				throw new ArgumentNullException("values contains a null object");
			if ((values != null) && !values.Contains(@this.Object))
				return @this;
			string valueContents = values.CombineItemContents();
			throw new ArgumentException(string.Format("Argument '{0}' is in collection '{{{1}}}'.", @this.Object, valueContents));
		}

		/// <summary>
		/// Throws an ArgumentException if the argument is in the specified collection of values.
		/// </summary>
		public static Verification<T> IsNotIn<T>(this Verification<T> @this, params T[] values)
		{
			return @this.IsNotIn(values.AsEnumerable());
		}

		#endregion
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
