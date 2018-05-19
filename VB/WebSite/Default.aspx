<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Date range filtering in the Filter Row</title>
	<script type="text/javascript">
		function ApplyFilter(dateFrom, dateTo) {
			var d1 = dateFrom.GetText();
			var d2 = dateTo.GetText();
			if (d1 == "" || d2 == "")
				return;
			grid.AutoFilterByColumn("BirthDate", d1 + "|" + d2);
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" ClientInstanceName="grid" DataSourceID="ads" KeyFieldName="EmployeeID" onautofiltercelleditorcreate="grid_AutoFilterCellEditorCreate" 
				onprocesscolumnautofilter="grid_ProcessColumnAutoFilter" >
				<Columns>
					<dx:GridViewCommandColumn VisibleIndex="0">
						<ClearFilterButton Visible="True">
						</ClearFilterButton>
					</dx:GridViewCommandColumn>
					<dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="1">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="3">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataDateColumn FieldName="BirthDate" VisibleIndex="4" Width="200px">
					</dx:GridViewDataDateColumn>
				</Columns>
				<Settings ShowFilterRow="True" />
			</dx:ASPxGridView>
			<asp:AccessDataSource ID="ads" runat="server" DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [BirthDate] FROM [Employees]">
			</asp:AccessDataSource>
		</div>
	</form>
</body>
</html>