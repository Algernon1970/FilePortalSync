Imports AshbyTools
Imports System.IO
Imports System.ComponentModel

Public Class Form1
    Dim cancelled As Boolean = False
    Dim displayTable As New DataTable
    Dim displayrow As DataRow

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.portalBlue
        Me.NotifyIcon1.Icon = My.Resources.portalBlue
        Me.NotifyIcon1.Visible = False
        displayTable.Columns.Add("TimeStamp")
        displayTable.Columns.Add("Username")
        displayTable.Columns.Add("Assignment")
        displayTable.Columns.Add("Original File")
        displayTable.Columns.Add("Destination File")
        displayTable.Columns.Add("Operation")
        displayTable.Columns.Add("Result")

        OutputData.DataSource = displayTable
        Dim wd As BackgroundWorker = New BackgroundWorker
        AddHandler wd.DoWork, AddressOf watchdog_DoWork
        wd.RunWorkerAsync()

    End Sub

    Private Sub watchdog_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim count As Integer = 0
        While Not cancelled
            count = count + 1
            If count > 5000 Then
                displayTable.Rows.Clear()
                count = 0
            End If

            UploadFiles()
            DeleteFiles()

            Threading.Thread.Sleep(5000)
        End While
    End Sub

    Private Sub DeleteFiles()
        Dim deleteFiles As fileportalDataSet1.filedataDataTable = FiledataTableAdapter.GetListToDelete()
        For Each dr As DataRow In deleteFiles.Rows
            Dim rowID As Integer = dr.Field(Of Integer)("idFileData")
            Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
            Dim origFN As String = dr.Field(Of String)("filename")
            Dim user As String = dr.Field(Of String)("username")
            Dim id As Integer = dr.Field(Of Integer)("idFileData")
            Dim assignmentName As String = AssignmentTableAdapter.GetAssignmentByID(assID).Rows(0).Field(Of String)("title")

            Dim fileext As String = Path.GetExtension(origFN)
            Dim copyFN As String = String.Format("{0}{1}", id, fileext)

            Dim newDetailRow As DataRow = displayTable.NewRow()
            newDetailRow("TimeStamp") = Now
            newDetailRow("Username") = user
            newDetailRow("Assignment") = assignmentName
            newDetailRow("Original File") = origFN
            newDetailRow("Destination File") = copyFN
            newDetailRow("Operation") = "Delete From Sharepoint"


            Dim res As String = AshbyTools.FileOperations.deleteFromSP(copyFN, My.Resources.LibraryURL, My.Resources.ShareName, My.Resources.LibraryUsername, Utils.convertToSecureString(My.Resources.LibraryPassword))
            newDetailRow("Result") = res
            displayTable.Rows.Add(newDetailRow)
            If res.ToLower.Equals("ok") Then
                FiledataTableAdapter.DeletebyRowID(rowID)
            Else
                NotifyIcon1.Icon = My.Resources.portalRed
            End If
        Next
    End Sub

    Private Sub UploadFiles()
        Dim readyFiles As fileportalDataSet1.filedataDataTable = FiledataTableAdapter.GetReadyFiles()
        For Each dr As DataRow In readyFiles.Rows
            Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
            Dim origFN As String = dr.Field(Of String)("filename")
            Dim user As String = dr.Field(Of String)("username")
            Dim id As Integer = dr.Field(Of Integer)("idFileData")
            Dim assignmentName As String = AssignmentTableAdapter.GetAssignmentByID(assID).Rows(0).Field(Of String)("title")

            Dim fileext As String = Path.GetExtension(origFN)
            Dim copyFN As String = String.Format("{0}{1}{2}", My.Resources.localShare, id, fileext)

            Dim newDetailRow As DataRow = displayTable.NewRow()
            newDetailRow("TimeStamp") = Now
            newDetailRow("Username") = user
            newDetailRow("Assignment") = assignmentName
            newDetailRow("Original File") = origFN
            newDetailRow("Destination File") = copyFN

            'upload to SP
            Dim res As String = AshbyTools.FileOperations.copyToSP(copyFN, My.Resources.LibraryURL, My.Resources.ShareName, My.Resources.LibraryUsername, Utils.convertToSecureString(My.Resources.LibraryPassword))
            If res.ToLower.Equals("ok") Then
                FiledataTableAdapter.SetUploaded(True, assID)
                File.Delete(copyFN)
            Else
                FiledataTableAdapter.SetError(True, assID)
                NotifyIcon1.Icon = My.Resources.portalRed
            End If
            newDetailRow("Operation") = "Copy to Sharepoint"
            newDetailRow("Result") = res
            displayTable.Rows.Add(newDetailRow)
            Me.Refresh()
        Next
    End Sub

#Region "Screen Handleing"
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        NotifyIcon1.Icon = My.Resources.portalBlue
        Me.NotifyIcon1.Visible = False
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            Me.NotifyIcon1.Visible = True
        End If
    End Sub

#End Region
End Class
