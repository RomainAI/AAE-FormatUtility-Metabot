using FormatUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Class1
    {
        static void Main(string[] args)
        {
            string sourceValue = "Total: 19.500,20 euros";
            string result = string.Empty;
            result = ExtractingValue.ExtractFormatValue(sourceValue, "Total:\",\"\";\"euros\",\"","",1,"numeric","#,0.00","error");


        }
        
    }
}
