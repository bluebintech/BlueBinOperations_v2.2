
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Drawing


Partial Class ScanLines
    Inherits Page

    Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
    Dim Location As String
    Dim Item1 As String
    Dim Qty1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CurrentTimeTB.Text = DateTime.Now.ToString("MM/dd/yyyy")
        ScannerTB.Text = UserLogin
        LocationDD.Focus()

    End Sub


    Public Sub ScanSubmit_Click(sender As Object, e As EventArgs) Handles ScanSubmit.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        Dim NewScanBatchID As String
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("sp_InsertScanBatch")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Location", LocationDD.SelectedValue)
                cmd.Parameters.AddWithValue("@Scanner", ScannerTB.Text)
                cmd.Connection = con
                con.Open()
                'cmd.ExecuteNonQuery()
                NewScanBatchID = Convert.ToString(cmd.ExecuteScalar())
                con.Close()
            End Using
        End Using

        Dim Item1 As String = Item1TB.Text
        Dim Item2 As String = Item2TB.Text
        Dim Item3 As String = Item3TB.Text
        Dim Item4 As String = Item4TB.Text
        Dim Item5 As String = Item5TB.Text
        Dim Item6 As String = Item6TB.Text
        Dim Item7 As String = Item7TB.Text
        Dim Item8 As String = Item8TB.Text
        Dim Item9 As String = Item9TB.Text
        Dim Item10 As String = Item10TB.Text
        Dim Item11 As String = Item11TB.Text
        Dim Item12 As String = Item12TB.Text
        Dim Item13 As String = Item13TB.Text
        Dim Item14 As String = Item14TB.Text
        Dim Item15 As String = Item15TB.Text
        Dim Item16 As String = Item16TB.Text
        Dim Item17 As String = Item17TB.Text
        Dim Item18 As String = Item18TB.Text
        Dim Item19 As String = Item19TB.Text
        Dim Item20 As String = Item20TB.Text
        Dim Item21 As String = Item21TB.Text
        Dim Item22 As String = Item22TB.Text
        Dim Item23 As String = Item23TB.Text
        Dim Item24 As String = Item24TB.Text
        Dim Item25 As String = Item25TB.Text
        Dim Item26 As String = Item26TB.Text
        Dim Item27 As String = Item27TB.Text
        Dim Item28 As String = Item28TB.Text
        Dim Item29 As String = Item29TB.Text
        Dim Item30 As String = Item30TB.Text
        Dim Item31 As String = Item31TB.Text
        Dim Item32 As String = Item32TB.Text
        Dim Item33 As String = Item33TB.Text
        Dim Item34 As String = Item34TB.Text
        Dim Item35 As String = Item35TB.Text
        Dim Item36 As String = Item36TB.Text
        Dim Item37 As String = Item37TB.Text
        Dim Item38 As String = Item38TB.Text
        Dim Item39 As String = Item39TB.Text
        Dim Item40 As String = Item40TB.Text
        Dim Item41 As String = Item41TB.Text
        Dim Item42 As String = Item42TB.Text
        Dim Item43 As String = Item43TB.Text
        Dim Item44 As String = Item44TB.Text
        Dim Item45 As String = Item45TB.Text
        Dim Item46 As String = Item46TB.Text
        Dim Item47 As String = Item47TB.Text
        Dim Item48 As String = Item48TB.Text
        Dim Item49 As String = Item49TB.Text
        Dim Item50 As String = Item50TB.Text
        Dim Item51 As String = Item51TB.Text
        Dim Item52 As String = Item52TB.Text
        Dim Item53 As String = Item53TB.Text
        Dim Item54 As String = Item54TB.Text
        Dim Item55 As String = Item55TB.Text
        Dim Item56 As String = Item56TB.Text
        Dim Item57 As String = Item57TB.Text
        Dim Item58 As String = Item58TB.Text
        Dim Item59 As String = Item59TB.Text
        Dim Item60 As String = Item60TB.Text
        Dim Item61 As String = Item61TB.Text
        Dim Item62 As String = Item62TB.Text
        Dim Item63 As String = Item63TB.Text
        Dim Item64 As String = Item64TB.Text
        Dim Item65 As String = Item65TB.Text
        Dim Item66 As String = Item66TB.Text
        Dim Item67 As String = Item67TB.Text
        Dim Item68 As String = Item68TB.Text
        Dim Item69 As String = Item69TB.Text
        Dim Item70 As String = Item70TB.Text
        Dim Item71 As String = Item71TB.Text
        Dim Item72 As String = Item72TB.Text
        Dim Item73 As String = Item73TB.Text
        Dim Item74 As String = Item74TB.Text
        Dim Item75 As String = Item75TB.Text
        Dim Item76 As String = Item76TB.Text
        Dim Item77 As String = Item77TB.Text
        Dim Item78 As String = Item78TB.Text
        Dim Item79 As String = Item79TB.Text
        Dim Item80 As String = Item80TB.Text
        Dim Item81 As String = Item81TB.Text
        Dim Item82 As String = Item82TB.Text
        Dim Item83 As String = Item83TB.Text
        Dim Item84 As String = Item84TB.Text
        Dim Item85 As String = Item85TB.Text
        Dim Item86 As String = Item86TB.Text
        Dim Item87 As String = Item87TB.Text
        Dim Item88 As String = Item88TB.Text
        Dim Item89 As String = Item89TB.Text
        Dim Item90 As String = Item90TB.Text
        Dim Qty1 As String = Qty1TB.Text
        Dim Qty2 As String = Qty2TB.Text
        Dim Qty3 As String = Qty3TB.Text
        Dim Qty4 As String = Qty4TB.Text
        Dim Qty5 As String = Qty5TB.Text
        Dim Qty6 As String = Qty6TB.Text
        Dim Qty7 As String = Qty7TB.Text
        Dim Qty8 As String = Qty8TB.Text
        Dim Qty9 As String = Qty9TB.Text
        Dim Qty10 As String = Qty10TB.Text
        Dim Qty11 As String = Qty11TB.Text
        Dim Qty12 As String = Qty12TB.Text
        Dim Qty13 As String = Qty13TB.Text
        Dim Qty14 As String = Qty14TB.Text
        Dim Qty15 As String = Qty15TB.Text
        Dim Qty16 As String = Qty16TB.Text
        Dim Qty17 As String = Qty17TB.Text
        Dim Qty18 As String = Qty18TB.Text
        Dim Qty19 As String = Qty19TB.Text
        Dim Qty20 As String = Qty20TB.Text
        Dim Qty21 As String = Qty21TB.Text
        Dim Qty22 As String = Qty22TB.Text
        Dim Qty23 As String = Qty23TB.Text
        Dim Qty24 As String = Qty24TB.Text
        Dim Qty25 As String = Qty25TB.Text
        Dim Qty26 As String = Qty26TB.Text
        Dim Qty27 As String = Qty27TB.Text
        Dim Qty28 As String = Qty28TB.Text
        Dim Qty29 As String = Qty29TB.Text
        Dim Qty30 As String = Qty30TB.Text
        Dim Qty31 As String = Qty31TB.Text
        Dim Qty32 As String = Qty32TB.Text
        Dim Qty33 As String = Qty33TB.Text
        Dim Qty34 As String = Qty34TB.Text
        Dim Qty35 As String = Qty35TB.Text
        Dim Qty36 As String = Qty36TB.Text
        Dim Qty37 As String = Qty37TB.Text
        Dim Qty38 As String = Qty38TB.Text
        Dim Qty39 As String = Qty39TB.Text
        Dim Qty40 As String = Qty40TB.Text
        Dim Qty41 As String = Qty41TB.Text
        Dim Qty42 As String = Qty42TB.Text
        Dim Qty43 As String = Qty43TB.Text
        Dim Qty44 As String = Qty44TB.Text
        Dim Qty45 As String = Qty45TB.Text
        Dim Qty46 As String = Qty46TB.Text
        Dim Qty47 As String = Qty47TB.Text
        Dim Qty48 As String = Qty48TB.Text
        Dim Qty49 As String = Qty49TB.Text
        Dim Qty50 As String = Qty50TB.Text
        Dim Qty51 As String = Qty51TB.Text
        Dim Qty52 As String = Qty52TB.Text
        Dim Qty53 As String = Qty53TB.Text
        Dim Qty54 As String = Qty54TB.Text
        Dim Qty55 As String = Qty55TB.Text
        Dim Qty56 As String = Qty56TB.Text
        Dim Qty57 As String = Qty57TB.Text
        Dim Qty58 As String = Qty58TB.Text
        Dim Qty59 As String = Qty59TB.Text
        Dim Qty60 As String = Qty60TB.Text
        Dim Qty61 As String = Qty61TB.Text
        Dim Qty62 As String = Qty62TB.Text
        Dim Qty63 As String = Qty63TB.Text
        Dim Qty64 As String = Qty64TB.Text
        Dim Qty65 As String = Qty65TB.Text
        Dim Qty66 As String = Qty66TB.Text
        Dim Qty67 As String = Qty67TB.Text
        Dim Qty68 As String = Qty68TB.Text
        Dim Qty69 As String = Qty69TB.Text
        Dim Qty70 As String = Qty70TB.Text
        Dim Qty71 As String = Qty71TB.Text
        Dim Qty72 As String = Qty72TB.Text
        Dim Qty73 As String = Qty73TB.Text
        Dim Qty74 As String = Qty74TB.Text
        Dim Qty75 As String = Qty75TB.Text
        Dim Qty76 As String = Qty76TB.Text
        Dim Qty77 As String = Qty77TB.Text
        Dim Qty78 As String = Qty78TB.Text
        Dim Qty79 As String = Qty79TB.Text
        Dim Qty80 As String = Qty80TB.Text
        Dim Qty81 As String = Qty81TB.Text
        Dim Qty82 As String = Qty82TB.Text
        Dim Qty83 As String = Qty83TB.Text
        Dim Qty84 As String = Qty84TB.Text
        Dim Qty85 As String = Qty85TB.Text
        Dim Qty86 As String = Qty86TB.Text
        Dim Qty87 As String = Qty87TB.Text
        Dim Qty88 As String = Qty88TB.Text
        Dim Qty89 As String = Qty89TB.Text
        Dim Qty90 As String = Qty90TB.Text



        Dim con2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim cmd3 As New SqlCommand
        Dim cmd4 As New SqlCommand
        Dim cmd5 As New SqlCommand
        Dim cmd6 As New SqlCommand
        Dim cmd7 As New SqlCommand
        Dim cmd8 As New SqlCommand
        Dim cmd9 As New SqlCommand
        Dim cmd10 As New SqlCommand
        Dim cmd11 As New SqlCommand
        Dim cmd12 As New SqlCommand
        Dim cmd13 As New SqlCommand
        Dim cmd14 As New SqlCommand
        Dim cmd15 As New SqlCommand
        Dim cmd16 As New SqlCommand
        Dim cmd17 As New SqlCommand
        Dim cmd18 As New SqlCommand
        Dim cmd19 As New SqlCommand
        Dim cmd20 As New SqlCommand
        Dim cmd21 As New SqlCommand
        Dim cmd22 As New SqlCommand
        Dim cmd23 As New SqlCommand
        Dim cmd24 As New SqlCommand
        Dim cmd25 As New SqlCommand
        Dim cmd26 As New SqlCommand
        Dim cmd27 As New SqlCommand
        Dim cmd28 As New SqlCommand
        Dim cmd29 As New SqlCommand
        Dim cmd30 As New SqlCommand
        Dim cmd31 As New SqlCommand
        Dim cmd32 As New SqlCommand
        Dim cmd33 As New SqlCommand
        Dim cmd34 As New SqlCommand
        Dim cmd35 As New SqlCommand
        Dim cmd36 As New SqlCommand
        Dim cmd37 As New SqlCommand
        Dim cmd38 As New SqlCommand
        Dim cmd39 As New SqlCommand
        Dim cmd40 As New SqlCommand
        Dim cmd41 As New SqlCommand
        Dim cmd42 As New SqlCommand
        Dim cmd43 As New SqlCommand
        Dim cmd44 As New SqlCommand
        Dim cmd45 As New SqlCommand
        Dim cmd46 As New SqlCommand
        Dim cmd47 As New SqlCommand
        Dim cmd48 As New SqlCommand
        Dim cmd49 As New SqlCommand
        Dim cmd50 As New SqlCommand
        Dim cmd51 As New SqlCommand
        Dim cmd52 As New SqlCommand
        Dim cmd53 As New SqlCommand
        Dim cmd54 As New SqlCommand
        Dim cmd55 As New SqlCommand
        Dim cmd56 As New SqlCommand
        Dim cmd57 As New SqlCommand
        Dim cmd58 As New SqlCommand
        Dim cmd59 As New SqlCommand
        Dim cmd60 As New SqlCommand
        Dim cmd61 As New SqlCommand
        Dim cmd62 As New SqlCommand
        Dim cmd63 As New SqlCommand
        Dim cmd64 As New SqlCommand
        Dim cmd65 As New SqlCommand
        Dim cmd66 As New SqlCommand
        Dim cmd67 As New SqlCommand
        Dim cmd68 As New SqlCommand
        Dim cmd69 As New SqlCommand
        Dim cmd70 As New SqlCommand
        Dim cmd71 As New SqlCommand
        Dim cmd72 As New SqlCommand
        Dim cmd73 As New SqlCommand
        Dim cmd74 As New SqlCommand
        Dim cmd75 As New SqlCommand
        Dim cmd76 As New SqlCommand
        Dim cmd77 As New SqlCommand
        Dim cmd78 As New SqlCommand
        Dim cmd79 As New SqlCommand
        Dim cmd80 As New SqlCommand
        Dim cmd81 As New SqlCommand
        Dim cmd82 As New SqlCommand
        Dim cmd83 As New SqlCommand
        Dim cmd84 As New SqlCommand
        Dim cmd85 As New SqlCommand
        Dim cmd86 As New SqlCommand
        Dim cmd87 As New SqlCommand
        Dim cmd88 As New SqlCommand
        Dim cmd89 As New SqlCommand
        Dim cmd90 As New SqlCommand


        cmd1.Connection = con2
        cmd2.Connection = con2
        cmd3.Connection = con2
        cmd4.Connection = con2
        cmd5.Connection = con2
        cmd6.Connection = con2
        cmd7.Connection = con2
        cmd8.Connection = con2
        cmd9.Connection = con2
        cmd10.Connection = con2
        cmd11.Connection = con2
        cmd12.Connection = con2
        cmd13.Connection = con2
        cmd14.Connection = con2
        cmd15.Connection = con2
        cmd16.Connection = con2
        cmd17.Connection = con2
        cmd18.Connection = con2
        cmd19.Connection = con2
        cmd20.Connection = con2
        cmd21.Connection = con2
        cmd22.Connection = con2
        cmd23.Connection = con2
        cmd24.Connection = con2
        cmd25.Connection = con2
        cmd26.Connection = con2
        cmd27.Connection = con2
        cmd28.Connection = con2
        cmd29.Connection = con2
        cmd30.Connection = con2
        cmd31.Connection = con2
        cmd32.Connection = con2
        cmd33.Connection = con2
        cmd34.Connection = con2
        cmd35.Connection = con2
        cmd36.Connection = con2
        cmd37.Connection = con2
        cmd38.Connection = con2
        cmd39.Connection = con2
        cmd40.Connection = con2
        cmd41.Connection = con2
        cmd42.Connection = con2
        cmd43.Connection = con2
        cmd44.Connection = con2
        cmd45.Connection = con2
        cmd46.Connection = con2
        cmd47.Connection = con2
        cmd48.Connection = con2
        cmd49.Connection = con2
        cmd50.Connection = con2
        cmd51.Connection = con2
        cmd52.Connection = con2
        cmd53.Connection = con2
        cmd54.Connection = con2
        cmd55.Connection = con2
        cmd56.Connection = con2
        cmd57.Connection = con2
        cmd58.Connection = con2
        cmd59.Connection = con2
        cmd60.Connection = con2
        cmd61.Connection = con2
        cmd62.Connection = con2
        cmd63.Connection = con2
        cmd64.Connection = con2
        cmd65.Connection = con2
        cmd66.Connection = con2
        cmd67.Connection = con2
        cmd68.Connection = con2
        cmd69.Connection = con2
        cmd70.Connection = con2
        cmd71.Connection = con2
        cmd72.Connection = con2
        cmd73.Connection = con2
        cmd74.Connection = con2
        cmd75.Connection = con2
        cmd76.Connection = con2
        cmd77.Connection = con2
        cmd78.Connection = con2
        cmd79.Connection = con2
        cmd80.Connection = con2
        cmd81.Connection = con2
        cmd82.Connection = con2
        cmd83.Connection = con2
        cmd84.Connection = con2
        cmd85.Connection = con2
        cmd86.Connection = con2
        cmd87.Connection = con2
        cmd88.Connection = con2
        cmd89.Connection = con2
        cmd90.Connection = con2

        con2.Open()

        Dim Error1 As Integer

        If Len(Item1) > 0 Then
            cmd1.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item1 & "','" & Qty1 & "','1'"
            'cmd1.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd1.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item1TB.BackColor = Color.Red
                    Item1TB.Text = "ItemID is Not valid!"
                    Qty1TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item2) > 0 Then
            cmd2.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item2 & "','" & Qty2 & "','2'"
            'cmd2.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd2.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item2TB.BackColor = Color.Red
                    Item2TB.Text = "ItemID is Not valid!"
                    Qty2TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item3) > 0 Then
            cmd3.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item3 & "','" & Qty3 & "','3'"
            'cmd3.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd3.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item3TB.BackColor = Color.Red
                    Item3TB.Text = "ItemID is Not valid!"
                    Qty3TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item4) > 0 Then
            cmd4.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item4 & "','" & Qty4 & "','4'"
            'cmd4.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd4.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item4TB.BackColor = Color.Red
                    Item4TB.Text = "ItemID is Not valid!"
                    Qty4TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item5) > 0 Then
            cmd5.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item5 & "','" & Qty5 & "','5'"
            'cmd5.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd5.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item5TB.BackColor = Color.Red
                    Item5TB.Text = "ItemID is Not valid!"
                    Qty5TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item6) > 0 Then
            cmd6.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item6 & "','" & Qty6 & "','6'"
            'cmd6.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd6.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item6TB.BackColor = Color.Red
                    Item6TB.Text = "ItemID is Not valid!"
                    Qty6TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item7) > 0 Then
            cmd7.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item7 & "','" & Qty7 & "','7'"
            'cmd7.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd7.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item7TB.BackColor = Color.Red
                    Item7TB.Text = "ItemID is Not valid!"
                    Qty7TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item8) > 0 Then
            cmd8.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item8 & "','" & Qty8 & "','8'"
            'cmd8.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd8.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item8TB.BackColor = Color.Red
                    Item8TB.Text = "ItemID is Not valid!"
                    Qty8TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item9) > 0 Then
            cmd9.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item9 & "','" & Qty9 & "','9'"
            'cmd9.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd9.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item9TB.BackColor = Color.Red
                    Item9TB.Text = "ItemID is Not valid!"
                    Qty9TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item10) > 0 Then
            cmd10.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item10 & "','" & Qty10 & "','10'"
            'cmd10.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd10.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item10TB.BackColor = Color.Red
                    Item10TB.Text = "ItemID is Not valid!"
                    Qty10TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item11) > 0 Then
            cmd11.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item11 & "','" & Qty11 & "','11'"
            'cmd11.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd11.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item11TB.BackColor = Color.Red
                    Item11TB.Text = "ItemID is Not valid!"
                    Qty11TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item12) > 0 Then
            cmd12.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item12 & "','" & Qty12 & "','12'"
            'cmd12.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd12.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item12TB.BackColor = Color.Red
                    Item12TB.Text = "ItemID is Not valid!"
                    Qty12TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item13) > 0 Then
            cmd13.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item13 & "','" & Qty13 & "','13'"
            'cmd13.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd13.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item13TB.BackColor = Color.Red
                    Item13TB.Text = "ItemID is Not valid!"
                    Qty13TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item14) > 0 Then
            cmd14.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item14 & "','" & Qty14 & "','14'"
            'cmd14.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd14.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item14TB.BackColor = Color.Red
                    Item14TB.Text = "ItemID is Not valid!"
                    Qty14TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item15) > 0 Then
            cmd15.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item15 & "','" & Qty15 & "','15'"
            'cmd15.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd15.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item15TB.BackColor = Color.Red
                    Item15TB.Text = "ItemID is Not valid!"
                    Qty15TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item16) > 0 Then
            cmd16.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item16 & "','" & Qty16 & "','16'"
            'cmd16.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd16.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item16TB.BackColor = Color.Red
                    Item16TB.Text = "ItemID is Not valid!"
                    Qty16TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item17) > 0 Then
            cmd17.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item17 & "','" & Qty17 & "','17'"
            'cmd17.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd17.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item17TB.BackColor = Color.Red
                    Item17TB.Text = "ItemID is Not valid!"
                    Qty17TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item18) > 0 Then
            cmd18.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item18 & "','" & Qty18 & "','18'"
            'cmd18.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd18.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item18TB.BackColor = Color.Red
                    Item18TB.Text = "ItemID is Not valid!"
                    Qty18TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item19) > 0 Then
            cmd19.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item19 & "','" & Qty19 & "','19'"
            'cmd19.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd19.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item19TB.BackColor = Color.Red
                    Item19TB.Text = "ItemID is Not valid!"
                    Qty19TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item20) > 0 Then
            cmd20.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item20 & "','" & Qty20 & "','20'"
            'cmd20.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd20.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item20TB.BackColor = Color.Red
                    Item20TB.Text = "ItemID is Not valid!"
                    Qty20TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item21) > 0 Then
            cmd21.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item21 & "','" & Qty21 & "','21'"
            'cmd21.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd21.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item21TB.BackColor = Color.Red
                    Item21TB.Text = "ItemID is Not valid!"
                    Qty21TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item22) > 0 Then
            cmd22.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item22 & "','" & Qty22 & "','22'"
            'cmd22.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd22.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item22TB.BackColor = Color.Red
                    Item22TB.Text = "ItemID is Not valid!"
                    Qty22TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item23) > 0 Then
            cmd23.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item23 & "','" & Qty23 & "','23'"
            'cmd23.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd23.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item23TB.BackColor = Color.Red
                    Item23TB.Text = "ItemID is Not valid!"
                    Qty23TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item24) > 0 Then
            cmd24.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item24 & "','" & Qty24 & "','24'"
            'cmd24.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd24.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item24TB.BackColor = Color.Red
                    Item24TB.Text = "ItemID is Not valid!"
                    Qty24TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item25) > 0 Then
            cmd25.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item25 & "','" & Qty25 & "','25'"
            'cmd25.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd25.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item25TB.BackColor = Color.Red
                    Item25TB.Text = "ItemID is Not valid!"
                    Qty25TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item26) > 0 Then
            cmd26.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item26 & "','" & Qty26 & "','26'"
            'cmd26.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd26.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item26TB.BackColor = Color.Red
                    Item26TB.Text = "ItemID is Not valid!"
                    Qty26TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item27) > 0 Then
            cmd27.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item27 & "','" & Qty27 & "','27'"
            'cmd27.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd27.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item27TB.BackColor = Color.Red
                    Item27TB.Text = "ItemID is Not valid!"
                    Qty27TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item28) > 0 Then
            cmd28.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item28 & "','" & Qty28 & "','28'"
            'cmd28.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd28.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item28TB.BackColor = Color.Red
                    Item28TB.Text = "ItemID is Not valid!"
                    Qty28TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item29) > 0 Then
            cmd29.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item29 & "','" & Qty29 & "','29'"
            'cmd29.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd29.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item29TB.BackColor = Color.Red
                    Item29TB.Text = "ItemID is Not valid!"
                    Qty29TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item30) > 0 Then
            cmd30.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item30 & "','" & Qty30 & "','30'"
            'cmd30.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd30.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item30TB.BackColor = Color.Red
                    Item30TB.Text = "ItemID is Not valid!"
                    Qty30TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item31) > 0 Then
            cmd31.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item31 & "','" & Qty31 & "','31'"
            'cmd31.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd31.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item31TB.BackColor = Color.Red
                    Item31TB.Text = "ItemID is Not valid!"
                    Qty31TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item32) > 0 Then
            cmd32.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item32 & "','" & Qty32 & "','32'"
            'cmd32.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd32.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item32TB.BackColor = Color.Red
                    Item32TB.Text = "ItemID is Not valid!"
                    Qty32TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item33) > 0 Then
            cmd33.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item33 & "','" & Qty33 & "','33'"
            'cmd33.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd33.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item33TB.BackColor = Color.Red
                    Item33TB.Text = "ItemID is Not valid!"
                    Qty33TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item34) > 0 Then
            cmd34.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item34 & "','" & Qty34 & "','34'"
            'cmd34.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd34.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item34TB.BackColor = Color.Red
                    Item34TB.Text = "ItemID is Not valid!"
                    Qty34TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item35) > 0 Then
            cmd35.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item35 & "','" & Qty35 & "','35'"
            'cmd35.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd35.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item35TB.BackColor = Color.Red
                    Item35TB.Text = "ItemID is Not valid!"
                    Qty35TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item36) > 0 Then
            cmd36.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item36 & "','" & Qty36 & "','36'"
            'cmd36.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd36.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item36TB.BackColor = Color.Red
                    Item36TB.Text = "ItemID is Not valid!"
                    Qty36TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item37) > 0 Then
            cmd37.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item37 & "','" & Qty37 & "','37'"
            'cmd37.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd37.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item37TB.BackColor = Color.Red
                    Item37TB.Text = "ItemID is Not valid!"
                    Qty37TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item38) > 0 Then
            cmd38.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item38 & "','" & Qty38 & "','38'"
            'cmd38.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd38.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item38TB.BackColor = Color.Red
                    Item38TB.Text = "ItemID is Not valid!"
                    Qty38TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item39) > 0 Then
            cmd39.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item39 & "','" & Qty39 & "','39'"
            'cmd39.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd39.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item39TB.BackColor = Color.Red
                    Item39TB.Text = "ItemID is Not valid!"
                    Qty39TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item40) > 0 Then
            cmd40.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item40 & "','" & Qty40 & "','40'"
            'cmd40.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd40.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item40TB.BackColor = Color.Red
                    Item40TB.Text = "ItemID is Not valid!"
                    Qty40TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item41) > 0 Then
            cmd41.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item41 & "','" & Qty41 & "','41'"
            'cmd41.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd41.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item41TB.BackColor = Color.Red
                    Item41TB.Text = "ItemID is Not valid!"
                    Qty41TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item42) > 0 Then
            cmd42.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item42 & "','" & Qty42 & "','42'"
            'cmd42.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd42.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item42TB.BackColor = Color.Red
                    Item42TB.Text = "ItemID is Not valid!"
                    Qty42TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item43) > 0 Then
            cmd43.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item43 & "','" & Qty43 & "','43'"
            'cmd43.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd43.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item43TB.BackColor = Color.Red
                    Item43TB.Text = "ItemID is Not valid!"
                    Qty43TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item44) > 0 Then
            cmd44.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item44 & "','" & Qty44 & "','44'"
            'cmd44.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd44.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item44TB.BackColor = Color.Red
                    Item44TB.Text = "ItemID is Not valid!"
                    Qty44TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item45) > 0 Then
            cmd45.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item45 & "','" & Qty45 & "','45'"
            'cmd45.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd45.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item45TB.BackColor = Color.Red
                    Item45TB.Text = "ItemID is Not valid!"
                    Qty45TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item46) > 0 Then
            cmd46.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item46 & "','" & Qty46 & "','46'"
            'cmd46.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd46.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item46TB.BackColor = Color.Red
                    Item46TB.Text = "ItemID is Not valid!"
                    Qty46TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item47) > 0 Then
            cmd47.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item47 & "','" & Qty47 & "','47'"
            'cmd47.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd47.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item47TB.BackColor = Color.Red
                    Item47TB.Text = "ItemID is Not valid!"
                    Qty47TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item48) > 0 Then
            cmd48.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item48 & "','" & Qty48 & "','48'"
            'cmd48.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd48.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item48TB.BackColor = Color.Red
                    Item48TB.Text = "ItemID is Not valid!"
                    Qty48TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item49) > 0 Then
            cmd49.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item49 & "','" & Qty49 & "','49'"
            'cmd49.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd49.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item49TB.BackColor = Color.Red
                    Item49TB.Text = "ItemID is Not valid!"
                    Qty49TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item50) > 0 Then
            cmd50.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item50 & "','" & Qty50 & "','50'"
            'cmd50.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd50.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item50TB.BackColor = Color.Red
                    Item50TB.Text = "ItemID is Not valid!"
                    Qty50TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item51) > 0 Then
            cmd51.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item51 & "','" & Qty51 & "','51'"
            'cmd51.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd51.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item51TB.BackColor = Color.Red
                    Item51TB.Text = "ItemID is Not valid!"
                    Qty51TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item52) > 0 Then
            cmd52.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item52 & "','" & Qty52 & "','52'"
            'cmd52.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd52.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item52TB.BackColor = Color.Red
                    Item52TB.Text = "ItemID is Not valid!"
                    Qty52TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item53) > 0 Then
            cmd53.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item53 & "','" & Qty53 & "','53'"
            'cmd53.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd53.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item53TB.BackColor = Color.Red
                    Item53TB.Text = "ItemID is Not valid!"
                    Qty53TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item55) > 0 Then
            cmd55.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item55 & "','" & Qty55 & "','55'"
            'cmd55.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd55.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item55TB.BackColor = Color.Red
                    Item55TB.Text = "ItemID is Not valid!"
                    Qty55TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item55) > 0 Then
            cmd55.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item55 & "','" & Qty55 & "','55'"
            'cmd55.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd55.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item55TB.BackColor = Color.Red
                    Item55TB.Text = "ItemID is Not valid!"
                    Qty55TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item56) > 0 Then
            cmd56.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item56 & "','" & Qty56 & "','56'"
            'cmd56.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd56.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item56TB.BackColor = Color.Red
                    Item56TB.Text = "ItemID is Not valid!"
                    Qty56TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item57) > 0 Then
            cmd57.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item57 & "','" & Qty57 & "','57'"
            'cmd57.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd57.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item57TB.BackColor = Color.Red
                    Item57TB.Text = "ItemID is Not valid!"
                    Qty57TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item58) > 0 Then
            cmd58.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item58 & "','" & Qty58 & "','58'"
            'cmd58.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd58.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item58TB.BackColor = Color.Red
                    Item58TB.Text = "ItemID is Not valid!"
                    Qty58TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item59) > 0 Then
            cmd59.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item59 & "','" & Qty59 & "','59'"
            'cmd59.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd59.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item59TB.BackColor = Color.Red
                    Item59TB.Text = "ItemID is Not valid!"
                    Qty59TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item60) > 0 Then
            cmd60.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item60 & "','" & Qty60 & "','60'"
            'cmd60.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd60.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item60TB.BackColor = Color.Red
                    Item60TB.Text = "ItemID is Not valid!"
                    Qty60TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item61) > 0 Then
            cmd61.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item61 & "','" & Qty61 & "','61'"
            'cmd61.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd61.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item61TB.BackColor = Color.Red
                    Item61TB.Text = "ItemID is Not valid!"
                    Qty61TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item62) > 0 Then
            cmd62.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item62 & "','" & Qty62 & "','62'"
            'cmd62.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd62.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item62TB.BackColor = Color.Red
                    Item62TB.Text = "ItemID is Not valid!"
                    Qty62TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item63) > 0 Then
            cmd63.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item63 & "','" & Qty63 & "','63'"
            'cmd63.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd63.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item63TB.BackColor = Color.Red
                    Item63TB.Text = "ItemID is Not valid!"
                    Qty63TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item65) > 0 Then
            cmd65.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item65 & "','" & Qty65 & "','65'"
            'cmd65.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd65.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item65TB.BackColor = Color.Red
                    Item65TB.Text = "ItemID is Not valid!"
                    Qty65TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item65) > 0 Then
            cmd65.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item65 & "','" & Qty65 & "','65'"
            'cmd65.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd65.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item65TB.BackColor = Color.Red
                    Item65TB.Text = "ItemID is Not valid!"
                    Qty65TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item66) > 0 Then
            cmd66.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item66 & "','" & Qty66 & "','66'"
            'cmd66.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd66.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item66TB.BackColor = Color.Red
                    Item66TB.Text = "ItemID is Not valid!"
                    Qty66TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item67) > 0 Then
            cmd67.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item67 & "','" & Qty67 & "','67'"
            'cmd67.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd67.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item67TB.BackColor = Color.Red
                    Item67TB.Text = "ItemID is Not valid!"
                    Qty67TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item68) > 0 Then
            cmd68.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item68 & "','" & Qty68 & "','68'"
            'cmd68.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd68.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item68TB.BackColor = Color.Red
                    Item68TB.Text = "ItemID is Not valid!"
                    Qty68TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item69) > 0 Then
            cmd69.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item69 & "','" & Qty69 & "','69'"
            'cmd69.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd69.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item69TB.BackColor = Color.Red
                    Item69TB.Text = "ItemID is Not valid!"
                    Qty69TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item70) > 0 Then
            cmd70.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item70 & "','" & Qty70 & "','70'"
            'cmd70.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd70.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item70TB.BackColor = Color.Red
                    Item70TB.Text = "ItemID is Not valid!"
                    Qty70TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item71) > 0 Then
            cmd71.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item71 & "','" & Qty71 & "','71'"
            'cmd71.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd71.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item71TB.BackColor = Color.Red
                    Item71TB.Text = "ItemID is Not valid!"
                    Qty71TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item72) > 0 Then
            cmd72.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item72 & "','" & Qty72 & "','72'"
            'cmd72.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd72.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item72TB.BackColor = Color.Red
                    Item72TB.Text = "ItemID is Not valid!"
                    Qty72TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item73) > 0 Then
            cmd73.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item73 & "','" & Qty73 & "','73'"
            'cmd73.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd73.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item73TB.BackColor = Color.Red
                    Item73TB.Text = "ItemID is Not valid!"
                    Qty73TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item75) > 0 Then
            cmd75.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item75 & "','" & Qty75 & "','75'"
            'cmd75.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd75.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item75TB.BackColor = Color.Red
                    Item75TB.Text = "ItemID is Not valid!"
                    Qty75TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item75) > 0 Then
            cmd75.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item75 & "','" & Qty75 & "','75'"
            'cmd75.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd75.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item75TB.BackColor = Color.Red
                    Item75TB.Text = "ItemID is Not valid!"
                    Qty75TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item76) > 0 Then
            cmd76.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item76 & "','" & Qty76 & "','76'"
            'cmd76.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd76.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item76TB.BackColor = Color.Red
                    Item76TB.Text = "ItemID is Not valid!"
                    Qty76TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item77) > 0 Then
            cmd77.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item77 & "','" & Qty77 & "','77'"
            'cmd77.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd77.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item77TB.BackColor = Color.Red
                    Item77TB.Text = "ItemID is Not valid!"
                    Qty77TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item78) > 0 Then
            cmd78.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item78 & "','" & Qty78 & "','78'"
            'cmd78.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd78.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item78TB.BackColor = Color.Red
                    Item78TB.Text = "ItemID is Not valid!"
                    Qty78TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item79) > 0 Then
            cmd79.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item79 & "','" & Qty79 & "','79'"
            'cmd79.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd79.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item79TB.BackColor = Color.Red
                    Item79TB.Text = "ItemID is Not valid!"
                    Qty79TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item80) > 0 Then
            cmd80.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item80 & "','" & Qty80 & "','80'"
            'cmd80.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd80.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item80TB.BackColor = Color.Red
                    Item80TB.Text = "ItemID is Not valid!"
                    Qty80TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item81) > 0 Then
            cmd81.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item81 & "','" & Qty81 & "','81'"
            'cmd81.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd81.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item81TB.BackColor = Color.Red
                    Item81TB.Text = "ItemID is Not valid!"
                    Qty81TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item82) > 0 Then
            cmd82.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item82 & "','" & Qty82 & "','82'"
            'cmd82.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd82.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item82TB.BackColor = Color.Red
                    Item82TB.Text = "ItemID is Not valid!"
                    Qty82TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item83) > 0 Then
            cmd83.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item83 & "','" & Qty83 & "','83'"
            'cmd83.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd83.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item83TB.BackColor = Color.Red
                    Item83TB.Text = "ItemID is Not valid!"
                    Qty83TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item85) > 0 Then
            cmd85.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item85 & "','" & Qty85 & "','85'"
            'cmd85.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd85.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item85TB.BackColor = Color.Red
                    Item85TB.Text = "ItemID is Not valid!"
                    Qty85TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item85) > 0 Then
            cmd85.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item85 & "','" & Qty85 & "','85'"
            'cmd85.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd85.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item85TB.BackColor = Color.Red
                    Item85TB.Text = "ItemID is Not valid!"
                    Qty85TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item86) > 0 Then
            cmd86.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item86 & "','" & Qty86 & "','86'"
            'cmd86.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd86.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item86TB.BackColor = Color.Red
                    Item86TB.Text = "ItemID is Not valid!"
                    Qty86TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item87) > 0 Then
            cmd87.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item87 & "','" & Qty87 & "','87'"
            'cmd87.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd87.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item87TB.BackColor = Color.Red
                    Item87TB.Text = "ItemID is Not valid!"
                    Qty87TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item88) > 0 Then
            cmd88.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item88 & "','" & Qty88 & "','88'"
            'cmd88.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd88.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item88TB.BackColor = Color.Red
                    Item88TB.Text = "ItemID is Not valid!"
                    Qty88TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item89) > 0 Then
            cmd89.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item89 & "','" & Qty89 & "','89'"
            'cmd89.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd89.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item89TB.BackColor = Color.Red
                    Item89TB.Text = "ItemID is Not valid!"
                    Qty89TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If
        If Len(Item90) > 0 Then
            cmd90.CommandText = "exec sp_InsertScanLine '" & NewScanBatchID & "','" & Item90 & "','" & Qty90 & "','90'"
            'cmd90.ExecuteNonQuery()
            Error1 = Convert.ToInt32(cmd90.ExecuteScalar())
            Select Case Error1
                Case -1
                    Item90TB.BackColor = Color.Red
                    Item90TB.Text = "ItemID is Not valid!"
                    Qty90TB.Text = ""
                    GoTo LastLine
                    Exit Select
            End Select
        End If

        'MsgBox("New Gemba Saved For With score = " & TotalScore & "")
        Response.Redirect("~/Scans")

LastLine:
        con2.Close()

    End Sub


    Protected Sub ScanningCancel_Click(sender As Object, e As EventArgs) Handles ScanningCancel.Click
        Response.Redirect("~/Scans")
    End Sub



End Class