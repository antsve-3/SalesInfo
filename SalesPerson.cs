using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInfo
{
    class SalesPerson
    {
        private String _name;
        private String _personnummer;
        private String _district;
        private int _soldArticles;
        public SalesPerson(String name, String personnummer, String district, int soldArticles)
        {
            _name = name;
            _personnummer = personnummer;
            _district = district;
            _soldArticles = soldArticles;
        }

        //public String getName()
        //{
        //    return _name;
        //}
        //public String getPersonnummer()
        //{
        //    return _personnummer;
        //}
        //public String getDistrict()
        //{
        //    return _district;
        //}
        //public int getSoldArticles()
        //{
        //    return _soldArticles;
        //}
        public String getSalesPersonInfo()
        {
            String salesPersonInfo = _name + "\t" + _personnummer + "\t" + _district + "\t" + _soldArticles;
            return salesPersonInfo;
        }
    }
}
