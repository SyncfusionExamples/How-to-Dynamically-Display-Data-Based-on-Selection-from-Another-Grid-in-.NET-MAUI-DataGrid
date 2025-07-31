using Syncfusion.Maui.DataGrid;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {

        private PasswordViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new PasswordViewModel();
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            passwordGrid.HeightRequest = passwordGrid.HeaderRowHeight + passwordGrid.RowHeight * 5;
        }

        private void GroupGrid_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            var grid = sender as SfDataGrid;
            if (grid == null) return;

            var selectedRows = grid.SelectedRows;
            foreach (var item in viewModel.Groups)
            {
                item.IsSelected = selectedRows.Contains(item);
            }

            // refresh the passwords grid
            viewModel.UpdatePasswordsBasedOnSelectedGroups();
        }
    }
}
