using System;
/*
 * Class constructor for Packages
 * Created by Susan Trinh on January 26, 2021
 */
namespace PackagesData
{
    public class Packages
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime PkgStartDate { get; set; }
        public DateTime PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal PkgAgencyCommission { get; set; }
    }
}
