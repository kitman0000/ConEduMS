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
    public static string addAdministrator(string adminID, string adminName, string adminGender, string adminBirthDate, string adminSocialID, string adminTel, string adminAddress,string adminRight)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_Administrator VALUES (@adminID,@adminName,@adminGender,@adminBirthDate,@adminSocialID,@adminTel,@adminAddress,@adminRight);", sqlcon);
        cmd.Parameters.AddWithValue("@adminID", adminID);
        cmd.Parameters.AddWithValue("@adminName", adminName);
        cmd.Parameters.AddWithValue("@adminGender", adminGender);
        cmd.Parameters.AddWithValue("@adminBirthDate", adminBirthDate);
        cmd.Parameters.AddWithValue("@adminSocialID", adminSocialID);
        cmd.Parameters.AddWithValue("@adminTel", adminTel);
        cmd.Parameters.AddWithValue("@adminAddress", adminAddress);
        cmd.Parameters.AddWithValue("@adminRight", adminRight);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delAdministrator(string adminID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_Administrator WHERE adminID = @adminID;", sqlcon);
        cmd.Parameters.AddWithValue("@adminID", adminID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editAdministrator(string adminID, string adminName, string adminGender, string adminBirthDate, string adminSocialID, string adminTel, string adminAddress,string adminRight)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_Administrator SET adminName = @adminName,adminGender = @adminGender,adminBirthDate = @adminBirthDate,adminSocialID = @adminSocialID, adminTel = @adminTel,adminAddress = @adminAddress,adminRight =@adminRight WHERE adminID = @adminID;", sqlcon);
        cmd.Parameters.AddWithValue("@adminID", adminID);
        cmd.Parameters.AddWithValue("@adminName", adminName);
        cmd.Parameters.AddWithValue("@adminGender", adminGender);
        cmd.Parameters.AddWithValue("@adminBirthDate", adminBirthDate);
        cmd.Parameters.AddWithValue("@adminSocialID", adminSocialID);
        cmd.Parameters.AddWithValue("@adminTel", adminTel);
        cmd.Parameters.AddWithValue("@adminAddress", adminAddress);
        cmd.Parameters.AddWithValue("@adminRight", adminRight);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}