Imports AshbyTools
Imports System.IO

Public Class Form1
    Dim cancelled As Boolean = False
    Dim displayTable As New DataTable
    Dim displayrow As DataRow

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displayTable.Columns.Add("TimeStamp")
        displayTable.Columns.Add("Username")
        displayTable.Columns.Add("Assignment")
        displayTable.Columns.Add("Original File")
        displayTable.Columns.Add("Destination File")
        displayTable.Columns.Add("Operation")

        OutputData.DataSource = displayTable

        watchdog_DoWork()
    End Sub

    Private Sub watchdog_DoWork()
        Dim count As Integer = 0
        While Not cancelled
            count = count + 1
            If count > 5000 Then
                displayTable.Rows.Clear()
                count = 0
            End If

            UploadFiles()
            DeleteFiles()

            ' Threading.Thread.Sleep(36000)
            cancelled = True
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
            Dim copyFN As String = String.Format("{0}.{1}", id, fileext)

            Dim newDetailRow As DataRow = displayTable.NewRow()
            newDetailRow("TimeStamp") = Now
            newDetailRow("Username") = user
            newDetailRow("Assignment") = assignmentName
            newDetailRow("Original File") = origFN
            newDetailRow("Destination File") = copyFN
            newDetailRow("Operation") = "Delete From Sharepoint"
            displayTable.Rows.Add(newDetailRow)

            'Delete from Sharepoint

            'FiledataTableAdapter.DeletebyRowID(rowID)
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
            Dim copyFN As String = String.Format("{0}.{1}", id, fileext)

            Dim newDetailRow As DataRow = displayTable.NewRow()
            newDetailRow("TimeStamp") = Now
            newDetailRow("Username") = user
            newDetailRow("Assignment") = assignmentName
            newDetailRow("Original File") = origFN
            newDetailRow("Destination File") = copyFN
            newDetailRow("Operation") = "Copy to Sharepoint"
            displayTable.Rows.Add(newDetailRow)

            'upload to SP

            ' FiledataTableAdapter.SetUploaded(assID)

        Next
    End Sub
End Class
