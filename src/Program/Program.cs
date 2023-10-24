using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        PictureProvider provider = new PictureProvider();
        IPicture picture = provider.GetPicture(@"PathToImageToLoad.jpg");

        IFilter filter1 = new FilterNegative();
        IFilter filter2 = new FilterBlurConvolution();

        IPipe pipe2 = new PipeNull();  // Pipe final que no hace nada
        IPipe pipe1 = new PipeSerial(filter2, pipe2);  // Pipe 1 con FilterBlurConvolution
        IPipe pipe0 = new PipeSerial(filter1, pipe1);  // Pipe 0 con FilterNegative

        // Aplicar la secuencia de pipes y filtros
        IPicture result = pipe0.Send(picture);

        provider.SavePicture(result, @"PathToImageToSave.jpg");

        Console.WriteLine("Proceso completado. Imagen guardada.");
        }
    }
}
