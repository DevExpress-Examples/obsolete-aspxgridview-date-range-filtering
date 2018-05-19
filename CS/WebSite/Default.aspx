<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Date range filtering in the Filter Row</title>
    <script type="text/javascript">
        function ApplyFilter(dateFrom, dateTo) {
            var d1 = dateFrom.GetText();
            var d2 = dateTo.GetText();
            if(d1 == "" || d2 == "")
                return;
            grid.AutoFilterByColumn("BirthDate", d1 + "|" + d2);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="grid" runat="server" ClientInstanceName="grid" DataSourceID="ads" KeyFieldName="EmployeeID"
                OnInit="grid_Init"
                OnProcessColumnAutoFilter="grid_ProcessColumnAutoFilter">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="True"/>
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
            <asp:AccessDataSource ID="ads" runat="server" DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [BirthDate] FROM [Employees]"></asp:AccessDataSource>
        </div>
    </form>
</body>
</html>
