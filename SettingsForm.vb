Imports System.Windows.Forms
Imports MySqlConnector

Public Class SettingsForm
    ' Eto yung form para sa database backup at restore. May dalawang button ito: "Backup Database" at "Restore Database".
    ' Kapag nag-click ang user sa "Backup Database" button,
    ' magpapakita ito ng SaveFileDialog para pumili ng location at filename para sa backup file.

    ' pano ngaba nagana ang database backup at restore? Eto yung mga steps:
    ' 1. Kapag nag-click ang user sa "Backup Database" button,
    ' magpapakita ito ng SaveFileDialog para pumili ng location at filename para sa backup file.
    ' 2. Kapag pumili ang user ng location at filename at nag-click ng "Save",
    ' gagamitin nito ang MySqlBackup class mula sa MySqlConnector library para i-export ang database sa napiling file.
    ' 3. Kapag nag-click ang user sa "Restore Database" button, magpapakita ito ng OpenFileDialog para pumili ng backup file na i-restore.
    ' 4. Kapag pumili ang user ng backup file at nag-click ng "Open",
    ' ipapakita nito ang confirmation dialog para i-confirm ang restore action.
    ' 5. Kapag ni-confirm ng user ang restore action, gagamitin nito ang MySqlBackup class para i-import
    ' ang database mula sa napiling backup file.
    ' 6. Pagkatapos ng backup o restore action, ipapakita nito ang success o error message depende sa resulta ng operation.
    ' Note: Ang MySqlBackup class ay bahagi ng MySqlConnector library at nagbibigay ng mga method para sa pag-export
    ' at pag-import ng MySQL databases.
    ' Important: Ang backup at restore operations ay maaaring mag-take ng ilang minuto depende sa laki ng database,
    ' kaya dapat ipakita ang loading indicator o disable ang buttons habang nagpe-perform ng operation para maiwasan ang multiple clicks.
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "SQL Backup File|*.sql"
            sfd.Title = "Save Database Backup"
            sfd.FileName = "ClinicBackup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim dbHelper As New DatabaseHelper()
                    Using conn As New MySqlConnection(dbHelper.GetDatabaseConnectionString())
                        Using cmd As New MySqlCommand()
                            Using mb As New MySqlBackup(cmd)
                                cmd.Connection = conn
                                conn.Open()
                                mb.ExportToFile(sfd.FileName)
                                conn.Close()
                            End Using
                        End Using
                    End Using
                    MessageBox.Show("Backup successfully saved to " & sfd.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Backup failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "SQL Backup File|*.sql"
            ofd.Title = "Select Database Backup File"

            If ofd.ShowDialog() = DialogResult.OK Then
                If MessageBox.Show("WARNING: Restoring a backup will overwrite all current data. Are you sure you want to continue?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Try
                        Dim dbHelper As New DatabaseHelper()
                        Using conn As New MySqlConnection(dbHelper.GetDatabaseConnectionString())
                            Using cmd As New MySqlCommand()
                                Using mb As New MySqlBackup(cmd)
                                    cmd.Connection = conn
                                    conn.Open()
                                    mb.ImportFromFile(ofd.FileName)
                                    conn.Close()
                                End Using
                            End Using
                        End Using
                        MessageBox.Show("Database successfully restored! Please restart the application.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Restore failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Using
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
