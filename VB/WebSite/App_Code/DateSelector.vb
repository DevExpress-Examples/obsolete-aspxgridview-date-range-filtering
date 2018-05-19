Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web


Public Class DateSelector
    Implements ITemplate

    Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        Dim lbl As New ASPxLabel()
        lbl.ID = "lblFrom"
        lbl.Text = "From:"
        container.Controls.Add(lbl)

        Dim dateFrom As New ASPxDateEdit()
        dateFrom.ID = "dateFrom"
        dateFrom.ClientInstanceName = "dFrom"
        dateFrom.Date = New Date(1950, 1, 1)
        container.Controls.Add(dateFrom)

        lbl = New ASPxLabel()
        lbl.ID = "lblTo"
        lbl.Text = "To:"
        container.Controls.Add(lbl)

        Dim dateTo As New ASPxDateEdit()
        dateTo.ID = "dateTo"
        dateTo.ClientInstanceName = "dTo"
        dateTo.Date = New Date(1960, 11, 30)
        container.Controls.Add(dateTo)

        Dim btn As New ASPxButton()
        btn.ID = "btnApply"
        btn.Text = "Apply"
        btn.AutoPostBack = False
        btn.ClientSideEvents.Click = "function (s, e) { ApplyFilter( dFrom, dTo ); }"
        container.Controls.Add(btn)
    End Sub
End Class