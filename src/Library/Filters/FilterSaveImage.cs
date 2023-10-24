using System;
using System.Drawing;
using CompAndDel;
using CompAndDel.Filters;
using CompAndDel.Pipes;

namespace CompAndDel
{
public class FilterSaveImage : IFilter
{
    private string outputPath; // Ruta de archivo para guardar la imagen

    public FilterSaveImage(string outputPath)
    {
        this.outputPath = outputPath;
    }

    public IPicture Filter(IPicture image)
    {
        // Guardar la imagen 
        PictureProvider provider = new PictureProvider();
        provider.SavePicture(image, outputPath);

        // Devolver la misma imagen
        return image;
    }
}
}
