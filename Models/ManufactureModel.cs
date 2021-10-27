using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStore.Models
{
    public class ManufactureModel
    {
        public int ManufactureId { get; set; }
        public string ManufactureName { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufactureMobile { get; set; }
        public string ManufactureAddress { get; set; }
        public int ManufactureZipcode { get; set; }
        public string ManufactureCountry { get; set; }
    }
}