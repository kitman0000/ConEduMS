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

public partial class trainingSchoolManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAlltrainingSchools()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_trainingSchool;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"schoolID\":\"" + dr[0].ToString().Trim() + "\"," +
                     "\"schoolName\":\"" + dr[1].ToString().Trim() + "\"," +
                         "\"schoolAddress\":\"" + dr[2].ToString().Trim() + "\"," +
                          "\"schoolTel\":\"" + dr[3].ToString().Trim() + "\"," +
                           "\"schoolRemark\":\"" + dr[4].ToString().Trim() + "\"," +                          
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
    public static string addTrainingSchool(string schoolID, string schoolName, string schoolAddress, string schoolTel, string schoolRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_trainingSchool VALUES (@schoolID,@schoolName,@schoolAddress,@schoolTel,@schoolRemark);", sqlcon);
        cmd.Parameters.AddWithValue("@schoolID", schoolID);
        cmd.Parameters.AddWithValue("@schoolName", schoolName);
        cmd.Parameters.AddWithValue("@schoolAddress", schoolAddress);
        cmd.Parameters.AddWithValue("@schoolTel", schoolTel);
        cmd.Parameters.AddWithValue("@schoolRemark", schoolRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delTrainingSchool(string schoolID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_trainingSchool WHERE schoolID = @schoolID;", sqlcon);
        cmd.Parameters.AddWithValue("@schoolID", schoolID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editTrainingSchool(string schoolID, string schoolName, string schoolAddress, string schoolTel, string schoolRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_trainingSchool SET schoolName = @schoolName,schoolAddress = @schoolAddress,schoolTel = @schoolTel,schoolRemark = @schoolRemark;", sqlcon);
        cmd.Parameters.AddWithValue("@schoolID", schoolID);
        cmd.Parameters.AddWithValue("@schoolName", schoolName);
        cmd.Parameters.AddWithValue("@schoolAddress", schoolAddress);
        cmd.Parameters.AddWithValue("@schoolTel", schoolTel);
        cmd.Parameters.AddWithValue("@schoolRemark", schoolRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}