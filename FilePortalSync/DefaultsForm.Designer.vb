<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefaultsForm
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LibraryURLBox = New System.Windows.Forms.TextBox()
        Me.LibraryShareBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LocalShareBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(279, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Library URL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Library Share"
        '
        'LibraryURLBox
        '
        Me.LibraryURLBox.Location = New System.Drawing.Point(87, 12)
        Me.LibraryURLBox.Name = "LibraryURLBox"
        Me.LibraryURLBox.Size = New System.Drawing.Size(267, 20)
        Me.LibraryURLBox.TabIndex = 5
        '
        'LibraryShareBox
        '
        Me.LibraryShareBox.Location = New System.Drawing.Point(87, 38)
        Me.LibraryShareBox.Name = "LibraryShareBox"
        Me.LibraryShareBox.Size = New System.Drawing.Size(267, 20)
        Me.LibraryShareBox.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Local Share"
        '
        'LocalShareBox
        '
        Me.LocalShareBox.Location = New System.Drawing.Point(87, 64)
        Me.LocalShareBox.Name = "LocalShareBox"
        Me.LocalShareBox.Size = New System.Drawing.Size(267, 20)
        Me.LocalShareBox.TabIndex = 10
        '
        'DefaultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 123)
        Me.ControlBox = False
        Me.Controls.Add(Me.LocalShareBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LibraryShareBox)
        Me.Controls.Add(Me.LibraryURLBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DefaultsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Library Settings"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LibraryURLBox As TextBox
    Friend WithEvents LibraryShareBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LocalShareBox As TextBox
End Class
