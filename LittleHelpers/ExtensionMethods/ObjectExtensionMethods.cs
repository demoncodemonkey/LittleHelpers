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

	public static class ObjectExtensionMethods
	{
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
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
