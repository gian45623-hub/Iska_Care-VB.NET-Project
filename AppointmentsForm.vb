Imports System.Windows.Forms
Imports System.Drawing
Public Class AppointmentsForm
    Private dbHelper As New DatabaseHelper()

    Private Sub AppointmentsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments(calAppointments.SelectionStart)
    End Sub

    Private Sub calAppointments_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calAppointments.DateChanged
        LoadAppointments(e.Start)
    End Sub

    ' dto ni di-diplay sa DataGridView, kaya kailangan natin i-load ulit ang appointments kapag may pagbabago
    Private Sub LoadAppointments(selectedDate As DateTime)
        Try
            Dim appointments = dbHelper.GetAppointments(selectedDate)
            dgvAppointments.DataSource = appointments
            dgvAppointments.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        End Try
    End Sub


    ' Kapag nag-click ang user sa "Add Appointment" button, kukunin nito ang input values,
    ' gagawa ng bagong appointment item, at i-save ito sa database. Pagkatapos, i-clear natin ang input fields at i-refresh ang appointment list.
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim patientName As String = txtPatient.Text.Trim()
        Dim reason As String = txtReason.Text.Trim()

        If String.IsNullOrWhiteSpace(patientName) Then
            MessageBox.Show("Please enter a patient name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim apptDate As DateTime = calAppointments.SelectionStart.Date.Add(dtpTime.Value.TimeOfDay)

        Dim newAppt As New DatabaseHelper.AppointmentItem() With {
            .PatientName = patientName,
            .AppointmentDate = apptDate,
            .Reason = reason
        }

        Try
            dbHelper.AddAppointment(newAppt)
            txtPatient.Clear()
            txtReason.Clear()
            LoadAppointments(calAppointments.SelectionStart)
        Catch ex As Exception
            MessageBox.Show("Error adding appointment: " & ex.Message)
        End Try
    End Sub


    ' pag nag-click ang user sa "Delete Appointment" button, iche-check nito kung may napiling appointment sa DataGridView.
    ' Kung meron, ipapakita nito ang confirmation dialog. Kapag ni confirm ni user,
    ' ide-delete nito ang appointment na nasa database at i-refresh ang appointment list.
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAppointments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an appointment to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAppt As DatabaseHelper.AppointmentItem = CType(dgvAppointments.SelectedRows(0).DataBoundItem, DatabaseHelper.AppointmentItem)
        If MessageBox.Show($"Cancel appointment for {selectedAppt.PatientName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                dbHelper.DeleteAppointment(selectedAppt.Id)
                LoadAppointments(calAppointments.SelectionStart)
            Catch ex As Exception
                MessageBox.Show("Error deleting appointment: " & ex.Message)
            End Try
        End If
    End Sub
End Class
