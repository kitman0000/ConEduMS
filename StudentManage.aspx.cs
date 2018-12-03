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


public partial class StudentManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllStudents()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_student;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"stuID\":\"" + dr[0].ToString().Trim() + "\"," +
                                "\"classID\":\"" + dr[1].ToString().Trim() + "\"," +
                                "\"majorID\":\"" + dr[2].ToString().Trim() + "\"," +
                                "\"stuGender\":\"" + dr[3].ToString().Trim() + "\"," +
                                "\"stuBirthDate\":\"" + dr[4].ToString().Trim() + "\"," +
                                "\"stuSocialID\":\"" + dr[5].ToString().Trim() + "\"," +
                                "\"stuTel\":\"" + dr[6].ToString().Trim() + "\"," +
                                "\"stuAddress\":\"" + dr[7].ToString().Trim() + "\"," +
                                    "\"stuRemark\":\"" + dr[8].ToString().Trim() + "\"" +
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
    public static string addStudent(string stuID, string classID, string majorID, string stuGender, string stuBirthDate, string stuSocialID, string stuTel, string stuAddress, string stuRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_teacher VALUES (@stuID,@classID,@majorID,@stuGender,@stuBirthDate,@stuSocialID,@stuTel,@stuAddress,@stuRemark);", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@stuGender", stuGender);
        cmd.Parameters.AddWithValue("@stuBirthDate", stuBirthDate);
        cmd.Parameters.AddWithValue("@stuSocialID", stuSocialID);
        cmd.Parameters.AddWithValue("@stuTel", stuTel);
        cmd.Parameters.AddWithValue("@stuAddress", stuAddress);
        cmd.Parameters.AddWithValue("@stuRemark", stuRemark);
        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delStudent(string stuID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_teacher WHERE stuID = @stuID;", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editStudent(string stuID, string classID, string majorID, string stuGender, string stuBirthDate, string stuSocialID, string stuTel, string stuAddress, string stuRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_teacher SET classID = @classID,majorID = @majorID, stuGender = @stuGender,stuBirthDate = @stuBirthDate,stuSocialID = @stuSocialID, stuTel = @stuTel,stuAddress = @stuAddress,stuRemark =@stuRemark WHERE stuID = @stuID;", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@majorID", majorID);
        cmd.Parameters.AddWithValue("@stuGender", stuGender);
        cmd.Parameters.AddWithValue("@stuBirthDate", stuBirthDate);
        cmd.Parameters.AddWithValue("@stuSocialID", stuSocialID);
        cmd.Parameters.AddWithValue("@stuTel", stuTel);
        cmd.Parameters.AddWithValue("@stuAddress", stuAddress);
        cmd.Parameters.AddWithValue("@stuRemark", stuRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}