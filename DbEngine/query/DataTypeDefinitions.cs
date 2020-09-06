namespace DbEngine.Query
{
    public class DataTypeDefinitions
    {
        /*
	   This class should contain a property named as DataTypes which is a String array, to hold
	   the data type for all columns for all data types and should override
	   toString() method as well.
	 */
     //Define constructor to initialize this property

        public string[] DataTypes { get; set; }

        public DataTypeDefinitions(string[] dataTypes)
        {
            this.DataTypes = dataTypes;
        }

        public override string ToString()
        {
            return string.Join(", ", DataTypes);
        }

    }
}