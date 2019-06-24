<!-- default file list -->
*Files to look at*:

* [DateTemplate.cs](./CS/WebSite/App_Code/DateTemplate.cs) (VB: [DateTemplate.vb](./VB/WebSite/App_Code/DateTemplate.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# OBSOLETE - Date Range Filtering in the Filter Row
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1990)**
<!-- run online end -->


<p><strong>UPDATED:</strong><br><br>Starting with version v2015 vol 2 (v15.2), this functionality is available out of the box. Simply set the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridViewDataColumnHeaderFilterSettings_Modetopic">GridViewDataColumn.SettingsHeaderFilter.Mode</a> property to <strong>DateRangePicker</strong> to activate it. Please refer to the <a href="https://community.devexpress.com/blogs/aspnet/archive/2015/11/10/asp-net-grid-view-data-range-filter-adaptivity-and-more-coming-soon-in-v15-2.aspx">ASP.NET Grid View - Data Range Filter, Adaptivity and More (Coming soon in v15.2)</a> blog post and the <a href="http://demos.devexpress.com/ASPxGridViewDemos/Filtering/DateRangeHeaderFilter.aspx">Date Range Header Filter</a> demo for more information.<br>If you have version v15.2+ available, consider using the built-in functionality instead of the approach detailed below.</p>
<p><br><strong>For Older Versions:</strong></p>
<p>This example illustrates how to specify a column's <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridViewColumn_FilterTemplatetopic">FilterTemplate</a> by using two ASPxDateEdit controls and use them for date range filtering

* Enter the start and end date values;
* Call the client-side <strong>ASPxClientGridView.AutoFilterByColumn</strong> method and pass the target column's FieldName and entered values as parameters;
* Handle the server-side <strong>ASPxGridView.ProcessColumnAutoFilte</strong>r event;
* Check if the currently processed column (<strong>e.Column.FieldName</strong>) is the target one. If so, retrieve the passed value (<strong>e.Value</strong>) and create data range filter criteria (<strong>e.Criteria</strong>) using the approach illustrated in the <a href="https://www.devexpress.com/Support/Center/p/E353">Create the Custom Filter Criteria</a> example.<strong><br><br>See Also:<br></strong><a href="https://www.devexpress.com/Support/Center/p/E2203">E2203: CheckComboBox filtering in the Auto Filter Row</a><br><a href="https://www.devexpress.com/Support/Center/p/E1950">E1950: OBSOLETE - ASPxGridView - Date Auto Filter</a><br><a href="https://www.devexpress.com/Support/Center/p/E5038">E5038: GridView - How to implement date range filtering using a custom editor in the AutoFilterRow</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/T151313">ASPxGridView - How to customize RowFilter in DataDateColumn and provide two ASPxDateEdit controls that allow setting a date range as a filter expression</a></p>

<br/>


