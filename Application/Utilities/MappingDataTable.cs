using System.Data;

namespace Application.Utilities
{
    public static class MappingDataTable
    {
        public static List<E> ConvertToList<E>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(E).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<E>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch
                        {
                        }
                    }
                }
                return objT;
            }).ToList();
        }
    }

}
