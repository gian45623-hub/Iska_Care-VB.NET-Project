<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        pnlSidebar = New Panel()
        btnSettings = New Button()
        btnAppointments = New Button()
        btnInventory = New Button()
        btnAddVisit = New Button()
        btnDashboard = New Button()
        lblTitle = New Label()
        pnlHeader = New Panel()
        btnHistory = New Button()
        btnCheckOut = New Button()
        chkQueueOnly = New CheckBox()
        btnPrint = New Button()
        btnExport = New Button()
        btnRefresh = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        lblHeaderTitle = New Label()
        lblUserProfile = New Label()
        pnlContent = New Panel()
        pnlCharts = New Panel()
        pnlRecent = New FlowLayoutPanel()
        dgvVisits = New DataGridView()
        btnAbout = New Button()
        pnlStats = New Panel()
        pnlStatAlerts = New Panel()
        lblStatAlertsTitle = New Label()
        lblStatAlertsCount = New Label()
        pnlStatVisits = New Panel()
        lblStatVisitsTitle = New Label()
        lblStatVisitsCount = New Label()
        pnlStatStudents = New Panel()
        lblStatStudentsTitle = New Label()
        lblStatStudentsCount = New Label()
        pnlStatEmployees = New Panel()
        lblStatEmployeesTitle = New Label()
        lblStatEmployeesCount = New Label()
        pnlSidebar.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlContent.SuspendLayout()
        CType(dgvVisits, ComponentModel.ISupportInitialize).BeginInit()
        pnlRightSidebar = New Panel()
        pnlRightSidebar.SuspendLayout()
        pnlStats.SuspendLayout()
        pnlStatAlerts.SuspendLayout()
        pnlStatVisits.SuspendLayout()
        pnlStatStudents.SuspendLayout()
        pnlStatEmployees.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        pnlSidebar.Controls.Add(btnSettings)
        pnlSidebar.Controls.Add(btnAbout)
        pnlSidebar.Controls.Add(btnAppointments)
        pnlSidebar.Controls.Add(btnInventory)
        pnlSidebar.Controls.Add(btnAddVisit)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Controls.Add(lblTitle)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Margin = New Padding(3, 4, 3, 4)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(251, 1033)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnSettings
        ' 
        btnSettings.Cursor = Cursors.Hand
        btnSettings.Dock = DockStyle.Bottom
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Segoe UI", 11F)
        btnSettings.ForeColor = Color.White
        btnSettings.Location = New Point(0, 966)
        btnSettings.Margin = New Padding(3, 4, 3, 4)
        btnSettings.Name = "btnSettings"
        btnSettings.Padding = New Padding(23, 0, 0, 0)
        btnSettings.Size = New Size(251, 67)
        btnSettings.TabIndex = 4
        btnSettings.Text = "Settings"
        btnSettings.TextAlign = ContentAlignment.MiddleLeft
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' btnAbout
        ' 
        btnAbout.Cursor = Cursors.Hand
        btnAbout.Dock = DockStyle.Top
        btnAbout.FlatAppearance.BorderSize = 0
        btnAbout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnAbout.FlatStyle = FlatStyle.Flat
        btnAbout.Font = New Font("Segoe UI", 11F)
        btnAbout.ForeColor = Color.White
        btnAbout.Location = New Point(0, 308)
        btnAbout.Name = "btnAbout"
        btnAbout.Padding = New Padding(23, 0, 0, 0)
        btnAbout.Size = New Size(251, 67)
        btnAbout.TabIndex = 6
        btnAbout.Text = "About Us"
        btnAbout.TextAlign = ContentAlignment.MiddleLeft
        btnAbout.UseVisualStyleBackColor = True
        ' 
        ' btnAppointments
        ' 
        btnAppointments.Cursor = Cursors.Hand
        btnAppointments.Dock = DockStyle.Top
        btnAppointments.FlatAppearance.BorderSize = 0
        btnAppointments.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnAppointments.FlatStyle = FlatStyle.Flat
        btnAppointments.Font = New Font("Segoe UI", 11F)
        btnAppointments.ForeColor = Color.White
        btnAppointments.Location = New Point(0, 375)
        btnAppointments.Name = "btnAppointments"
        btnAppointments.Padding = New Padding(23, 0, 0, 0)
        btnAppointments.Size = New Size(251, 67)
        btnAppointments.TabIndex = 5
        btnAppointments.Text = "Appointments"
        btnAppointments.TextAlign = ContentAlignment.MiddleLeft
        btnAppointments.UseVisualStyleBackColor = True
        ' 
        ' btnInventory
        ' 
        btnInventory.Cursor = Cursors.Hand
        btnInventory.Dock = DockStyle.Top
        btnInventory.FlatAppearance.BorderSize = 0
        btnInventory.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnInventory.FlatStyle = FlatStyle.Flat
        btnInventory.Font = New Font("Segoe UI", 11F)
        btnInventory.ForeColor = Color.White
        btnInventory.Location = New Point(0, 241)
        btnInventory.Margin = New Padding(3, 4, 3, 4)
        btnInventory.Name = "btnInventory"
        btnInventory.Padding = New Padding(23, 0, 0, 0)
        btnInventory.Size = New Size(251, 67)
        btnInventory.TabIndex = 3
        btnInventory.Text = "Inventory"
        btnInventory.TextAlign = ContentAlignment.MiddleLeft
        btnInventory.UseVisualStyleBackColor = True
        ' 
        ' btnAddVisit
        ' 
        btnAddVisit.Cursor = Cursors.Hand
        btnAddVisit.Dock = DockStyle.Top
        btnAddVisit.FlatAppearance.BorderSize = 0
        btnAddVisit.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnAddVisit.FlatStyle = FlatStyle.Flat
        btnAddVisit.Font = New Font("Segoe UI", 11F)
        btnAddVisit.ForeColor = Color.White
        btnAddVisit.Location = New Point(0, 174)
        btnAddVisit.Margin = New Padding(3, 4, 3, 4)
        btnAddVisit.Name = "btnAddVisit"
        btnAddVisit.Padding = New Padding(23, 0, 0, 0)
        btnAddVisit.Size = New Size(251, 67)
        btnAddVisit.TabIndex = 2
        btnAddVisit.Text = "Add New Visit"
        btnAddVisit.TextAlign = ContentAlignment.MiddleLeft
        btnAddVisit.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.Cursor = Cursors.Hand
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI", 11F)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 107)
        btnDashboard.Margin = New Padding(3, 4, 3, 4)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(23, 0, 0, 0)
        btnDashboard.Size = New Size(251, 67)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(251, 107)
        lblTitle.TabIndex = 0
        lblTitle.Text = "ISKA CARE"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(btnCheckOut)
        pnlHeader.Controls.Add(chkQueueOnly)
        pnlHeader.Controls.Add(btnHistory)
        pnlHeader.Controls.Add(btnPrint)
        pnlHeader.Controls.Add(btnExport)
        pnlHeader.Controls.Add(btnRefresh)
        pnlHeader.Controls.Add(btnDelete)
        pnlHeader.Controls.Add(btnEdit)
        pnlHeader.Controls.Add(txtSearch)
        pnlHeader.Controls.Add(lblSearch)
        pnlHeader.Controls.Add(lblHeaderTitle)
        pnlHeader.Controls.Add(lblUserProfile)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(251, 0)
        pnlHeader.Margin = New Padding(3, 4, 3, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1651, 93)
        pnlHeader.TabIndex = 1
        ' 
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.White
        btnHistory.Cursor = Cursors.Hand
        btnHistory.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnHistory.FlatStyle = FlatStyle.Flat
        btnHistory.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnHistory.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnHistory.Location = New Point(885, 20)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(95, 32)
        btnHistory.TabIndex = 8
        btnHistory.Text = "View History"
        btnHistory.UseVisualStyleBackColor = False
        ' 
        ' btnCheckOut
        ' 
        btnCheckOut.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnCheckOut.Cursor = Cursors.Hand
        btnCheckOut.FlatAppearance.BorderSize = 0
        btnCheckOut.FlatStyle = FlatStyle.Flat
        btnCheckOut.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnCheckOut.ForeColor = Color.White
        btnCheckOut.Location = New Point(985, 20)
        btnCheckOut.Name = "btnCheckOut"
        btnCheckOut.Size = New Size(95, 32)
        btnCheckOut.TabIndex = 9
        btnCheckOut.Text = "Check Out"
        btnCheckOut.UseVisualStyleBackColor = False
        ' 
        ' chkQueueOnly
        ' 
        chkQueueOnly.AutoSize = True
        chkQueueOnly.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        chkQueueOnly.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        chkQueueOnly.Location = New Point(1090, 25)
        chkQueueOnly.Name = "chkQueueOnly"
        chkQueueOnly.Size = New Size(111, 24)
        chkQueueOnly.TabIndex = 10
        chkQueueOnly.Text = "Queue Only"
        chkQueueOnly.UseVisualStyleBackColor = True
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.White
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnPrint.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPrint.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnPrint.Location = New Point(790, 20)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(90, 32)
        btnPrint.TabIndex = 7
        btnPrint.Text = "Print Slip"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.White
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnExport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExport.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnExport.Location = New Point(695, 20)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(90, 32)
        btnExport.TabIndex = 6
        btnExport.Text = "Export CSV"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.White
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnRefresh.Location = New Point(610, 20)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(80, 32)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.White
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnDelete.Location = New Point(525, 20)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 32)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.White
        btnEdit.Cursor = Cursors.Hand
        btnEdit.FlatAppearance.BorderColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        btnEdit.Location = New Point(430, 20)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(90, 32)
        btnEdit.TabIndex = 3
        btnEdit.Text = "Edit Selected"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(250, 21)
        txtSearch.Margin = New Padding(3, 4, 3, 4)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(160, 30)
        txtSearch.TabIndex = 2
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 10F)
        lblSearch.Location = New Point(169, 24)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(65, 23)
        lblSearch.TabIndex = 1
        lblSearch.Text = "Search:"
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblHeaderTitle.Location = New Point(6, 29)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(157, 37)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "Dashboard"
        '
        ' lblUserProfile
        '
        lblUserProfile.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblUserProfile.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblUserProfile.Location = New Point(1250, 25)
        lblUserProfile.Name = "lblUserProfile"
        lblUserProfile.Size = New Size(380, 23)
        lblUserProfile.TabIndex = 11
        lblUserProfile.Text = "Welcome"
        lblUserProfile.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' pnlContent
        ' 
        pnlContent.Controls.Add(dgvVisits)
        pnlContent.Controls.Add(pnlRightSidebar)
        pnlContent.Controls.Add(pnlCharts)
        pnlContent.Controls.Add(pnlStats)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(251, 93)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(23, 27, 23, 27)
        pnlContent.Size = New Size(1651, 940)
        pnlContent.TabIndex = 2
        '
        ' pnlRightSidebar
        '
        pnlRightSidebar.Dock = DockStyle.Right
        pnlRightSidebar.Location = New Point(1328, 497)
        pnlRightSidebar.Name = "pnlRightSidebar"
        pnlRightSidebar.Size = New Size(300, 416)
        pnlRightSidebar.Controls.Add(pnlTodayAppointments)
        pnlRightSidebar.Controls.Add(pnlRecent)
        '
        ' pnlRecent
        '
        pnlRecent.Dock = DockStyle.Top
        pnlRecent.AutoScroll = True
        pnlRecent.Location = New Point(0, 0)
        pnlRecent.Name = "pnlRecent"
        pnlRecent.Size = New Size(300, 208)
        pnlRecent.Padding = New Padding(10)
        pnlRecent.BackColor = Color.White
        '
        ' pnlTodayAppointments
        '
        pnlTodayAppointments = New FlowLayoutPanel()
        pnlTodayAppointments.Dock = DockStyle.Bottom
        pnlTodayAppointments.AutoScroll = True
        pnlTodayAppointments.Location = New Point(0, 208)
        pnlTodayAppointments.Name = "pnlTodayAppointments"
        pnlTodayAppointments.Size = New Size(300, 208)
        pnlTodayAppointments.Padding = New Padding(10)
        pnlTodayAppointments.BackColor = Color.WhiteSmoke
        '
        ' pnlCharts
        '
        pnlCharts.Dock = DockStyle.Top
        pnlCharts.Location = New Point(23, 147)
        pnlCharts.Name = "pnlCharts"
        pnlCharts.Size = New Size(1605, 350)
        pnlCharts.Padding = New Padding(0, 0, 0, 20)
        ' 
        ' dgvVisits
        ' 
        dgvVisits.AllowUserToAddRows = False
        dgvVisits.AllowUserToDeleteRows = False
        dgvVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvVisits.BackgroundColor = Color.White
        dgvVisits.BorderStyle = BorderStyle.None
        dgvVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVisits.Dock = DockStyle.Fill
        dgvVisits.Location = New Point(23, 497)
        dgvVisits.Name = "dgvVisits"
        dgvVisits.ReadOnly = True
        dgvVisits.RowHeadersVisible = False
        dgvVisits.RowHeadersWidth = 51
        dgvVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVisits.Size = New Size(1305, 416)
        dgvVisits.TabIndex = 0
        ' 
        ' pnlStats
        ' 
        pnlStats.Controls.Add(pnlStatAlerts)
        pnlStats.Controls.Add(pnlStatVisits)
        pnlStats.Controls.Add(pnlStatStudents)
        pnlStats.Controls.Add(pnlStatEmployees)
        pnlStats.Dock = DockStyle.Top
        pnlStats.Location = New Point(23, 27)
        pnlStats.Name = "pnlStats"
        pnlStats.Padding = New Padding(0, 0, 0, 20)
        pnlStats.Size = New Size(1605, 120)
        pnlStats.TabIndex = 1
        ' 
        ' pnlStatAlerts
        ' 
        pnlStatAlerts.BackColor = Color.White
        pnlStatAlerts.Controls.Add(lblStatAlertsTitle)
        pnlStatAlerts.Controls.Add(lblStatAlertsCount)
        pnlStatAlerts.Dock = DockStyle.Left
        pnlStatAlerts.Location = New Point(780, 0)
        pnlStatAlerts.Margin = New Padding(20, 0, 0, 0)
        pnlStatAlerts.Name = "pnlStatAlerts"
        pnlStatAlerts.Size = New Size(260, 100)
        pnlStatAlerts.TabIndex = 3
        ' 
        ' lblStatAlertsTitle
        ' 
        lblStatAlertsTitle.Dock = DockStyle.Top
        lblStatAlertsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblStatAlertsTitle.ForeColor = Color.Red
        lblStatAlertsTitle.Location = New Point(0, 0)
        lblStatAlertsTitle.Name = "lblStatAlertsTitle"
        lblStatAlertsTitle.Size = New Size(260, 30)
        lblStatAlertsTitle.TabIndex = 0
        lblStatAlertsTitle.Text = "LOW INVENTORY ALERTS"
        lblStatAlertsTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatAlertsCount
        ' 
        lblStatAlertsCount.Dock = DockStyle.Fill
        lblStatAlertsCount.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblStatAlertsCount.ForeColor = Color.Red
        lblStatAlertsCount.Location = New Point(0, 0)
        lblStatAlertsCount.Name = "lblStatAlertsCount"
        lblStatAlertsCount.Size = New Size(260, 100)
        lblStatAlertsCount.TabIndex = 1
        lblStatAlertsCount.Text = "0"
        lblStatAlertsCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlStatVisits
        ' 
        pnlStatVisits.BackColor = Color.White
        pnlStatVisits.Controls.Add(lblStatVisitsTitle)
        pnlStatVisits.Controls.Add(lblStatVisitsCount)
        pnlStatVisits.Dock = DockStyle.Left
        pnlStatVisits.Location = New Point(520, 0)
        pnlStatVisits.Name = "pnlStatVisits"
        pnlStatVisits.Size = New Size(260, 100)
        pnlStatVisits.TabIndex = 0
        ' 
        ' lblStatVisitsTitle
        ' 
        lblStatVisitsTitle.Dock = DockStyle.Top
        lblStatVisitsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblStatVisitsTitle.ForeColor = Color.Gray
        lblStatVisitsTitle.Location = New Point(0, 0)
        lblStatVisitsTitle.Name = "lblStatVisitsTitle"
        lblStatVisitsTitle.Size = New Size(260, 30)
        lblStatVisitsTitle.TabIndex = 0
        lblStatVisitsTitle.Text = "TOTAL VISITS TODAY"
        lblStatVisitsTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatVisitsCount
        ' 
        lblStatVisitsCount.Dock = DockStyle.Fill
        lblStatVisitsCount.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblStatVisitsCount.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblStatVisitsCount.Location = New Point(0, 0)
        lblStatVisitsCount.Name = "lblStatVisitsCount"
        lblStatVisitsCount.Size = New Size(260, 100)
        lblStatVisitsCount.TabIndex = 1
        lblStatVisitsCount.Text = "0"
        lblStatVisitsCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlStatStudents
        ' 
        pnlStatStudents.BackColor = Color.White
        pnlStatStudents.Controls.Add(lblStatStudentsTitle)
        pnlStatStudents.Controls.Add(lblStatStudentsCount)
        pnlStatStudents.Dock = DockStyle.Left
        pnlStatStudents.Location = New Point(260, 0)
        pnlStatStudents.Margin = New Padding(20, 0, 0, 0)
        pnlStatStudents.Name = "pnlStatStudents"
        pnlStatStudents.Size = New Size(260, 100)
        pnlStatStudents.TabIndex = 1
        ' 
        ' lblStatStudentsTitle
        ' 
        lblStatStudentsTitle.Dock = DockStyle.Top
        lblStatStudentsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblStatStudentsTitle.ForeColor = Color.Gray
        lblStatStudentsTitle.Location = New Point(0, 0)
        lblStatStudentsTitle.Name = "lblStatStudentsTitle"
        lblStatStudentsTitle.Size = New Size(260, 30)
        lblStatStudentsTitle.TabIndex = 0
        lblStatStudentsTitle.Text = "TOTAL STUDENT VISITS"
        lblStatStudentsTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatStudentsCount
        ' 
        lblStatStudentsCount.Dock = DockStyle.Fill
        lblStatStudentsCount.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblStatStudentsCount.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblStatStudentsCount.Location = New Point(0, 0)
        lblStatStudentsCount.Name = "lblStatStudentsCount"
        lblStatStudentsCount.Size = New Size(260, 100)
        lblStatStudentsCount.TabIndex = 1
        lblStatStudentsCount.Text = "0"
        lblStatStudentsCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlStatEmployees
        ' 
        pnlStatEmployees.BackColor = Color.White
        pnlStatEmployees.Controls.Add(lblStatEmployeesTitle)
        pnlStatEmployees.Controls.Add(lblStatEmployeesCount)
        pnlStatEmployees.Dock = DockStyle.Left
        pnlStatEmployees.Location = New Point(0, 0)
        pnlStatEmployees.Margin = New Padding(20, 0, 0, 0)
        pnlStatEmployees.Name = "pnlStatEmployees"
        pnlStatEmployees.Size = New Size(260, 100)
        pnlStatEmployees.TabIndex = 2
        ' 
        ' lblStatEmployeesTitle
        ' 
        lblStatEmployeesTitle.Dock = DockStyle.Top
        lblStatEmployeesTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblStatEmployeesTitle.ForeColor = Color.Gray
        lblStatEmployeesTitle.Location = New Point(0, 0)
        lblStatEmployeesTitle.Name = "lblStatEmployeesTitle"
        lblStatEmployeesTitle.Size = New Size(260, 30)
        lblStatEmployeesTitle.TabIndex = 0
        lblStatEmployeesTitle.Text = "TOTAL EMPLOYEE VISITS"
        lblStatEmployeesTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatEmployeesCount
        ' 
        lblStatEmployeesCount.Dock = DockStyle.Fill
        lblStatEmployeesCount.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblStatEmployeesCount.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(0))
        lblStatEmployeesCount.Location = New Point(0, 0)
        lblStatEmployeesCount.Name = "lblStatEmployeesCount"
        lblStatEmployeesCount.Size = New Size(260, 100)
        lblStatEmployeesCount.TabIndex = 1
        lblStatEmployeesCount.Text = "0"
        lblStatEmployeesCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1902, 1033)
        Controls.Add(pnlContent)
        Controls.Add(pnlHeader)
        Controls.Add(pnlSidebar)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PUP Clinic Management System"
        pnlSidebar.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlContent.ResumeLayout(False)
        CType(dgvVisits, ComponentModel.ISupportInitialize).EndInit()
        pnlRightSidebar.ResumeLayout(False)
        pnlStats.ResumeLayout(False)
        pnlStatAlerts.ResumeLayout(False)
        pnlStatVisits.ResumeLayout(False)
        pnlStatStudents.ResumeLayout(False)
        pnlStatEmployees.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnDashboard As System.Windows.Forms.Button
    Friend WithEvents btnAddVisit As System.Windows.Forms.Button
    Friend WithEvents btnInventory As System.Windows.Forms.Button
    Friend WithEvents btnAppointments As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserProfile As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnCheckOut As System.Windows.Forms.Button
    Friend WithEvents chkQueueOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlCharts As System.Windows.Forms.Panel
    Friend WithEvents pnlRightSidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlRecent As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlTodayAppointments As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlStats As System.Windows.Forms.Panel
    Friend WithEvents pnlStatAlerts As System.Windows.Forms.Panel
    Friend WithEvents lblStatAlertsTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatAlertsCount As System.Windows.Forms.Label
    Friend WithEvents pnlStatVisits As System.Windows.Forms.Panel
    Friend WithEvents lblStatVisitsTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatVisitsCount As System.Windows.Forms.Label
    Friend WithEvents pnlStatStudents As System.Windows.Forms.Panel
    Friend WithEvents lblStatStudentsTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatStudentsCount As System.Windows.Forms.Label
    Friend WithEvents pnlStatEmployees As System.Windows.Forms.Panel
    Friend WithEvents lblStatEmployeesTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatEmployeesCount As System.Windows.Forms.Label
    Friend WithEvents dgvVisits As System.Windows.Forms.DataGridView
End Class
