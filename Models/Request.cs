using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMXRentACar.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Unesite Vaše ime")]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unesite Vaše prezime")]
        [Display(Name = "Prezime")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Unesite Vaš kontakt e-mail")]
        [Display(Name = "Kontakt E-mail")]
        [EmailAddress(ErrorMessage = "Unesite validan kontakt e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Molimo Unesite validan početni datum")]
        [DataType(DataType.Date)]
        [Display(Name = "Početni Datum")]
        [ValidateStartDate]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Molimo Unesite validan završni datum")]
        [Display(Name = "Završni Datum")]
        [ValidateEndDate]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public bool IsValid { get; set; }

        public int VehicleId { get; set; }
    }
}