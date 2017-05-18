<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDefaultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDefaultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnterPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutputData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.TableAdapterManager.filecheckTableAdapter = Nothing
        Me.TableAdapterManager.filedataTableAdapter = Me.FiledataTableAdapter
        Me.TableAdapterManager.UpdateOrder = FilePortalSync.fileportalDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AssignmentTableAdapter
        '
        Me.AssignmentTableAdapter.ClearBeforeFill = True
        '
        'OutputData
        '
        Me.OutputData.AllowUserToAddRows = False
        Me.OutputData.AllowUserToDeleteRows = False
        Me.OutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutputData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputData.Location = New System.Drawing.Point(0, 24)
        Me.OutputData.Name = "OutputData"
        Me.OutputData.ReadOnly = True
        Me.OutputData.RowHeadersWidth = 60
        Me.OutputData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.OutputData.ShowEditingIcon = False
        Me.OutputData.Size = New System.Drawing.Size(930, 489)
        Me.OutputData.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.StartToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(930, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDefaultsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDefaultsToolStripMenuItem
        '
        Me.SaveDefaultsToolStripMenuItem.Name = "SaveDefaultsToolStripMenuItem"
        Me.SaveDefaultsToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SaveDefaultsToolStripMenuItem.Text = "Save Defaults"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditDefaultsToolStripMenuItem, Me.EnterPasswordToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EditDefaultsToolStripMenuItem
        '
        Me.EditDefaultsToolStripMenuItem.Name = "EditDefaultsToolStripMenuItem"
        Me.EditDefaultsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.EditDefaultsToolStripMenuItem.Text = "Edit Defaults"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.BackColor = System.Drawing.Color.LawnGreen
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'EnterPasswordToolStripMenuItem
        '
        Me.EnterPasswordToolStripMenuItem.Name = "EnterPasswordToolStripMenuItem"
        Me.EnterPasswordToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.EnterPasswordToolStripMenuItem.Text = "Enter Password"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 513)
        Me.Controls.Add(Me.OutputData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "File Portal Sync"
        CType(Me.AssignmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FiledataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutputData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents FileportalDataSet1 As fileportalDataSet1
    Friend WithEvents FiledataBindingSource As BindingSource
    Friend WithEvents FiledataTableAdapter As fileportalDataSet1TableAdapters.filedataTableAdapter
    Friend WithEvents TableAdapterManager As fileportalDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents AssignmentTableAdapter As fileportalDataSet1TableAdapters.assignmentTableAdapter
    Friend WithEvents AssignmentBindingSource As BindingSource
    Friend WithEvents OutputData As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveDefaultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDefaultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnterPasswordToolStripMenuItem As ToolStripMenuItem
End Class
