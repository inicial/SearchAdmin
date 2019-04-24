using System.Data;
using System.Data.SqlClient;

namespace CruiseSearchAdminTest
{
    public class TestHelper
    {
        private static string CONNECTION_STRING = @"Data Source={0};Initial Catalog=ts2;User ID={1}; pwd={2}; Timeout=30;";
        private static string CONNECTION_STRING_LANTA = @"Data Source={0};Initial Catalog=test;User ID={1}; pwd={2}; Timeout=30;";
        private static SqlConnection _mcConnection;
        private static SqlConnection _evConnection;
        private static string _saPass = null;
        public static string GetSaPass {
            get {
                return _saPass ??
                       (_saPass =
                        new EncriptionService.EncryptionServiceSoapClient().DecryptString("LmjCeTih4FSTCuwqO9TDow=="));
            }
        }
        public static SqlConnection McConnection 
        { 
            get {
                if (_mcConnection == null)
                    _mcConnection =
                     new SqlConnection(string.Format(CONNECTION_STRING, "192.168.10.4", "sa", GetSaPass)); if (_mcConnection.State != ConnectionState.Open) _mcConnection.Open();
                return _mcConnection;
            }
        }
        public static SqlConnection McConnectionLanta
        {
            get
            {
                if (_mcConnection == null)
                    _mcConnection =
                     new SqlConnection(string.Format(CONNECTION_STRING_LANTA, "192.168.10.4", "sa", GetSaPass)); if (_mcConnection.State != ConnectionState.Open) _mcConnection.Open();
                return _mcConnection;
            }
        }
        public static SqlConnection EvConnection
        {
            get
            {
                if(_evConnection==null)
                       _evConnection =
                        new SqlConnection(string.Format(CONNECTION_STRING, "192.168.60.2", "dzubik", GetSaPass)); if (_evConnection.State != ConnectionState.Open) _evConnection.Open();
                return _evConnection;
            }
        } 
    }
}