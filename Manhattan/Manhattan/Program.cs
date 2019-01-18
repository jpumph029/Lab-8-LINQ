﻿using Manhattan.Classes;
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
            //ReturnAllNeighborhoodsFilterNoNames(path);
            ReturnAllNeighborhoodsFilterNoDuplicates(path);
        }
        /// <summary>
        /// Returns all neighborhoods
        /// </summary>
        /// <param name="path"></param>
        static void ReturnAllNeighborhoods(string path)
        {
            var allNeighborhoods = "";
            using (StreamReader reader = File.OpenText(path))
            {
                allNeighborhoods = reader.ReadToEnd();
            }
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(allNeighborhoods);
            var neighborhoods = from classes
                                in deserializedProduct.features
                                select classes.properties.neighborhood;

            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Returns all neighborhoods and filters out white space.
        /// </summary>
        /// <param name="path"></param>
        static void ReturnAllNeighborhoodsFilterNoNames(string path)
        {
            var allNeighborhoods = "";
            using (StreamReader reader = File.OpenText(path))
            {
                allNeighborhoods = reader.ReadToEnd();
            }
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(allNeighborhoods);
            var neighborhoods = from classes 
                                in deserializedProduct.features
                                where classes.properties.neighborhood != ""
                                select classes.properties.neighborhood;

            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// Return all neighborhoods and filters out duplicate neighborhoods
        /// </summary>
        /// <param name="path"></param>
        static void ReturnAllNeighborhoodsFilterNoDuplicates(string path)
        {
            var allNeighborhoods = "";
            using (StreamReader reader = File.OpenText(path))
            {
                allNeighborhoods = reader.ReadToEnd();
            }
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(allNeighborhoods);
            var neighborhoods = from classes
                                in deserializedProduct.features
                                group classes by classes.properties.neighborhood
                                into noDuplicate
                                select noDuplicate;
                               
            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item.Key);
            }
        }

    }

}
