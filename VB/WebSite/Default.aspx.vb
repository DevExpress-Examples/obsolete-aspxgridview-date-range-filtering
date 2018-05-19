Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Data.Filtering

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub grid_AutoFilterCellEditorCreate(ByVal sender As Object, ByVal e As ASPxGridViewEditorCreateEventArgs)
		If e.Column.FieldName = "BirthDate" Then
			e.Column.FilterTemplate = New DateSelector()
		End If
	End Sub

	Protected Sub grid_ProcessColumnAutoFilter(ByVal sender As Object, ByVal e As ASPxGridViewAutoFilterEventArgs)
		If e.Value = "|" Then
			Return
		End If

		If e.Column.FieldName = "BirthDate" Then
			If e.Kind = GridViewAutoFilterEventKind.CreateCriteria Then
				Dim dates() As String = e.Value.Split("|"c)
				Session("BirthDateFilterText") = dates(0) & " - " & dates(1)
				Dim dateFrom As DateTime = Convert.ToDateTime(dates(0)), dateTo As DateTime = Convert.ToDateTime(dates(1))
				e.Criteria = (New OperandProperty("BirthDate") >= dateFrom) And (New OperandProperty("BirthDate") <= dateTo)
			ElseIf e.Kind = GridViewAutoFilterEventKind.ExtractDisplayText Then
				e.Value = Session("BirthDateFilterText").ToString()
			End If
		End If
	End Sub
End Class
