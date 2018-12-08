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

public partial class CourseManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllCourses()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_course;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"courseID\":\"" + dr[0].ToString().Trim() + "\"," +
                     "\"courseName\":\"" + dr[1].ToString().Trim() + "\"," +
                         "\"courseRemark\":\"" + dr[2].ToString().Trim() + "\"" +
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
    public static string addCourse(string courseID, string courseName, string courseRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_course VALUES (@courseID,@courseName,@courseRemark);", sqlcon);
        cmd.Parameters.AddWithValue("@courseID", courseID);
        cmd.Parameters.AddWithValue("@courseName", courseName);
        cmd.Parameters.AddWithValue("@courseRemark", courseRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delCourse(string courseID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_course WHERE courseID = @courseID;", sqlcon);
        cmd.Parameters.AddWithValue("@courseID", courseID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editCourse(string courseID, string courseName, string courseRemark)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_course SET courseName = @courseName,courseRemark = @courseRemark WHERE courseID = @courseID;", sqlcon);
        cmd.Parameters.AddWithValue("@courseID", courseID);
        cmd.Parameters.AddWithValue("@courseName", courseName);
        cmd.Parameters.AddWithValue("@courseRemark", courseRemark);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}   