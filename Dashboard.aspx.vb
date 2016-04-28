
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.UserControl



Public Class Dashboard
    Inherits Page
    Protected TableauFullURL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        con.Open()
        Dim da As New SqlDataAdapter("exec sp_SelectTableauURL", con)
        Dim dt As New DataTable

        da.Fill(dt)

        Dim TableaURLDB As String = dt.Rows(0)("ConfigValue").ToString()
        TableauFullURL = "https://10ay.online.tableau.com/t" & TableaURLDB & "Home"

        con.Close()

        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim MENUDashboardSC As String
            Dim MENUDashboardSrc As String
            Dim MENUDashboardOps As String
            Dim MENUDashboardHB As String
            Dim UserMENUDashboardSC As String
            Dim UserMENUDashboardSrc As String
            Dim UserMENUDashboardOps As String
            Dim UserMENUDashboardHB As String


            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using conroles As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conroles
                    conroles.Open()
                    'cmd.ExecuteNonQuery()
                    'command.Parameters["@id"].Value = rowUserID

                    'UserMENU-Dashboard-SupplyChain
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-SupplyChain")
                    UserMENUDashboardSC = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-Sourcing
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-Sourcing")
                    UserMENUDashboardSrc = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-Ops
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-Ops")
                    UserMENUDashboardOps = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-HuddleBoard
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-HuddleBoard")
                    UserMENUDashboardHB = Convert.ToString(cmdadmin.ExecuteScalar())

                    conroles.Close()
                End Using
            End Using

            Using conmenu As New SqlConnection(constr)
                Using cmdmenu As New SqlCommand("sp_ValidateMenus")
                    cmdmenu.CommandType = CommandType.StoredProcedure
                    cmdmenu.Connection = conmenu
                    conmenu.Open()
                    'cmd.ExecuteNonQuery()

                    'MENU-Dashboard-SupplyChain
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-SupplyChain")
                    MENUDashboardSC = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Dashboard-Sourcing
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-Sourcing")
                    MENUDashboardSrc = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Dashboard-Ops
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-Ops")
                    MENUDashboardOps = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Dashboard-HuddleBoard
                    'cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-HuddleBoard")
                    'MENUDashboardHB = Convert.ToString(cmdmenu.ExecuteScalar())
                    'cmdmenu.Parameters.Clear()
                    conmenu.Close()
                End Using
            End Using



            'Main Menus


            If MENUDashboardSC = "No" Or UserMENUDashboardSC = "No" Then
                themes.Visible = False
            Else
                themes.Visible = True
            End If

            If MENUDashboardSrc = "No" Or UserMENUDashboardSrc = "No" Then
                download3.Visible = False
            Else
                download3.Visible = True
            End If

            If MENUDashboardOps = "No" Or UserMENUDashboardOps = "No" Then
                download2.Visible = False
            Else
                download2.Visible = True
            End If

            'If MENUDashboardHB = "No" Or UserMENUDashboardHB = "No" Then
            'HuddleBoardDD.Visible = False
            'HBDivider.Visible = False
            'Else
            'HuddleBoardDD.Visible = True
            'HBDivider.Visible = True
            'End If

        End If

    End Sub


    '/bluebinanalytics/views/MHS/Home
    ' TableauFullURL.ToString()
End Class