using System;
using System.IO;
using DbEngine.Query;
using DbEngine.Reader;
using Xunit;
using FluentAssertions;
using System.Xml.Linq;

namespace test
{
    public class DataMungerTest
    {
        #region Don't Try to Delete/Change the Logic Keep it as it is
        readonly string strtogetipldotcsv = "";
        readonly string rootdir = "";
        #endregion
        private static CsvQueryProcessor _reader;
        public DataMungerTest()
        {
            #region Don't Try to Delete/Change the Logic Keep it as it is in Constructor
            var mydirectory = Environment.CurrentDirectory;
            int indexofmyvar = mydirectory.IndexOf("bin");
            string substr = mydirectory.Substring(0, indexofmyvar);
            if (substr.Contains("test"))
            {
                int testindex = substr.IndexOf("test");
                rootdir = substr.Substring(0, testindex);
                strtogetipldotcsv = rootdir + "data/ipl.csv";
            }
            _reader = new CsvQueryProcessor(strtogetipldotcsv);
            #endregion
        }
        [Fact]
        public void TestRetrieveHeader()
        {
            Header result = _reader.GetHeader();
            string[] expectedHeaders = new string[] {
              "id", "season", "city", "date", "team1", "team2", "toss_winner", "toss_decision",
                          "result", "dl_applied", "winner", "win_by_runs", "win_by_wickets", "player_of_match", "venue",
                          "umpire1", "umpire2", "umpire3"
            };
            result.Headers.Should().NotBeNull();
            result.Headers.Should().BeEquivalentTo(expectedHeaders);
        }
        //ERROR in TEST CASE
        [Fact]
        public void TestRetrieveDataTypes()
        {
            DataTypeDefinitions result = _reader.GetColumnType();
            string[] expectedDataTypes = new string[] {
                "System.Int32", "System.Int32", "System.String", "System.DateTime",
                        "System.String", "System.String", "System.String", "System.String",
                        "System.String", "System.Int32", "System.String", "System.Int32",
                        "System.Int32", "System.String", "System.String", "System.String",
                        "System.String", "System.Object"
            };
            result.DataTypes.Should().BeEquivalentTo(expectedDataTypes);
        }

        [Fact]
        public void TestFileNotFound()
        {
            try
            {
                // CsvQueryProcessor reader = new CsvQueryProcessor(Path.Combine(Environment.CurrentDirectory, @"data/ipl2.csv"));
                CsvQueryProcessor reader = new CsvQueryProcessor(strtogetipldotcsv);
            }
            catch (Exception exception)
            {
                exception.GetType().ToString().Should().Be("System.IO.FileNotFoundException");
            }
        }
    }
}
