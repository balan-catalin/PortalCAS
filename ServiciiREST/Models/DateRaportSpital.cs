//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciiREST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DateRaportSpital
    {
        public int Id { get; set; }
        public string CodSpital { get; set; }
        public string CNP { get; set; }
        public string NumarCaz { get; set; }
        public System.DateTime DataInchidereCaz { get; set; }
        public string CodDiagnosticPrincipal { get; set; }
        public string CodInvestigatie { get; set; }
        public double CostAditionalInvestigatie { get; set; }
        public string CodServiciuMedical { get; set; }
        public double CostAditionalServiciuMedical { get; set; }
    }
}