using DbEngine.Query;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DbEngine.Reader
{
    public class CsvQueryProcessor : QueryProcessingEngine
    {
        private readonly string _fileName;
        private StreamReader _reader;
        /*
	    parameterized constructor to initialize filename. As you are trying to
	    perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */
        public CsvQueryProcessor(string fileName)
        {
            if (File.Exists(fileName))
            {
                this._fileName = fileName;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /*
	    implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    */
        public override Header GetHeader()
        {
            using (_reader = new StreamReader(_fileName))
            {
                string headerRow = _reader.ReadLine();
                if (!string.IsNullOrEmpty(headerRow))
                {
                    Header header = new Header(headerRow.Split(',').Select(x => x.Trim()).ToArray());
                    return header;
                }
            }
            return null;
        }

        /*
	     implementation of getColumnType() method. To find out the data types, we will
	     read the first line from the file and extract the field values from it. In
	     the previous assignment, we have tried to convert a specific field value to
	     Integer or Double. However, in this assignment, we are going to use Regular
	     Expression to find the appropriate data type of a field. Integers: should
	     contain only digits without decimal point Double: should contain digits as
	     well as decimal point Date: Dates can be written in many formats in the CSV
	     file. However, in this assignment,we will test for the following date
	     formats('dd/mm/yyyy','mm/dd/yyyy','dd-mon-yy','dd-mon-yyyy','dd-month-yy','dd-month-yyyy','yyyy-mm-dd')
	    */
        public override DataTypeDefinitions GetColumnType()
        {
            using (_reader = new StreamReader(_fileName))
            {
                _reader.ReadLine();
                string firstDataRow = _reader.ReadLine();
                if (!string.IsNullOrEmpty(firstDataRow))
                {
                    string ddString = $"((0[1-9])|([12]\\d)|(3[01]))";
                    string mmString = $"((0[1-9])|(1[012]))";
                    string yyString = $"(\\d{{2}})";
                    string yyyyString = $"(\\d{{4}})";
                    string shortMonthString = $"(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)";
                    string longMonthString = $"(January|February|March|April|May|June|July|August|September|October|November|December)";
                    List<string> dataTypes = new List<string>();
                    foreach (string field in firstDataRow.Split(','))
                    {
                        // checking for Integer
                        if (Regex.IsMatch(field, $"^([0-9]+)$"))
                        {
                            dataTypes.Add(typeof(System.Int32).ToString());
                        }
                        // checking for floating point numbers
                        else if (Regex.IsMatch(field, $"^([0-9]+.[0-9]+)$"))
                        {
                            dataTypes.Add(typeof(System.Double).ToString());
                        }
                        // checking for date format dd/mm/yyyy
                        else if (Regex.IsMatch(field,
                            $"^({ddString}/{mmString}/{yyyyString})$"))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format mm/dd/yyyy
                        else if (Regex.IsMatch(field,
                            $"^({mmString}/{ddString}/{yyyyString})$"))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format dd-mon-yy
                        else if (Regex.IsMatch(field,
                            $"^({ddString}-{shortMonthString}-{yyString})$", RegexOptions.IgnoreCase))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format dd-mon-yyyy
                        else if (Regex.IsMatch(field,
                            $"^({ddString}-{shortMonthString}-{yyyyString})$",
                            RegexOptions.IgnoreCase))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format dd-month-yy
                        else if (Regex.IsMatch(field,
                            $"^({ddString}-{longMonthString}-{yyString})$",
                            RegexOptions.IgnoreCase))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format dd-month-yyyy
                        else if (Regex.IsMatch(field,
                            $"^({ddString}-{longMonthString}-{yyyyString})$",
                            RegexOptions.IgnoreCase))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        // checking for date format yyyy-mm-dd
                        else if (Regex.IsMatch(field,
                            $"^({yyyyString}-{mmString}-{ddString})$"))
                        {
                            dataTypes.Add(typeof(System.DateTime).ToString());
                        }
                        else if (string.IsNullOrEmpty(field))
                        {
                            dataTypes.Add(typeof(System.Object).ToString());
                        }
                        else
                        {
                            dataTypes.Add(typeof(System.String).ToString());
                        }
                    }
                    DataTypeDefinitions dataTypeDefinitions = new DataTypeDefinitions(dataTypes.ToArray());
                    return dataTypeDefinitions;
                }
            }
            return null;
        }

        //This method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}