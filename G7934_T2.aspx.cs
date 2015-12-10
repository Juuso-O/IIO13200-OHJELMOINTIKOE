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

    protected void Page_Load(object sender, EventArgs e)
    {
        file = WebConfigurationManager.AppSettings["file"];

        if (file.Length > 0)
        {
            if (!IsPostBack)
            {
                ds = new DataSet();
                ds.ReadXml(file);
                gvData.DataSource = ds;
                gvData.DataBind();
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
        ds = new DataSet();
        ds.ReadXml(file);
        var dv = ds.Tables[0].DefaultView;
        dv.RowFilter = "tyosuhde = '"+ s + "'";
        gvData.DataSource = dv;
        gvData.DataBind();
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
        ds = new DataSet();
        ds.ReadXml(file);
        gvData.DataSource = ds;
        gvData.DataBind();

        lblCount.Text = "Kaikkien työntekijöiden määrä: " + gvData.Rows.Count.ToString();
    }

    protected void btnCountVakkarit_Click(object sender, EventArgs e)
    {
        refresh("vakituinen");

        lblCount.Text = "Vakituisten työntekijöiden määrä: " + gvData.Rows.Count.ToString();
    }

    protected void btnCountMaaraikaset_Click(object sender, EventArgs e)
    {
        refresh("määräaikainen");

        lblCount.Text = "Määräaikaisten työntekijöiden määrä: " + gvData.Rows.Count.ToString();
    }

    protected void btnCountElse_Click(object sender, EventArgs e)
    {
        refresh("vierailija");

        lblCount.Text = "Muiden työntekijöiden määrä: " + gvData.Rows.Count.ToString();
    }

    protected void btnCountSalariesAll_Click(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds.ReadXml(file);
        gvData.DataSource = ds;
        gvData.DataBind();

        var groupedData = from b in ds.Tables[0].AsEnumerable()
                          group b by b.Field<string>("etunimi") into g
                          select new
                          {
                              ChargeTag = g.Key,
                              Count = g.Count(),
                              ChargeSum = g.Sum(x => x.Field<int>("palkka"))
                          };
        int total = 0;
        foreach (var item in groupedData)
        {
            total = item.ChargeSum;
        }
        lblCount.Text = "Kaikkien työntekijöiden palkka: " + total.ToString();
    }

    protected void btnCountSalariesVakkarit_Click(object sender, EventArgs e)
    {

    }

    protected void btnCountSalariesMaaraikaset_Click(object sender, EventArgs e)
    {

    }

    protected void btnCountSalariesElse_Click(object sender, EventArgs e)
    {

    }
}