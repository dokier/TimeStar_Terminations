using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer.HelperClasses;
using System.Configuration;
using System.Windows.Forms;

namespace DataLayer
{
    public class DatabaseLayer
    {
        public string ConnString;
        public string ServerName;

        public string CreateConnectionString(string InstanceName)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = InstanceName,
                InitialCatalog = "master",
                IntegratedSecurity = false,
                //MultipleActiveResultSets = false,
                //PersistSecurityInfo = true,
                UserID = "sql_account",
                Password = "password"
            };

            return builder.ConnectionString;
        }

        public Object ExecuteQuery(string Query)
        {
            try
            {
                using (SqlConnection objsqlconn = new SqlConnection(ConnString))
                {
                    string setOptions = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED SET ARITHABORT ON ";
                    objsqlconn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand objcmd = new SqlCommand(setOptions + Query, objsqlconn);
                    objcmd.CommandTimeout = 60;
                    SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                    objAdp.Fill(ds);
                    return ds;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<DatabaseStatus> GetDatabaseStatus(DataRow[] Databases)
        {
            //DatabaseStatus SP = new DatabaseStatus();
            var databaseList = new List<DatabaseStatus>();
            DataSet ds = new DataSet();
            //string query = Resources.ServerProperties;

            //Change to use parameterized query instead (No user input though)

            //string query = "SELECT name, is_read_only, state_desc FROM sys.databases where name in (";
            string query = @";WITH LastBackUp AS
                    (
                    SELECT  bs.database_name,
                            bs.backup_size,
                            bs.backup_start_date,
                            bmf.physical_device_name,
                            Position = ROW_NUMBER() OVER(PARTITION BY bs.database_name ORDER BY bs.backup_start_date DESC)
                    FROM  msdb.dbo.backupmediafamily bmf
                    JOIN msdb.dbo.backupmediaset bms ON bmf.media_set_id = bms.media_set_id
                    JOIN msdb.dbo.backupset bs ON bms.media_set_id = bs.media_set_id
                    WHERE   bs.[type] = 'D'
                    and bmf.device_type = 2
                    AND bs.is_copy_only = 1
                    )
                    SELECT
                            sd.name, sd.is_read_only, sd.state_desc,
                            coalesce(backup_start_date,'') AS[last_copyonly_backupdate]
                    FROM sys.databases AS sd
                    LEFT JOIN LastBackUp AS lb
                        ON sd.name = lb.database_name
                        AND Position = 1

                        where sd.name in (";
            string comma = "";
            foreach (DataRow s in Databases)
            {
                query += comma + "'" + s[1] + "'";
                comma = ", ";
            }

            query.TrimEnd(',');
            query += ")";

            try
            {
                ds = (DataSet)ExecuteQuery(query);
                foreach (DataTable t in ds.Tables)
                {
                    foreach (DataRow r in t.Rows)
                    {
                        DatabaseStatus SP = new DatabaseStatus();
                        SP.ServerName = (String)ServerName;
                        SP.DatabaseName = (String)r["name"];
                        SP.ReadOnly = Convert.ToBoolean(r["is_read_only"]);
                        SP.StateDesc = (String)r["state_desc"];
                        SP.BackupDate = (DateTime)r["last_copyonly_backupdate"];
                        /*
                        SP.ComputerName = (String)ds.Tables["Table"].Rows[0]["ComputerName"];
                        SP.InstanceName = (String)ds.Tables["Table"].Rows[0]["InstanceName"];
                        SP.Edition = (String)ds.Tables["Table"].Rows[0]["Edition"];
                        SP.ProductVersion = (String)ds.Tables["Table"].Rows[0]["ProductVersion"];
                        SP.ProductLevel = (String)ds.Tables["Table"].Rows[0]["ProductLevel"];
                        SP.AuthMode = Convert.ToBoolean(ds.Tables["Table"].Rows[0]["AuthMode"]);
                        SP.SQLInstallDate = (DateTime)ds.Tables["Table"].Rows[0]["SQLInstallDate"];
                        SP.LocalTcpPort = (Int32)ds2.Tables["Table"].Rows[0]["local_tcp_port"];
                        SP.Success = true;
                        */
                        databaseList.Add(SP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            return databaseList;
        }

        public void SetReadOnly(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();

            //Change to use parameterized query instead (No user input though)

            string query = "ALTER DATABASE [" + Database + "] SET READ_ONLY WITH NO_WAIT";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public void SetReadWrite(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();

            //Change to use parameterized query instead (No user input though)

            string query = "ALTER DATABASE [" + Database + "] SET READ_WRITE WITH NO_WAIT";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public void SetOffline(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();

            //Change to use parameterized query instead (No user input though)

            string query = "ALTER DATABASE [" + Database + "] SET OFFLINE WITH ROLLBACK IMMEDIATE";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public void SetOnline(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();

            //Change to use parameterized query instead (No user input though)

            string query = "ALTER DATABASE [" + Database + "] SET ONLINE";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public void TakeBackup(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();
            string backupLocation = ConfigurationManager.AppSettings["BackupLocation"];
            //Change to use parameterized query instead (No user input though)

            string query = "EXECUTE DBA.dbo.DatabaseBackup @Databases='" + Database + "', @Directory = '"+ backupLocation + "', @CopyOnly= 'Y', @BackupType = 'FULL'";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (SqlException s)
            {
                MessageBox.Show("Error encountered: " + s.Message);
                //Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public void DropDatabase(string Database)
        {
            //bool success = false;
            DataSet ds = new DataSet();
            //Change to use parameterized query instead (No user input though)

            string query = "DROP DATABASE [" + Database +"];";
            try
            {
                ds = (DataSet)ExecuteQuery(query);
            }
            catch (SqlException s)
            {
                MessageBox.Show("Error encountered: " + s.Message);
                //Console.WriteLine("Exception catched: " + ex.Message);
                //SP.Success = false;
            }

            //return success;
        }

        public bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    //Console.WriteLine("Could not connect to server...");
                    return false;
                }
            }
        }
    }
}
