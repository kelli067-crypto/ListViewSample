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
        Try
            ReadInputFile(strFileName)
        Catch exNotFound As FileNotFoundException
            'put error handling code here
        Catch exIOError As IOException
            'put error handling code here
        Catch exOther As Exception 'anything else that might go wrong
            'put error handling here
        End Try
    End Sub

    Private Sub ReadInputFile(strIn As String)
        Dim fileIn As StreamReader
        Dim strLineIn As String
        Dim strFields() As String 'string array to hold the fields from a record in the file
        Dim i As Integer
        lvwInventory.Items.Clear()
        Try
            fileIn = New StreamReader(strIn)
            If Not fileIn.EndOfStream Then 'get the first line and use it to build column headings
                strLineIn = fileIn.ReadLine
                strFields = strLineIn.Split(",")
                For i = 0 To strFields.Length - 1 'build column headings
                    lvwInventory.Columns.Add(strFields(i))
                Next

                'do some formatting of the columns
                With lvwInventory
                    .Columns(ARTIST).Width = 80
                    .Columns(ITEM_TITLE).Width = 150
                    .Columns(DATE_ACQUIRED).Width = 80
                    .Columns(CATEGORY).Width = 80
                    .Columns(CONDITION).Width = 80
                    .Columns(ITEM_LOCATION).Width = 100
                    .Columns(ITEM_VALUE).Width = 100
                    .Columns(ITEM_VALUE).TextAlign = HorizontalAlignment.Right
                End With
            End If
            'now get the data for each row
            While Not fileIn.EndOfStream
                strLineIn = fileIn.ReadLine
                strFields = strLineIn.Split(",")
                'set up the first column value in a new listview item (the row)
                Dim lviRow As New ListViewItem(strFields(0))
                'now add the rest of the column values as subitems to that listviewitem
                For i = 1 To strFields.Length - 1
                    Dim lsiCol As New ListViewItem.ListViewSubItem
                    If i <> ITEM_VALUE Then
                        lsiCol.Text = strFields(i)
                    Else 'it is the money value, so format it
                        lsiCol.Text = FormatCurrency(strFields(i), 0)
                    End If
                    lviRow.SubItems.Add(lsiCol) ' add the column to the row
                Next
                'now add the completed row to the listview
                lvwInventory.Items.Add(lviRow)
            End While
            fileIn.Close()
            fileIn.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        OpenFile()
    End Sub
End Class
