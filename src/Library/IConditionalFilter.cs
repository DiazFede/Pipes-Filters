using System;

namespace CompAndDel
{
    public interface IConditionalFilter : IFilter
    {
        bool Result { get; }
    }
}