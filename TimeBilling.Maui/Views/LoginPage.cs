namespace TimeBilling.Maui.Views;

using CommunityToolkit.Maui.Markup;

using TimeBilling.Maui.ViewModels;

using static CommunityToolkit.Maui.Markup.GridRowsColumns;

internal class LoginPage : ContentPage
{
  private readonly LoginPageViewModel vm;

  public LoginPage(LoginPageViewModel vm)
  {
    BindingContext = vm;
    Content = new Grid
    {
      RowDefinitions = Rows.Define(
            (Row.Username, 30),
            (Row.Password, 30),
            (Row.Submit, Star)),

      ColumnDefinitions = Columns.Define(
            (Column.Description, Star),
            (Column.UserInput, Star)),

      Children =
            {
                new Label()
                    .Text("Username")
                    .Row(Row.Username)
                    .Column(Column.Description),

                new Entry()
                    .Placeholder("Username")
                    .Text("Username")
                    .Row(Row.Username)
                    .Column(Column.UserInput),

                new Label()
                    .Text("Password")
                    .Row(Row.Password)
                    .Column(Column.Description),

                new Entry { IsPassword = true }
                    .Placeholder("Password")
                    .Text("Password")
                    //.SetBinding(Entry.TextProperty, vm.Password)
                    .Row(Row.Password)
                    .Column(Column.UserInput),

                new Button()
                    //.Command.Execute(vm.OkCommand)
                    .Text("Submit")
                    .Row(Row.Submit)
                    .ColumnSpan(2)
            }
    };
  }

  private enum Row { Username, Password, Submit }

  private enum Column { Description, UserInput }
}