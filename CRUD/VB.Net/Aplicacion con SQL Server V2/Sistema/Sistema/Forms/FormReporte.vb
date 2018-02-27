' Written By Ismael Heredia in the year 2017

Public Class FormReporte

    Private Sub FormReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reporte As New Reporte()
        reporte.SetDatabaseLogon("admin", "123456", "SINDECIDIR-PC", "sistemaV2")
        reporte.Refresh()
        crvReporte.Refresh()
        crvReporte.ReportSource = reporte
    End Sub
End Class