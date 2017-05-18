Imports AshbyTools
Public Class DefaultsForm
    Public localLibrary As New Library
    Public Sub New(ByVal library As Library)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LibraryURLBox.Text = library.URL
        LibraryShareBox.Text = library.Share
        LocalShareBox.Text = library.LocalShare
    End Sub

    Private Sub LibraryURLBox_TextChanged(sender As Object, e As EventArgs) Handles LibraryURLBox.TextChanged
        localLibrary.URL = LibraryURLBox.Text
    End Sub

    Private Sub LibraryShareBox_TextChanged(sender As Object, e As EventArgs) Handles LibraryShareBox.TextChanged
        localLibrary.Share = LibraryShareBox.Text
    End Sub

    Private Sub LocalShareBox_TextChanged(sender As Object, e As EventArgs) Handles LocalShareBox.TextChanged
        localLibrary.LocalShare = LocalShareBox.Text
    End Sub
End Class