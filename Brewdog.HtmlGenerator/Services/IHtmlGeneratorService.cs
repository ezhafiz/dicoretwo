using System.Collections.Generic;
using Brewdog.Extensions.Models;

namespace Brewdog.HtmlGenerator.Services
{
    public interface IHtmlGeneratorService
    {
        void GenerateHtml(List<Beer> beers);

    }
}
