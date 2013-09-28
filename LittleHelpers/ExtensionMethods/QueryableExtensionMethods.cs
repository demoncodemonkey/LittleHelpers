using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
namespace demoncodemonkey.LittleHelpers
{
#endif

	public static class QueryableExtensionMethods
	{
		public static IQueryable<string[]> SelectColumns(this IQueryable @this, string[] columnNames)
		{
			var results = @this.Select(string.Format("new({0})", string.Join(",", columnNames)));
			var listData = new List<string[]>();
			foreach (var item in @this)
			{
				var sublist = new List<string>();
				foreach (var columnName in columnNames)
					sublist.Add(Utils.GetPropertyValue(item, columnName).ToString());
				listData.Add(sublist.ToArray());
			}
			return listData.AsQueryable();
		}
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
