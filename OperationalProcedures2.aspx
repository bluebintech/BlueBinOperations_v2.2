<%@ Page Title="Operational Procedures2" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="OperationalProcedures2.aspx.vb" Inherits="OperationalProcedures2" %>

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
                <asp:GridView CssClass="GridViewitem" ID="GridViewDocuments" DataKeyNames="DocumentID"  runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CellSpacing="3" FooterStyle-BackColor="#333333" ShowFooter="True" PageSize="20">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="DocumentID" Text="View" Target="_blank"></asp:HyperLinkField>
                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" Visible="false"/>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName" ItemStyle-Width="100px" />
                        <asp:BoundField DataField="DocumentType" HeaderText="DocumentType" />
                        <asp:BoundField DataField="DocumentSource" HeaderText="DocumentSource" />
                        <asp:BoundField DataField="Active" HeaderText="Active"  Visible="false"/>
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" />
                        <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated" />
                        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                    CommandArgument='<%# Eval("DocumentID") %>'></asp:LinkButton>
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
                                &nbsp;<asp:Button ID="DocumentInsert" class="btn btn-primary btn-sm" runat="server" Text="Upload" OnClientClick="DocumentInsert_Click" CausesValidation="False"></asp:Button>
                                
           </asp:TableCell>
      </asp:TableRow>
          <asp:TableRow>  
          <asp:TableCell>
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Names = "Arial"></asp:Label>
           </asp:TableCell>
      </asp:TableRow>
    </asp:Table>
 
   
        <div>
        <a runat="server" href="~/BlueBinDocuments/3000 - Replenishing BlueBin Technology Nodes.pdf" target="_blank">3000 - Replenishing BlueBin Technology Nodes</a><br />
        <a runat="server" href="~/BlueBinDocuments/3001 - BlueBin Stage Operations.pdf" target="_blank">3001 - BlueBin Stage Operations</a><br /> 
        <a runat="server" href="~/BlueBinDocuments/3002 - Filling BBT Orders - Art of Bin Fill.pdf" target="_blank">3002 - Filling BBT Orders - Art of Bin Fill</a><br />
        <a runat="server" href="~/BlueBinDocuments/3003 - Managing BlueBin Stock-Outs.pdf" target="_blank">3003 - Managing BlueBin Stock-Outs</a><br />
        <a runat="server" href="~/BlueBinDocuments/3004 - BlueBin Kanban & Stage Maintenance.pdf" target="_blank">3004 - BlueBin Kanban & Stage Maintenance</a><br />
        <a runat="server" href="~/BlueBinDocuments/3005 - BlueBin Stage Audit Process.pdf" target="_blank">3005 - BlueBin Stage Audit Process</a><br />
        <a runat="server" href="~/BlueBinDocuments/3006 - Stage Audit Form.pdf" target="_blank">3006 - Stage Audit Form</a><br />
        <a runat="server" href="~/BlueBinDocuments/3007 - BlueBIn Daily Health Audit Process.pdf" target="_blank">3007 - BlueBIn Daily Health Audit Process</a><br />
        <a runat="server" href="~/BlueBinDocuments/3008 - BBT Weekly Health Checklist.pdf" target="_blank">3008 - BBT Weekly Health Checklist</a><br />
        <a runat="server" href="~/BlueBinDocuments/3009 - BBT Orange Cone Process.pdf" target="_blank">3009 - BBT Orange Cone Process</a><br /> 
        <a runat="server" href="~/BlueBinDocuments/3010 - QCN Process.pdf" target="_blank">3010 - QCN Process</a><br />  
          </div>   

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
