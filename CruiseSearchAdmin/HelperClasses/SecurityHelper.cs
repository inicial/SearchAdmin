using System;
using System.Data.SqlClient;
using System.Diagnostics;
using CruiseSearchAdmin.EncriptionService;
using lanta.SQLConfig;

namespace CruiseSearchAdmin.HelperClasses
{
    public class SecurityHelper
    {
        private static string _saPass=null;
        public static string GetSuperUserPassword
        {
            get
            {
                try
                {
                    if (_saPass == null)
                    {
                        lanta.SQLConfig.Config_XML cfg = new Config_XML();
                        var cryptedPass = cfg.Get_Value("appSettings", "saPass");
                        EncryptionServiceSoap encryptionService = new EncryptionServiceSoapClient();
                        _saPass = encryptionService.DecryptString(cryptedPass);
                    }
                    return _saPass;
                }
                catch
                {
                    _saPass = string.Empty;
                    throw new Exception("Дешифровка данных неудачна");
                }
            }
        }
    }

    public class AccessController
    {
        private ulong _accessBitMask = 0;
        
        private SqlConnection _sqlConnection;
     
        public AccessController(SqlConnection connection)
        {
            _sqlConnection = connection;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connection.ConnectionString);
            _accessBitMask = GetAccessRigts(connection, sb.UserID);
            
        }
        public bool IsAdmin(string principal)
        {
            var adm = false;
            using (SqlCommand com = new SqlCommand(@"select IS_SRVROLEMEMBER ('sysadmin',@principal)", _sqlConnection))
            {
                com.Parameters.AddWithValue("@principal", principal);
                object res = com.ExecuteScalar();
                if (res != DBNull.Value && (int) res != 0)
                {
                    adm = true;
                }
            }
            return adm;
        }
        public bool IsAdmin()
        {
#if  DEBUG 
            return true;
#endif

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(_sqlConnection.ConnectionString);
            return IsAdmin(sb.UserID);
        }
        private ulong GetAccessRigts(SqlConnection connection,string principal)
        {
            ulong accessBitMask = 0;
            bool isAdmin = IsAdmin(principal);
            using (SqlCommand com = new SqlCommand(@"select IS_ROLEMEMBER('csaSynchronizator',@principal)", connection))
            {
                com.Parameters.AddWithValue("@principal", principal);
                object res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0)||isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.SyncAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaCruiseEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.CruiseEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaShipsEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.ShipsEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaPortsEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.PortsEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaActionsEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.ActionsEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaExcursionsEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.ExcursionsEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaDiscountEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0)||isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.DiscountEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaVisaEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.VisaEditAccess;
                }
                com.CommandText = @"select IS_ROLEMEMBER('csaCruiseSearchSettingsEditor',@principal)";
                res = com.ExecuteScalar();
                if ((res != DBNull.Value && (int)res != 0) || isAdmin)
                {
                    accessBitMask |= (ulong)AccessRigt.CruiseSearchSettingsAccess;
                }
                return accessBitMask;
            }
        }
        public bool IsAccess(AccessRigt accessRigt)
        {
            if (IsAdmin()) return true;
            return ((_accessBitMask & (ulong) accessRigt) != 0);
        }
        public bool IsAccess(AccessRigt accessRigt,string principal)
        {
            if (IsAdmin(principal)) return true;
            var accessBitMask = GetAccessRigts(_sqlConnection, principal);
            return ((accessBitMask & (ulong)accessRigt) != 0);
        }
    }
    public enum AccessRigt:ulong
        {
            SyncAccess = 1,
            CruiseEditAccess = 2,
            ShipsEditAccess = 4,
            PortsEditAccess = 8,
            ActionsEditAccess = 16,
            ExcursionsEditAccess = 32,
            DiscountEditAccess = 64,
            VisaEditAccess = 128,
            CruiseSearchSettingsAccess = 256

        }
}