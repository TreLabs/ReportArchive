
Imports System
Imports System.IO
Imports System.Collections

Public Class Form1


    Private Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click

        'Based on checkboxes, process environment files
        If CB_UAT.Checked Then Call Process_Files(UAT_Spot, UAT_Base, OutBoxUAT)
        If CB_Stage.Checked Then Call Process_Files(Stage_Spot, Stage_Base, OutBoxStage)
        If CB_Prod.Checked Then Call Process_Files(Production_Spot, Production_Base, OutBoxProd)

    End Sub
    '
    'This is a quick utility to distribute reports into their archive folders.
    'It works on 3 environments, controllable from the main window. 
    'It moves the file, decrypts it in place, and unTars it into a subdir.  All intermediate files are kept.
    '
    'Reuires Gnupg For GPG And 7Z For untar.  Keys must be installed For decrypt To work.  
    'Also relies on ShareFile Sync to map local folders out to ShareFile Cloud.
    '
    'on the Server, c:\Users\Bob\.\rep mm-dd-yyyy will move all files for the given date to the landing area on local C:
    'This program works from that landing area.
    '
    Dim Dupe_Spot As String = "\Dupes\"
    Dim UAT_Spot As String = "C:\Relay\UAT\"
    Dim Stage_Spot As String = "c:\Relay\Stage\"
    Dim Production_Spot As String = "C:\Relay\Production\"
    Dim UAT_Base As String = "C:\Reports\Shared~1\UAT\Received\"
    Dim Stage_Base As String = "C:\Reports\Shared~1\Stage\Received\"
    Dim Production_Base As String = "C:\Reports\Shared~1\Production\Received\"


    Public Sub Process_Files(ByRef Source_Path As String, ByRef Dest_Path As String, LB As ListBox)

        'Call withe the full path of files ot be examined and the landing area where type folders are

        Dim di As New DirectoryInfo(Source_Path)
        Dim fileset As FileInfo() = di.GetFiles()
        Dim F As IO.FileInfo

        Dim wname As String

        If Directory.Exists(Source_Path) Then

            LB.Items.Add("Files Found: " & CStr(fileset.Count) & vbCrLf)

            For Each F In fileset

                'Decide on correct destination folder - to be appended to "base" name
                'New file type requires change to select stmt
                wname = F.Name.Substring(0, 7).ToUpper

                Select Case wname
                    Case "ACCUM_E"
                        Call MoveIt(F, Dest_Path & "Accum_Extract\", LB)
                    Case "ACCUM_L"
                        Call MoveIt(F, Dest_Path & "Accum_Load\", LB)
                    Case "AUTH_LO"
                        Call MoveIt(F, Dest_Path & "Auth_Load\", LB)
                    Case "CARD_PR"
                        Call MoveIt(F, Dest_Path & "Card_Prod\", LB)
                    Case "CLAIMWA"
                        Call MoveIt(F, Dest_Path & "ClaimWarehouse\", LB)
                    Case "CLAIM_C"
                        Call MoveIt(F, Dest_Path & "Claim_Conv_Load\", LB)
                    Case "COMPOUN"
                        Call MoveIt(F, Dest_Path & "Compound_Claim_Whse\", LB)
                    Case "ELIG_PR"
                        Call MoveIt(F, Dest_Path & "Pre_Eligibility\", LB)
                    Case "ELIG_20"
                        Call MoveIt(F, Dest_Path & "Eligibility\", LB)
                    Case "ELIG_EX"
                        Call MoveIt(F, Dest_Path & "Elig_Extract\", LB)
                    Case "EXCEP_2"
                        Call MoveIt(F, Dest_Path & "Exception\", LB)
                    Case "GPI_MAC"
                        Call MoveIt(F, Dest_Path & "GPI_MAC\", LB)
                    Case "GROUP_L"
                        Call MoveIt(F, Dest_Path & "Group_Load\", LB)
                    Case "NDC_MAC"
                        Call MoveIt(F, Dest_Path & "NDC_MAC\", LB)
                    Case "REVERSA"
                        Call MoveIt(F, Dest_Path & "Reversals\", LB)
                    Case "RX_NET_"
                        Call MoveIt(F, Dest_Path & "RxNetwork\", LB)
                    Case Else
                        MsgBox("New File Type " & wname)
                        LB.Items.Add("New Type " & wname)
                End Select
            Next
        Else
            MsgBox("Dir Not found" & Source_Path)
            LB.Items.Add("Dir Not found " & Source_Path)
        End If

    End Sub

    Public Sub MoveIt(F As FileInfo, Target_Folder As String, LB As ListBox)


        Dim cmd As String
        Dim cmd2 As String
        Dim x As Int16
        Dim q As String = " """

        If File.Exists(Target_Folder & F.Name) Then
            'MsgBox("File Exists " & F.Name)

            If File.Exists(F.DirectoryName & Dupe_Spot & F.Name) Then
                LB.Items.Add("Already Exists " & Target_Folder & F.Name & " Already in Dupes")
                F.Delete()
            Else
                F.MoveTo(F.DirectoryName & Dupe_Spot & F.Name)
                LB.Items.Add("Already Exists " & Target_Folder & F.Name & " Moved to Dupes")
            End If

        Else
                'Move the pgp file to the specific archive folder
                F.MoveTo(Target_Folder & F.Name)
            LB.Items.Add(F.Name & vbCrLf)

            'Decrypt in target folder - drop pgp from output name
            If F.Name.Substring(Len(F.Name) - 4, 4) = ".pgp" Then
                'gpg.exe was very touchy about how it runs.  Didn't like spaces in path.
                cmd = "--batch --passphrase-file C:\Users\Bob\p.txt  -o " & Target_Folder & F.Name.Substring(0, Len(F.Name) - 4) & " -d " & Target_Folder & F.Name

                Call Spawn("gpg.exe", cmd)

                LB.Items.Add(cmd)
                LB.Items.Add("Decrypted " & F.Name & vbCrLf)
                Application.DoEvents()

                'use 7z to untar any archive - its ok if is not a tar

                cmd2 = "x " & Target_Folder & F.Name.Substring(0, Len(F.Name) - 4) & " -o" & Target_Folder & F.Name.Substring(0, Len(F.Name) - 4) & "~"

                Call Spawn("\progra~1\7-zip\7z", cmd2)

                LB.Items.Add(cmd2 & vbCrLf)

            End If
        End If

    End Sub

    Private Sub CB_All_CheckedChanged(sender As Object, e As EventArgs) Handles CB_All.CheckedChanged

        CB_UAT.Checked = CB_All.Checked
        CB_Stage.Checked = CB_All.Checked
        CB_Prod.Checked = CB_All.Checked


    End Sub

    Private Sub Spawn(ByRef Pgm As String, ByRef Parms As String)
        'general purpose routine to start external process

        Dim procID As Integer
        Dim newProc As New Diagnostics.Process

        newProc.StartInfo.FileName = Pgm
        newProc.StartInfo.Arguments = Parms
        newProc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized

        newProc.Start()

        procID = newProc.Id
        newProc.WaitForExit()
        Dim procEC As Integer = -1
        If newProc.HasExited Then
            procEC = newProc.ExitCode
        End If

        If procEC > 2 Then MsgBox("Process with ID " & CStr(procID) & " terminated with exit code " & CStr(procEC))

    End Sub




End Class
