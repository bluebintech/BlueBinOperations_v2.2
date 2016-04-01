Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO


Partial Public Class OperationalProcedures

    Inherits System.Web.UI.Page
    Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()


    Protected Sub Page_Load(sender As Object, e As EventArgs)

        Dim SqlDataSourceSOPs As New SqlDataSource()
        SqlDataSourceSOPs.ID = "SqlDataSourceSOPs"
        Me.Page.Controls.Add(SqlDataSourceSOPs)
        SqlDataSourceSOPs.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceSOPs.SelectCommand = "exec sp_SelectDocuments '" & UserLogin & "','SOPs'"
        GridViewSOPs.DataSource = SqlDataSourceSOPs

        Dim SqlDataSourceFormsSignage As New SqlDataSource()
        SqlDataSourceFormsSignage.ID = "SqlDataSourceFormsSignage"
        Me.Page.Controls.Add(SqlDataSourceFormsSignage)
        SqlDataSourceFormsSignage.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceFormsSignage.SelectCommand = "exec sp_SelectDocuments '" & UserLogin & "','FormsSignage'"
        GridViewFormsSignage.DataSource = SqlDataSourceFormsSignage

        Dim SqlDataSourceBeltCertification As New SqlDataSource()
        SqlDataSourceBeltCertification.ID = "SqlDataSourceBeltCertification"
        Me.Page.Controls.Add(SqlDataSourceBeltCertification)
        SqlDataSourceBeltCertification.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceBeltCertification.SelectCommand = "exec sp_SelectDocuments '" & UserLogin & "','BeltCertification'"
        GridViewBeltCertification.DataSource = SqlDataSourceBeltCertification

        Dim SqlDataSourceOther As New SqlDataSource()
        SqlDataSourceOther.ID = "SqlDataSourceOther"
        Me.Page.Controls.Add(SqlDataSourceOther)
        SqlDataSourceOther.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceOther.SelectCommand = "exec sp_SelectDocuments '" & UserLogin & "','Other'"
        GridViewOther.DataSource = SqlDataSourceOther

        GridViewSOPs.DataBind()
        GridViewFormsSignage.DataBind()
        GridViewBeltCertification.DataBind()
        GridViewOther.DataBind()
        GridViewSOPs.Visible = True
        GridViewFormsSignage.Visible = True
        GridViewBeltCertification.Visible = True
        GridViewOther.Visible = True

        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim UserDocUploadOther As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conroles As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conroles
                    conroles.Open()
                    'cmd.ExecuteNonQuery()
                    'command.Parameters["@id"].Value = rowUserID
                    'UserDocumentUplaod Utility
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "DOCUMENTS-UploadUtility")
                    UserDocUploadOther = Convert.ToString(cmdadmin.ExecuteScalar())

                    conroles.Close()
                End Using
            End Using

            If UserDocUploadOther = "Yes" Then
                UploadUtility.Visible = True

            Else
                UploadUtility.Visible = False

            End If


        End If

    End Sub

    Protected Sub DocumentInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DocumentInsert.Click
        'Make sure a file has been successfully uploaded
        If UploadDocument.PostedFile Is Nothing OrElse String.IsNullOrEmpty(UploadDocument.PostedFile.FileName) OrElse UploadDocument.PostedFile.InputStream Is Nothing Then
            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "File Upload Unsuccessful.  Please select a file to upload"
            Exit Sub
        End If
        If DocumentGroupDDL.SelectedValue.ToString() = "" Then

            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "File Upload Unsuccessful.  You must select a Document Group."
            Exit Sub
        End If

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        con.Open()
        Dim da As New SqlDataAdapter("exec sp_SelectSingleConfig 'SiteAppURL'", con)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim Customer As String = dt.Rows(0)("ConfigValue").ToString()
        con.Close()

        'Make sure we are dealing with a JPG or GIF file
        Dim extension As String = Path.GetExtension(UploadDocument.PostedFile.FileName).ToLower()
        Dim DocumentType As String = String.Empty
        Dim filePath As String = UploadDocument.PostedFile.FileName
        Dim filename2 As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename2)

        Dim fileName As String = Path.GetFileName(UploadDocument.PostedFile.FileName)
        'Dim DocumentLocation As String = Server.MapPath("\")+"BlueBinDocuments\" + Customer + "\" + DocumentGroupDDL.SelectedValue.ToString() + "\" + fileName
        Dim dr As String = "D"
        Dim DocumentLocation As String = dr + ":\BlueBinDocuments\" + Customer + "\" + DocumentGroupDDL.SelectedValue.ToString() + "\" + fileName

        Select Case extension
            Case ".doc"
                DocumentType = "application/vnd.ms-word"
                Exit Select
            Case ".docx"
                DocumentType = "application/vnd.ms-word"
                Exit Select
            Case ".xls"
                DocumentType = "application/vnd.ms-excel"
                Exit Select
            Case ".xlsx"
                DocumentType = "application/vnd.ms-excel"
                Exit Select
            Case ".jpg"
                DocumentType = "image/jpg"
                Exit Select
            Case ".png"
                DocumentType = "image/png"
                Exit Select
            Case ".gif"
                DocumentType = "image/gif"
                Exit Select
            Case ".pdf"
                DocumentType = "application/pdf"
                Exit Select
            Case ".ppsx"
                DocumentType = "application/ppsx"
                Exit Select
            Case Else
                'Invalid file type uploaded
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "File Upload Unuccessful.  Invalid File Type"
                Exit Sub
        End Select
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            If DocumentType <> String.Empty Then
                Const SQL As String = "exec sp_InsertDocument @DocumentName,@DocumentType,@DocumentSource,@UserLogin,@Document"
                Dim myCommand As New SqlCommand(SQL, myConnection)
                myCommand.Parameters.AddWithValue("@DocumentName", DocumentName.Text)
                myCommand.Parameters.AddWithValue("@DocumentType", DocumentType)
                myCommand.Parameters.AddWithValue("@DocumentSource", DocumentGroupDDL.SelectedValue.ToString())
                myCommand.Parameters.AddWithValue("@UserLogin", UserLogin)
                myCommand.Parameters.AddWithValue("@Document", DocumentLocation)

                myConnection.Open()
                myCommand.ExecuteNonQuery()
                myConnection.Close()
                lblMessage.ForeColor = System.Drawing.Color.Green
                lblMessage.Text = "Document '" + DocumentName.Text + "' Uploaded Successfully"
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "File Upload Unsuccessful. Please Try again."
            End If
        End Using

        UploadDocument.PostedFile.SaveAs((DocumentLocation))


        GridViewSOPs.DataBind()
        GridViewFormsSignage.DataBind()
        GridViewBeltCertification.DataBind()
        GridViewOther.DataBind()
        DocumentName.Text = ""
        DocumentGroupDDL.SelectedValue = ""
    End Sub


    '*************


    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        lblMessage.Text = ""
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim fileName As String, filePath As String, contentType As String

        Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        If id > 0 Then

            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand()
                    cmd.CommandText = "exec sp_SelectDocumentSingle @DocumentID"
                    cmd.Parameters.AddWithValue("@DocumentID", id)
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        sdr.Read()
                        filePath = sdr("Document").ToString()
                        contentType = sdr("DocumentType").ToString()
                        fileName = sdr("DocumentName").ToString()
                    End Using
                    con.Close()
                End Using
            End Using
        Else
            filePath = "\false"
        End If
        Dim fileInfo As New FileInfo(filePath)
        If fileInfo.Exists Or filePath <> "\false" Then
            Try
                Response.ContentType = contentType
                Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
                Response.WriteFile(filePath)
                Response.End()

            Catch ex As Exception
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "File not available.  Please reupload or try again."
            End Try
        Else
            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "File not available.  Please reupload or try again."
        End If

        GridViewSOPs.DataBind()
        GridViewFormsSignage.DataBind()
        GridViewBeltCertification.DataBind()
        GridViewOther.DataBind()
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim fileName As String, filePath As String, contentType As String
        Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "exec sp_SelectDocumentSingle @DocumentID"
                cmd.Parameters.AddWithValue("@DocumentID", id)
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    filePath = sdr("Document").ToString()
                    contentType = sdr("DocumentType").ToString()
                    fileName = sdr("DocumentName").ToString()
                End Using

                Using cmd2 As New SqlCommand()
                    cmd2.Connection = con
                    cmd2.CommandText = "exec sp_DeleteDocument '" + UserLogin + "','" & id & "'"
                    cmd2.ExecuteNonQuery()

                End Using

                con.Close()

            End Using

        End Using

        File.Delete(filePath)
        GridViewSOPs.DataBind()
        GridViewFormsSignage.DataBind()
        GridViewBeltCertification.DataBind()
        GridViewOther.DataBind()
        DocumentName.Text = ""
    End Sub


End Class