<%@ Page Title="Scan Lines" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ScanLines.aspx.vb" Inherits="ScanLines" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function swallowEnter(){
            if(event.keyCode==13){
                event.keyCode = null;
                return;
            }
        }
    </script>
    <script>
        function handleKeyPress(evt) {
            var nbr;
            if (window.Event) nbr = evt.which;
            else nbr = event.keyCode;
            if (nbr == 113) {
                document.SubmitScan.focus();
            }
        }
    </script>
    <asp:panel runat ="server">
<asp:Table ID="PageTable" runat="server" Width="1050px" >
<asp:TableRow><asp:TableCell><h2>New Item Scan</h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell Width="1050px"  BorderColor="#032169" BorderStyle="Solid" BorderWidth="1" BackColor="#eeeeee">

        <asp:Table ID="Table3" runat="server" CellPadding="10" Width="350px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
            <asp:TableRow Height="10">
                <asp:TableCell Width="125px"><img src="img/Bluebin_logo-inline.png" width="150" /></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

<%-- Date --%>   
             <asp:TableRow Width="40px">    
                <asp:TableCell Width="100px">
                    <asp:Label ID="DateL" runat="server" Text="Date" Width="100px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="240px">
                    <asp:TextBox ID="CurrentTimeTB" runat="server"  ReadOnly="True" BackColor="#CCCCCC" DataFormatString="{0:d}" Width="100px"></asp:TextBox>
                </asp:TableCell>
                 </asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>

<%-- Scanner --%> 
                <asp:TableRow Width="350px">    
                <asp:TableCell Width="100px">
                    <asp:Label ID="ScannerL" runat="server" Text="Auditer" TextMode="MultiLine" Width="100px"></asp:Label>
                                  
                </asp:TableCell>
                           <asp:TableCell Width="240px">
                    <asp:TextBox ID="ScannerTB" runat="server"  ReadOnly="True" BackColor="#CCCCCC"  Width="200px" ></asp:TextBox>                                               
                </asp:TableCell>

                </asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>

 <%-- Location --%>   
                <asp:TableRow Width="350px">    
                <asp:TableCell Width="100px" >
                    <asp:Label ID="LocationL" runat="server" Text="Location" TextMode="MultiLine" Width="100px"></asp:Label>
                    
                     </asp:TableCell>
                <asp:TableCell Width="240px">
                    <asp:DropDownList ID="LocationDD"   Width="200px" AppendDataBoundItems="true" runat="server" DataSourceID="ScanLinesLocationSource" DataTextField="LocationName" DataValueField="LocationID">
                        <asp:ListItem Selected = "True" Text = "" Value = ""></asp:ListItem>
                          </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="LocationDD" runat="server" ForeColor="Red" ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
  
                </asp:TableCell>
                 </asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>
        
        
        
        </asp:Table>

 <%-- Item Table --%> 
<asp:Table ID="TableItems" runat="server" CellPadding="10" Width="1050px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
<asp:TableRow Width="1050px" >
     <%-- Left Column of Items --%> 
    <asp:TableCell Width="350px" >
        <asp:Table ID="TableLC" runat="server" CellPadding="10" Width="350px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
            <asp:TableRow>    
                <asp:TableHeaderCell Width="20px">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="250px">
                    <asp:Label ID="LabelItemLC" runat="server" Text="Item"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="80px">
                    <asp:Label ID="LabelQuantityLC" runat="server" Text="Quantity"></asp:Label>
                 </asp:TableHeaderCell>
            </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL1" runat="server" Text="1"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item1TB" runat="server"  Width="225px"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="Item1TB" runat="server" ForeColor="Red" ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty1TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL2" runat="server" Text="2"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item2TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty2TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL3" runat="server" Text="3"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item3TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty3TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL4" runat="server" Text="4"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item4TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty4TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL5" runat="server" Text="5"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item5TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty5TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL6" runat="server" Text="6"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item6TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty6TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL7" runat="server" Text="7"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item7TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty7TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL8" runat="server" Text="8"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item8TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty8TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL9" runat="server" Text="9"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item9TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty9TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL10" runat="server" Text="10"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item10TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty10TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow Height="5"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL11" runat="server" Text="11"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item11TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty11TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL12" runat="server" Text="12"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item12TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty12TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL13" runat="server" Text="13"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item13TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty13TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL14" runat="server" Text="14"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item14TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty14TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL15" runat="server" Text="15"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item15TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty15TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL16" runat="server" Text="16"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item16TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty16TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL17" runat="server" Text="17"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item17TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty17TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL18" runat="server" Text="18"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item18TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty18TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL19" runat="server" Text="19"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item19TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty19TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL20" runat="server" Text="20"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item20TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty20TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
            <asp:TableRow Height="5"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL21" runat="server" Text="21"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item21TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty21TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL22" runat="server" Text="22"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item22TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty22TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL23" runat="server" Text="23"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item23TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty23TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL24" runat="server" Text="24"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item24TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty24TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL25" runat="server" Text="25"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item25TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty25TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL26" runat="server" Text="26"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item26TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty26TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL27" runat="server" Text="27"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item27TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty27TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL28" runat="server" Text="28"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item28TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty28TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL29" runat="server" Text="29"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item29TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty29TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL30" runat="server" Text="30"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item30TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty30TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>             
        </asp:Table>
    </asp:TableCell>


     <%-- Middle Column of Items --%> 
    <asp:TableCell Width="350px">
        <asp:Table ID="TableMC" runat="server" CellPadding="10" Width="350px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
            <asp:TableRow>    
                <asp:TableHeaderCell Width="20px">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="250px">
                    <asp:Label ID="LabelItemMC" runat="server" Text="Item" onkeydown = "return (event.keyCode!=13)"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="80px">
                    <asp:Label ID="LabelQuantityMC" runat="server" Text="Quantity" onkeydown = "return (event.keyCode!=13)"></asp:Label>
                 </asp:TableHeaderCell>
            </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
                       <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL31" runat="server" Text="31"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item31TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty31TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL32" runat="server" Text="32"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item32TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty32TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL33" runat="server" Text="33"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item33TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty33TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL34" runat="server" Text="34"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item34TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty34TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL35" runat="server" Text="35"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item35TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty35TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL36" runat="server" Text="36"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item36TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty36TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL37" runat="server" Text="37"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item37TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty37TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL38" runat="server" Text="38"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item38TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty38TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL39" runat="server" Text="39"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item39TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty39TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL40" runat="server" Text="40"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item40TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty40TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	        <asp:TableRow Height="5"></asp:TableRow> 
	        <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL41" runat="server" Text="41"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item41TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty41TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL42" runat="server" Text="42"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item42TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty42TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL43" runat="server" Text="43"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item43TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty43TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL44" runat="server" Text="44"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item44TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty44TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL45" runat="server" Text="45"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item45TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty45TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL46" runat="server" Text="46"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item46TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty46TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL47" runat="server" Text="47"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item47TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty47TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL48" runat="server" Text="48"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item48TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty48TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL49" runat="server" Text="49"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item49TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty49TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL50" runat="server" Text="50"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item50TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty50TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
            <asp:TableRow Height="5"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL51" runat="server" Text="51"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item51TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty51TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL52" runat="server" Text="52"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item52TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty52TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL53" runat="server" Text="53"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item53TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty53TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL54" runat="server" Text="54"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item54TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty54TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL55" runat="server" Text="55"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item55TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty55TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL56" runat="server" Text="56"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item56TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty56TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL57" runat="server" Text="57"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item57TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty57TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL58" runat="server" Text="58"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item58TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty58TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL59" runat="server" Text="59"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item59TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty59TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="60px">
                    <asp:Label ID="Label1" runat="server" Text="60"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item60TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty60TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>              
        </asp:Table>
    </asp:TableCell>


     <%-- Right Column of Items --%> 
    <asp:TableCell Width="350px">
        <asp:Table ID="TableRC" runat="server" CellPadding="10" Width="350px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
                <asp:TableRow>    
                <asp:TableHeaderCell Width="20px">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="250px">
                    <asp:Label ID="LabelItemRC" runat="server" Text="Item"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="80px">
                    <asp:Label ID="LabelQuantityRC" runat="server" Text="Quantity"></asp:Label>
                 </asp:TableHeaderCell>
            </asp:TableRow> 
            <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL61" runat="server" Text="61"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item61TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty61TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL62" runat="server" Text="62"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item62TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty62TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL63" runat="server" Text="63"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item63TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty63TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL64" runat="server" Text="64"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item64TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty64TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL65" runat="server" Text="65"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item65TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty65TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL66" runat="server" Text="66"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item66TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty66TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL67" runat="server" Text="67"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item67TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty67TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL68" runat="server" Text="68"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item68TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty68TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL69" runat="server" Text="69"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item69TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty69TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL70" runat="server" Text="70"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item70TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty70TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	        <asp:TableRow Height="5"></asp:TableRow> 
	        <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL71" runat="server" Text="71"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item71TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty71TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL72" runat="server" Text="72"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item72TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty72TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL73" runat="server" Text="73"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item73TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty73TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL74" runat="server" Text="74"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item74TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty74TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL75" runat="server" Text="75"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item75TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty75TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL76" runat="server" Text="76"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item76TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty76TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL77" runat="server" Text="77"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item77TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty77TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL78" runat="server" Text="78"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item78TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty78TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL79" runat="server" Text="79"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item79TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty79TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL80" runat="server" Text="80"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item80TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty80TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
            <asp:TableRow Height="5"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL81" runat="server" Text="81"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item81TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty81TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL82" runat="server" Text="82"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item82TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty82TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL83" runat="server" Text="83"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item83TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty83TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL84" runat="server" Text="84"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item84TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty84TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL85" runat="server" Text="85"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item85TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty85TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL86" runat="server" Text="86"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item86TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty86TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>
	           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL87" runat="server" Text="87"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item87TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty87TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL88" runat="server" Text="88"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item88TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty88TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow> 
           <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="30px">
                    <asp:Label ID="NumL89" runat="server" Text="89"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item89TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty89TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>  
	       <asp:TableRow Height="5"></asp:TableRow>
           <asp:TableRow>    
                <asp:TableCell Width="60px">
                    <asp:Label ID="NumL90" runat="server" Text="90"></asp:Label>
                </asp:TableCell>
               <asp:TableCell Width="240px">
                    <asp:TextBox ID="Item90TB" runat="server"  Width="225px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    <asp:TextBox ID="Qty90TB" runat="server"  Width="80px" onkeydown = "return (event.keyCode!=13)"></asp:TextBox>
                 </asp:TableCell>
           </asp:TableRow>              
        </asp:Table>
    </asp:TableCell>




</asp:TableRow>        
</asp:Table>



</asp:TableCell>
</asp:TableRow>

<asp:TableRow Height="10"></asp:TableRow>
 <asp:TableRow>
     <asp:TableCell><asp:Button ID="ScanSubmit" runat="server" Text="Submit Batch"  OnClientClick="return confirm('Are you sure you want to submit this scanning?');" AccessKey="@" />&nbsp;
     <asp:Button ID="ScanningCancel" CausesValidation="false" runat="server" Text="Cancel" /><br /></asp:TableCell>
 </asp:TableRow>       
      
</asp:Table>

    
   
    
    
  
</asp:panel>
   <asp:SqlDataSource ID="ScanLinesLocationSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectLocation"></asp:SqlDataSource>      
         
</asp:Content>
