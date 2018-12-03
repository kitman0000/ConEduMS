function getNavbar()
{
	result = "";
	result += "<li id = MajorManage role=\"presentation\"><a href=\"MajorManage.html\">专业管理</a></li>";
	result += "<li id = SchoolManage role=\"presentation\"><a href=\"SchoolManage.html\">教学点管理</a></li>";
	result += "<li id = CourseManage role=\"presentation\"><a href=\"CourseManage.html\">课程管理</a></li>";
	result += "<li id = TeacherManage role=\"presentation\"><a href=\"TeacherManage.html\">教师管理</a></li>";
	result += "<li id = ClassManage role=\"presentation\"><a href=\"ClassManage.html\">教学班管理</a></li>";
	result += "<li id = StudentManage role=\"presentation\"><a href=\"StudentManage.html\">学生管理</a></li>";
	result += "<li id = ScoreManage role=\"presentation\"><a href=\"ScoreManage.html\">成绩管理</a></li>";
	result += "<li id = StudentSreach role=\"presentation\"><a href=\"StudentSreach.html\">学生查询</a></li>";
	return result;
}