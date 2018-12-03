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


public partial class ScoreManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getAllScores()
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("SELECT * FROM DB_ConEduMS.dbo.tb_score;", sqlcon);
        DataSet ds;
        ds = SQLserverOper.executeSqlWithReturn(cmd);

        int i = 1;
        resultStr += "[";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            resultStr += "{\"stuID\":\"" + dr[0].ToString().Trim() + "\"," +
                            "\"courseID\":\"" + dr[1].ToString().Trim() + "\"," +
                            "\"semesterID\":\"" + dr[2].ToString().Trim() + "\"," +
                            "\"teacherID\":\"" + dr[3].ToString().Trim() + "\"," +
                            "\"classID\":\"" + dr[4].ToString().Trim() + "\"," +
                            "\"score\":\"" + dr[5].ToString().Trim() + "\"" +
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
    public static string addScore(string stuID, string courseID, string semesterID, string teacherID, string classID, string score)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("INSERT INTO DB_ConEduMS.dbo.tb_score VALUES (@stuID,@courseID,@semesterID,@teacherID,@classID,@score);", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);
        cmd.Parameters.AddWithValue("@courseID", courseID);
        cmd.Parameters.AddWithValue("@semesterID", semesterID);
        cmd.Parameters.AddWithValue("@teacherID", teacherID);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@score", score);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";
        return resultStr;
    }

    [WebMethod]
    public static string delScore(string stuID)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);
        SqlCommand cmd = new SqlCommand("DELETE FROM DB_ConEduMS.dbo.tb_score WHERE stuID = @stuID;", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }

    [WebMethod]
    public static string editScore(string stuID, string courseID, string semesterID, string teacherID, string classID, string score)
    {
        string resultStr = "";

        SqlConnection sqlcon = null;
        SQLserverOper.open(ref sqlcon);

        SqlCommand cmd = new SqlCommand("UPDATE DB_ConEduMS.dbo.tb_score SET courseID = @courseID,semesterID = @semesterID,teacherID = @teacherID, classID = @classID,score = @score WHERE stuID = @stuID;", sqlcon);
        cmd.Parameters.AddWithValue("@stuID", stuID);
        cmd.Parameters.AddWithValue("@courseID", courseID);
        cmd.Parameters.AddWithValue("@semesterID", semesterID);
        cmd.Parameters.AddWithValue("@teacherID", teacherID);
        cmd.Parameters.AddWithValue("@classID", classID);
        cmd.Parameters.AddWithValue("@score", score);

        SQLserverOper.executeSql(cmd);

        resultStr = "success";

        return resultStr;
    }
}