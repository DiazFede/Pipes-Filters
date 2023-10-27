using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive;
namespace CompAndDel
{

    public class CognitiveFilter : IConditionalFilter
    {
        public bool Result { get; private set; }

        public IPicture Filter(IPicture image)
        {
            CognitiveFace cogFace = new CognitiveFace();
            cogFace.Recognize("ruta_de_la_imagen.jpg");

            Result = cogFace.FaceFound; // resultado del filtro condicional

            // devuelve la imagen original sin modificar
            return image;
        }

    }
}
