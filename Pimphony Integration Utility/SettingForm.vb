﻿Public Class SettingForm
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'make sure file exist
        dbFileName = txtFilename.Text
        If Not System.IO.File.Exists(dbFileName) Then
            MessageBox.Show("The database file is not exist. Please fix this first", Application.ProductName & " " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        isAcceptInternalCall = chkAcceptIntCall.Checked
        SaveRegistryValue()
        End
    End Sub

    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadRegistryValue()
        txtFilename.Text = dbFileName
        chkAcceptIntCall.Checked = isAcceptInternalCall
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        dbFileName = GetDbFilename()
        txtFilename.Text = dbFileName
    End Sub
End Class