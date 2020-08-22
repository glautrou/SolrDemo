using SolrNet.Attributes;
using System;
using System.Collections.Generic;

namespace SolrDemo.Models
{
    public class UserRequests
    {
        [SolrUniqueKey("id")]
        public int Id { get; set; }
        [SolrField("reference")]
        public string Reference { get; set; }
        [SolrField("firstname")]
        public string Firstname { get; set; }
        [SolrField("firstname2")]
        public string Firstname2 { get; set; }
        [SolrField("lastname")]
        public string Lastname { get; set; }
        //[SolrField("requests")]
        //public ICollection<UserRequestItem> Requests { get; set; }
        //[SolrField("tags")]
        //public ICollection<string> Tags { get; set; }
    }

    public class UserRequestItem
    {
        [SolrUniqueKey("id")]
        public int Id { get; set; }
        [SolrField("title")]
        public string Title { get; set; }
        [SolrField("creation_date")]
        public DateTime CreationDate { get; set; }
    }
}
