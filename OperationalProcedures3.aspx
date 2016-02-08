<%@ Page Title="Operational Procedures3" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="OperationalProcedures3.aspx.vb" Inherits="OperationalProcedures3" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Operational Procedures and Documentation</h2>
<p>Welcome to the Operational Procedures and Documentation Page for BlueBin Operations.  Below is a listing of Groups of Standard Operating Procedures (SOPs), Documents, 
    and Presentations that can be used as reference for your program setup and continued improvement intitiatives.</p>

    <asp:Table runat="server">
        <asp:TableRow><asp:TableCell><h3>SOPs</h3></asp:TableCell></asp:TableRow>
        <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" id="DocumentsL" Visible="False"><h3>SOPs</h3></asp:Label>
            <p> 
                <asp:GridView CssClass="GridViewitem" ID="GridViewDocuments" EmptyDataText = "No files uploaded" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CellSpacing="3" FooterStyle-BackColor="#333333" ShowFooter="True" PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="Text" HeaderText="File Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor="#333333" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>  
      <asp:TableRow>  
          <asp:TableCell>
                                &nbsp;Document Name:&nbsp;&nbsp;<asp:TextBox ID="DocumentName" runat="server"  Width="160px" />
                                <asp:FileUpload ID="UploadDocument" runat="server"  Visible="True" BorderWidth="4" BorderColor="#eeeeee" />
                                &nbsp;<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" class="btn btn-primary btn-sm" CausesValidation="False"></asp:Button>
                                
           </asp:TableCell>
      </asp:TableRow>
          <asp:TableRow>  
          <asp:TableCell>
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Names = "Arial"></asp:Label>
           </asp:TableCell>
      </asp:TableRow>
    </asp:Table>
 
   
    <br />

    <h3>Belt Certification</h3>
        <div>   
         <a runat="server" href="~/BlueBinDocuments/DMS-CERTIFICATION.ppsx" target="_blank">Belt Certificate Overview</a><br />

        </div>
    
        <h3>Forms and Signage</h3>
        <div>   
         <a runat="server" href="~/BlueBinDocuments/NODE SIGNAGE - Main.pdf" target="_blank">NODE SIGNAGE - Main</a><br />
         <a runat="server" href="~/BlueBinDocuments/QCN Drop.pdf" target="_blank">QCN Drop</a><br />       
         <a runat="server" href="~/BlueBinDocuments/SEQUENCE WORKSHEET.xlsx" target="_blank">Sequence Worksheet</a><br /> 
        </div>

  </asp:Content>
