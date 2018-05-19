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
Imports DevExpress.Data.Filtering

Partial Public Class _Default
	Inherits System.Web.UI.Page
	' global reference: required for client-side event handlers
	Private dateTemplate As DateTemplate = Nothing

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub grid_AutoFilterCellEditorCreate(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorCreateEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		If e.Column.FieldName = "BirthDate" Then
			Dim dde As New DropDownEditProperties()
			dde.EnableClientSideAPI = True

			dateTemplate = New DateTemplate()

			dde.DropDownWindowTemplate = dateTemplate
			e.EditorProperties = dde
		End If
	End Sub
	Protected Sub grid_AutoFilterCellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		If e.Column.FieldName = "BirthDate" Then
			Dim dde As ASPxDropDownEdit = TryCast(e.Editor, ASPxDropDownEdit)
			dde.ClientSideEvents.CloseUp = String.Format("function (s, e) {{ ApplyFilter(s, {0}, {1}); }}", dateTemplate.cIdFrom, dateTemplate.cIdTo)
			dde.ClientSideEvents.DropDown = String.Format("function (s, e) {{ OnDropDown(s, {0}, {1}); }}", dateTemplate.cIdFrom, dateTemplate.cIdTo)
			dde.ReadOnly = True
		End If
	End Sub

	Protected Sub grid_ProcessColumnAutoFilter(ByVal sender As Object, ByVal e As ASPxGridViewAutoFilterEventArgs)
		If e.Value = "|" Then
			Return
		End If
		If e.Column.FieldName = "BirthDate" Then
			If e.Kind = GridViewAutoFilterEventKind.CreateCriteria Then
				Session("BrithDateFilter") = e.Value
				Dim dates() As String = e.Value.Split("|"c)
				Dim dateFrom As DateTime = Convert.ToDateTime(dates(0)), dateTo As DateTime = Convert.ToDateTime(dates(1))
				e.Criteria = (New OperandProperty("BirthDate") >= dateFrom) And (New OperandProperty("BirthDate") <= dateTo)
			Else
				If Session("BrithDateFilter") IsNot Nothing Then
					e.Value = Session("BrithDateFilter").ToString()
				End If
			End If
		End If
	End Sub
End Class
