Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors


Public Class DateTemplate
	Implements ITemplate
	' client IDs of two ASPxDateEdit controls
	Public cIdFrom As String
	Public cIdTo As String

	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Dim table As New Table()
		container.Controls.Add(table)
		Dim row As New TableRow()
		table.Rows.Add(row)

		Dim cell As New TableCell()
		row.Cells.Add(cell)
		Dim lbl As New ASPxLabel()
		lbl.ID = "lblFrom"
		lbl.Text = "From:"
		cell.Controls.Add(lbl)

		cell = New TableCell()
		row.Cells.Add(cell)
		Dim dateFrom As New ASPxDateEdit()
		dateFrom.ID = "dateFrom"
		dateFrom.EnableClientSideAPI = True
		cell.Controls.Add(dateFrom)

		row = New TableRow()

		table.Rows.Add(row)

		cell = New TableCell()
		row.Cells.Add(cell)
		lbl = New ASPxLabel()
		lbl.ID = "lblTo"
		lbl.Text = "To:"
		cell.Controls.Add(lbl)

		cell = New TableCell()
		row.Cells.Add(cell)
		Dim dateTo As New ASPxDateEdit()
		dateTo.ID = "dateTo"
		dateTo.EnableClientSideAPI = True
		cell.Controls.Add(dateTo)

		cIdFrom = dateFrom.ClientID
		cIdTo = dateTo.ClientID

		row = New TableRow()

		table.Rows.Add(row)

		cell = New TableCell()
		cell.ColumnSpan = 2
		row.Cells.Add(cell)
		Dim lnk As New ASPxHyperLink()
		lnk.ID = "lnkApply"
		lnk.Text = "Apply"
		lnk.NavigateUrl = "#"
		lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.HideDropDown(); ApplyFilter({0}, {1}, {2}); }}", container.NamingContainer.NamingContainer.ClientID, cIdFrom, cIdTo)
		cell.Controls.Add(lnk)
	End Sub
End Class
