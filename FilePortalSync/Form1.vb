Imports AshbyTools

Public Class Form1
    Dim cancelled As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FileportalDataSet1.assignment' table. You can move, or remove it, as needed.
        'Me.AssignmentTableAdapter.Fill(Me.FileportalDataSet1.assignment)
        'TODO: This line of code loads data into the 'FileportalDataSet1.filedata' table. You can move, or remove it, as needed.
        'Me.FiledataTableAdapter.Fill(Me.FileportalDataSet1.filedata)
        'startup, launch watchdog on timer
        OutPutBox.Items.Clear()
        OutPutBox.Items.Add(New AshbyToolsControls.ColorListBoxItem("Date/Time     | Origin Filename                                         | Assignment              | User"))
        watchdog_DoWork()
    End Sub

    Private Sub watchdog_DoWork()
        While Not cancelled
            Dim readyFiles As fileportalDataSet1.filedataDataTable = FiledataTableAdapter.GetReadyFiles()
            For Each dr As DataRow In readyFiles.Rows
                Dim origFN As String = dr.Field(Of String)("filename")
                Dim user As String = dr.Field(Of String)("username")
                Dim id As Integer = dr.Field(Of Integer)("idFileData")
                OutPutBox.Items.Add(New AshbyToolsControls.ColorListBoxItem(String.Format("{1}{0}{2}{0}{3}{4}", vbTab, Now, origFN, "dummy", user)))
            Next
            'for each file in list
            '   copy from share to sp
            '   set UPLOADED
            '   delete from share
            '   log work
            'next

            ' Threading.Thread.Sleep(36000)
            cancelled = True
        End While
    End Sub
End Class
