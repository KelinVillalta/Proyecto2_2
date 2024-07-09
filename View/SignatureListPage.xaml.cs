using Proyecto2_2.Controller;
using Proyecto2_2.Models;
using Proyecto2_2.View;
using System.IO;

namespace Proyecto2_2.View;

public partial class SignatureListPage : ContentPage
{
    private Database _database;
    public SignatureListPage()
	{
		InitializeComponent();
        _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "signatures.db3"));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        signatureListView.ItemsSource = await _database.GetSignatureAsync();
    }
}