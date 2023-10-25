using System;
using System.Drawing;
using CompAndDel;
using CompAndDel.Filters;
using CompAndDel.Pipes;
using Ucu.Poo.Twitter;

namespace CompAndDel

public class TwitterFilter : IFilter
{
    private TwitterImage twitterImage;

    public TwitterFilter(TwitterImage twitterImage)
    {
        this.twitterImage = twitterImage;
    }
    public async Task ApplyAsync(IPicture picture)
    {  
        string result = twitterImage.PublishToTwitter(picture, path);
    }
}



