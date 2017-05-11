<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.OutPutBox = New AshbyToolsControls.ColorListBox()
        Me.FileportalDataSet1 = New FilePortalSync.fileportalDataSet1()
        Me.FiledataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FiledataTableAdapter = New FilePortalSync.fileportalDataSet1TableAdapters.filedataTableAdapter()
        Me.TableAdapterManager = New FilePortalSync.fileportalDataSet1TableAdapters.TableAdapterManager()
        Me.AssignmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssignmentTableAdapter = New FilePortalSync.fileportalDataSet1TableAdapters.assignmentTableAdapter()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "File Portal Sync"
        Me.NotifyIcon1.Visible = True
        '
        'OutPutBox
        '
        Me.OutPutBox.DataSource = Me.AssignmentBindingSource
        Me.OutPutBox.DisplayMember = "teacher"
        Me.OutPutBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutPutBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.OutPutBox.FormattingEnabled = True
        Me.OutPutBox.Location = New System.Drawing.Point(0, 0)
        Me.OutPutBox.Name = "OutPutBox"
        Me.OutPutBox.SelectedItem = Nothing
        Me.OutPutBox.Size = New System.Drawing.Size(930, 513)
        Me.OutPutBox.TabIndex = 0
        Me.OutPutBox.ValueMember = "idAssignment"
        '
        'FileportalDataSet1
        '
        Me.FileportalDataSet1.DataSetName = "fileportalDataSet1"
        Me.FileportalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FiledataBindingSource
        '
        Me.FiledataBindingSource.DataMember = "filedata"
        Me.FiledataBindingSource.DataSource = Me.FileportalDataSet1
        '
        'FiledataTableAdapter
        '
        Me.FiledataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.assignmentTableAdapter = Me.AssignmentTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.filedataTableAdapter = Me.FiledataTableAdapter
        Me.TableAdapterManager.UpdateOrder = FilePortalSync.fileportalDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AssignmentBindingSource
        '
        Me.AssignmentBindingSource.DataMember = "assignment"
        Me.AssignmentBindingSource.DataSource = Me.FileportalDataSet1
        '
        'AssignmentTableAdapter
        '
        Me.AssignmentTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 513)
        Me.Controls.Add(Me.OutPutBox)
        Me.Name = "Form1"
        Me.Text = "File Portal Sync"
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents OutPutBox As AshbyToolsControls.ColorListBox
    Friend WithEvents FileportalDataSet1 As fileportalDataSet1
    Friend WithEvents FiledataBindingSource As BindingSource
    Friend WithEvents FiledataTableAdapter As fileportalDataSet1TableAdapters.filedataTableAdapter
    Friend WithEvents TableAdapterManager As fileportalDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents AssignmentTableAdapter As fileportalDataSet1TableAdapters.assignmentTableAdapter
    Friend WithEvents AssignmentBindingSource As BindingSource
End Class
