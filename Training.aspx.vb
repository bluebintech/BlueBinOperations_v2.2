Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration

Partial Class Training
    Inherits Page
    Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
    Protected Sub TrainingB_Click(sender As Object, e As EventArgs) Handles TrainingB.Click
        GridViewTraining.Visible = True
        GridViewTrainingModule.Visible = False
        SearchBox.Visible = True
        SearchModule.Visible = True
        SearchNameLB.Visible = True
        SearchModuleLB.Visible = True
        ExportTraining.Visible = True
        hiddenTraining.Visible = True
        hiddenTrainingModule.Visible = False
        GridViewTraining.DataBind()
    End Sub

    Protected Sub TrainingModulesB_Click(sender As Object, e As EventArgs) Handles TrainingModulesB.Click
        GridViewTraining.Visible = False
        GridViewTrainingModule.Visible = True
        SearchBox.Visible = False
        SearchModule.Visible = True
        SearchNameLB.Visible = False
        SearchModuleLB.Visible = True
        ExportTraining.Visible = False
        hiddenTraining.Visible = False
        hiddenTrainingModule.Visible = True
        GridViewTrainingModule.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            GridViewTraining.Visible = True
            GridViewTrainingModule.Visible = False
            SearchBox.Visible = True
            SearchModule.Visible = True
            SearchNameLB.Visible = True
            SearchModuleLB.Visible = True
            ExportTraining.Visible = True
            hiddenTraining.Visible = True
            hiddenTrainingModule.Visible = False
            UpdaterTB.Text = UserLogin
            GridViewTraining.DataBind()
            GridViewTrainingModule.DataBind()
        End If
    End Sub
    Protected Sub Training_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "TrainingInsert" Then
            Dim txtResourceName As String = TryCast(GridViewTraining.FooterRow.FindControl("ResourceNameDD"), DropDownList).SelectedItem.Value
            Dim txtTrainingModuleID As String = TryCast(GridViewTraining.FooterRow.FindControl("TrainingModuleDDF"), DropDownList).SelectedItem.Value
            Dim txtStatus As String = TryCast(GridViewTraining.FooterRow.FindControl("StatusDDF"), DropDownList).SelectedItem.Value


            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("sp_InsertTraining")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@BlueBinResource", txtResourceName)
                    cmd.Parameters.AddWithValue("@TrainingModuleID", txtTrainingModuleID)
                    cmd.Parameters.AddWithValue("@Status", txtStatus)
                    cmd.Parameters.AddWithValue("@Updater", UserLogin)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using

            GridViewTraining.DataBind()
        End If


    End Sub

    Protected Sub TrainingModule_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "TrainingModuleInsert" Then
            Dim txtModuleName As TextBox = DirectCast(GridViewTrainingModule.FooterRow.FindControl("TrainingModuleNameF"), TextBox)
            Dim txtModuleDescription As TextBox = DirectCast(GridViewTrainingModule.FooterRow.FindControl("TrainingModuleDescriptionF"), TextBox)
            Dim txtRequired As String = TryCast(GridViewTrainingModule.FooterRow.FindControl("RequiredDDF"), DropDownList).SelectedItem.Value



            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("sp_InsertTrainingModule")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text)
                    cmd.Parameters.AddWithValue("@ModuleDescription", txtModuleDescription.Text)
                    cmd.Parameters.AddWithValue("@Required", txtRequired)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using

            GridViewTrainingModule.DataBind()
        End If


    End Sub

    Protected Sub ExportToExcelTraining(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=TrainingExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewTraining.AllowPaging = False
            GridViewTraining.DataBind()
            GridViewTraining.HeaderRow.BackColor = Color.White
            GridViewTraining.HeaderRow.Cells(0).Visible = False
            GridViewTraining.FooterRow.Visible = False

            For Each cell As TableCell In GridViewTraining.HeaderRow.Cells
                cell.BackColor = GridViewTraining.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewTraining.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewTraining.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewTraining.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewTraining.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cellModuleDescription As TableCell = e.Row.Cells(5)

            cellModuleDescription.ToolTip = TryCast(e.Row.DataItem, DataRowView)("ModuleDescription").ToString()

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cellStatus As TableCell = e.Row.Cells(9)
            Dim Status As String = cellStatus.Text
            If Status = "Demo" Or Status = "Teach" Then
                cellStatus.BackColor = Color.Yellow
            End If
            If Status = "Trained" Or Status = "Critical" Then
                cellStatus.BackColor = Color.Green
            End If

        End If
    End Sub


End Class