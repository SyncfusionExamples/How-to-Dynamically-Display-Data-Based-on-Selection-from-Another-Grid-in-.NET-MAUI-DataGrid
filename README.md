# How-to-Dynamically-Display-Data-Based-on-Selection-from-Another-Grid-in-.NET-MAUI-DataGrid ?
This article demonstrates how to dynamically display data based on selection from another grid  in the Syncfusion [.NET MAUI DataGrid](https://help.syncfusion.com/maui/datagrid/overview) (`SfDataGrid`). 

In this scenario, users can select one or more groups from the left-side DataGrid, and the right-side DataGrid will automatically update to reflect the corresponding data based on the selection. This dynamic interaction enhances the user experience by enabling real-time data filtering and display across multiple grids.

## Xaml
```
     <ContentPage.Content>
      <Grid RowDefinitions="Auto,*"
      ColumnDefinitions="*,*"
      Padding="10"
      RowSpacing="5" 
      ColumnSpacing="20">

          <Label Grid.Row="0" Grid.Column="0"
           Text="Password Groups"
           FontAttributes="Bold"
           FontSize="16"
           Margin="0,0,0,2"/>
          <Label Grid.Row="0" Grid.Column="1"
           Text="Passwords"
           FontAttributes="Bold"
           FontSize="16"
           Margin="0,0,0,2"/>

          <syncfusion:SfDataGrid Grid.Row="1" Grid.Column="0"
                                HorizontalOptions="Start"
                                WidthRequest="100"
                                x:Name="groupGrid"
                                SelectionMode="Multiple"
                                NavigationMode="Row"
                                SelectionChanged="GroupGrid_SelectionChanged"
                                AutoGenerateColumnsMode="None"
                                HeaderRowHeight="45"
                                HeaderGridLinesVisibility="Both" 
                                GridLinesVisibility="Both"
                                ItemsSource="{Binding Groups}">

              <syncfusion:SfDataGrid.Columns>
                  <syncfusion:DataGridTextColumn HeaderText="Group Name"
                                           MappingName="Name"
                                           Width="150"/>
              </syncfusion:SfDataGrid.Columns>
          </syncfusion:SfDataGrid>

          <syncfusion:SfDataGrid Grid.Row="1" Grid.Column="1"
                                HorizontalOptions="Start"
                                VerticalOptions="Start"
                                x:Name="passwordGrid"
                                AutoGenerateColumnsMode="None"
                                VerticalScrollBarVisibility="Always"
                                SelectionMode="Multiple"
                                NavigationMode="Row"
                                SortingMode="Single"
                                BackgroundColor="White"
                                HeaderRowHeight="30"
                                Margin="20,30,20,0"
                                HeaderGridLinesVisibility="Both" 
                                GridLinesVisibility="Both"
                                MinimumHeightRequest="0"
                                IsVisible="{Binding PwVisible}"
                                ItemsSource="{Binding FilteredPasswords}">

              <syncfusion:SfDataGrid.Columns>
                  <syncfusion:DataGridTextColumn HeaderText="Title"
                                           MappingName="Title"
                                           Width="100"/>
                  <syncfusion:DataGridTextColumn HeaderText="Username"
                                           MappingName="Username"
                                           Width="150"/>
                  <syncfusion:DataGridTextColumn HeaderText="Password"
                                           MappingName="Value"
                                           Width="100"/>
              </syncfusion:SfDataGrid.Columns>
          </syncfusion:SfDataGrid>

      </Grid>
  </ContentPage.Content>

```
## Xaml.cs
```
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
```

### ScreenShot
<img src="https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQ0Mzk5Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.L7qKpVnx0LZB7Qu9DSkXPanBUGqNGad-R1fX71FHJTI" width=800/>

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-Dynamically-Display-Data-Based-on-Selection-from-Another-Grid-in-.NET-MAUI-DataGrid)

 Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).

### Conclusion
I hope you enjoyed learning about How to implement select all checkbox column in SfDataGrid.

You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.

If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums),[Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
