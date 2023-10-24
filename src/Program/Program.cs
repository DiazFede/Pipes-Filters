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

            // Crear filtros
            IFilter filter1 = new FilterNegative();
            IFilter filter2 = new FilterBlurConvolution();

            // Crear pipes
            IPipe pipe2 = new PipeNull();  // Pipe final que no hace nada
            IPipe pipe1 = new PipeSerial(filter2, pipe2);  // Pipe 1 con FilterBlurConvolution
            IPipe pipe0 = new PipeSerial(filter1, pipe1);  // Pipe 0 con FilterNegative

            // Insertar el filtro para guardar la imagen en el paso 1
            string outputPathStep1 = @"PathToStep1.jpg";
            IFilter saveImageFilter = new FilterSaveImage(outputPathStep1);
            pipe0 = new PipeSerial(pipe0, saveImageFilter);

            // Aplicar la secuencia de pipes y filtros
            IPicture result = pipe0.Send(picture);

            Console.WriteLine("Imagen guardada en " + outputPathStep1);

            // Continuar con la secuencia (paso 2)
            result = pipe1.Send(result);

            Console.WriteLine("Paso 2 completado");

            // Guardar la imagen final
            string outputPathFinal = @"PathToFinalImage.jpg";
            provider.SavePicture(result, outputPathFinal);

            Console.WriteLine("Proceso completado. Imagen final guardada en " + outputPathFinal);

        }
    }
}
