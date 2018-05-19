using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data.Filtering;

public partial class _Default : System.Web.UI.Page
{
    // global reference: required for client-side event handlers
    DateTemplate dateTemplate = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grid_AutoFilterCellEditorCreate(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorCreateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        if (e.Column.FieldName == "BirthDate")
        {
            DropDownEditProperties dde = new DropDownEditProperties();
            dde.EnableClientSideAPI = true;

            dateTemplate = new DateTemplate();

            dde.DropDownWindowTemplate = dateTemplate;
            e.EditorProperties = dde;
        }
    }
    protected void grid_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        if (e.Column.FieldName == "BirthDate")
        {
            ASPxDropDownEdit dde = e.Editor as ASPxDropDownEdit;
            dde.ClientSideEvents.CloseUp = String.Format("function (s, e) {{ ApplyFilter(s, {0}, {1}); }}", dateTemplate.cIdFrom, dateTemplate.cIdTo);
            dde.ClientSideEvents.DropDown = String.Format("function (s, e) {{ OnDropDown(s, {0}, {1}); }}", dateTemplate.cIdFrom, dateTemplate.cIdTo);
            dde.ReadOnly = true;
        }
    }

    protected void grid_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
    {
        if (e.Value == "|")
            return;
        if (e.Column.FieldName == "BirthDate")
        {
            if (e.Kind == GridViewAutoFilterEventKind.CreateCriteria)
            {
                Session["BrithDateFilter"] = e.Value;
                String[] dates = e.Value.Split('|');
                DateTime dateFrom = Convert.ToDateTime(dates[0]),
                    dateTo = Convert.ToDateTime(dates[1]);
                e.Criteria = (new OperandProperty("BirthDate") >= dateFrom) &
                             (new OperandProperty("BirthDate") <= dateTo);
            }
            else
            {
                if (Session["BrithDateFilter"] != null)
                    e.Value = Session["BrithDateFilter"].ToString();
            }
        }
    }
}
