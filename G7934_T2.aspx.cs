using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;

public partial class G7934_T2 : System.Web.UI.Page
{
    String file;
    DataSet ds;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        file = WebConfigurationManager.AppSettings["file"];

        if (file.Length > 0)
        {
            if (!IsPostBack)
            {
                refresh("");
            }
        } 
        else
        {
            found.Visible = false;
            notfound.Visible = true;
        }
    }

    private void refresh(String s)
    {
        if (!s.Equals(""))
        {
            ds = new DataSet();
            ds.ReadXml(file);
            var dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "tyosuhde = '" + s + "'";
            gvData.DataSource = dv;
            gvData.DataBind();
        }
        else
        {
            ds = new DataSet();
            ds.ReadXml(file);
            gvData.DataSource = ds;
            gvData.DataBind();
        }
    }

    private int countStuff(String s)
    {
        ds = new DataSet();
        ds.ReadXml(file);
        dt = ds.Tables[0];
        var groupedData = from b in dt.AsEnumerable()
                          group b by b.Field<string>("tyosuhde") into g
                          select new
                          {
                              TyoSuhde = g.Key,
                              Sum = g.Sum(x => 1)
                          };
        int totals = 0;
        foreach (var item in groupedData)
        {
            if (item.TyoSuhde.Equals(s) || s.Equals(""))
            {
                totals = totals + item.Sum;
            }
        }
        return totals;
    }

    private int countSalaries(String s)
    {
        ds = new DataSet();
        ds.ReadXml(file);
        dt = ds.Tables[0];
        var groupedData = from b in dt.AsEnumerable()
                          group b by b.Field<string>("tyosuhde") into g
                          select new
                          {
                              TyoSuhde = g.Key,
                              ChargeSum = g.Sum(x => int.Parse(x.Field<string>("palkka")))
                          };
        int total = 0;
        foreach (var item in groupedData)
        {
            if (item.TyoSuhde == s || s.Equals(""))
            {
                total = total + item.ChargeSum;
            }
        }
        return total;
    }

    protected void btnAll_Click(object sender, EventArgs e)
    {
        refresh("");
    }

    protected void btnVakkarit_Click(object sender, EventArgs e)
    {
        refresh("vakituinen");
    }

    protected void btnMaaraikaset_Click(object sender, EventArgs e)
    {
        refresh("määräaikainen");
    }

    protected void btnElse_Click(object sender, EventArgs e)
    {
        refresh("vierailija");
    }

    protected void btnCountAll_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Kaikkien työntekijöiden määrä: " + countStuff("").ToString();
    }

    protected void btnCountVakkarit_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Vakituisten työntekijöiden määrä: " + countStuff("vakituinen").ToString();
    }

    protected void btnCountMaaraikaset_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Määräaikaisten työntekijöiden määrä: " + countStuff("määräaikainen").ToString();
    }

    protected void btnCountElse_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Muiden työntekijöiden määrä: " + countStuff("vierailija").ToString();
    }

    protected void btnCountSalariesAll_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Kaikkien työntekijöiden palkka: " + countSalaries("");
    }

    protected void btnCountSalariesVakkarit_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Vakituisten työntekijöiden palkka: " + +countSalaries("vakituinen");
    }

    protected void btnCountSalariesMaaraikaset_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Määräaikaisten työntekijöiden palkka: " + +countSalaries("määräaikainen");
    }

    protected void btnCountSalariesElse_Click(object sender, EventArgs e)
    {
        lblCount.Text = "Muiden työntekijöiden palkka: " + +countSalaries("vierailija");
    }
}