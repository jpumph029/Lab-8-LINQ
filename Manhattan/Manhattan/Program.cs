using Manhattan.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../data.json";
            ReturnAllNeighborhoods(path);
        }

        /// <summary>
        /// Returns all neighborhoods
        /// </summary>
        /// <param name="path">JSON path</param>
        static void ReturnAllNeighborhoods(string path)
        {
            var allNeighborhoods = "";
            using (StreamReader reader = File.OpenText(path))
            {
                allNeighborhoods = reader.ReadToEnd();
            }
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(allNeighborhoods);
            var neighborhoods = from properties in deserializedProduct.features select properties.properties.neighborhood;
            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }

        }

    }

}
