using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DataLayer;
using DataLayer.HelperClasses;

namespace TimeStar_Terminations.UtilityClasses
{
    public class Utility
    {
        public static void trimData(DataTable dt)
        {
            foreach (DataColumn c in dt.Columns)
                if (c.DataType == typeof(string))
                    foreach (DataRow r in dt.Rows)
                        try
                        {
                            r[c.ColumnName] = r[c.ColumnName].ToString().ToUpper().Trim();
                        }
                        catch
                        {
                            string message = "Error trimming data table";
                            MessageBox.Show(message);
                        }
        }

        public static DataTable ObjectToData(object o)
        {
            DataTable dt = new DataTable("OutputData");

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(o, null);
                    dt.Columns.Add(f.Name, f.PropertyType);
                    dt.Rows[0][f.Name] = f.GetValue(o, null);
                }
                catch {
                    string message = "Error converting object to data table";
                    MessageBox.Show(message);
                }
            });
            return dt;
        }

        public static DataTable RefreshDataGrid(DataTable dt)
        {
            //loading to a dataview so we can filter and get distinct server values
            DataView view = new DataView(dt);
            DataTable distinctValues = view.ToTable(true, "ServerName");

            //Create a new data table to load results from each server connection
            DataTable results = new DataTable();


            foreach (DataRow row in distinctValues.Rows)
            {
                string serverName = row[0].ToString();
                //Get Database Names
                DataRow[] result = dt.Select("[ServerName] = '" + serverName + "'");

                DatabaseLayer objDataLayer = new DatabaseLayer();
                objDataLayer.ServerName = serverName;
                objDataLayer.ConnString = objDataLayer.CreateConnectionString(serverName);

                if (objDataLayer.IsServerConnected(objDataLayer.ConnString) == true)
                {

                    foreach (DatabaseStatus DS in objDataLayer.GetDatabaseStatus(result))
                    {
                        results.Merge(Utility.ObjectToData(DS));
                    }
                }
                else
                {
                    string message = "Could not connect to Instance: " + serverName;
                    MessageBox.Show(message);
                }
            }

            return results;
        }
    }
}
