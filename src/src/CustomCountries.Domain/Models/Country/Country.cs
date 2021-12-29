﻿using CustomCountries.Domain.Attributes.Mongo;
using CustomCountries.Domain.Models.Mongo;
using System.Collections.Generic;

namespace CustomCountries.Domain.Models.Country
{
    [BsonCollection("countries")]
    public class Country : Document
    {
        public string Name { get; set; }
        public string Native { get; set; }
        public string Capital { get; set; }
        public string Emoji { get; set; }
        public string Currency { get; set; }
        public ICollection<Language> Languages { get; set; }

        public Country()
        {
            Languages = new HashSet<Language>();
        }
    }
}