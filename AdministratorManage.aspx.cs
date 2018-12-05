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

public partial class AdministratorManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllAdministrators()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_Administrator;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"adminID\":\"" + dr[0].ToString().Trim() + "\"," +
                     "\"adminName\":\"" + dr[1].ToString().Trim() + "\"," +
                         "\"adminGender\":\"" + dr[2].ToString().Trim() + "\"," +
                          "\"adminBirthDate\":\"" + dr[3].ToString().Trim() + "\"," +
                           "\"adminSocialID\":\"" + dr[4].ToString().Trim() + "\"," +
                           "\"adminTel\":\"" + dr[5].ToString().Trim() + "\"," +
                           "\"adminAddress\":\"" + dr[6].ToString().Trim() + "\"" +
                            "\"adminRight\":\"" + dr[6].ToString().Trim() + "\"" +
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
    public static string addAdministrator(string classID, string majorID, string schoolID, string counselorName, string counselorTel, string startDate, string endDate)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_class VALUES (@classID,@majorID,@schoolID,@counselorName,@counselorTel,@startDate,@endDate);", sqlcon);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@schoolID", schoolID);
        cmd.Parameters.AddWithValue("@counselorName", counselorName);
        cmd.Parameters.AddWithValue("@counselorTel", counselorTel);
        cmd.Parameters.AddWithValue("@startDate", startDate);
        cmd.Parameters.AddWithValue("@endDate", endDate);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delClass(string classID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_class WHERE classID = @classID;", sqlcon);
        cmd.Parameters.AddWithValue("@classID", classID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editClass(string classID, string majorID, string schoolID, string counselorName, string counselorTel, string startDate, string endDate)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_class SET majorID = @majorID,schoolID = @schoolID,counselorName = @counselorName,counselorTel = @counselorTel, startDate = @startDate,endDate = @endDate WHERE classID = @classID;", sqlcon);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@schoolID", schoolID);
        cmd.Parameters.AddWithValue("@counselorName", counselorName);
        cmd.Parameters.AddWithValue("@counselorTel", counselorTel);
        cmd.Parameters.AddWithValue("@startDate", startDate);
        cmd.Parameters.AddWithValue("@endDate", endDate);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}