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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LibraryURLBox = New System.Windows.Forms.TextBox()
        Me.UsernameBox = New System.Windows.Forms.TextBox()
        Me.LibraryShareBox = New System.Windows.Forms.TextBox()
        Me.PasswordBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LocalShareBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(277, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Library URL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Library Share"
        '
        'LibraryURLBox
        '
        Me.LibraryURLBox.Location = New System.Drawing.Point(85, 61)
        Me.LibraryURLBox.Name = "LibraryURLBox"
        Me.LibraryURLBox.Size = New System.Drawing.Size(267, 20)
        Me.LibraryURLBox.TabIndex = 5
        '
        'UsernameBox
        '
        Me.UsernameBox.Location = New System.Drawing.Point(85, 9)
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.Size = New System.Drawing.Size(267, 20)
        Me.UsernameBox.TabIndex = 6
        '
        'LibraryShareBox
        '
        Me.LibraryShareBox.Location = New System.Drawing.Point(85, 87)
        Me.LibraryShareBox.Name = "LibraryShareBox"
        Me.LibraryShareBox.Size = New System.Drawing.Size(267, 20)
        Me.LibraryShareBox.TabIndex = 7
        '
        'PasswordBox
        '
        Me.PasswordBox.Location = New System.Drawing.Point(85, 35)
        Me.PasswordBox.Name = "PasswordBox"
        Me.PasswordBox.Size = New System.Drawing.Size(267, 20)
        Me.PasswordBox.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Local Share"
        '
        'LocalShareBox
        '
        Me.LocalShareBox.Location = New System.Drawing.Point(85, 113)
        Me.LocalShareBox.Name = "LocalShareBox"
        Me.LocalShareBox.Size = New System.Drawing.Size(267, 20)
        Me.LocalShareBox.TabIndex = 10
        '
        'DefaultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 169)
        Me.ControlBox = False
        Me.Controls.Add(Me.LocalShareBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PasswordBox)
        Me.Controls.Add(Me.LibraryShareBox)
        Me.Controls.Add(Me.UsernameBox)
        Me.Controls.Add(Me.LibraryURLBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LibraryURLBox As TextBox
    Friend WithEvents UsernameBox As TextBox
    Friend WithEvents LibraryShareBox As TextBox
    Friend WithEvents PasswordBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LocalShareBox As TextBox
End Class
