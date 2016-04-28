<%@ Page Title="Training" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Training.aspx.vb" Inherits="Training" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   
<asp:Table ID="PageTable" runat="server" Width="500px">
<asp:TableRow><asp:TableCell><h2><%: Title %></h2>
    <p>Welcome to the Training Tracker for the BlueBin DMS Application.  </p>
    <p>With this Module you can track who is going through training on various modules.  
        You can insert or update the status of the training using the buttons below, or navigate to Training Modules to customize additional training.</p>
              </asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell Width="500px"  >
        <p>
            <asp:LinkButton ID="TrainingB" runat="server" class="btn btn-default">Training</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="TrainingModulesB" runat="server" class="btn btn-default">Training Modules</asp:LinkButton>&nbsp;

            <br /><br />
            <asp:TextBox ID="SearchModule" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="SearchModuleLB" runat="server" CausesValidation="False" Text="Search Module"></asp:Button>
            
            <asp:TextBox ID="UpdaterTB" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></p>
            <p>
            
            <asp:TextBox ID="SearchBox" runat="server" Width="150px"></asp:TextBox>
            &nbsp;<asp:Button ID="SearchNameLB" runat="server" CausesValidation="False" Text="Search Name"></asp:Button>

</p>
        <asp:Label runat="server" id="hiddenTraining" Visible="False"><h3>Training</h3><p></asp:Label>
   <%-- Training  --%>           
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
                        <asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" ValidationGroup="Edit" ID="Button4"></asp:LinkButton>
                        <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="TrainingDeleteB" OnClientClick="return confirm('Are you sure you want to delete this entry?');"></asp:LinkButton>
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
        <asp:ImageButton ID="ExportTraining" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelTraining" Height="25px" CausesValidation="False" />
    </p>

</asp:TableCell>
    </asp:TableRow>


<%-- Training Modules --%>  

    <asp:TableRow><asp:TableCell><asp:Label runat="server" id="AddUserErrorLabel"></asp:Label></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell Width="600px"  >
<asp:Label runat="server" id="hiddenTrainingModule" Visible="False"><h3>Training Modules</h3><p></asp:Label>
        <asp:GridView ID="GridViewTrainingModule" OnRowCommand="TrainingModule_RowCommand" CssClass="GridViewitem" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataSourceID="TrainingModuleDatasource" AutoGenerateColumns="False" DataKeyNames="TrainingModuleID" AllowSorting="True" AllowPaging="True" ShowFooter="True">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" ValidationGroup="EditTrainingModule" ID="Button1"></asp:LinkButton><br /><asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="Button2"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="ITTrainingModuleB"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="TrainingModuleDeleteB" OnClientClick="return confirm('Are you sure you want to delete this entry?  Removing a Module will also remove all Training entries for the Module!');"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate><asp:LinkButton ID="TrainingModuleInsert" runat="server" Text="Add" CausesValidation="True" ValidationGroup="AddTrainingModule"  CommandName="TrainingModuleInsert"></asp:LinkButton></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="TrainingModuleID"  Visible="false">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("TrainingModuleID") %>' ID="LabelTrainingModuleIDIT"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("TrainingModuleID") %>' ID="LabelTrainingModuleIDET"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Module Name" SortExpression="ModuleName">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("ModuleName") %>' ID="LabelTrainingModuleNameET"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="AddTrainingModule" runat="server" ControlToValidate="LabelTrainingModuleNameET" Display="Dynamic" ForeColor="Red" Font-Size="X-Small">REQUIRED</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ModuleName") %>' ID="LabelTrainingModuleNameIT"></asp:Label>
                </ItemTemplate>
                <FooterTemplate><asp:TextBox runat="server" ID="TrainingModuleNameF"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorTrainingModuleName" ValidationGroup="AddTrainingModule" runat="server" ControlToValidate="TrainingModuleNameF" Display="Dynamic" ForeColor="Red" Font-Size="X-Small">REQUIRED</asp:RequiredFieldValidator></FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Module Description" SortExpression="ModuleDescription" ItemStyle-Width="200">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("ModuleDescription") %>' ID="LabelTrainingModuleDescriptionET"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ModuleDescription") %>' ID="LabelTrainingModuleDescriptionIT"></asp:Label>
                </ItemTemplate>
                <FooterTemplate><asp:TextBox runat="server" ID="TrainingModuleDescriptionF"></asp:TextBox></FooterTemplate>
            </asp:TemplateField>
            
                         <asp:TemplateField HeaderText="Required" SortExpression="Required">
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="StatusDD" SelectedValue=<%#Bind("Required")%>>
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Required") %>' ID="LabelRequiredIT"></asp:Label>
                </ItemTemplate>
                    <FooterTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="RequiredDDF">
                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Updated" InsertVisible="False" SortExpression="LastUpdated">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("LastUpdated", "{0:d}") %>' ID="LabelEditTrainingModule"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("LastUpdated", "{0:d}") %>' ID="LabelItemTrainingModule"></asp:Label>
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
    </asp:TableCell></asp:TableRow>
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

        <p>
        <asp:SqlDataSource ID="TrainingModuleDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>"
            SelectCommand="exec sp_SelectTrainingModule @Module"
            DeleteCommand="exec sp_DeleteTrainingModule @TrainingModuleID"
            UpdateCommand="exec sp_EditTrainingModule  @TrainingModuleID,@ModuleName,@ModuleDescription,@Required">
            <UpdateParameters>
                <asp:Parameter Name="TrainingModuleID"></asp:Parameter>
                <asp:Parameter Name="ModuleName"></asp:Parameter>
                <asp:Parameter Name="ModuleDescription"></asp:Parameter>
                <asp:Parameter Name="Active"></asp:Parameter>
                <asp:Parameter Name="Required"></asp:Parameter>
            </UpdateParameters>
             <SelectParameters>
                 <asp:ControlParameter ControlID="SearchModule" Name="Module" PropertyName="Text" DefaultValue="%"  />
            </SelectParameters>
             <DeleteParameters>
                <asp:Parameter Name="TrainingModuleID"></asp:Parameter>
            </DeleteParameters>

        </asp:SqlDataSource>

        

</p>

</asp:Content>
