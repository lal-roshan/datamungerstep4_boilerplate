using DbEngine.Query;

namespace DbEngine.Reader
{
    public abstract class QueryProcessingEngine
    {
        public abstract Header GetHeader();
        public abstract void GetDataRow();
        public abstract DataTypeDefinitions GetColumnType();
    }
}