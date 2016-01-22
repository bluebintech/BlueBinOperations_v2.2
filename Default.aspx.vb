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
            LogoImage.ImageUrl = "~/img/" & LogoString

            con.Close()
        End If


        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString()
            Dim MENUDashboard As String
            Dim MENUDashboardSC As String
            Dim MENUDashboardSrc As String
            Dim MENUDashboardOps As String
            Dim MENUQCN As String
            Dim MENUGemba As String
            Dim MENUHardware As String
            Dim MENUScanning As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString


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

                    conmenu.Close()
                End Using
            End Using


            If MENUQCN = "Yes" Then
                qcndiv.Visible = True
            Else
                qcndiv.Visible = False
            End If

            If MENUGemba = "Yes" Then
                gembadiv.Visible = True
            Else
                gembadiv.Visible = False
            End If

            If MENUScanning = "Yes" Then
                scanningdiv.Visible = True
            Else
                scanningdiv.Visible = False
            End If

            If MENUHardware = "Yes" Then
                hardwarediv.Visible = True
            Else
                hardwarediv.Visible = False
            End If
        End If
    End Sub


End Class