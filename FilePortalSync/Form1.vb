Imports AshbyTools
Imports System.IO
Imports System.ComponentModel
Imports System.Security
Imports System.Xml.Serialization
Imports System.Threading.Tasks.Dataflow


Public Class Form1
    Dim cancelled As Boolean = False
    Dim displayTable As New DataTable
    Dim displayrow As DataRow
    Dim library As New Library()
    Dim settingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Ashby School\" & My.Resources.settingsFile
    Dim Username As String = "Anonymous"
    Dim Password As SecureString
    Dim threadsRunning As Integer = 0

    Private Delegate Sub updateScreenCallback()

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
#End Region

#Region "Thread Handleing"
    Private Sub incThread()
        SyncLock Me
            threadsRunning = threadsRunning + 1
            updateScreen()
        End SyncLock
    End Sub

    Private Sub decThread()
        SyncLock Me
            threadsRunning = threadsRunning - 1
            updateScreen()
        End SyncLock
    End Sub

    Private Function testThread() As Boolean
        Dim test As Boolean = True
        SyncLock Me
            If threadsRunning < 1 Then
                test = False
            End If
        End SyncLock
        Return test
    End Function

    Private Sub uploader_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        incThread()

        While Not cancelled
            UploadFiles()
            DeleteFiles()
            Threading.Thread.Sleep(5000)
        End While
    End Sub

    Private Sub downloader_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        incThread()
        While Not cancelled
            DownloadFiles()
            Threading.Thread.Sleep(2000)
        End While
    End Sub

    Private Sub uploader_StopWork()
        decThread()
        If Not testThread() Then
            StartToolStripMenuItem.Text = "Start"
            StartToolStripMenuItem.BackColor = Color.LawnGreen
            EditToolStripMenuItem.Enabled = True
            FileToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub downloader_StopWork()
        decThread()
        If Not testThread() Then
            StartToolStripMenuItem.Text = "Start"
            StartToolStripMenuItem.BackColor = Color.LawnGreen
            EditToolStripMenuItem.Enabled = True
            FileToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub updateScreen()
        If Me.InvokeRequired Then
            Dim d As New updateScreenCallback(AddressOf updateScreen)
            Me.Invoke(d)
        Else
            If OutputData.Rows.Count > 5000 Then
                displayTable.Rows.Remove(displayTable.Rows.Item(0))
            End If
            Me.Text = "ThreadCount = " & threadsRunning
            Me.Refresh()
        End If
    End Sub
#End Region

#Region "Sharepoint Handleing"
    Private Sub DeleteFiles()
        Dim deleteFiles As fileportalDataSet1.filedataDataTable
        SyncLock Me
            deleteFiles = FiledataTableAdapter.GetListToDelete()
        End SyncLock

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
            updateScreen()
            If res.ToLower.Equals("ok") Then
                SyncLock Me
                    FiledataTableAdapter.SetDelFlag(False, rowID)
                End SyncLock
            Else
                NotifyIcon1.Icon = My.Resources.portalRed
            End If
        Next
    End Sub

    Private Sub UploadFiles()
        Dim readyFiles As fileportalDataSet1.filedataDataTable
        SyncLock Me
            readyFiles = FiledataTableAdapter.GetReadyFiles()
        End SyncLock

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

            SyncLock Me
                If res.ToLower.Equals("ok") Then
                    FiledataTableAdapter.SetUploaded(True, assID)
                    File.Delete(copyFN)
                Else
                    FiledataTableAdapter.SetError(True, assID)
                    NotifyIcon1.Icon = My.Resources.portalRed
                End If
            End SyncLock

            newDetailRow("Operation") = "Copy to Sharepoint"
            newDetailRow("Result") = res
            displayTable.Rows.Add(newDetailRow)
            updateScreen()
        Next
    End Sub

    Private Sub DoCopy(taskLib As Library)
        incThread()
        Dim newDetailRow As DataRow = displayTable.NewRow()
        newDetailRow("TimeStamp") = Now
        newDetailRow("Original File") = taskLib.SharePointFile
        newDetailRow("Operation") = "Download"

        Dim fs As Stream = FileOperations.loadFromSP(taskLib.SharePointFile, taskLib.URL, taskLib.Share, taskLib.Username, taskLib.Password)
        If IsNothing(fs) Then
            decThread()
            newDetailRow("Result") = "Failed"
            displayTable.Rows.Add(newDetailRow)
            updateScreen()
            Return
        End If
        Using nfs As New FileStream("C:\temp\" & taskLib.SharePointFile, FileMode.Create)
            fs.CopyTo(nfs)
        End Using

        SyncLock Me
            FiledataTableAdapter.setDownloadReadyFlag(True, taskLib.id)
        End SyncLock
        newDetailRow("Result") = "Downloaded " & Now.ToShortTimeString
        displayTable.Rows.Add(newDetailRow)
        updateScreen()
        decThread()
    End Sub

    Private Sub DownloadFiles()
        Dim readyFiles As fileportalDataSet1.filedataDataTable
        SyncLock Me
            readyFiles = FiledataTableAdapter.getFilesToDownload()
        End SyncLock

        Dim options = New ExecutionDataflowBlockOptions() With {.MaxDegreeOfParallelism = 20}
        Dim myFileWorker = New ActionBlock(Of Library)(Sub(library As Library) DoCopy(library), options)

        For Each dr As DataRow In readyFiles
            Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
            Dim origFN As String = dr.Field(Of String)("filename")
            Dim id As Integer = dr.Field(Of Integer)("idFileData")
            Dim fileext As String = Path.GetExtension(origFN)
            Dim remoteFile As String = String.Format("{0}{1}", id, fileext)

            SyncLock Me
                FiledataTableAdapter.setDownloadFlag(False, id)
            End SyncLock
            Dim taskLib As New Library
            taskLib.SharePointFile = remoteFile
            taskLib.Username = Username
            taskLib.Password = Password
            taskLib.URL = library.URL
            taskLib.Share = library.Share
            taskLib.id = id
            'spawn thread to do copy
            myFileWorker.Post(taskLib)
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
        Dim uploaderThread As BackgroundWorker = New BackgroundWorker
        Dim downloaderThread As BackgroundWorker = New BackgroundWorker
        uploaderThread.WorkerSupportsCancellation = True
        downloaderThread.WorkerSupportsCancellation = True
        AddHandler uploaderThread.DoWork, AddressOf uploader_DoWork
        AddHandler uploaderThread.RunWorkerCompleted, AddressOf uploader_StopWork
        AddHandler downloaderThread.DoWork, AddressOf downloader_DoWork
        AddHandler downloaderThread.RunWorkerCompleted, AddressOf downloader_StopWork
        If StartToolStripMenuItem.Text.Equals("Start") Then
            EditToolStripMenuItem.Enabled = False
            FileToolStripMenuItem.Enabled = False
            StartToolStripMenuItem.Text = "Stop"
            StartToolStripMenuItem.BackColor = Color.Red
            OutputData.DataSource = displayTable
            cancelled = False
            uploaderThread.RunWorkerAsync()
            downloaderThread.RunWorkerAsync()
        Else
            StartToolStripMenuItem.Text = "Stopping"
            StartToolStripMenuItem.BackColor = Color.Orange
            cancelled = True
            uploaderThread.CancelAsync()
            downloaderThread.CancelAsync()
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

    Private Sub TESTToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DownloadFiles()
    End Sub

#End Region
End Class
