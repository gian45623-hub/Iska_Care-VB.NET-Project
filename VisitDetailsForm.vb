Imports System.Windows.Forms
Imports System.Drawing

Public Class VisitDetailsForm
    Inherits Form
    ' eto yung form na ginagamit para mag-add o mag-edit ng visit record. Kapag nag-open ang form,
    ' iche-check nito kung may existing record na ibinigay sa constructor.
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property Record As VisitRecord

    Public Sub New(Optional existingRecord As VisitRecord = Nothing)
        InitializeComponent()
        Record = If(existingRecord, New VisitRecord() With {.TimeIn = DateTime.Now})
        LoadData()
        ' Kapag may existing record, i-po-populate nito yung form fields gamit yung data mula sa record.
        ' Kung wala naman, edi magse-set ito ng default values (e.g., current time para sa TimeIn or Timeout/checked out).
    End Sub

    Private Sub LoadData()
        ' Eto yung method na naglo-load ng data sa form fields.
        ' Iche-check nito kung may existing record at i-po-populate ang mga fields na walang laman sa record.
        If Not String.IsNullOrEmpty(Record.PatientType) Then cboType.SelectedItem = Record.PatientType Else cboType.SelectedIndex = 0
        txtName.Text = Record.PatientName
        numAge.Value = Record.Age
        numHeight.Value = CDec(Record.Height)
        numWeight.Value = CDec(Record.Weight)
        If Not String.IsNullOrEmpty(Record.Course) Then cboCourse.SelectedItem = Record.Course
        txtJob.Text = Record.Job
        txtContact.Text = Record.ContactNumber
        txtReason.Text = Record.ReasonForVisit
        txtSickness.Text = Record.Sickness
        txtInjury.Text = Record.Injury
        txtPrescription.Text = Record.Prescription

        If Not String.IsNullOrEmpty(Record.Gender) Then cboGender.SelectedItem = Record.Gender
        txtStudentID.Text = Record.StudentID
        If Not String.IsNullOrEmpty(Record.Year) Then cboYear.SelectedItem = Record.Year
        txtDoctor.Text = Record.DoctorAssigned

        If Record.TimeIn <> DateTime.MinValue Then dtpTimeIn.Value = Record.TimeIn
        If Record.TimeOut.HasValue Then
            chkTimeOut.Checked = True
            dtpTimeOut.Value = Record.TimeOut.Value
        Else
            chkTimeOut.Checked = False
            dtpTimeOut.Enabled = False
        End If
    End Sub

    Private Sub chkTimeOut_CheckedChanged(sender As Object, e As EventArgs) Handles chkTimeOut.CheckedChanged
        dtpTimeOut.Enabled = chkTimeOut.Checked
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Dim selectedType As String = If(cboType.SelectedItem IsNot Nothing, cboType.SelectedItem.ToString(), "")
        ' dto ni iche-check kung ano yung napili sa cboType (Student,Employee, o iba pa)
        ' at i-enable/disable ang mga related fields (cboCourse, cboYear, txtStudentID, txtJob) base sa selection.
        If selectedType = "Student" Then
            cboCourse.Enabled = True
            cboYear.Enabled = True
            txtStudentID.Enabled = True
            txtJob.Enabled = False
            txtJob.Text = ""
        ElseIf selectedType = "Employee" Then
            cboCourse.Enabled = False
            cboCourse.SelectedIndex = -1
            cboYear.Enabled = False
            cboYear.SelectedIndex = -1
            txtStudentID.Enabled = False
            txtStudentID.Text = ""
            txtJob.Enabled = True
        Else
            cboCourse.Enabled = False
            cboCourse.SelectedIndex = -1
            cboYear.Enabled = False
            cboYear.SelectedIndex = -1
            txtStudentID.Enabled = False
            txtStudentID.Text = ""
            txtJob.Enabled = False
            txtJob.Text = ""
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Eto yung method na nagse-save ng data mula sa form fields pabalik sa Record property.
        ' Iche-check nito kung may mga required fields na walang laman (e.g., Patient Name)
        ' at ipapakita ang validation error kung meron.
        Record.PatientType = cboType.SelectedItem?.ToString()
        Record.PatientName = txtName.Text
        Record.Age = CInt(numAge.Value)
        Record.Height = CDbl(numHeight.Value)
        Record.Weight = CDbl(numWeight.Value)
        Record.Course = cboCourse.SelectedItem?.ToString()
        Record.Job = txtJob.Text
        Record.ContactNumber = txtContact.Text
        Record.ReasonForVisit = txtReason.Text
        Record.Sickness = txtSickness.Text
        Record.Injury = txtInjury.Text
        Record.Prescription = txtPrescription.Text
        Record.Gender = cboGender.SelectedItem?.ToString()
        Record.StudentID = txtStudentID.Text
        Record.Year = cboYear.SelectedItem?.ToString()
        Record.DoctorAssigned = txtDoctor.Text
        Record.TimeIn = dtpTimeIn.Value

        If chkTimeOut.Checked Then
            Record.TimeOut = dtpTimeOut.Value
        Else
            Record.TimeOut = Nothing
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub VisitDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
