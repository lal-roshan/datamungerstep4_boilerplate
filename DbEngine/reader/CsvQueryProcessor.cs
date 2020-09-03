using DbEngine.Query;

namespace DbEngine.Reader
{
    public class CsvQueryProcessor: QueryProcessingEngine
    {
        /*
	    parameterized constructor to initialize filename. As you are trying to
	    perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */
        public CsvQueryProcessor(string fileName)
        {
         
        }

        /*
	    implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    */
        public override Header GetHeader()
        {
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
            // checking for Integer

            // checking for floating point numbers

            // checking for date format dd/mm/yyyy

            // checking for date format mm/dd/yyyy

            // checking for date format dd-mon-yy

            // checking for date format dd-mon-yyyy

            // checking for date format dd-month-yy

            // checking for date format dd-month-yyyy

            // checking for date format yyyy-mm-dd
            return null;
        }
	 
        //This method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}