using Proyecto2_2.Controller;
using Proyecto2_2.Models;
using Proyecto2_2.View;
using SignaturePad.Forms;
using System.IO;
using System.Xml.Linq;
using Microsoft.Maui.Controls;


namespace Proyecto2_2.View;

public partial class SignaturePage : ContentPage
{
    private Database _database;

    public SignaturePage()
    {
        InitializeComponent();
        _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "signatures.db3"));
    }

    async void OnSaveSignatureClicked(object sender, EventArgs e)
    {
        
        var image = await signaturePad.GetImageStreamAsync(SignatureImageFormat.Png);
        var imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Guid.NewGuid()}.png");

        using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
        {
            image.CopyTo(fileStream);
        }

       

        var signature = new Signature
        {
          
            Name = nameEntry.Text,
            Description =descriptionEntry.Text,
            ImagePath = imagePath,
            Date = DateTime.Now
        };

        var result = await _database.SaveSignatureAsync(signature);
      
        if (result != 1)
        {
            await DisplayAlert("ERROR", "OCURRIO UN ERROR, INTENTE DE NUEVO", "ACEPTAR");
        }

        await DisplayAlert("AVISO", "GUARDADO CORRECTAMENTE", "ACEPTAR");
    }


    async void OnViewSignaturesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignatureListPage());
    }

}
