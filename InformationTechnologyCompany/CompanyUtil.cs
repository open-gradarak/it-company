using System;
namespace InformationTechnologyCompany
{
    public class CompanyUtil
    {
        public static string getGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

    }
}
