Imports System.Collections.Generic
Imports System.Security.Claims
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.UserControl
Imports System.Data.SqlClient
Imports System.Data

Partial Public Class SiteMaster
    Inherits MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Page.IsPostBack() Then
            'Comment
            'This populates the Logo displaying from the config value

            Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            con.Open()

            Dim da As New SqlDataAdapter("exec sp_SelectVersion", con)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim Version As String = dt.Rows(0)("ConfigValue").ToString()
            LabelVersion.Text = "Version " & Version

            con.Close()

        End If

        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString()
            Dim ADMINMENU As String
            Dim ADMINCONFIG As String
            Dim ADMINUSERS As String
            Dim ADMINRESOURCES As String
            Dim ADMINTRAINING As String
            Dim MENUDashboard As String
            Dim MENUDashboardSC As String
            Dim MENUDashboardSrc As String
            Dim MENUDashboardOps As String
            Dim MENUDashboardHB As String
            Dim MENUQCN As String
            Dim MENUGemba As String
            Dim MENUHardware As String
            Dim MENUScanning As String
            Dim MENUOther As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using conroles As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conroles
                    conroles.Open()
                    'cmd.ExecuteNonQuery()
                    'command.Parameters["@id"].Value = rowUserID
                    'ADMIN-MENU
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-MENU")
                    ADMINMENU = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-CONFIG
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-CONFIG")
                    ADMINCONFIG = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-USERS
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-USERS")
                    ADMINUSERS = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-RESOURCES
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-RESOURCES")
                    ADMINRESOURCES = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-TRAINING
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-TRAINING")
                    ADMINTRAINING = Convert.ToString(cmdadmin.ExecuteScalar())
                    conroles.Close()
                End Using
            End Using

            Using conmenu As New SqlConnection(constr)
                Using cmdmenu As New SqlCommand("sp_ValidateMenus")
                    cmdmenu.CommandType = CommandType.StoredProcedure
                    cmdmenu.Connection = conmenu
                    conmenu.Open()
                    'cmd.ExecuteNonQuery()

                    'MENU-Dashboard
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard")
                    MENUDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
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
                    'MENU-QCN
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-QCN")
                    MENUQCN = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Gemba
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Gemba")
                    MENUGemba = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Hardware
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Hardware")
                    MENUHardware = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Scanning
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Scanning")
                    MENUScanning = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Other
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Other")
                    MENUOther = Convert.ToString(cmdmenu.ExecuteScalar())

                    conmenu.Close()
                End Using
            End Using

            'Admin Meus
            If ADMINMENU = "Yes" Then
                ADMINMENUDD.Visible = True
            Else
                ADMINMENUDD.Visible = False
            End If

            If ADMINCONFIG = "Yes" Then
                ADMINCONFIGDD.Visible = True
            Else
                ADMINCONFIGDD.Visible = False
            End If

            If ADMINUSERS = "Yes" Then
                ADMINUSERSDD.Visible = True
            Else
                ADMINUSERSDD.Visible = False
            End If

            If ADMINRESOURCES = "Yes" Then
                ADMINRESOURCESDD.Visible = True
            Else
                ADMINRESOURCESDD.Visible = False
            End If

            If ADMINTRAINING = "Yes" Then
                ADMINTRAININGDD.Visible = True
            Else
                ADMINTRAININGDD.Visible = False
            End If

            'Main Menus
            If MENUDashboard = "Yes" Then
                DashboardDD.Visible = True
            Else
                DashboardDD.Visible = False
            End If

            If MENUDashboardHB = "Yes" Then
                HuddleBoardDD.Visible = True
            Else
                HuddleBoardDD.Visible = False
            End If

            'If MENUDashboardSC = "Yes" Then
            'DashboardDD.Visible = True
            'Else
            'DashboardDD.Visible = False
            'End If

            'If MENUDashboardSrc = "Yes" Then
            'DashboardDD.Visible = True
            'Else
            'DashboardDD.Visible = False
            'End If

            'If MENUDashboardOps = "Yes" Then
            'DashboardDD.Visible = True
            'Else
            'DashboardDD.Visible = False
            'End If

            If MENUQCN = "Yes" Then
                QCNDD.Visible = True
            Else
                QCNDD.Visible = False
            End If

            If MENUGemba = "Yes" Then
                GembaDD.Visible = True
            Else
                GembaDD.Visible = False
            End If

            If MENUScanning = "Yes" Then
                ScanningDD.Visible = True
            Else
                ScanningDD.Visible = False
            End If

            If MENUHardware = "Yes" Then
                HardwareDD.Visible = True
            Else
                HardwareDD.Visible = False
            End If

            If MENUOther = "Yes" Then
                OtherDD.Visible = True
            Else
                OtherDD.Visible = False
            End If


        End If
    End Sub


End Class