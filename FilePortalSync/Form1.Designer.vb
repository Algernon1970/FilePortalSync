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
        Me.AssignmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FileportalDataSet1 = New FilePortalSync.fileportalDataSet1()
        Me.FiledataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FiledataTableAdapter = New FilePortalSync.fileportalDataSet1TableAdapters.filedataTableAdapter()
        Me.TableAdapterManager = New FilePortalSync.fileportalDataSet1TableAdapters.TableAdapterManager()
        Me.AssignmentTableAdapter = New FilePortalSync.fileportalDataSet1TableAdapters.assignmentTableAdapter()
        Me.OutputData = New System.Windows.Forms.DataGridView()
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutputData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "File Portal Sync"
        Me.NotifyIcon1.Visible = True
        '
        'AssignmentBindingSource
        '
        Me.AssignmentBindingSource.DataMember = "assignment"
        Me.AssignmentBindingSource.DataSource = Me.FileportalDataSet1
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
        'AssignmentTableAdapter
        '
        Me.AssignmentTableAdapter.ClearBeforeFill = True
        '
        'OutputData
        '
        Me.OutputData.AllowUserToDeleteRows = False
        Me.OutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutputData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputData.Location = New System.Drawing.Point(0, 0)
        Me.OutputData.Name = "OutputData"
        Me.OutputData.ReadOnly = True
        Me.OutputData.Size = New System.Drawing.Size(930, 513)
        Me.OutputData.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 513)
        Me.Controls.Add(Me.OutputData)
        Me.Name = "Form1"
        Me.Text = "File Portal Sync"
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutputData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents FileportalDataSet1 As fileportalDataSet1
    Friend WithEvents FiledataBindingSource As BindingSource
    Friend WithEvents FiledataTableAdapter As fileportalDataSet1TableAdapters.filedataTableAdapter
    Friend WithEvents TableAdapterManager As fileportalDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents AssignmentTableAdapter As fileportalDataSet1TableAdapters.assignmentTableAdapter
    Friend WithEvents AssignmentBindingSource As BindingSource
    Friend WithEvents OutputData As DataGridView
End Class
