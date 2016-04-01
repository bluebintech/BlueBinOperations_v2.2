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
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim UserADMINMENU As String
            Dim UserADMINCONFIG As String
            Dim UserADMINUSERS As String
            Dim UserADMINRESOURCES As String
            Dim UserADMINTRAINING As String
            Dim UserMENUDashboard As String
            Dim UserMENUDashboardSC As String
            Dim UserMENUDashboardSrc As String
            Dim UserMENUDashboardOps As String
            Dim UserMENUDashboardHB As String
            Dim UserMENUQCN As String
            Dim UserMENUGemba As String
            Dim UserMENUHardware As String
            Dim UserMENUScanning As String
            Dim UserMENUOther As String
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
            Dim UserADMINPARMASTER As String
            Dim MENUADMINPARMASTER As String

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
                    UserADMINMENU = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-CONFIG
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-CONFIG")
                    UserADMINCONFIG = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-USERS
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-USERS")
                    UserADMINUSERS = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-RESOURCES
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-RESOURCES")
                    UserADMINRESOURCES = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-PARMASTER
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-PARMASTER")
                    UserADMINPARMASTER = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'ADMIN-TRAINING
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "ADMIN-TRAINING")
                    UserADMINTRAINING = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard")
                    UserMENUDashboard = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
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
                    cmdadmin.Parameters.Clear()
                    'UserMENU-QCN
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-QCN")
                    UserMENUQCN = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Gemba
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Gemba")
                    UserMENUGemba = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Hardware
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Hardware")
                    UserMENUHardware = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Scanning
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Scanning")
                    UserMENUScanning = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Other
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Other")
                    UserMENUOther = Convert.ToString(cmdadmin.ExecuteScalar())

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
                    'MenuAdmin-PARMASTER
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "ADMIN-PARMASTER")
                    MENUADMINPARMASTER = Convert.ToString(cmdmenu.ExecuteScalar())
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
            If UserADMINMENU = "Yes" Then
                ADMINMENUDD.Visible = True
            Else
                ADMINMENUDD.Visible = False
            End If

            If UserADMINCONFIG = "Yes" Then
                ADMINCONFIGDD.Visible = True
            Else
                ADMINCONFIGDD.Visible = False
            End If

            If UserADMINUSERS = "Yes" Then
                ADMINUSERSDD.Visible = True
            Else
                ADMINUSERSDD.Visible = False
            End If

            If UserADMINRESOURCES = "Yes" Then
                ADMINRESOURCESDD.Visible = True
            Else
                ADMINRESOURCESDD.Visible = False
            End If

            If UserADMINTRAINING = "Yes" Then
                ADMINTRAININGDD.Visible = True
            Else
                ADMINTRAININGDD.Visible = False
            End If

            'Main Menus
            If MENUDashboard = "No" Or UserMENUDashboard = "No" Then
                DashboardDD.Visible = False
            Else
                DashboardDD.Visible = True
            End If

            If MENUDashboardHB = "No" Or UserMENUDashboardHB = "No" Then
                HuddleBoardDD.Visible = False
            Else
                HuddleBoardDD.Visible = True
            End If

            'If MENUDashboardSC = "No" Or UserMENUDashboardSC = "No" Then
            'DashboardDD.Visible = False
            'Else
            'DashboardDD.Visible = True
            'End If

            'If MENUDashboardSrc = "No" Or UserMENUDashboardSrc = "No" Then
            'DashboardDD.Visible = False
            'Else
            'DashboardDD.Visible = True
            'End If

            'If MENUDashboardOps = "No" Or UserMENUDashboardOps = "No" Then
            'DashboardDD.Visible = False
            'Else
            'DashboardDD.Visible = True
            'End If

            If MENUQCN = "No" Or UserMENUQCN = "No" Then
                QCNDD.Visible = False
            Else
                QCNDD.Visible = True
            End If

            If MENUGemba = "No" Or UserMENUGemba = "No" Then
                GembaDD.Visible = False
            Else
                GembaDD.Visible = True
            End If

            If MENUScanning = "No" Or UserMENUScanning = "No" Then
                ScanningDD.Visible = False
            Else
                ScanningDD.Visible = True
            End If

            If MENUHardware = "No" Or UserMENUHardware = "No" Then
                HardwareDD.Visible = False
            Else
                HardwareDD.Visible = True
            End If

            If MENUOther = "No" Or UserMENUOther = "No" Then
                OtherDD.Visible = False
            Else
                OtherDD.Visible = True
            End If
            'Main Menus
            If MENUADMINPARMASTER = "No" Or UserADMINPARMASTER = "No" Then
                ADMINPARMASTERDD.Visible = False
            Else
                ADMINPARMASTERDD.Visible = True
            End If

        End If
    End Sub


End Class