using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class G7934_T3c : System.Web.UI.Page
{
    DemoxOyEntities ctx;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            // Tähän alkuilmo!
            start.Visible = true;

            try
            {
                ctx = new DemoxOyEntities();
                var results = from c in ctx.lasnaolot
                              select new
                              {
                                  asioId = c.asioid,
                                  course = c.course
                              };
                int students = 0, courses = 0;
                List<string> usedStudents, usedCourses;
                usedStudents = new List<string>();
                usedCourses = new List<string>();
                foreach (var i in results)
                {
                    if (!usedStudents.Contains(i.asioId))
                    {
                        usedStudents.Add(i.asioId);
                        students++;
                    }
                    if (!usedCourses.Contains(i.course))
                    {
                        usedCourses.Add(i.course);
                        courses++;
                    }
                }
                lblStudentsAmount.Text = "Oppilaita: " + students;
                lblCoursesAmount.Text = "Kursseja: " + courses;

                populateDDL();
            } catch
            {
                lblStudentsAmount.Text = "Kantaan ei saatu yhteyttä!";
            }
        } else
        {
            start.Visible = false;
        }
    }

    private void populateDDL()
    {
        var results = from c in ctx.lasnaolot
                      group c by c.course into g
                      select new
                      {
                          course = g.Key
                      };
        List<string> courses = new List<string>();
        foreach (var i in results)
        {
            courses.Add(i.course);
        }
        ddlCourses.DataSource = courses;
        ddlCourses.DataBind();

        var results2 = from c in ctx.lasnaolot
                       orderby c.lastname ascending
                       select new
                       {
                           firstname = c.firstname,
                           lastname = c.lastname
                       };
        List<string> studentList = new List<string>();
        foreach (var i in results2)
        {
            if (!studentList.Contains(i.firstname + " " + i.lastname))
            {
                studentList.Add(i.firstname + " " + i.lastname);
            }
        }
        ddlStudents.DataSource = studentList;
        ddlStudents.DataBind();
    }

    protected void btnShowAllStudents_Click(object sender, EventArgs e)
    {
        ctx = new DemoxOyEntities();
        var results = from c in ctx.lasnaolot
                      select new
                      {
                          asioId = c.asioid,
                          firstname = c.firstname,
                          lastname = c.lastname
                      };
        List<string> studentList = new List<string>();
        foreach (var i in results)
        {
            if (!studentList.Contains(i.firstname + " " + i.lastname))
            {
                studentList.Add(i.firstname + " " + i.lastname);
            }
        }

        gvData.DataSource = studentList;
        gvData.DataBind();
    }

    protected void btnOrderByLastName_Click(object sender, EventArgs e)
    {
        /*ctx = new DemoxOyEntities();
        var results = from c in ctx.lasnaolot
                      select new Lasnaolo
                      {
                          asioid = c.asioid,
                          firstname = c.firstname,
                          lastname = c.lastname,
                          date = c.date.ToString(),
                          course = c.course
                      };*/
        ctx = new DemoxOyEntities();
        var results = from c in ctx.lasnaolot
                      orderby c.lastname ascending
                      select new
                      {
                          asioId = c.asioid,
                          firstname = c.firstname,
                          lastname = c.lastname
                      };
        List<string> studentList = new List<string>();
        foreach (var i in results)
        {
            if (!studentList.Contains(i.firstname + " " + i.lastname))
            {
                studentList.Add(i.firstname + " " + i.lastname);
            }
        }

        gvData.DataSource = studentList;
        gvData.DataBind();
    }

    protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedCourse = ddlCourses.SelectedValue;
        ctx = new DemoxOyEntities();
        var results = from c in ctx.lasnaolot
                      where c.course == selectedCourse
                      orderby c.lastname ascending
                      select new
                      {
                          asioId = c.asioid,
                          firstname = c.firstname,
                          lastname = c.lastname
                      };
        List<string> studentList = new List<string>();
        foreach (var i in results)
        {
            if (!studentList.Contains(i.firstname + " " + i.lastname))
            {
                studentList.Add(i.firstname + " " + i.lastname);
            }
        }

        gvData.DataSource = studentList;
        gvData.DataBind();
    }

    protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        string chosenOne = ddlStudents.SelectedValue;
        ctx = new DemoxOyEntities();
        var results = from c in ctx.lasnaolot
                      where c.firstname + " " + c.lastname == chosenOne
                      orderby c.lastname descending
                      select new
                      {
                          firstname = c.firstname,
                          lastname = c.lastname,
                          course = c.course,
                          date = c.date
                      };
        
        gvData.DataSource = results.ToList();
        gvData.DataBind();
    }
}