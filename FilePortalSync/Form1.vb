Imports AshbyTools
Imports System.IO
Imports System.ComponentModel
Imports System.Security
Imports System.Xml.Serialization

Public Class Form1
    Dim cancelled As Boolean = False
    Dim displayTable As New DataTable
    Dim displayrow As DataRow
    Dim library As New Library()
    Dim settingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Ashby School\" & My.Resources.settingsFile
    Dim Username As String = "Anonymous"
    Dim Password As SecureString

#Region "Setup"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.portalBlue
        Me.NotifyIcon1.Icon = My.Resources.portalBlue
        Me.NotifyIcon1.Visible = False

        Me.Text = "Assignment File Portal Sync " & My.Resources.Version

        library.URL = My.Resources.LibraryURL
        library.Share = My.Resources.ShareName
        library.LocalShare = My.Resources.LocalShare
        If File.Exists(settingsFile) Then
            loadLibrary()
        End If

        GetPassword()

        displayTable.Columns.Add("TimeStamp")
        displayTable.Columns.Add("Username")
        displayTable.Columns.Add("Assignment")
        displayTable.Columns.Add("Original File")
        displayTable.Columns.Add("Destination File")
        displayTable.Columns.Add("Operation")
        displayTable.Columns.Add("Result")
    End Sub

    Private Sub GetPassword()
        Dim req As New PasswordForm()
        Dim res As DialogResult = req.ShowDialog
        Username = req.UsernameBox.Text
        Password = AshbyTools.convertToSecureString(req.PasswordBox.Text)
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

    Private Sub watchdog_StopWork()
        StartToolStripMenuItem.Text = "Start"
        StartToolStripMenuItem.BackColor = Color.LawnGreen
        EditToolStripMenuItem.Enabled = True
        FileToolStripMenuItem.Enabled = True
    End Sub
#End Region

#Region "Sharepoint Handleing"
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


            Dim res As String = AshbyTools.FileOperations.deleteFromSP(copyFN, library.URL, library.Share, Username, Password)
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
            Dim copyFN As String = String.Format("{0}{1}{2}", library.LocalShare, id, fileext)

            Dim newDetailRow As DataRow = displayTable.NewRow()
            newDetailRow("TimeStamp") = Now
            newDetailRow("Username") = user
            newDetailRow("Assignment") = assignmentName
            newDetailRow("Original File") = origFN
            newDetailRow("Destination File") = copyFN

            'upload to SP
            Dim res As String = AshbyTools.FileOperations.copyToSP(copyFN, library.URL, library.Share, Username, Password)
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
#End Region

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

#Region "Menu Handleing"

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        Dim wd As BackgroundWorker = New BackgroundWorker
        wd.WorkerSupportsCancellation = True
        AddHandler wd.DoWork, AddressOf watchdog_DoWork
        AddHandler wd.RunWorkerCompleted, AddressOf watchdog_StopWork
        If StartToolStripMenuItem.Text.Equals("Start") Then
            EditToolStripMenuItem.Enabled = False
            FileToolStripMenuItem.Enabled = False
            StartToolStripMenuItem.Text = "Stop"
            StartToolStripMenuItem.BackColor = Color.Red
            OutputData.DataSource = displayTable
            cancelled = False
            wd.RunWorkerAsync()
        Else
            StartToolStripMenuItem.Text = "Stopping"
            StartToolStripMenuItem.BackColor = Color.Orange
            cancelled = True
            wd.CancelAsync()
        End If
    End Sub

    Private Sub EditDefaultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDefaultsToolStripMenuItem.Click
        Dim defaultsForm As New DefaultsForm(library)
        Dim res As DialogResult = defaultsForm.ShowDialog()
        If res = DialogResult.OK Then
            library = defaultsForm.localLibrary
        End If
    End Sub

    Private Sub SaveDefaultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDefaultsToolStripMenuItem.Click
        Using writer = New StreamWriter(settingsFile)
            Dim ser As XmlSerializer = New XmlSerializer(GetType(Library))
            ser.Serialize(writer, library)
        End Using
    End Sub

    Private Sub loadLibrary()
        Using fs As New FileStream(settingsFile, FileMode.Open)
            Dim ser As New XmlSerializer(GetType(Library))
            library = CType(ser.Deserialize(fs), Library)
        End Using
    End Sub

    Private Sub EnterPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnterPasswordToolStripMenuItem.Click
        GetPassword()
    End Sub

#End Region
End Class
