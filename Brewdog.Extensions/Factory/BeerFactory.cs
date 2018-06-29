namespace Brewdog.Extensions.Factory
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Models;
    using Newtonsoft.Json.Linq;
    

    public static class BeerFactory
    {
        public static List<Beer> Build(JToken beerToken)
        {
            var beers = new List<Beer>();

            if (beerToken == null) return beers;

            var beerTokenList = beerToken.ToList();

            if (!beerTokenList.Any()) return beers;

            beers.AddRange(beerTokenList.Select(beer => new Beer()
            {
                BeerId = beer.SelectToken($"$..id").Value<int>(),
                BeerAbv = beer.SelectToken($"$.abv").Value<double>(),
                BeerImage = beer.SelectToken($"$.image_url").Value<string>(),
                BeerName = beer.SelectToken($"$.name").Value<string>(),
                BeerDescription = beer.SelectToken($"$.description").Value<string>()
            }));

            return beers;
        }
        
    }
}
