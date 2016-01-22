<%@ Page Title="Training" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Training.aspx.vb" Inherits="Training" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   
<asp:Table ID="PageTable" runat="server" Width="500px">
<asp:TableRow><asp:TableCell><h2><%: Title %></h2>
    <p>Welcome to the Training Tracker for your BlueBin Operations Site.  </p>
    <p>Below are Identified Resources who are going through training on various forms.  
        You can insert or update the status of the training using the buttons below. Each form header is a clickable link to the form itself.</p>
              </asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell Width="500px"  >
        <p>
            <br />
            <asp:TextBox ID="SearchBox" runat="server" Width="150px"></asp:TextBox>
            &nbsp;<asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="Search Name"></asp:Button>
            <asp:TextBox ID="UpdaterTB" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
</p>
        <p>
            
        <asp:GridView ID="GridViewBlueBinTraining" OnRowCommand="BlueBinTraining_RowCommand" CssClass="GridViewitem" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="BlueBinTrainingSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="BlueBinTrainingID" PageSize="15" ShowFooter="True" EditRowStyle-Width="50px" EditRowStyle-CssClass="ResourceRowWidth">
            <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>
            <Columns>
                
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="True" ValidationGroup="Edit" ID="Button1"></asp:Button>
                        <asp:Button runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="Button3"></asp:Button>
                        <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="Button2"></asp:Button>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="Button1"></asp:Button>
                    </ItemTemplate>
                    <FooterTemplate><asp:LinkButton ID="TrainingInsert" runat="server" Text="Add" CommandName="TrainingInsert"></asp:LinkButton></FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="BlueBinTrainingID" InsertVisible="False" Visible="false" SortExpression="BlueBinTrainingID">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("BlueBinTrainingID") %>' ID="LabelTrainingE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("BlueBinTrainingID") %>' ID="LabelTrainingI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="BlueBinResourceID" InsertVisible="False" Visible="false" SortExpression="BlueBinResourceID">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("BlueBinResourceID") %>' ID="LabelResourceE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("BlueBinResourceID") %>' ID="LabelResourceEI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ResourceName" SortExpression="ResourceName">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("ResourceName") %>' ID="LabelResourceNameE"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ResourceName") %>' ID="ITResourceNameL"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server" ID="ResourceNameDD" SelectedValue='<%# Bind("ResourceName") %>' DataSourceID="ResourceNameDataSource" DataTextField="ResourceName" DataValueField="BlueBinResourceID">
                    </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="ResourceNameDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="SELECT DISTINCT [BlueBinResourceID],LastName + ', ' + FirstName as [ResourceName] FROM bluebin.[BlueBinResource] where BlueBinResourceID not in (select BlueBinResourceID from bluebin.BlueBinTraining where Active = 1)"></asp:SqlDataSource>
                 </FooterTemplate>
                <ItemStyle Wrap="False" Width="60px"></ItemStyle>
            </asp:TemplateField>
          
                <asp:TemplateField HeaderText="Title" InsertVisible="False" SortExpression="Title">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Title") %>' ID="LabelTitleE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Title") %>' ID="LabelTitleI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Trained?" InsertVisible="False" SortExpression="Title">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("FullyTrained") %>' ID="LabelTitleE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("FullyTrained") %>' ID="LabelTitleI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                <HeaderTemplate>
                    <asp:HyperLink runat="server" NavigateUrl="~/BlueBinDocuments/3000 - Replenishing BlueBin Technology Nodes.pdf" target="_blank" Text="Form3000"> </asp:HyperLink>
                </HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3000DD" SelectedValue=<%#Bind("Form3000")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3000") %>' ID="LabelForm3000"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3000DDF" SelectedValue=<%#Bind("Form3000")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3001 - BlueBin Stage Operations.pdf" target="_blank" Text="Form3001"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3001DD" SelectedValue=<%#Bind("Form3001")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3001") %>' ID="LabelForm3001"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3001DDF" SelectedValue=<%#Bind("Form3001")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3002 - Filling BBT Orders - Art of Bin Fill.pdf" target="_blank" Text="Form3002"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3002DD" SelectedValue=<%#Bind("Form3002")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3002") %>' ID="LabelForm3002"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3002DDF" SelectedValue=<%#Bind("Form3002")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3003 - Managing BlueBin Stock-Outs.pdf" target="_blank" Text="Form3003"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3003DD" SelectedValue=<%#Bind("Form3003")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3003") %>' ID="LabelForm3003"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3003DDF" SelectedValue=<%#Bind("Form3003")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3004 - BlueBin Kanban & Stage Maintenance.pdf" target="_blank" Text="Form3004"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3004DD" SelectedValue=<%#Bind("Form3004")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3004") %>' ID="LabelForm3004"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3004DDF" SelectedValue=<%#Bind("Form3004")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3005 - BlueBin Stage Audit Process.pdf" target="_blank" Text="Form3005"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3005DD" SelectedValue=<%#Bind("Form3005")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3005") %>' ID="LabelForm3005"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3005DDF" SelectedValue=<%#Bind("Form3005")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3006 - Stage Audit Form.pdf" target="_blank" Text="Form3006"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3006DD" SelectedValue=<%#Bind("Form3006")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3006") %>' ID="LabelForm3006"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3006DDF" SelectedValue=<%#Bind("Form3006")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3007 - BlueBIn Daily Health Audit Process.pdf" target="_blank" Text="Form3007"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3007DD" SelectedValue=<%#Bind("Form3007")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3007") %>' ID="LabelForm3007"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3007DDF" SelectedValue=<%#Bind("Form3007")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3008 - BBT Weekly Health Checklist.pdf" target="_blank" Text="Form3008"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3008DD" SelectedValue=<%#Bind("Form3008")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3008") %>' ID="LabelForm3008"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3008DDF" SelectedValue=<%#Bind("Form3008")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3009 - BBT Orange Cone Process.pdf" target="_blank" Text="Form3009"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3009DD" SelectedValue=<%#Bind("Form3009")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3009") %>' ID="LabelForm3009"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3009DDF" SelectedValue=<%#Bind("Form3009")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>

<asp:TemplateField><HeaderTemplate>
<asp:HyperLink runat="server" NavigateUrl="/BlueBinDocuments/3010 - QCN Process.pdf" target="_blank" Text="Form30010"> </asp:HyperLink>
</HeaderTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3010DD" SelectedValue=<%#Bind("Form3010")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Form3010") %>' ID="LabelForm3010"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="Form3010DDF" SelectedValue=<%#Bind("Form3010")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                </asp:TemplateField>



                
                <asp:TemplateField HeaderText="Updater" SortExpression="Updater">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Updater") %>' ID="LabelUpdaterE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Updater") %>' ID="LabelUpdaterI"></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

 
            
                <asp:TemplateField HeaderText="Last Updated" InsertVisible="False" SortExpression="LastUpdated">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("LastUpdated", "{0:d}") %>' ID="LabelEditTraining"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("LastUpdated", "{0:d}") %>' ID="LabelItemTraining"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>




            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

            <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>

            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#000065"></SortedDescendingHeaderStyle>
        </asp:GridView>
        </p>
        <p>
 
        </p>
            <p>
        <asp:ImageButton ID="ExportTraining" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelTraining" Height="25px" CausesValidation="False" />
    </p>

</asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    

    <p>
        <asp:SqlDataSource ID="BlueBinTrainingSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>"
            SelectCommand="exec sp_SelectBlueBinTraining @Name"
            DeleteCommand="exec sp_DeleteBlueBinTraining @BlueBinTrainingID"
            UpdateCommand="exec sp_EditBlueBinTraining  @BlueBinTrainingID,@Form3000,@Form3001,@Form3002,@Form3003,@Form3004,@Form3005,@Form3006,@Form3007,@Form3008,@Form3009,@Form3010,@UpdaterTB">
            <UpdateParameters>
                <asp:Parameter Name="Form3000"></asp:Parameter>
                <asp:Parameter Name="Form3001"></asp:Parameter>
                <asp:Parameter Name="Form3002"></asp:Parameter>
                <asp:Parameter Name="Form3003"></asp:Parameter>
                <asp:Parameter Name="Form3004"></asp:Parameter>
                <asp:Parameter Name="Form3005"></asp:Parameter>
                <asp:Parameter Name="Form3006"></asp:Parameter>
                <asp:Parameter Name="Form3007"></asp:Parameter>
                <asp:Parameter Name="Form3008"></asp:Parameter>
                <asp:Parameter Name="Form3009"></asp:Parameter>
                <asp:Parameter Name="Form3010"></asp:Parameter>
                <asp:Parameter Name="LastName"></asp:Parameter>
                <asp:ControlParameter ControlID="UpdaterTB" Name="UpdaterTB" PropertyName="Text" />
                <asp:Parameter Name="BlueBinTrainingID"></asp:Parameter>
            </UpdateParameters>
             <SelectParameters>
                <asp:ControlParameter ControlID="SearchBox" Name="Name" PropertyName="Text" DefaultValue="%"  />
            </SelectParameters>
             <DeleteParameters>
                <asp:Parameter Name="BlueBinTrainingID"></asp:Parameter>
            </DeleteParameters>

        </asp:SqlDataSource>

        

</p>

</asp:Content>
