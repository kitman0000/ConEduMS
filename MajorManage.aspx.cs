using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.ServiceModel.Web;
using System.Net;
using System.Text;
using System.IO;

public partial class MajorManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllMajors()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_ major;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"majorID\":\"" + dr[0].ToString().Trim() + "\"," +
                     "\"majorName\":\"" + dr[1].ToString().Trim() + "\"," +
                         "\"majorRemark\":\"" + dr[2].ToString().Trim() + "\"" +
                     "}";

            if (i != ds.Tables[0].Rows.Count)
            {
                resultStr += ",";
            }

            i++;
        }
        resultStr += "]";

        return resultStr;
    }

    [WebMethod]
    public static string addMajor(string majorID, string majorName, string majorRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_major VALUES (@majorID,@majorName,@majorRemark);", sqlcon);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@majorName", majorName);
        cmd.Parameters.AddWithValue("@majorRemark", majorRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delMajors(string majorID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_major WHERE majorID = @majorID;", sqlcon);
        cmd.Parameters.AddWithValue("@majorID", majorID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editMajor(string majorID, string majorName, string majorRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_major SET majorName = @majorName,majorRemark = @majorRemark WHERE majorID = @majorID;", sqlcon);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@majorName", majorName);
        cmd.Parameters.AddWithValue("@majorRemark", majorRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}