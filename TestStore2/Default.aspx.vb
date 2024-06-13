
Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Data.SqlClient


Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Dim strcnn As String = ConfigurationManager.ConnectionStrings("Store_connection").ConnectionString
            Dim objCnn As New SqlConnection(strcnn)
            Dim dst As New DataSet()
            Dim strSQl As String = "Select * From Products1; "
            Dim dpt As New SqlClient.SqlDataAdapter(strSQl, objCnn)
            dpt.Fill(dst, "ttmProducts1")
            Dim tblData As DataTable = dst.Tables("ttmProducts1")



            gvwMain.DataSource = tblData
            gvwMain.DataBind()

            objCnn.Close()
            tblData.Dispose()
            dpt.Dispose()
        Catch ex As Exception
        End Try
    End Sub

End Class