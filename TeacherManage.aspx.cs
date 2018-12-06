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

public partial class TeacherManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllTeachers()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_teacher;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
                resultStr += "{\"teacherID\":\"" + dr[0].ToString().Trim() + "\"," +
                                    "\"teacherName\":\"" + dr[1].ToString().Trim() + "\"," +
                                    "\"teacherGender\":\"" + dr[2].ToString().Trim() + "\"," +
                                    "\"teacherBirthDate\":\"" + dr[3].ToString().Trim() + "\"," +
                                    "\"teacherSocialID\":\"" + dr[4].ToString().Trim() + "\"," +
                                    "\"teacherTel\":\"" + dr[5].ToString().Trim() + "\"," +
                                    "\"teacherAddress\":\"" + dr[6].ToString().Trim() + "\"," +
                                    "\"teacherRemark\":\"" + dr[7].ToString().Trim() + "\"," +
                                        "\"majorID\":\"" + dr[8].ToString().Trim() + "\"" +
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
    public static string addTeacher(string teacherID, string teacherName, string teacherGender, string teacherBirthDate, string teacherSocialID, string teacherTel, string teacherAddress,string teacherRemark,string majorID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_teacher VALUES (@teacherID,@teacherName,@teacherGender,@teacherBirthDate,@teacherSocialID,@teacherTel,@teacherAddress,@teacherRemark,@majorID);", sqlcon);
        cmd.Parameters.AddWithValue("@teacherID", teacherID);
        cmd.Parameters.AddWithValue("@teacherName", teacherName);
        cmd.Parameters.AddWithValue("@teacherGender", teacherGender);   
        cmd.Parameters.AddWithValue("@teacherBirthDate", teacherBirthDate);
        cmd.Parameters.AddWithValue("@teacherSocialID", teacherSocialID);
        cmd.Parameters.AddWithValue("@teacherTel", teacherTel);
        cmd.Parameters.AddWithValue("@teacherAddress", teacherAddress);
        cmd.Parameters.AddWithValue("@teacherRemark", teacherRemark);
        cmd.Parameters.AddWithValue("@majorID", majorID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delTeacher(string teacherID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_teacher WHERE teacherID = @teacherID;", sqlcon);
        cmd.Parameters.AddWithValue("@teacherID", teacherID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editTeacher(string teacherID, string teacherName, string teacherGender, string teacherBirthDate, string teacherSocialID, string teacherTel, string teacherAddress, string teacherRemark, string majorID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_teacher SET teacherName = @teacherName,teacherGender = @teacherGender,teacherBirthDate = @teacherBirthDate, teacherSocialID = @teacherSocialID,teacherTel = @teacherTel,teacherAddress = @teacherAddress, teacherRemark = @teacherRemark,majorID = @majorID WHERE teacherID = @teacherID;", sqlcon);
        cmd.Parameters.AddWithValue("@teacherID", teacherID);
        cmd.Parameters.AddWithValue("@teacherName", teacherName);
        cmd.Parameters.AddWithValue("@teacherGender", teacherGender);
        cmd.Parameters.AddWithValue("@teacherBirthDate", teacherBirthDate);
        cmd.Parameters.AddWithValue("@teacherSocialID", teacherSocialID);
        cmd.Parameters.AddWithValue("@teacherTel", teacherTel);
        cmd.Parameters.AddWithValue("@teacherAddress", teacherAddress);
        cmd.Parameters.AddWithValue("@teacherRemark", teacherRemark);
        cmd.Parameters.AddWithValue("@majorID", majorID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}