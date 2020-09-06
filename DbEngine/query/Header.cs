namespace DbEngine.Query
{
    public class Header
    {
        /*
	 * This class should contain a property named as Headers which is a String array, to hold
	 * the headers and should override toString() method as well. Initialize this property in constructor
	 */
        public string[] Headers { get; set; }

        public Header(string[] headers)
        {
            this.Headers = headers;
        }

        public override string ToString()
        {
            return string.Join(", ", Headers);
        }
    }
}