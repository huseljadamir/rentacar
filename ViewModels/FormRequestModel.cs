using LMXRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMXRentACar.ViewModels
{
    public class FormRequestModel
    {
        public Vehicle vehicle { get; set; }
        public Request request { get; set; }
    }
}