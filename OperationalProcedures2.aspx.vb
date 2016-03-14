Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO


Partial Public Class OperationalProcedures2

    Inherits System.Web.UI.Page
    Dim UserLogin As String = Page.User.Identity.Name.ToString()


    Protected Sub Page_Load(sender As Object, e As EventArgs)
        GridViewDocuments.DataBind()
    End Sub

    Protected Sub DocumentInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DocumentInsert.Click
        'Make sure a file has been successfully uploaded
        If UploadDocument.PostedFile Is Nothing OrElse String.IsNullOrEmpty(UploadDocument.PostedFile.FileName) OrElse UploadDocument.PostedFile.InputStream Is Nothing Then
            Response.Write("Please upload a a Powerpoint, Word, Excel, or PDF Document")
            Exit Sub
        End If

        'Make sure we are dealing with a JPG or GIF file
        Dim extension As String = Path.GetExtension(UploadDocument.PostedFile.FileName).ToLower()
        Dim DocumentType As String = String.Empty
        Dim filePath As String = UploadDocument.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)


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
            Case Else
                'Invalid file type uploaded
                Response.Write("Please upload a a Powerpoint, Word, Excel, or PDF File")
                Exit Sub
        End Select
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            If DocumentType <> String.Empty Then
                Const SQL As String = "exec sp_InsertDocument @DocumentName,@DocumentType,@DocumentSource,@UserLogin,@Document"
                Dim myCommand As New SqlCommand(SQL, myConnection)
                myCommand.Parameters.AddWithValue("@DocumentName", DocumentName.Text)
                myCommand.Parameters.AddWithValue("@DocumentType", DocumentType)
                myCommand.Parameters.AddWithValue("@DocumentSource", "SOPs")
                myCommand.Parameters.AddWithValue("@UserLogin", UserLogin)

                'Load FileUpload's InputStream into Byte array
                Dim DocumentBytes(UploadDocument.PostedFile.InputStream.Length) As Byte
                UploadDocument.PostedFile.InputStream.Read(DocumentBytes, 0, DocumentBytes.Length)
                myCommand.Parameters.AddWithValue("@Document", DocumentBytes)

                myConnection.Open()
                myCommand.ExecuteNonQuery()
                myConnection.Close()
                lblMessage.ForeColor = System.Drawing.Color.Green
                lblMessage.Text = "File Uploaded Successfully"
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "File Upload UnSuccessful"
            End If
        End Using

        Dim SqlDataSourceDocuments As New SqlDataSource()
        SqlDataSourceDocuments.ID = "SqlDataSourceDocuments"
        Me.Page.Controls.Add(SqlDataSourceDocuments)
        SqlDataSourceDocuments.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceDocuments.SelectCommand = "exec sp_SelectDocuments '" & UserLogin & "','SOPs'"
        GridViewDocuments.DataSource = SqlDataSourceDocuments
        GridViewDocuments.DataBind()
        GridViewDocuments.Visible = True

    End Sub
    Protected Sub DownloadFile(sender As Object, e As EventArgs)
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim bytes As Byte()
        Dim fileName As String, contentType As String
        Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select DocumentName, Document, DocumentType from tblFiles where DocumentID=@DocumentID"
                cmd.Parameters.AddWithValue("@DocumentID", id)
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    bytes = DirectCast(sdr("Document"), Byte())
                    contentType = sdr("DocumentType").ToString()
                    fileName = sdr("DocumentName").ToString()
                End Using
                con.Close()
            End Using
        End Using
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
        GridViewDocuments.DataBind()
    End Sub
End Class