Imports System.Windows.Forms
Imports System.Drawing

Public Class InventoryForm
    Private dbHelper As New DatabaseHelper()

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
    End Sub

    Private Sub LoadInventory()
        Try
            Dim inventory = dbHelper.GetInventory()
            dgvInventory.DataSource = inventory
            dgvInventory.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim medicineName As String = txtMedicine.Text.Trim()
        Dim quantity As Integer = Convert.ToInt32(numQuantity.Value)

        If String.IsNullOrWhiteSpace(medicineName) Then
            MessageBox.Show("Please enter a medicine name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            dbHelper.AddOrUpdateInventory(medicineName, quantity)
            txtMedicine.Clear()
            numQuantity.Value = 1
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error adding to inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvInventory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As DatabaseHelper.InventoryItem = CType(dgvInventory.SelectedRows(0).DataBoundItem, DatabaseHelper.InventoryItem)
        If MessageBox.Show($"Are you sure you want to delete {selectedItem.MedicineName} from inventory?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                dbHelper.DeleteInventoryItem(selectedItem.Id)
                LoadInventory()
            Catch ex As Exception
                MessageBox.Show("Error deleting item: " & ex.Message)
            End Try
        End If
    End Sub
End Class
