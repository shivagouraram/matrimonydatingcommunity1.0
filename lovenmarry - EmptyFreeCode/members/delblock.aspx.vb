Imports System.Data
Imports System.Data.SqlClient

Partial Class members_delblock
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""



        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "delete from blacklisted where memberidblocked='" & Request.QueryString("pid") & "' and pid='" & Session("pid") & "'"
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Label1.Text = "Block Removed Succesfully"
        Else
            Label1.Text = " Block not Found"
        End If

        cn.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove Your Blocked Profile?"
        Else
            LinkButton1.Text = ""
        End If
    End Sub
End Class
