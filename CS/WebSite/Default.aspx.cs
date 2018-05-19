using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data.Filtering;

public partial class _Default : System.Web.UI.Page
{
    protected void grid_AutoFilterCellEditorCreate(object sender, ASPxGridViewEditorCreateEventArgs e)
    {
        if (e.Column.FieldName == "BirthDate") e.Column.FilterTemplate = new DateSelector();
    }

    protected void grid_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
    {
        if (e.Value == "|") return;

        if (e.Column.FieldName == "BirthDate")
        {
            if (e.Kind == GridViewAutoFilterEventKind.CreateCriteria)
            {
                String[] dates = e.Value.Split('|');
                Session["BirthDateFilterText"] = dates[0] + " - " + dates[1];
                DateTime dateFrom = Convert.ToDateTime(dates[0]), dateTo = Convert.ToDateTime(dates[1]);
                e.Criteria = (new OperandProperty("BirthDate") >= dateFrom) & (new OperandProperty("BirthDate") <= dateTo);
            }
            else if (e.Kind == GridViewAutoFilterEventKind.ExtractDisplayText)
            {
                e.Value = Session["BirthDateFilterText"].ToString();
            }
        }
    }
}
