﻿Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Module GlobalModule
    Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Long
    Declare Function IsIconic Lib "User32" (ByVal hWnd As Long) As Long
    Declare Function ShowWindow Lib "User32" (ByVal hWnd As Long, ByVal nCmdShow As Long) As Long
    Public Const SW_NORMAL = 1     'Show window in normal size
    Public Const SW_MINIMIZE = 2   'Show window minimized
    Public Const SW_MAXIMIZE = 3   'Show window maximized
    Public Const SW_SHOW = 9       'Show window without changing window size

    Public objAccess As Object 'module-level declaration
    Public RegKey As String = "SOFTWARE\\Swdev Bali\\PIMPhony Integration Utility\\1.0"
    Public dbFileName As String = Nothing
    Public dbPassword As String
    Public isAcceptInternalCall As Boolean
    Public isAutomaticallyOpenDatabase As Boolean
    Public OpenFileDialog As New OpenFileDialog


    Public AppKey As RegistryKey
    Sub ShowAccess(instance As Object, size As Integer)
        Dim hWnd As Long, temp As Long
        On Error Resume Next
        instance.Visible = False
        On Error GoTo 0 'turn off error handler

        hWnd = instance.hWndAccessApp

        temp = SetForegroundWindow(hWnd)

    End Sub
    Sub openAccessForm()

        'On Error Resume Next 'temporary error handling
        Try
            objAccess = GetObject(, "Access.Application")
        Catch ex As Exception
            If Not isAutomaticallyOpenDatabase Then Exit Sub
            objAccess = CreateObject("Access.Application")
        End Try
        ShowAccess(instance:=objAccess, size:=SW_MAXIMIZE)

        Dim iWorkspace As Integer
        Dim iDatabase As Integer
        Dim isAccessOpeningDatabase As Boolean = False
        Dim isOurDatabaseOpen As Boolean = False


        With objAccess
            If .DBEngine.Workspaces(0).Databases.Count = 0 Then
                Dim db = .DBEngine.OpenDatabase(dbFileName, False, False, ";PWD=" & dbPassword)
                .OpenCurrentDatabase(filepath:=dbFileName)
                .DoCmd.OpenForm(FormName:="NewCall", View:=Access.AcFormView.acNormal)
                Try
                    objAccess.visible = True
                Catch ex As Exception
                End Try
                .DoCmd.RunCommand(Access.AcCommand.acCmdAppMaximize)

            Else
                'an Access database is open, check whether our database is also open, and use it
                For iWorkspace = 0 To .DBEngine.Workspaces.count - 1
                    For iDatabase = 0 To .DBEngine.Workspaces(iWorkspace).Databases.count - 1
                        isAccessOpeningDatabase = True
                        If .DBEngine.Workspaces(iWorkspace).Databases(iDatabase).Name = dbFileName Then
                            isOurDatabaseOpen = True
                            iWorkspace = .DBEngine.Workspaces.count - 1
                            Exit For
                        End If
                    Next
                Next
            End If
            Try
                If isAccessOpeningDatabase And isOurDatabaseOpen Then
                    'close the form by saving it first, and then open it
                    objAccess.DoCmd.Close(Access.AcObjectType.acForm, "NewCall", Access.AcCloseSave.acSaveYes)
                    objAccess.DoCmd.OpenForm(FormName:="NewCall", View:=Access.AcFormView.acNormal)
                    objAccess.DoCmd.RunCommand(Access.AcCommand.acCmdAppMaximize)
                    objAccess.visible = True
                ElseIf isAccessOpeningDatabase And isAutomaticallyOpenDatabase Then
                    objAccess.CloseCurrentDatabase()
                    objAccess.OpenCurrentDatabase(filepath:=dbFileName)
                    objAccess.DoCmd.OpenForm(FormName:="NewCall", View:=Access.AcFormView.acNormal)
                    objAccess.DoCmd.RunCommand(Access.AcCommand.acCmdAppMaximize)
                    objAccess.visible = True
                End If
            Catch ex As Exception

            End Try


        End With
    End Sub
    Public Function GetDbFilename() As String
        Dim result As String
        OpenFileDialog.Title = "Select the database file"
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Microsoft Access Database (*.accdb) | *.accdb| Microsoft Access Executable (*.accde) | *.accde"
        If dbFileName.Contains(".accdb") Then
            OpenFileDialog.FilterIndex = 1
        Else
            OpenFileDialog.FilterIndex = 2
        End If
        OpenFileDialog.ShowDialog()
        result = OpenFileDialog.FileName
        GetDbFilename = result
    End Function

    Public Sub OpenRegistry()
        AppKey = Registry.CurrentUser.OpenSubKey(RegKey, True)
        If AppKey Is Nothing Then
            AppKey = Registry.CurrentUser.CreateSubKey(RegKey)
        End If
    End Sub

    Public Sub LoadRegistryValue()
        If AppKey.GetValue("DB Filename", Nothing) Is Nothing Then
            AppKey.SetValue("DB Filename", "")
            dbFileName = ""
        Else
            dbFileName = AppKey.GetValue("DB Filename", "")
        End If

        If AppKey.GetValue("Accept Internal Call", Nothing) Is Nothing Then
            AppKey.SetValue("Accept Internal Call", False)
            isAcceptInternalCall = False
        Else
            isAcceptInternalCall = AppKey.GetValue("Accept Internal Call", False)
        End If


        If AppKey.GetValue("Automatically Open Database", Nothing) Is Nothing Then
            AppKey.SetValue("Automatically Open Database", False)
            isAutomaticallyOpenDatabase = False
        Else
            isAutomaticallyOpenDatabase = AppKey.GetValue("Automatically Open Database", False)
        End If

        If AppKey.GetValue("DB Password", Nothing) Is Nothing Then
            AppKey.SetValue("DB Password", "")
            dbPassword = ""
        Else
            dbPassword = AppKey.GetValue("DB Password", "")
        End If
    End Sub
    Public Sub SaveRegistryValue()
        AppKey.SetValue("DB Filename", dbFileName)
        AppKey.SetValue("DB Password", dbPassword)
        AppKey.SetValue("Accept Internal Call", isAcceptInternalCall)
        AppKey.SetValue("Automatically Open Database", isAutomaticallyOpenDatabase)
    End Sub
End Module
