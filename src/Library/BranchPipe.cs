using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive;
namespace CompAndDel
{
public class ConditionalBranchPipe : IPipe
{
    private readonly IConditionalFilter conditionalFilter;
    private readonly IPipe truePipe;
    private readonly IPipe falsePipe;

    public ConditionalBranchPipe(IConditionalFilter conditionalFilter, IPipe truePipe, IPipe falsePipe)
    {
        this.conditionalFilter = conditionalFilter;
        this.truePipe = truePipe;
        this.falsePipe = falsePipe;
    }

    public IPicture Send(IPicture picture)
    {
        if (conditionalFilter.Result)
        {
            return truePipe.Send(picture);
        }
        else
        {
            return falsePipe.Send(picture);
        }
    }
}
}