using System.Collections.Generic;
using System;

namespace Demo.CustomCountries.Application.ViewModels
{
    public class CountryViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        public string Capital { get; set; }
        public string Emoji { get; set; }
        public string Currency { get; set; }
        public ICollection<LanguageViewModel> Languages { get; set; }

        public CountryViewModel()
        {
            Languages = new HashSet<LanguageViewModel>();
        }
    }
}