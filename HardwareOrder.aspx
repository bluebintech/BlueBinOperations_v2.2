<%@ Page Title="Hardware Order" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="HardwareOrder.aspx.vb" Inherits="HardwareOrder" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Table ID="PageTable" runat="server" Width="900px">
<asp:TableRow><asp:TableCell><h2><%: Page.Title %></h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell Width="900px">  
    
    <p>
        <asp:Button ID="NewHardware" runat="server" Text="New Hardware Order" /> 
    </p>
    <p>
    <p>
        <asp:GridView  CssClass="GridViewitem" ID="GridViewHardware" OnPageIndexChanging="OnPageIndexChanging" DataKeyNames="ClientInvoiceID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CellSpacing="3">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                <asp:BoundField DataField="POID" HeaderText="POID" SortExpression="POID" Visible="False"/>
                <asp:BoundField DataField="PO" HeaderText="PO" SortExpression="PO" Visible="False" />
                <asp:BoundField DataField="ClientInvoiceID" HeaderText="ClientInvoiceID" SortExpression="ClientInvoiceID" Visible="False" /> 
                <asp:BoundField DataField="ClientInvoice" HeaderText="Invoice" SortExpression="ClientInvoice" /> 
                <asp:BoundField DataField="CustomerName" HeaderText="Customer" SortExpression="CustomerName" />
                <asp:BoundField DataField="VendorName" HeaderText="Vendor" SortExpression="VendorName" Visible ="False"/>             
                <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Tax" HeaderText="Tax" SortExpression="Tax" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Shipping" HeaderText="Shipping" SortExpression="Shipping" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:c}" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" DataFormatString="{0:d}"  />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BlueBinHardwareConnectionString %>" >

        </asp:SqlDataSource>
           </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:GridView  CssClass="GridViewitem" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="SqlDataSource4" GridLines="Vertical" HorizontalAlign="NotSet">
                    <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                        <asp:BoundField DataField="ClientInvoiceID" HeaderText="ClientInvoiceID" SortExpression="ClientInvoiceID" Visible="False" />
                        <asp:BoundField DataField="ClientInvoice" HeaderText="Invoice" SortExpression="ClientInvoice" />
                        <asp:BoundField DataField="ClientInvoiceLine" HeaderText="Invoice Line" SortExpression="ClientInvoiceLine" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                        <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" SortExpression="UnitCost"  DataFormatString="{0:c}"/>
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" SortExpression="Subtotal"  DataFormatString="{0:c}"/>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:BlueBinHardwareConnectionString %>" 
                    SelectCommand="exec sp_SelectClientInvoiceLines @ClientInvoiceID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridViewHardware" Name="ClientInvoiceID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </p>
    
    
</asp:TableCell>
    </asp:TableRow>
        </asp:Table>

</asp:Content>
