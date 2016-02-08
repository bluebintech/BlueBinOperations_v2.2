<%@ Page Title="Operational Procedures2" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="OperationalProcedures2.aspx.vb" Inherits="OperationalProcedures2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Operational Procedures and Documentation</h2>
<p>Welcome to the Operational Procedures and Documentation Page for BlueBin Operations.  Below is a listing of Groups of Standard Operating Procedures (SOPs), Documents, 
    and Presentations that can be used as reference for your program setup and continued improvement intitiatives.</p>

    <asp:Table runat="server">
 
<%--SOPs List--%>
     
        <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" id="DocumentsL" ><h3>SOPs</h3></asp:Label>
            <p> 
                <asp:GridView ID="GridViewSOPs" CssClass="GridViewitemDocument" DataKeyNames="DocumentID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" CellPadding="5" GridLines="None" AllowPaging="False" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" CellSpacing="5" ShowHeader="False">
                    <Columns>
                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" Visible="false"/>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName"  Visible="false" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="DocumentSource" HeaderText="DocumentSource" Visible="false"/>
                        <asp:BoundField DataField="DocumentType" HeaderText="DocumentType" Visible="false" />
                        <asp:BoundField DataField="Document" HeaderText="Document" Visible="false" />
                        <asp:BoundField DataField="Active" HeaderText="Active"  Visible="false"/>
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" Visible="false" />
                        <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated"  Visible="false"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text ='<%#Eval("DocumentName").ToString()%>' CommandArgument = '<%# Eval("DocumentID") %>' runat="server" OnClick = "DownloadFile" Width="350" CausesValidation="False"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Wrap="False">
                            <ItemTemplate>
                                <asp:Label ID = "UpdatedL" Text ='<%#"Last Updated: " + Eval("LastUpdated", "{0:d}").ToString()%>'  runat = "server"  DataFormatString="{0:d}"/>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                    
                    <FooterStyle BackColor="#333333" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
        </asp:TableCell>
           <asp:TableCell Width="20">  </asp:TableCell>     
            
            
            <asp:TableCell>
          <div class="jumbotronmini">
          <asp:Table runat="server">
          <asp:TableRow><asp:TableCell><h1>Upload/Update Documents</h1></asp:TableCell></asp:TableRow>
        <asp:TableRow>
          <asp:TableCell>Document Group:
              <asp:DropDownList ID="DocumentGroupDDL"  AppendDataBoundItems="true" runat="server" AutoPostBack="False">
                                        <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                                        <asp:ListItem Value="SOPs">SOPs</asp:ListItem>
                                        <asp:ListItem Value="FormsSignage">Forms and Signage</asp:ListItem>
                                        <asp:ListItem Value="BeltCertification">Belt Certification</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                  </asp:DropDownList>
              <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorGroup" ControlToValidate="DocumentGroupDDL" runat="server" ForeColor="Red" ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
          </asp:TableCell>
         </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
         <asp:TableRow>
              <asp:TableCell>Document Name:&nbsp;<asp:TextBox ID="DocumentName" runat="server" BorderColor="#eeeeee" Width="220px" /></asp:TableCell>
          </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
          <asp:TableRow>
              <asp:TableCell><asp:FileUpload ID="UploadDocument" runat="server" BorderWidth="4" BorderColor="#eeeeee" /></asp:TableCell>
          </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
          <asp:TableRow>
              <asp:TableCell><asp:Button ID="DocumentInsert" class="btn btn-primary btn-lg" runat="server" Text="Upload" OnClientClick="DocumentInsert_Click"></asp:Button></asp:TableCell>
          </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
          <asp:TableRow>  
            <asp:TableCell><asp:Label ID="lblMessage" runat="server" Text="" Font-Names = "Arial"></asp:Label> </asp:TableCell>
            </asp:TableRow>
          </asp:Table>  </div>                     
      </asp:TableCell>



    </asp:TableRow>  

<%--Forms and Signage List--%>

        <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" id="Label1"><h3>Forms and Signage</h3></asp:Label>
            <p> 
                <asp:GridView ID="GridViewFormsSignage" CssClass="GridViewitemDocument" DataKeyNames="DocumentID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" CellPadding="5" GridLines="None" AllowPaging="False" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" CellSpacing="5" ShowHeader="False">
                    <Columns>
                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" Visible="false"/>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName"  Visible="false" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="DocumentSource" HeaderText="DocumentSource" Visible="false"/>
                        <asp:BoundField DataField="DocumentType" HeaderText="DocumentType" Visible="false" />
                        <asp:BoundField DataField="Document" HeaderText="Document" Visible="false" />
                        <asp:BoundField DataField="Active" HeaderText="Active"  Visible="false"/>
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" Visible="false" />
                        <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated"  Visible="false"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text ='<%#Eval("DocumentName").ToString()%>' CommandArgument = '<%# Eval("DocumentID") %>' runat="server" OnClick = "DownloadFile" Width="350" CausesValidation="False" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Wrap="False">
                            <ItemTemplate>
                                <asp:Label ID = "UpdatedL" Text ='<%#"Last Updated: " + Eval("LastUpdated", "{0:d}").ToString()%>'  runat = "server"  DataFormatString="{0:d}"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    
                    <FooterStyle BackColor="#333333" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
        </asp:TableCell>
    </asp:TableRow> 
         
<%--Belt Certification List--%>     
         <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" id="Label2"><h3>Belt Certification</h3></asp:Label>
            <p> 
                <asp:GridView ID="GridViewBeltCertification" CssClass="GridViewitemDocument" DataKeyNames="DocumentID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" CellPadding="5" GridLines="None" AllowPaging="False" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" CellSpacing="5" ShowHeader="False">
                    <Columns>
                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" Visible="false"/>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName"  Visible="false" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="DocumentSource" HeaderText="DocumentSource" Visible="false"/>
                        <asp:BoundField DataField="DocumentType" HeaderText="DocumentType" Visible="false" />
                        <asp:BoundField DataField="Document" HeaderText="Document" Visible="false" />
                        <asp:BoundField DataField="Active" HeaderText="Active"  Visible="false"/>
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" Visible="false" />
                        <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated"  Visible="false"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text ='<%#Eval("DocumentName").ToString()%>' CommandArgument = '<%# Eval("DocumentID") %>' runat="server" OnClick = "DownloadFile" Width="350" CausesValidation="False" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Wrap="False">
                            <ItemTemplate>
                                <asp:Label ID = "UpdatedL" Text ='<%#"Last Updated: " + Eval("LastUpdated", "{0:d}").ToString()%>'  runat = "server"  DataFormatString="{0:d}"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    
                    <FooterStyle BackColor="#333333" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>
        
<%--Other List--%>   
                <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" id="Label3"><h3>Other Custom Documents</h3></asp:Label>
            <p> 
                <asp:GridView ID="GridViewOther" CssClass="GridViewitemDocument" DataKeyNames="DocumentID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" CellPadding="5" GridLines="None" AllowPaging="False" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" CellSpacing="5" ShowHeader="False">
                    <Columns>
                        <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" Visible="false"/>
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName"  Visible="false" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="DocumentSource" HeaderText="DocumentSource" Visible="false"/>
                        <asp:BoundField DataField="DocumentType" HeaderText="DocumentType" Visible="false" />
                        <asp:BoundField DataField="Document" HeaderText="Document" Visible="false" />
                        <asp:BoundField DataField="Active" HeaderText="Active"  Visible="false"/>
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" Visible="false" />
                        <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated"  Visible="false"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text ='<%#Eval("DocumentName").ToString()%>' CommandArgument = '<%# Eval("DocumentID") %>' runat="server" OnClick = "DownloadFile" Width="350" CausesValidation="False"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Wrap="False">
                            <ItemTemplate>
                                <asp:Label ID = "UpdatedL" Text ='<%#"Last Updated: " + Eval("LastUpdated", "{0:d}").ToString()%>'  runat = "server"  DataFormatString="{0:d}"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    
                    <FooterStyle BackColor="#333333" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>     
        
       <asp:TableRow Height ="15"></asp:TableRow> 
      
        <asp:TableRow> 







      </asp:TableRow>
          
    </asp:Table>
 
   
        

  </asp:Content>
