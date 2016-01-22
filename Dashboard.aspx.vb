
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
        TableauFullURL = "https://10ay.online.tableau.com/#/site" & TableaURLDB & "Home"

        con.Close()

        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString()
            Dim MENUDashboardSC As String
            Dim MENUDashboardSrc As String
            Dim MENUDashboardOps As String
            Dim MENUDashboardHB As String


            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString


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
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-HuddleBoard")
                    MENUDashboardHB = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    conmenu.Close()
                End Using
            End Using



            'Main Menus


            If MENUDashboardSC = "Yes" Then
                themes.Visible = True
            Else
                themes.Visible = False
            End If

            If MENUDashboardSrc = "Yes" Then
                download3.Visible = True
            Else
                download3.Visible = False
            End If

            If MENUDashboardOps = "Yes" Then
                download2.Visible = True
            Else
                download2.Visible = False
            End If

            If MENUDashboardHB = "Yes" Then
                HuddleBoardDD.Visible = True
                HBDivider.Visible = True
            Else
                HuddleBoardDD.Visible = False
                HBDivider.Visible = False
            End If

        End If

    End Sub


    '/bluebinanalytics/views/MHS/Home
    ' TableauFullURL.ToString()
End Class