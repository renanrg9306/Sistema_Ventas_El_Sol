Public Class frmBienvenida

    Dim contador As Integer = 0

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub frmBienvenida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0.0
        ProgressBar1.Maximum = 100
        Timer1.Interval = 35
        Timer1.Enabled = True

        Timer1.Start()
    End Sub

    ' iniciamos el codigo del timer en su evento click
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If contador = 100 Then
            'la propiedad opacity del form se ira disminuyendo hasta desaparecer el form
            Me.Opacity -= 0.9
            ' si opacidad llega a 0 nos cerrara el form y nos abrira el que declaramos
            If Me.Opacity = 0.0 Then
                Timer1.Enabled = False
                Me.Hide()
                frmMenu_Principal.Show()
            End If
        Else
            ProgressBar1.Value = contador
            contador += 1
            lblcargar.Text = "CARGANDO........."
            lblproceso.Text = ProgressBar1.Value & (" %")
        End If

    End Sub
End Class