Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            'Comment
            'Comment
            Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            con.Open()
            Dim da As New SqlDataAdapter("exec sp_SelectLogoImage", con)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim LogoString As String = dt.Rows(0)("ConfigValue").ToString()
            'LogoImage.ImageUrl = "~/img/" & LogoString
            LogoImage.ImageUrl = "/BlueBinLogos/" & LogoString

            con.Close()

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Using conUser As New SqlConnection(constr)
                Using cmdUser As New SqlCommand("sp_SelectUserName")
                    cmdUser.CommandType = CommandType.StoredProcedure
                    cmdUser.Connection = conUser
                    conUser.Open()
                    cmdUser.Parameters.AddWithValue("@UserLogin", UserLogin)
                    UserNameLabel.Text = Convert.ToString(cmdUser.ExecuteScalar())
                    conUser.Close()
                End Using
            End Using
            Using conFacilityName As New SqlConnection(constr)
                Using cmdFacilityName As New SqlCommand("sp_SelectFacilityName")
                    cmdFacilityName.CommandType = CommandType.StoredProcedure
                    cmdFacilityName.Connection = conFacilityName
                    conFacilityName.Open()
                    FacilityNameLabel.Text = Convert.ToString(cmdFacilityName.ExecuteScalar())
                    conFacilityName.Close()
                End Using
            End Using
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

            If MENUQCN = "No" Or UserMENUQCN = "No" Then
                qcndiv.Visible = False
            Else
                qcndiv.Visible = True
            End If

            If MENUGemba = "No" Or UserMENUGemba = "No" Then
                gembadiv.Visible = False
            Else
                gembadiv.Visible = True
            End If

            If MENUScanning = "No" Or UserMENUScanning = "No" Then
                scanningdiv.Visible = False
            Else
                scanningdiv.Visible = True
            End If

            If MENUHardware = "No" Or UserMENUHardware = "No" Then
                hardwarediv.Visible = False
            Else
                hardwarediv.Visible = True
            End If

            If MENUDashboard = "No" Or UserMENUDashboard = "No" Then
                dashboarddiv.Visible = False
            Else
                dashboarddiv.Visible = True
            End If

        End If
    End Sub


End Class