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


public class DateTemplate : ITemplate
{
    // client IDs of two ASPxDateEdit controls
    public String cIdFrom;
    public String cIdTo;

    public void InstantiateIn(Control container)
    {
        Table table = new Table();
        container.Controls.Add(table);
        TableRow row = new TableRow();
        table.Rows.Add(row);

        TableCell cell = new TableCell();
        row.Cells.Add(cell);
        ASPxLabel lbl = new ASPxLabel();
        lbl.ID = "lblFrom";
        lbl.Text = "From:";
        cell.Controls.Add(lbl);
        
        cell = new TableCell();
        row.Cells.Add(cell);
        ASPxDateEdit dateFrom = new ASPxDateEdit();
        dateFrom.ID = "dateFrom";
        dateFrom.EnableClientSideAPI = true;
        cell.Controls.Add(dateFrom);
        
        row = new TableRow();

        table.Rows.Add(row);

        cell = new TableCell();
        row.Cells.Add(cell);
        lbl = new ASPxLabel();
        lbl.ID = "lblTo";
        lbl.Text = "To:";
        cell.Controls.Add(lbl);

        cell = new TableCell();
        row.Cells.Add(cell);
        ASPxDateEdit dateTo = new ASPxDateEdit();
        dateTo.ID = "dateTo";
        dateTo.EnableClientSideAPI = true;
        cell.Controls.Add(dateTo);

        cIdFrom = dateFrom.ClientID;
        cIdTo = dateTo.ClientID;

        row = new TableRow();

        table.Rows.Add(row);

        cell = new TableCell();
        cell.ColumnSpan = 2;
        row.Cells.Add(cell);
        ASPxHyperLink lnk = new ASPxHyperLink();
        lnk.ID = "lnkApply";
        lnk.Text = "Apply";
        lnk.NavigateUrl = "javascript:void(0)";
        lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.HideDropDown(); ApplyFilter({0}, {1}, {2}); }}",
            container.NamingContainer.NamingContainer.ClientID,
            cIdFrom,
            cIdTo);
        cell.Controls.Add(lnk);
    }
}
