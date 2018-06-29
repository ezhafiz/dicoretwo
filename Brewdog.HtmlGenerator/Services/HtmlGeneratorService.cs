using System;
using System.Collections.Generic;
using Brewdog.Extensions.Models;
using HtmlGenerator;

namespace Brewdog.HtmlGenerator.Services
{
    
    public class HtmlGeneratorService : IHtmlGeneratorService
    {
        public void GenerateHtml(List<Beer> beers)
        {
            var htmlPage = new HtmlDocument();
            var head = htmlPage.Head;
            var body = htmlPage.Body;

            head.AddChild(Tag.Title).WithInnerText("Beers!");
            
            // Foreach beer, generate some shit
            foreach (var beer in beers)
            {
                body.AddChild(Tag.Image(beer.BeerImage));
                body.AddChild(Tag.H1).WithInnerText(beer.BeerName);
                body.AddChild(Tag.P).WithInnerText(beer.BeerDescription);
            }

            Console.WriteLine(htmlPage);
            
        }
    }
}
