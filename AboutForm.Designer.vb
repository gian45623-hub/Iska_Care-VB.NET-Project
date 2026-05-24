<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblDesc = New Label()
        lblTeam = New Label()
        lblJon = New Label()
        lblGian = New Label()
        lblPaulo = New Label()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblTitle.Location = New Point(14, 27)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(526, 53)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Creative Code_ Project Group"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDesc
        ' 
        lblDesc.Font = New Font("Segoe UI", 10F)
        lblDesc.Location = New Point(23, 93)
        lblDesc.Name = "lblDesc"
        lblDesc.Size = New Size(503, 107)
        lblDesc.TabIndex = 1
        lblDesc.Text = "We are the Creatve Code_ Project Group. We aim to create a simple and easy to use healthcare system for the modern Iskolar ng Bayan."
        lblDesc.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblTeam
        ' 
        lblTeam.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTeam.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblTeam.Location = New Point(14, 213)
        lblTeam.Name = "lblTeam"
        lblTeam.Size = New Size(526, 40)
        lblTeam.TabIndex = 2
        lblTeam.Text = "Meet Our Team"
        lblTeam.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblJon
        ' 
        lblJon.Font = New Font("Segoe UI", 10F)
        lblJon.Location = New Point(175, 267)
        lblJon.Name = "lblJon"
        lblJon.Size = New Size(202, 53)
        lblJon.TabIndex = 3
        lblJon.Text = "• Jon Carlo A. Marasigan"
        ' 
        ' lblGian
        ' 
        lblGian.Font = New Font("Segoe UI", 10F)
        lblGian.Location = New Point(175, 320)
        lblGian.Name = "lblGian"
        lblGian.Size = New Size(169, 53)
        lblGian.TabIndex = 4
        lblGian.Text = "• Gian Errol V. Labso"
        ' 
        ' lblPaulo
        ' 
        lblPaulo.Font = New Font("Segoe UI", 10F)
        lblPaulo.Location = New Point(175, 373)
        lblPaulo.Name = "lblPaulo"
        lblPaulo.Size = New Size(195, 80)
        lblPaulo.TabIndex = 5
        lblPaulo.Text = "• Paulo Xezar F. Basanta"
        ' 
        ' AboutForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(553, 533)
        Controls.Add(lblPaulo)
        Controls.Add(lblGian)
        Controls.Add(lblJon)
        Controls.Add(lblTeam)
        Controls.Add(lblDesc)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AboutForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "About Us"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblJon As System.Windows.Forms.Label
    Friend WithEvents lblGian As System.Windows.Forms.Label
    Friend WithEvents lblPaulo As System.Windows.Forms.Label
End Class
