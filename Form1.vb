Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.IO
Imports ClosedXML.Excel

Public Class Form1
    Private dbHelper As DatabaseHelper
    Private ReadOnly PUPMaroon As Color = Color.FromArgb(128, 0, 0)

    Public Sub New()
        InitializeComponent()
        ' Pra Full screen sya
        Me.WindowState = FormWindowState.Maximized

        ' login eto, dapat may role-based access control hehe
        Dim login As New LoginForm()
        If login.ShowDialog() <> DialogResult.OK Then
            Environment.Exit(0)
            Return
        End If

        ' pra sa role-based access control, eto lang muna, pwede pang i-expand sa future
        Dim userRole As String = login.AuthenticatedRole
        Dim username As String = login.AuthenticatedUsername
        lblUserProfile.Text = $"Welcome, Dr. {username} - Clinic {userRole}"

        If userRole = "Staff" Then
            btnDelete.Enabled = False
            btnDelete.Text = "No Access"
        End If

        SetupCharts()

        'design ng datagridview, pwede pang i-improve sa future kung gusto nyo haha
        dgvVisits.EnableHeadersVisualStyles = False
        dgvVisits.ColumnHeadersDefaultCellStyle.BackColor = PUPMaroon
        dgvVisits.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvVisits.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvVisits.ColumnHeadersHeight = 40
        dgvVisits.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvVisits.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 230)
        dgvVisits.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvVisits.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        dgvVisits.RowTemplate.Height = 35
        ' koneksyon sa database, eto yung pinaka-importante, dito nagkakaroon ng error kapag hindi nakaconnect sa MySQL, kaya may try-catch block
        Try
            dbHelper = New DatabaseHelper()
            LoadData()
        Catch ex As Exception 'sure ka??
            MessageBox.Show("Could not connect to database. Is Laragon / MySQL running? Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Eto yung function na naglo-load ng data sa datagridview, may option to filter by search term at queue-only WOW ano AHAHHAHAHa
    Private Sub LoadData(Optional searchTerm As String = "")
        If dbHelper Is Nothing Then Return
        Try
            Dim records = dbHelper.GetAllVisits()
            If chkQueueOnly.Checked Then
                records = records.FindAll(Function(r) Not r.TimeOut.HasValue)
            End If
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                records = records.FindAll(Function(r) Not String.IsNullOrEmpty(r.PatientName) AndAlso r.PatientName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
            End If
            dgvVisits.DataSource = records

            ' Normalize DataGridView to only show essential information for nurses
            If dgvVisits.Columns.Count > 0 Then
                For Each col As DataGridViewColumn In dgvVisits.Columns
                    col.Visible = False
                Next

                With dgvVisits
                    .Columns("Id").Visible = True
                    .Columns("Id").HeaderText = "Visit ID"
                    .Columns("Id").Width = 80
                    .Columns("Id").DisplayIndex = 0

                    .Columns("PatientName").Visible = True
                    .Columns("PatientName").HeaderText = "Patient Name"
                    .Columns("PatientName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Columns("PatientName").DisplayIndex = 1

                    .Columns("PatientType").Visible = True
                    .Columns("PatientType").HeaderText = "Type"
                    .Columns("PatientType").Width = 100
                    .Columns("PatientType").DisplayIndex = 2

                    .Columns("Sickness").Visible = True
                    .Columns("Sickness").HeaderText = "Condition"
                    .Columns("Sickness").Width = 150
                    .Columns("Sickness").DisplayIndex = 3

                    .Columns("TimeIn").Visible = True
                    .Columns("TimeIn").HeaderText = "Time In"
                    .Columns("TimeIn").DefaultCellStyle.Format = "MMM dd, hh:mm tt"
                    .Columns("TimeIn").Width = 150
                    .Columns("TimeIn").DisplayIndex = 4

                    .Columns("TimeOut").Visible = True
                    .Columns("TimeOut").HeaderText = "Time Out"
                    .Columns("TimeOut").DefaultCellStyle.Format = "MMM dd, hh:mm tt"
                    .Columns("TimeOut").Width = 150
                    .Columns("TimeOut").DisplayIndex = 5

                    .Columns("DoctorAssigned").Visible = True
                    .Columns("DoctorAssigned").HeaderText = "Doctor Assigned"
                    .Columns("DoctorAssigned").Width = 150
                    .Columns("DoctorAssigned").DisplayIndex = 6
                End With
            End If

            dgvVisits.ClearSelection() 'piipigilan na ma-select yung first row after mag-load ng data, para hindi agad may naka-highlight sa record

            UpdateRecentActivities(records)
            UpdateCharts(records)

            ' pang update ng statistics sa dashboard, eto yung mga labels sa taas, pwede pang i-improve sa future kung gusto nyo haha 
            ' (sana all ni u-update)
            Dim numStudents = dbHelper.GetTotalStudents()
            Dim numEmployees = dbHelper.GetTotalEmployees()
            lblStatVisitsCount.Text = dbHelper.GetTotalVisitsToday().ToString()
            lblStatStudentsCount.Text = numStudents.ToString()
            lblStatEmployeesCount.Text = numEmployees.ToString()

            ' 1. Low Inventory Alerts
            Dim inventory = dbHelper.GetInventory()
            Dim lowStockItems = inventory.Where(Function(i) i.StockQuantity <= 10).ToList()
            If lowStockItems.Count > 0 Then
                lblStatAlertsCount.Text = lowStockItems.Count.ToString()
                pnlStatAlerts.BackColor = Color.LightCoral
                lblStatAlertsCount.ForeColor = Color.White
                lblStatAlertsTitle.ForeColor = Color.White
            Else
                lblStatAlertsCount.Text = "0"
                pnlStatAlerts.BackColor = Color.White
                lblStatAlertsCount.ForeColor = Color.Green
                lblStatAlertsTitle.ForeColor = Color.Green
            End If

            ' 2. Today's Appointments
            UpdateTodayAppointments()

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    ' Eto yung event handler para sa search box, every time mag-change yung text, magre-refresh yung data sa grid based sa ni search
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadData(txtSearch.Text)
    End Sub
    ' Eto yung event handler para sa "Add Visit" button, magbubukas ng new form para mag-input ng details ng visit
    ' ,tapos pag na-save, mag-iinsert sa database at magre-refresh na ang data sa grid
    Private Sub btnAddVisit_Click(sender As Object, e As EventArgs) Handles btnAddVisit.Click
        If dbHelper Is Nothing Then Return
        Dim detailsForm As New VisitDetailsForm()
        If detailsForm.ShowDialog() = DialogResult.OK Then
            Try
                dbHelper.InsertVisit(detailsForm.Record)
                If Not String.IsNullOrWhiteSpace(detailsForm.Record.Prescription) Then
                    dbHelper.DeductInventory(detailsForm.Record.Prescription.Trim(), 1)
                End If
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Error adding record: " & ex.Message)
            End Try
        End If
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Eto yung event handler para sa "Edit" button, magbubukas ng new form na may pre-filled details ng selected record,
        ' pwede i-edit tapos pag na-save mag-uupdate sa database at magre-refresh ang data sa grid
        If dbHelper Is Nothing Then Return
        If dgvVisits.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to edit.")
            Return
        End If
        If dgvVisits.SelectedRows.Count > 1 Then
            MessageBox.Show("Please select only one record to edit.")
            Return
        End If

        Dim selectedRecord As VisitRecord = CType(dgvVisits.SelectedRows(0).DataBoundItem, VisitRecord)
        Dim detailsForm As New VisitDetailsForm(selectedRecord)
        If detailsForm.ShowDialog() = DialogResult.OK Then
            Try
                dbHelper.UpdateVisit(detailsForm.Record)
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Error updating record: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Eto yung event handler para sa "Delete" button, magde-delete ng selected record sa database at magre-refresh ang data sa grid
        If dbHelper Is Nothing Then Return
        If dgvVisits.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.")
            Return
        End If

        If MessageBox.Show($"Are you sure you want to delete {dgvVisits.SelectedRows.Count} selected record(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                For Each row As DataGridViewRow In dgvVisits.SelectedRows
                    Dim selectedRecord As VisitRecord = CType(row.DataBoundItem, VisitRecord)
                    dbHelper.DeleteVisit(selectedRecord.Id)
                Next
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Error deleting record(s): " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData(txtSearch.Text)
    End Sub

    Private Sub chkQueueOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkQueueOnly.CheckedChanged
        LoadData(txtSearch.Text)
    End Sub


    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        ' Eto yung event handler para sa "Check Out" button, magse-set ng TimeOut ng selected record sa current time,
        ' tapos mag-uupdate sa database at magre-refresh ang data sa grid
        If dbHelper Is Nothing Then Return
        If dgvVisits.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select patient(s) in queue to check out.")
            Return
        End If

        Dim recordsToCheckOut As New List(Of VisitRecord)()
        For Each row As DataGridViewRow In dgvVisits.SelectedRows
            Dim selectedRecord As VisitRecord = CType(row.DataBoundItem, VisitRecord)
            If Not selectedRecord.TimeOut.HasValue Then
                recordsToCheckOut.Add(selectedRecord)
            End If
        Next

        If recordsToCheckOut.Count = 0 Then
            MessageBox.Show("The selected patient(s) are already checked out.", "Already Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Are you sure you want to check out {recordsToCheckOut.Count} patient(s)?", "Confirm Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                For Each record In recordsToCheckOut
                    record.TimeOut = DateTime.Now
                    dbHelper.UpdateVisit(record)
                Next
                LoadData(txtSearch.Text)
                MessageBox.Show("Patient(s) checked out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error checking out patient(s): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        LoadData()
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
    End Sub


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Eto yung event handler para sa "Export to Excel" button, mag-eexport ng data sa grid papuntang Excel file gamit ang 'ClosedXML library'

        ' ano ngaba ang ClosedXML? Eto yung library na nagpapadali ng pag-create at pag-manipulate ng Excel files sa
        ' .NET, kaya hindi na natin kailangan mag-deal with the complexities ng raw Excel file formats,
        ' at nagbibigay ito ng simple API para mag-add ng worksheets, mag-set ng cell values, mag-format ng cells,
        ' at marami pang iba. Sa code na ito, nag-create tayo ng new workbook, nag-add ng worksheet, nag-populate ng headers
        ' at rows base sa data sa grid, tapos nag-save ng file gamit ang SaveFileDialog para pumili kung saan i-save yung Excel file.
        If dgvVisits.Rows.Count = 0 Then
            MessageBox.Show("No records to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "Excel Files|*.xlsx"
            sfd.FileName = "ClinicVisits_Export_" & DateTime.Now.ToString("yyyyMMdd") & ".xlsx"
            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using workbook As New XLWorkbook()
                        Dim worksheet = workbook.Worksheets.Add("Visits")

                        ' Headers
                        For colIdx As Integer = 0 To dgvVisits.Columns.Count - 1
                            Dim cell = worksheet.Cell(1, colIdx + 1)
                            cell.Value = dgvVisits.Columns(colIdx).HeaderText
                            cell.Style.Font.Bold = True
                            cell.Style.Fill.BackgroundColor = XLColor.FromArgb(128, 0, 0)
                            cell.Style.Font.FontColor = XLColor.White
                        Next

                        ' Rows
                        For rowIdx As Integer = 0 To dgvVisits.Rows.Count - 1
                            For colIdx As Integer = 0 To dgvVisits.Columns.Count - 1
                                Dim val = dgvVisits.Rows(rowIdx).Cells(colIdx).Value
                                Dim cell = worksheet.Cell(rowIdx + 2, colIdx + 1)

                                If val IsNot Nothing Then
                                    If dgvVisits.Columns(colIdx).HeaderText = "ContactNumber" Then
                                        cell.Style.NumberFormat.Format = "@"
                                        cell.Value = val.ToString()
                                    ElseIf TypeOf val Is DateTime Then
                                        cell.Value = CType(val, DateTime)
                                        cell.Style.DateFormat.Format = "mm/dd/yyyy hh:mm AM/PM"
                                    Else
                                        cell.Value = val.ToString()
                                    End If
                                Else
                                    cell.Value = ""
                                End If
                            Next
                        Next

                        worksheet.Columns().AdjustToContents()
                        workbook.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("Export completed successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error exporting file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim invForm As New InventoryForm()
        invForm.ShowDialog()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim settings As New SettingsForm()
        settings.ShowDialog()
    End Sub

    Private Sub btnAppointments_Click(sender As Object, e As EventArgs) Handles btnAppointments.Click
        Dim appts As New AppointmentsForm()
        appts.ShowDialog()
    End Sub



    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        ' Eto yung event handler para sa "View History" button, magfi-filter ng data sa grid para ipakita lahat ng records ng selected patient
        If dgvVisits.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a patient to view their history.", "View History", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If dgvVisits.SelectedRows.Count > 1 Then
            MessageBox.Show("Please select only one patient to view their history.", "View History", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRecord As VisitRecord = CType(dgvVisits.SelectedRows(0).DataBoundItem, VisitRecord)

        ' Set the search box to the patient's exact name
        txtSearch.Text = selectedRecord.PatientName

        ' Filter the grid using LoadData
        LoadData(txtSearch.Text)
    End Sub




    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Eto yung event handler para sa "Print" button, magpi-print ng medical excuse slip para sa selected record gamit ang PrintDocument
        ' Sa code na ito, nag-create tayo ng new PrintDocument, nag-define ng PrintPage event handler para mag-draw ng content ng medical excuse
        ' slip gamit ang Graphics object, which is panget pa ang design pero functional na, tapos nag-show ng PrintPreviewDialog para makita muna
        ' yung preview bago mag-print.
        If dgvVisits.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If dgvVisits.SelectedRows.Count > 1 Then
            MessageBox.Show("Please select only one record to print at a time.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRecord As VisitRecord = CType(dgvVisits.SelectedRows(0).DataBoundItem, VisitRecord)

        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, Sub(s, ev)
                                     Dim g = ev.Graphics
                                     Dim leftMargin As Single = ev.MarginBounds.Left
                                     Dim topMargin As Single = ev.MarginBounds.Top
                                     Dim pageWidth As Single = ev.MarginBounds.Width
                                     Dim yPos As Single = topMargin

                                     Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
                                     Dim subTitleFont As New Font("Arial", 12, FontStyle.Regular)
                                     Dim headerFont As New Font("Arial", 22, FontStyle.Bold)
                                     Dim labelFont As New Font("Arial", 12, FontStyle.Bold)
                                     Dim valFont As New Font("Arial", 12, FontStyle.Regular)

                                     ' Draw Logo
                                     Try
                                         Dim projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName
                                         Dim logoPath = Path.Combine(projectPath, "Iska-Care-main\iska-care\images\pup.png")
                                         If File.Exists(logoPath) Then
                                             Dim logo As Image = Image.FromFile(logoPath)
                                             g.DrawImage(logo, leftMargin, topMargin, 80, 80)
                                         End If
                                     Catch ex As Exception
                                     End Try

                                     ' Draw Headers
                                     Dim centerFormat As New StringFormat() With {.Alignment = StringAlignment.Center}
                                     g.DrawString("Republic of the Philippines", subTitleFont, Brushes.Black, leftMargin + (pageWidth / 2), yPos, centerFormat)
                                     yPos += 20
                                     g.DrawString("POLYTECHNIC UNIVERSITY OF THE PHILIPPINES", titleFont, Brushes.Black, leftMargin + (pageWidth / 2), yPos, centerFormat)
                                     yPos += 25
                                     g.DrawString("Bataan Branch", subTitleFont, Brushes.Black, leftMargin + (pageWidth / 2), yPos, centerFormat)
                                     yPos += 50

                                     g.DrawString("MEDICAL EXCUSE SLIP", headerFont, Brushes.Black, leftMargin + (pageWidth / 2), yPos, centerFormat)
                                     yPos += 50

                                     ' Draw Box
                                     Dim boxRect As New Rectangle(CInt(leftMargin), CInt(yPos), CInt(pageWidth), 350)
                                     g.DrawRectangle(Pens.Black, boxRect)

                                     yPos += 20
                                     Dim xLeft = leftMargin + 20
                                     Dim xMid = leftMargin + (pageWidth / 2) + 20

                                     g.DrawString("Date:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.TimeIn.ToString("MM/dd/yyyy"), valFont, Brushes.Black, xLeft + 60, yPos)

                                     g.DrawString("Time In:", labelFont, Brushes.Black, xMid, yPos)
                                     g.DrawString(selectedRecord.TimeIn.ToString("hh:mm tt"), valFont, Brushes.Black, xMid + 80, yPos)
                                     yPos += 40

                                     g.DrawString("Patient Name:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.PatientName, valFont, Brushes.Black, xLeft + 120, yPos)
                                     yPos += 40

                                     g.DrawString("Type:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.PatientType, valFont, Brushes.Black, xLeft + 60, yPos)

                                     g.DrawString("Age:", labelFont, Brushes.Black, xMid, yPos)
                                     g.DrawString(selectedRecord.Age, valFont, Brushes.Black, xMid + 50, yPos)
                                     yPos += 40

                                     If selectedRecord.PatientType = "Student" Then
                                         g.DrawString("Course/Year:", labelFont, Brushes.Black, xLeft, yPos)
                                         g.DrawString($"{selectedRecord.Course} - {selectedRecord.Year}", valFont, Brushes.Black, xLeft + 110, yPos)
                                     ElseIf selectedRecord.PatientType = "Employee" Then
                                         g.DrawString("Job Title:", labelFont, Brushes.Black, xLeft, yPos)
                                         g.DrawString(selectedRecord.Job, valFont, Brushes.Black, xLeft + 90, yPos)
                                     End If
                                     yPos += 50

                                     g.DrawString("Reason for Visit:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.ReasonForVisit, valFont, Brushes.Black, xLeft + 140, yPos)
                                     yPos += 40

                                     g.DrawString("Diagnosis/Sickness:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.Sickness, valFont, Brushes.Black, xLeft + 180, yPos)
                                     yPos += 40

                                     g.DrawString("Prescription:", labelFont, Brushes.Black, xLeft, yPos)
                                     g.DrawString(selectedRecord.Prescription, valFont, Brushes.Black, xLeft + 110, yPos)
                                     yPos += 80

                                     ' Signatures
                                     g.DrawString("___________________________", labelFont, Brushes.Black, leftMargin + pageWidth - 250, yPos)
                                     yPos += 20
                                     g.DrawString("Attending Nurse / Doctor", valFont, Brushes.Black, leftMargin + pageWidth - 230, yPos)

                                     ev.HasMorePages = False
                                 End Sub

        Dim ppd As New PrintPreviewDialog()
        ppd.Document = pd
        ppd.Width = 800
        ppd.Height = 1000
        ppd.ShowDialog()
    End Sub

    Private Sub lblStatEmployeesCount_Click(sender As Object, e As EventArgs) Handles lblStatEmployeesCount.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private formsPlotLine As ScottPlot.WinForms.FormsPlot
    Private formsPlotBar As ScottPlot.WinForms.FormsPlot
    Private formsPlotPie As ScottPlot.WinForms.FormsPlot


    ' Eto yung function para i-setup yung charts sa dashboard,
    ' nag-create tayo ng 3 FormsPlot controls para sa line, bar,
    ' at pie charts, tapos ni-add natin sila sa panel na pnlCharts
    Private Sub SetupCharts()
        formsPlotLine = New ScottPlot.WinForms.FormsPlot() With {.Dock = DockStyle.Left, .Width = 500}
        formsPlotBar = New ScottPlot.WinForms.FormsPlot() With {.Dock = DockStyle.Left, .Width = 500}
        formsPlotPie = New ScottPlot.WinForms.FormsPlot() With {.Dock = DockStyle.Fill}

        pnlCharts.Controls.Add(formsPlotPie)
        pnlCharts.Controls.Add(formsPlotBar)
        pnlCharts.Controls.Add(formsPlotLine)
    End Sub


    ' Eto yung function para i-update yung charts sa dashboard base sa data ng visit records,
    ' nag-clear muna ng existing plots, tapos nag-generate ng new data para sa bawat chart at ni-plot gamit ang ScottPlot library.

    ' ano ngaba and ScottPlot? Eto yung open-source plotting library para sa .NET na nagpapadali ng pag-create ng interactive
    ' at high-performance charts sa Windows Forms, WPF, at Avalonia applications. Sa code na ito,
    ' ginagamit natin ang ScottPlot para mag-plot ng line chart para sa weekly admissions,
    ' bar chart para sa queue by time period, at pie chart para sa top conditions. (Wow galing noh?)
    Private Sub UpdateCharts(records As List(Of VisitRecord))
        If formsPlotLine Is Nothing Then Return

        formsPlotLine.Plot.Clear()
        formsPlotBar.Plot.Clear()
        formsPlotPie.Plot.Clear()

        ' Weekly Admissions (Line Chart)
        Dim last7Days = Enumerable.Range(0, 7).Select(Function(i) DateTime.Today.AddDays(-i)).Reverse().ToList()
        Dim counts = last7Days.Select(Function(d) records.Where(Function(r) r.TimeIn.Date = d).Count()).ToArray()
        Dim datesAsDouble = last7Days.Select(Function(d) d.ToOADate()).ToArray()
        If datesAsDouble.Length > 0 Then
            Dim sig = formsPlotLine.Plot.Add.Scatter(datesAsDouble, counts.Select(Function(c) CDbl(c)).ToArray())
            sig.Color = ScottPlot.Color.FromHex("#c40202")
            formsPlotLine.Plot.Axes.DateTimeTicksBottom()
            formsPlotLine.Plot.Title("Weekly Admissions")
        End If

        ' Queue by Time Period (Bar Chart)
        Dim morning = records.Where(Function(r) r.TimeIn.Hour >= 6 AndAlso r.TimeIn.Hour < 12).Count()
        Dim afternoon = records.Where(Function(r) r.TimeIn.Hour >= 12 AndAlso r.TimeIn.Hour < 18).Count()
        Dim evening = records.Where(Function(r) r.TimeIn.Hour >= 18).Count()
        Dim barPlot = formsPlotBar.Plot.Add.Bars(New Double() {morning, afternoon, evening})
        formsPlotBar.Plot.Title("Queue by Time Period")

        ' Top Conditions (Pie Chart)
        Dim conditions = records.Where(Function(r) Not String.IsNullOrEmpty(r.Sickness)).GroupBy(Function(r) r.Sickness).Select(Function(g) New With {.Name = g.Key, .Count = g.Count()}).OrderByDescending(Function(x) x.Count).Take(5).ToList()
        If conditions.Count > 0 Then
            Dim pieSlices As New List(Of ScottPlot.PieSlice)()
            For Each c In conditions
                pieSlices.Add(New ScottPlot.PieSlice() With {.Value = c.Count, .Label = c.Name})
            Next
            formsPlotPie.Plot.Add.Pie(pieSlices)
            formsPlotPie.Plot.Title("Top Conditions")
        End If

        formsPlotLine.Refresh()
        formsPlotBar.Refresh()
        formsPlotPie.Refresh()
    End Sub


    ' Eto yung function para i-update yung "Recent Activities" panel sa dashboard,
    ' nag-clear muna ng existing controls sa panel, tapos nag-add ng new labels para sa pinaka-recent 5 visits base sa TimeIn ng records.
    ' Kung walang recent visits, magpapakita ng message na "No recent visits."
    Private Sub UpdateRecentActivities(records As List(Of VisitRecord))
        If pnlRecent Is Nothing Then Return
        pnlRecent.Controls.Clear()
        Dim recentLabel As New Label With {.Text = "Recent Activities", .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.Maroon, .AutoSize = True, .Margin = New Padding(0, 0, 0, 10)}
        pnlRecent.Controls.Add(recentLabel)

        Dim recentVisits = records.OrderByDescending(Function(r) r.TimeIn).Take(5).ToList()
        If recentVisits.Count = 0 Then
            pnlRecent.Controls.Add(New Label With {.Text = "No recent visits.", .AutoSize = True})
        Else
            For Each visit In recentVisits
                Dim visitLabel As New Label With {
                    .Text = $"{visit.PatientName}{vbCrLf}{visit.Sickness}{vbCrLf}{visit.TimeIn.ToString("MMM d, yyyy")}",
                    .AutoSize = True,
                    .Margin = New Padding(0, 0, 0, 10),
                    .Padding = New Padding(5),
                    .BackColor = Color.WhiteSmoke,
                    .Width = pnlRecent.Width - 30
                }
                pnlRecent.Controls.Add(visitLabel)
            Next
        End If
    End Sub

    Private Sub UpdateTodayAppointments()

        ' Eto yung function para i-update yung "Today's Appointments" panel sa dashboard,
        ' nag-clear muna ng existing controls sa panel, tapos nag-add ng new labels para sa lahat ng
        ' appointments na naka-schedule sa current date base sa data mula sa database.
        If pnlTodayAppointments Is Nothing Then Return
        pnlTodayAppointments.Controls.Clear()
        Dim apptLabel As New Label With {.Text = "Today's Appointments", .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.Maroon, .AutoSize = True, .Margin = New Padding(0, 0, 0, 10)}
        pnlTodayAppointments.Controls.Add(apptLabel)

        Dim todayAppts = dbHelper.GetAppointments(DateTime.Today)
        If todayAppts.Count = 0 Then
            pnlTodayAppointments.Controls.Add(New Label With {.Text = "No appointments today.", .AutoSize = True})
        Else
            For Each appt In todayAppts
                Dim lbl As New Label With {
                    .Text = $"{appt.PatientName}{vbCrLf}{appt.Reason}{vbCrLf}{appt.AppointmentDate.ToString("hh:mm tt")}",
                    .AutoSize = True,
                    .Margin = New Padding(0, 0, 0, 10),
                    .Padding = New Padding(5),
                    .BackColor = Color.WhiteSmoke,
                    .Width = pnlTodayAppointments.Width - 30
                }
                pnlTodayAppointments.Controls.Add(lbl)
            Next
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim about As New AboutForm()
        about.ShowDialog()
    End Sub
End Class
