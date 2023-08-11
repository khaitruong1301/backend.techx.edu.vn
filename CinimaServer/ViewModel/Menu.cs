using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CinimaServer.ViewModel
{
    public class MenuModel
    {
        public Dictionary<string, IEnumerable<dynamic>> content = new Dictionary<string, IEnumerable<dynamic>>();

    }

    public class CategoryModel {
        public string id { get; set; }
        public string title { get; set; }
        public string subTitle { get; set; }
        public string img { get; set; }
        public string path { get; set; }
        public string description { get; set; }
        //public Dictionary<string, IEnumerable<ItemModel>> items = new Dictionary<string, IEnumerable<ItemModel>>();
        //public IEnumerable<ItemModel> items = new List<ItemModel>();


    }

    public class ItemModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string subName { get; set; }
        public string path { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public string categoryId { get; set; }

    }
}