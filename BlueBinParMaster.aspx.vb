Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration
Imports System.Net.Mail
Imports System.Web.UI.WebControls

Partial Class BlueBinParMaster
    Inherits Page

    Protected Sub ParMasterB_Click(sender As Object, e As EventArgs) Handles ParMasterB.Click

        GridViewParMaster.Visible = True
        GridViewItemMaster.Visible = False
        GridViewParMaster.DataBind()
        hiddenParMaster.Visible = True
        hiddenItemMaster.Visible = False
        GridViewLocationMaster.Visible = False
        hiddenLocationMaster.Visible = False
        LocationL.Visible = True
        LocationSB.Visible = True
        LocationSB.Text = ""
        ItemL.Visible = True
        ItemSB.Visible = True
        ItemSB.Text = ""
        FacilityL.Visible = True
        FacilitySB.Visible = True
        ExportParMaster.Visible = True
        ExportItemMaster.Visible = False
        ExportLocationMaster.Visible = False
        AUSB.Visible = False
        AUL.Visible = False
        ManufSB.Visible = False
        ManufL.Visible = False
        DetailsC.Visible = False
    End Sub

    Protected Sub ItemMasterB_Click(sender As Object, e As EventArgs) Handles ItemMasterB.Click

        GridViewParMaster.Visible = False
        GridViewItemMaster.Visible = True
        GridViewItemMaster.DataBind()
        hiddenItemMaster.Visible = True
        hiddenParMaster.Visible = False
        GridViewLocationMaster.Visible = False
        hiddenLocationMaster.Visible = False
        LocationL.Visible = False
        LocationSB.Visible = False
        ItemL.Visible = True
        ItemSB.Visible = True
        FacilityL.Visible = False
        FacilitySB.Visible = False
        ExportParMaster.Visible = False
        ExportItemMaster.Visible = True
        ExportLocationMaster.Visible = False
        AUSB.Visible = False
        AUL.Visible = False
        ManufSB.Visible = True
        ManufL.Visible = True
        DetailsC.Visible = True
        DetailsC.Checked = False

    End Sub

    Protected Sub LocationMasterB_Click(sender As Object, e As EventArgs) Handles LocationMasterB.Click

        GridViewParMaster.Visible = False
        GridViewItemMaster.Visible = False
        GridViewLocationMaster.Visible = True
        GridViewLocationMaster.DataBind()
        hiddenLocationMaster.Visible = True
        hiddenItemMaster.Visible = False
        hiddenParMaster.Visible = False
        LocationL.Visible = True
        LocationSB.Visible = True
        ItemL.Visible = False
        ItemSB.Visible = False
        FacilityL.Visible = False
        FacilitySB.Visible = False
        ExportParMaster.Visible = False
        ExportItemMaster.Visible = False
        ExportLocationMaster.Visible = True
        AUSB.Visible = False
        AUL.Visible = False
        ManufSB.Visible = False
        ManufL.Visible = False
        DetailsC.Visible = False
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)


        If Not Page.IsPostBack() Then


            GridViewParMaster.DataBind()
            'GridViewItemMaster.DataBind()
            'GridViewLocationMaster.DataBind()
            GridViewParMaster.Visible = True
            GridViewItemMaster.Visible = False
            GridViewLocationMaster.Visible = False
            hiddenLocationMaster.Visible = False
            hiddenItemMaster.Visible = False
            hiddenParMaster.Visible = True
            LocationL.Visible = True
            LocationSB.Visible = True
            ItemL.Visible = True
            ItemSB.Visible = True
            FacilityL.Visible = True
            FacilitySB.Visible = True
            ExportParMaster.Visible = True
            ExportItemMaster.Visible = False
            ExportLocationMaster.Visible = False
            AUSB.Visible = False
            AUL.Visible = False
            ManufSB.Visible = False
            ManufL.Visible = False
            DetailsC.Visible = False
            DetailsC.Checked = False
        End If

        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim UserParMasterEdit As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conedit As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conedit
                    conedit.Open()
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-PARMASTER-EDIT")
                    UserParMasterEdit = Convert.ToString(cmdadmin.ExecuteScalar())

                    conedit.Close()
                End Using
            End Using

            If UserParMasterEdit = "Yes" Then
                GridViewLocationMaster.Columns(0).Visible = True
                GridViewLocationMaster.Columns(6).Visible = True
                GridViewLocationMaster.ShowFooter = True
                GridViewParMaster.Columns(0).Visible = True
                GridViewParMaster.Columns(19).Visible = True
                GridViewParMaster.ShowFooter = True
                GridViewItemMaster.Columns(0).Visible = True
                GridViewItemMaster.ShowFooter = True
                'DetailsViewItemMaster.Rows(11).Visible = True

            Else
                GridViewLocationMaster.Columns(0).Visible = False
                GridViewLocationMaster.Columns(7).Visible = False
                GridViewLocationMaster.ShowFooter = False
                GridViewParMaster.Columns(0).Visible = False
                GridViewParMaster.Columns(19).Visible = False
                GridViewParMaster.ShowFooter = False
                GridViewItemMaster.Columns(0).Visible = False
                GridViewItemMaster.ShowFooter = False

            End If


        End If
    End Sub

    Protected Sub GridViewParMaster_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "ParMasterInsert" Then
            Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Dim ad As New SqlDataAdapter()
            Dim cmd As New SqlCommand()
            Dim txtLocationName As String = TryCast(GridViewParMaster.FooterRow.FindControl("LocationDDF"), DropDownList).SelectedItem.Value
            Dim txtItemDescription As String = TryCast(GridViewParMaster.FooterRow.FindControl("ItemDDF"), DropDownList).SelectedItem.Value
            Dim txtFacilityName As String = TryCast(GridViewParMaster.FooterRow.FindControl("FacilityDDF"), DropDownList).SelectedItem.Value
            Dim txtBinSequence As TextBox = DirectCast(GridViewParMaster.FooterRow.FindControl("BinSequenceF"), TextBox)
            Dim txtBinUOM As String = TryCast(GridViewParMaster.FooterRow.FindControl("BinUOMDDF"), DropDownList).SelectedItem.Value
            Dim txtBinQuantity As TextBox = DirectCast(GridViewParMaster.FooterRow.FindControl("BinQuantityF"), TextBox)
            Dim txtLeadTime As String = TryCast(GridViewParMaster.FooterRow.FindControl("BinLeadTimeDDF"), DropDownList).SelectedItem.Value
            Dim txtItemType As TextBox = DirectCast(GridViewParMaster.FooterRow.FindControl("ItemTypeF"), TextBox)
            Dim txtWHSequence As TextBox = DirectCast(GridViewParMaster.FooterRow.FindControl("WHSequenceF"), TextBox)
            Dim txtPatientCharge As String = TryCast(GridViewParMaster.FooterRow.FindControl("PatientChargeDDF"), DropDownList).SelectedItem.Value


            cmd.Connection = conn
            cmd.CommandText = "exec sp_InsertBlueBinParMaster '" & txtFacilityName & "','" & txtLocationName & "','" & txtItemDescription & "','" & txtBinSequence.Text & "','" & txtBinUOM & "','" & txtBinQuantity.Text & "','" & txtLeadTime & "','" & txtItemType.Text & "','" & txtWHSequence.Text & "','" & txtPatientCharge & "'"
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            GridViewParMaster.DataBind()
        End If
    End Sub

    Protected Sub GridViewItemMaster_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "ItemInsert" Then
            Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Dim ad As New SqlDataAdapter()
            Dim cmd As New SqlCommand()
            Dim txtItemID As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("ItemID"), TextBox)
            Dim txtItemDescription As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("ItemDescription"), TextBox)
            Dim txtItemClinicalDescription As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("ItemClinicalDescription"), TextBox)
            Dim txtManufacturer As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("Manufacturer"), TextBox)
            Dim txtManufacturerNo As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("ManufacturerNo"), TextBox)
            Dim txtVendor As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("Vendor"), TextBox)
            Dim txtVendorNo As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("VendorNo"), TextBox)
            Dim txtVendorItemID As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("VendorItemID"), TextBox)
            Dim txtStockUOM As TextBox = DirectCast(GridViewItemMaster.FooterRow.FindControl("StockUOM"), TextBox)

            Dim StItemDescription As String = txtItemDescription.Text
            Dim StItemClinicalDescription As String = txtItemClinicalDescription.Text
            StItemDescription = StItemDescription.Replace("'", "''")
            StItemClinicalDescription = StItemClinicalDescription.Replace("'", "''")

            cmd.Connection = conn
            cmd.CommandText = "exec sp_InsertBlueBinItemMaster '" & txtItemID.Text & "','" & StItemDescription & "','" & StItemClinicalDescription & "','" & txtManufacturer.Text & "','" & txtManufacturerNo.Text & "','" & txtVendor.Text & "','" & txtVendorNo.Text & "','" & txtVendorItemID.Text & "','" & txtStockUOM.Text & "'"
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            GridViewItemMaster.DataBind()
        End If



    End Sub


    Protected Sub GridViewLocationMaster_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "LocationInsert" Then
            Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Dim ad As New SqlDataAdapter()
            Dim cmd As New SqlCommand()
            Dim txtLocationID As TextBox = DirectCast(GridViewLocationMaster.FooterRow.FindControl("LocationID"), TextBox)
            Dim txtLocationName As TextBox = DirectCast(GridViewLocationMaster.FooterRow.FindControl("LocationName"), TextBox)

            Dim StLocationName As String = txtLocationName.Text
            StLocationName = StLocationName.Replace("'", "''")

            cmd.Connection = conn
            cmd.CommandText = "exec sp_InsertBlueBinLocationMaster '" & txtLocationID.Text & "','" & StLocationName & "'"
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            GridViewLocationMaster.DataBind()
        End If
    End Sub




    Protected Sub ExportToExcelParMaster(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=ParMasterExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewParMaster.AllowPaging = False
            GridViewParMaster.DataBind()
            GridViewParMaster.HeaderRow.BackColor = Color.White
            GridViewParMaster.HeaderRow.Cells(0).Visible = False
            GridViewParMaster.HeaderRow.Cells(15).Visible = False
            GridViewParMaster.HeaderRow.Cells(16).Visible = False
            GridViewParMaster.FooterRow.Visible = False

            For Each cell As TableCell In GridViewParMaster.HeaderRow.Cells
                cell.BackColor = GridViewParMaster.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewParMaster.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                row.Cells(15).Visible = False
                row.Cells(16).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewParMaster.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewParMaster.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewParMaster.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Protected Sub ExportToExcelLocationMaster(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=LocationMasterExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewLocationMaster.AllowPaging = False
            GridViewLocationMaster.DataBind()
            GridViewLocationMaster.HeaderRow.BackColor = Color.White
            GridViewLocationMaster.HeaderRow.Cells(0).Visible = False
            GridViewLocationMaster.FooterRow.Visible = False



            For Each cell As TableCell In GridViewLocationMaster.HeaderRow.Cells
                cell.BackColor = GridViewLocationMaster.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewLocationMaster.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewLocationMaster.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewLocationMaster.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewLocationMaster.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Protected Sub ExportToExcelItemMaster(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=ItemMasterExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewItemMaster.AllowPaging = True
            GridViewItemMaster.DataBind()
            GridViewItemMaster.HeaderRow.BackColor = Color.White
            GridViewItemMaster.HeaderRow.Cells(0).Visible = False
            GridViewItemMaster.FooterRow.Visible = False


            For Each cell As TableCell In GridViewItemMaster.HeaderRow.Cells
                cell.BackColor = GridViewItemMaster.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewItemMaster.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewItemMaster.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewItemMaster.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewItemMaster.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub OnCheckedChanged(sender As Object, e As EventArgs)
        GridViewItemMaster.Columns(8).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(9).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(10).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(11).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(12).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(13).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(14).Visible = TryCast(sender, CheckBox).Checked
        GridViewItemMaster.Columns(15).Visible = TryCast(sender, CheckBox).Checked
    End Sub
End Class