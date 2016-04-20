<%@ Page Title="Training" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Training.aspx.vb" Inherits="Training" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   
<asp:Table ID="PageTable" runat="server" Width="500px">
<asp:TableRow><asp:TableCell><h2><%: Title %></h2>
    <p>Welcome to the Training Tracker for the BlueBin DMS Application.  </p>
    <p>Below are Identified Resources who are going through training on various forms.  
        You can insert or update the status of the training using the buttons below. Each form header is a clickable link to the form itself.</p>
              </asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell Width="500px"  >
        <p>
            <br />
            <asp:TextBox ID="SearchBox" runat="server" Width="150px"></asp:TextBox>
            &nbsp;<asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="Search Name"></asp:Button>
            <asp:TextBox ID="UpdaterTB" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></p>
            <p>
            <asp:TextBox ID="SearchModule" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="LinkButton2" runat="server" CausesValidation="False" Text="Search Module"></asp:Button>
            

</p>
        <p>
            
        <asp:GridView ID="GridViewTraining" OnRowCommand="Training_RowCommand" CssClass="GridViewitem" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="TrainingSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="TrainingID" PageSize="15" ShowFooter="True" EditRowStyle-Width="50px" EditRowStyle-CssClass="ResourceRowWidth">
            <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>
            <Columns>
                
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="True" ValidationGroup="Edit" ID="Button1"></asp:Button>
                        <asp:Button runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="Button3"></asp:Button>
                        <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="Button2"></asp:Button>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="True" ValidationGroup="Edit" ID="Button4"></asp:Button>
                        <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="Button6" Visible="False"></asp:Button>
                    </ItemTemplate>
                    <FooterTemplate><asp:LinkButton ID="TrainingInsert" runat="server" Text="Add" CommandName="TrainingInsert"></asp:LinkButton></FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="TrainingID" InsertVisible="False" Visible="false" SortExpression="TrainingID">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("TrainingID") %>' ID="LabelTrainingE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("TrainingID") %>' ID="LabelTrainingI"></asp:Label>
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
                    <asp:SqlDataSource runat="server" ID="ResourceNameDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="SELECT DISTINCT [BlueBinResourceID],LastName + ', ' + FirstName as [ResourceName] FROM bluebin.[BlueBinResource]"></asp:SqlDataSource>
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

                <asp:TemplateField HeaderText="Trained" InsertVisible="False" SortExpression="Trained">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Trained") %>' ID="LabelTrainedE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Trained") %>' ID="LabelTrainedI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Total" InsertVisible="False" SortExpression="Total">
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Total") %>' ID="LabelTotalE"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Total") %>' ID="LabelTotalI"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="TrainingModule" SortExpression="ModuleName">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ModuleName") %>' ID="ETModuleNameL"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ModuleName") %>' ID="ITModuleNameL"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server" ID="TrainingModuleDDF" DataSourceID="TrainingModuleDataSourceF" DataTextField="ModuleName" DataValueField="TrainingModuleID" AppendDataBoundItems="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="TrainingModuleDataSourceF" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="select TrainingModuleID,ModuleName from bluebin.TrainingModule where Active = 1"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemStyle Wrap="False" Width="60px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ModuleDescription" SortExpression="ModuleDescription" Visible ="False">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("ModuleDescription") %>' ID="LabelModuleDescriptionI"></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="StatusDD" SelectedValue=<%#Bind("Status")%>>
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList runat="server" AutoPostBack="False"  ID="StatusDD" SelectedValue=<%#Bind("Status")%> >
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                    <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="StatusDDF">
                        <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        <asp:ListItem Value="Trained">Trained</asp:ListItem>
                        <asp:ListItem Value="Demo">Demo</asp:ListItem>
                        <asp:ListItem Value="Teach">Teach</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Active" SortExpression="Active">
                <EditItemTemplate>
                <asp:Label runat="server" Text='<%# Bind("Active") %>' ID="ETActiveL"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Active") %>' ID="ITActiveL"></asp:Label>
                </ItemTemplate>
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
        <asp:SqlDataSource ID="TrainingSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>"
            SelectCommand="exec sp_SelectTraining @Name,@Module"
            DeleteCommand="exec sp_DeleteTraining @TrainingID"
            UpdateCommand="exec sp_EditTraining  @TrainingID,@Status,@UpdaterTB">
            <UpdateParameters>
                
                
                <asp:ControlParameter ControlID="UpdaterTB" Name="UpdaterTB" PropertyName="Text" />
                <asp:Parameter Name="TrainingID"></asp:Parameter>
                <asp:Parameter Name="Status"></asp:Parameter>
            </UpdateParameters>
             <SelectParameters>
                <asp:ControlParameter ControlID="SearchBox" Name="Name" PropertyName="Text" DefaultValue="%"  />
                 <asp:ControlParameter ControlID="SearchModule" Name="Module" PropertyName="Text" DefaultValue="%"  />
            </SelectParameters>
             <DeleteParameters>
                <asp:Parameter Name="TrainingID"></asp:Parameter>
            </DeleteParameters>

        </asp:SqlDataSource>

        

</p>

</asp:Content>
