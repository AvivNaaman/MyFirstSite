using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
//
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//

/// <summary>
/// Summary description for DalAccessAccess
/// </summary>
public class DalAccess
{

    private string dbPath;
    private OleDbConnection conn;
    private OleDbCommand command;
    private OleDbDataAdapter adapter;


    public DalAccess(string strQuery)
    {

        //לכאן יש להעתיק את ה string Connection 
        string ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Data.accdb");

        conn = new OleDbConnection(ConnectionString);
        command = new OleDbCommand(strQuery, conn);
        adapter = new OleDbDataAdapter(command);
    }

    public int InsertUpdateDelete(string strSql)
    {
        int rowsAffected;
        this.conn.Open();
        OleDbCommand cmd = new OleDbCommand(strSql, conn);
        rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return rowsAffected;
    }


    public DataSet GetDataSet(string strSql, string tableName)
    {
        DataSet ds = new DataSet();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(strSql, this.conn);
        dataAdapter.Fill(ds, tableName);
        return ds;
    }
}