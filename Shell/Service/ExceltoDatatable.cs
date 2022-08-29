using OfficeOpenXml;
using OfficeOpenXml.Table;
using Shell.Model;
using System.ComponentModel;
using System.Data;

namespace Shell.Service
{
    public class myCanWritecol
    {
        public string Name { get; set; }
        public int index { get; set; }
    }
    //https://stackoverflow.com/questions/36637882/epplus-read-excel-table
    public static class ExceltoDatatable
    {
        public static IEnumerable<T> ConvertTableToObjects<T>(this ExcelTable table) where T : new()
        {
            var matchfield = new List<MatchField>();
            using (var db = new SHELLREGContext())
            {
                matchfield = db.MatchFields.ToList();
            }
            //DateTime Conversion
            var convertDateTime = new Func<double, DateTime>(excelDate =>
            {
                if (excelDate < 1)
                    throw new ArgumentException("Excel dates cannot be smaller than 0.");

                var dateOfReference = new DateTime(1900, 1, 1);

                if (excelDate > 60d)
                    excelDate = excelDate - 2;
                else
                    excelDate = excelDate - 1;
                return dateOfReference.AddDays(excelDate);
            });

            //Get the properties of T
            var tprops = (new T())
                .GetType()
                .GetProperties()
                .ToList();

            //Get the cells based on the table address
            var start = table.Address.Start;
            var end = table.Address.End;
            var cells = new List<ExcelRangeBase>();

            //Have to use for loops insteadof worksheet.Cells to protect against empties
            for (var r = start.Row; r <= end.Row; r++)
                for (var c = start.Column; c <= end.Column; c++)
                    cells.Add(table.WorkSheet.Cells[r, c]);

            var groups = cells
                .GroupBy(cell => cell.Start.Row)
                .ToList();

            //Assume the second row represents column data types (big assumption!)
            var types = groups
                .Skip(1)
                .First()
                .Select(rcell => rcell.Value == null ? typeof(string) : rcell.Value.GetType())
                .ToList();

            //Assume first row has the column names
            /*var colnames = groups
                .First()
                .Select((hcell, idx) => new { Name = hcell.Value.ToString(), index = idx })
                .Where(o => tprops.Select(p => p.Name).Contains(o.Name))
                .ToList();*/
            var colnames_before = groups.First().Select((hcell, idx) => new { 
                Name = hcell.Value.ToString(), index = idx 
            });

            //debug
            var debugging_col_Replaced_excel = new List<myCanWritecol>();
            var debugging_col_database_fieldExcel = new List<myCanWritecol>();


            var colnames_edited = new List<myCanWritecol>();
            foreach (var eachcol in colnames_before)
            {
                var matched_db_row = matchfield.Where(t => t.FieldExcel == eachcol.Name.Replace(@"#", "."));
                string Found_FieldData = "";
                string Found_FieldExcel_forDebuging = "";
                if (matched_db_row.Any())
                {
                    Found_FieldData = matched_db_row.First().FieldData;
                    Found_FieldExcel_forDebuging = matched_db_row.First().FieldExcel;
                }
                else
                {
                    Found_FieldData = "";
                    Found_FieldExcel_forDebuging = "";
                }
                colnames_edited.Add(new myCanWritecol()
                {
                    Name = Found_FieldData,
                    index = eachcol.index,
                });
                //debug
                debugging_col_Replaced_excel.Add(new myCanWritecol()
                {
                    Name = eachcol.Name.Replace(@"#", "."),
                    index = eachcol.index,
                });
                debugging_col_database_fieldExcel.Add(new myCanWritecol()
                {
                    Name = Found_FieldExcel_forDebuging,
                    index = eachcol.index,
                });
            }
            var colnames = colnames_edited.Where(o => tprops.Select(p => p.Name).Contains(o.Name)).ToList();

            //Everything after the header is data
            var rowvalues = groups
                .Skip(1) //Exclude header
                .Select(cg => cg.Select(c => c.Value).ToList());

            //Create the collection container
            var collection = rowvalues
                .Select(row =>
                {
                    var tnew = new T();
                    colnames.ForEach(colname =>
                    {
                //This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                        var val = row[colname.index];
                        var type = types[colname.index];
                        var prop = tprops.First(p => p.Name == colname.Name);

                //If it is numeric it is a double since that is how excel stores all numbers
                        if (type == typeof(double))
                        {
                            if (!string.IsNullOrWhiteSpace(val?.ToString()))
                            {
                        //Unbox it
                                var unboxedVal = (double)val;

                        //FAR FROM A COMPLETE LIST!!!
                                if (prop.PropertyType == typeof(Int32))
                                    prop.SetValue(tnew, (int)unboxedVal);
                                else if (prop.PropertyType == typeof(double))
                                    prop.SetValue(tnew, unboxedVal);
                                else if (prop.PropertyType == typeof(DateTime))
                                    prop.SetValue(tnew, convertDateTime(unboxedVal));
                                else if(prop.PropertyType == typeof(string))
                                {
                                    prop.SetValue(tnew, val?.ToString());
                                }
                                else
                                    throw new NotImplementedException(String.Format("Type '{0}' not implemented yet!", prop.PropertyType.Name));
                            }
                        }
                        else
                        {
                    //Its a string
                            prop.SetValue(tnew, val);
                        }
                    });

                    return tnew;
                });


            //Send it back
            return collection;
        }

        public static DataTable ToDataTable<T>(this IList<T> data,string f_fieldtype)
        {
            var matchfield = new List<MatchField>();
            using (var db = new SHELLREGContext())
            {
                matchfield = db.MatchFields.ToList();
            }

            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            /*
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            */
            foreach (PropertyDescriptor prop in properties)
            {
                var temp_name = prop.Name;
                var matched_db_row = matchfield.Where(t => t.FieldData == prop.Name && t.FieldType == f_fieldtype);
                if (matched_db_row.Any())
                {
                    temp_name = matched_db_row.First().FieldExcel;
                }
                table.Columns.Add(temp_name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                /*foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;*/
                foreach (PropertyDescriptor prop in properties) {

                    var temp_name = prop.Name;
                    var matched_db_row = matchfield.Where(t => t.FieldData == prop.Name && t.FieldType == f_fieldtype);
                    if (matched_db_row.Any())
                    {
                        temp_name = matched_db_row.First().FieldExcel;
                    }
                    row[temp_name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            // if(f_fieldtype == product point list)
            return table;
        }
    }
}
