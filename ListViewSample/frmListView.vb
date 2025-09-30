Imports System.IO
Public Class frmListView
    Private strFileName As String
    Private dblTotalInValue As Double
    Private intTotalCount As Integer
#Region "Column constance"
    'constants to manage the listview columns
    Private Const ARTID As Integer = 0
    Private Const ARTIST As Integer = 1
    Private Const ITEM_TITLE As Integer = 2
    Private Const DATE_ACQUIRED As Integer = 3
    Private Const CATEGORY As Integer = 4
    Private Const CONDITION As Integer = 5
    Private Const ITEM_LOCATION As Integer = 6
    Private Const ITEM_VALUE As Integer = 7

#End Region
    Private Sub OpenFile()
        Dim intResult As Integer
        ofdOpen.InitialDirectory = Application.StartupPath
        ofdOpen.Filter = "All Files (*.*)|*.*|Text files (*.txt)|*.txt"
        ofdOpen.FilterIndex = 2
        intResult = ofdOpen.ShowDialog
        If intResult = DialogResult.Cancel Then 'user canceled the open
            Exit Sub
        End If
        strFileName = ofdOpen.FileName
    End Sub
End Class
