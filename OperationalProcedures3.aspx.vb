Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Collections.Generic


Partial Public Class OperationalProcedures3

    Inherits System.Web.UI.Page
    Dim UserLogin As String = Page.User.Identity.Name.ToString()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        con.Open()
        Dim da As New SqlDataAdapter("exec sp_SelectSingleConfig 'SiteAppURL'", con)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim Customer As String = dt.Rows(0)("ConfigValue").ToString()
        con.Close()

        Dim filePaths() As String = Directory.GetFiles("C:\BlueBinDocuments\" + Customer + "\SOPs\")
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        GridViewDocuments.DataSource = files
        GridViewDocuments.DataBind()

    End Sub

    Protected Sub UploadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        con.Open()
        Dim da As New SqlDataAdapter("exec sp_SelectSingleConfig 'SiteAppURL'", con)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim Customer As String = dt.Rows(0)("ConfigValue").ToString()
        con.Close()

        Dim fileName As String = Path.GetFileName(UploadDocument.PostedFile.FileName)
        UploadDocument.PostedFile.SaveAs(("C:\BlueBinDocuments\" + Customer + "\SOPs\" + fileName))



        GridViewDocuments.DataBind()
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, LinkButton).CommandArgument
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
        Response.WriteFile(filePath)
        Response.End()
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, LinkButton).CommandArgument
        File.Delete(filePath)
        GridViewDocuments.DataBind()
    End Sub
End Class