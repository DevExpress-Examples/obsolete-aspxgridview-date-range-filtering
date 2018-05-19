<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
     function ApplyFilter(dde, dateFrom, dateTo)
     {        
        var d1 = dateFrom.GetText();
        var d2 = dateTo.GetText();
        if (d1 == "" || d2 == "")
            return;
        dde.SetText(d1 + "|" + d2);
        grid.AutoFilterByColumn("BirthDate", dde.GetText());
     }
    
    function OnDropDown(s, dateFrom, dateTo)
    {
        var str = s.GetText();
        if (str == "")
        {
            // default date (1950-1961 for demo)     
            dateFrom.SetDate(new Date(1950, 0, 1));
            dateTo.SetDate(new Date(1960, 11, 31));
            return;
        }
        var d = str.split("|");
        dateFrom.SetText(d[0]);
        dateTo.SetText(d[1]);        
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="ads"
                KeyFieldName="EmployeeID" OnAutoFilterCellEditorCreate="grid_AutoFilterCellEditorCreate"
                OnAutoFilterCellEditorInitialize="grid_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="grid_ProcessColumnAutoFilter">
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
