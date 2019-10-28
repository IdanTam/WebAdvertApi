using AdvertApi.Models;
using System;
using Amazon.DynamoDBv2.DataModel;

namespace AdvertApi.Services
{

    public class AdvertDbModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public AdvertStatus Status { get; set; }
    }
}
