using LMXRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMXRentACar.ViewModels
{
    public class ConfirmRequestModel
    {
        public Request request { get; set; }
        public Vehicle vehicle { get; set; }
        public List<Request> otherRequests { get; set; }
    }
}