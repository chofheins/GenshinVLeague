//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenshinVLeague
{
    using System;
    using System.Collections.Generic;
    
    public partial class HappinessIndex
    {
        public string Country { get; set; }
        public decimal LadderScore { get; set; }
        public decimal GDP { get; set; }
    
        public virtual GenshinCountry GenshinCountry { get; set; }
        public virtual LeagueCountry LeagueCountry { get; set; }
    }
}