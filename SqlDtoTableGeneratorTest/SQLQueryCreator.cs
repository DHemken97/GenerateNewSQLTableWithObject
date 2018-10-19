using System.Collections.Generic;

namespace SqlDtoTableGeneratorTest
{
    public static class SQLQueryCreator
    {
        private static Dictionary<string, string> knownDataTypes => 
            new Dictionary<string, string>
            {
             {  "Int64",  "bigint"  },
             {  "Boolean" ,  "bit" },
             {  "DateTime" ,  "datetime" },
             {  "Decimal" ,  "decimal(18,18)" },
             {  "Double"  ,  "float"},
             {  "Int32",  "int" },
             {  "System.String"  ,  "nvarchar(max)" },
             {  "Char"  ,  "nvarchar" },
             {  "Single"  ,  "real" },
             {  "Int16"  ,  "smallint" },
             {  "Guid" ,  "uniqueidentifier" },
             {  "Byte[]"  ,  "varbinary(max)"},
             {  "Xml" ,  "xml" }
            };
               
        public static string GenerateNewTableQueryString(object DTO, string TableName = "Temp")
        {
            var columns = new List<string>();

            var myPropertyInfo = DTO.GetType().GetProperties();

            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                var info = myPropertyInfo[i].ToString().Split(' ');

                var prop_type = info[0];

                var prop_name = info[1];

                knownDataTypes.TryGetValue(prop_type, out string sqltype);

                columns.Add($"\n{prop_name} {sqltype}");
            }
            return $"CREATE TABLE {TableName}\n({string.Join(',', columns)}\n)";
        }
    }
}
