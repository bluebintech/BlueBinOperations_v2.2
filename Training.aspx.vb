Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration

Partial Class Training
    Inherits Page
    Dim UserLogin As String = Page.User.Identity.Name.ToString()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            UpdaterTB.Text = UserLogin
            GridViewBlueBinTraining.DataBind()
        End If
    End Sub
    Protected Sub BlueBinTraining_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "TrainingInsert" Then
            Dim txtResourceName As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("ResourceNameDD"), DropDownList).SelectedItem.Value
            Dim txtForm3000 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3000DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3001 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3001DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3002 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3002DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3003 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3003DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3004 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3004DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3005 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3005DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3006 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3006DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3007 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3007DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3008 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3008DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3009 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3009DDF"), DropDownList).SelectedItem.Value
            Dim txtForm3010 As String = TryCast(GridViewBlueBinTraining.FooterRow.FindControl("Form3010DDF"), DropDownList).SelectedItem.Value

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("sp_InsertBlueBinTraining")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@BlueBinResource", txtResourceName)
                    cmd.Parameters.AddWithValue("@Form3000", txtForm3000)
                    cmd.Parameters.AddWithValue("@Form3001", txtForm3001)
                    cmd.Parameters.AddWithValue("@Form3002", txtForm3002)
                    cmd.Parameters.AddWithValue("@Form3003", txtForm3003)
                    cmd.Parameters.AddWithValue("@Form3004", txtForm3004)
                    cmd.Parameters.AddWithValue("@Form3005", txtForm3005)
                    cmd.Parameters.AddWithValue("@Form3006", txtForm3006)
                    cmd.Parameters.AddWithValue("@Form3007", txtForm3007)
                    cmd.Parameters.AddWithValue("@Form3008", txtForm3008)
                    cmd.Parameters.AddWithValue("@Form3009", txtForm3009)
                    cmd.Parameters.AddWithValue("@Form3010", txtForm3010)
                    cmd.Parameters.AddWithValue("@Updater", UserLogin)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using

            GridViewBlueBinTraining.DataBind()
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
            GridViewBlueBinTraining.AllowPaging = False
            GridViewBlueBinTraining.DataBind()
            GridViewBlueBinTraining.HeaderRow.BackColor = Color.White
            GridViewBlueBinTraining.HeaderRow.Cells(0).Visible = False
            GridViewBlueBinTraining.FooterRow.Visible = False

            For Each cell As TableCell In GridViewBlueBinTraining.HeaderRow.Cells
                cell.BackColor = GridViewBlueBinTraining.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewBlueBinTraining.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewBlueBinTraining.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewBlueBinTraining.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewBlueBinTraining.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub



End Class