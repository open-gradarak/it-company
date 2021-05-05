using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public class TestGeneratorUtil
    {
        // Minimum valid applicant age
        static readonly byte APPLICANT_MIN_AGE = 18;
        // Maximum valid applicant age
        static readonly byte APPLICANT_MAX_AGE = 70;
        static readonly string[] syllables = { "Ab", "Saa", "Levo", "Pari", "Rub", "Ask",
            "Mam", "Ket", "Zar", "Luci", "Ter", "Ova", "Sar", "Vol", "Ver" };

        static readonly string[] firstNames = { "Sevak", "Nina", "Grisha", "Karine",
            "Arevshat", "Margarita", "Karen", "Smbat", "Rouben", "Garegin",
            "Narine", "Nane", "Marina", "Suren", "Arkadij" };

        
        /// <summary>Generates random date of birth values within the specified age range./>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>The DateTime value within specified range.</returns>
        public static DateTime GetDateOfBirth(byte minAge, byte maxAge)
        {
            // input's validation: check age limits, make sure their within
            // the allowed range

            minAge = Math.Max(APPLICANT_MIN_AGE, minAge);
            maxAge = Math.Min(APPLICANT_MAX_AGE, maxAge);

            var rand = new Random();
            DateTime currentDateTime = DateTime.Now;

            int applicantAge = rand.Next(minAge, maxAge + 1);
            int year = currentDateTime.Year - applicantAge;
            int month = rand.Next(1, 13);
            int day;
            if(month == 2)
            {
                day = rand.Next(1, 29);
            } else
            {
                day = rand.Next(1, 30);
            }
            
           
            DateTime applicantDateOfBirth = new DateTime(year, month, day);
            //Console.WriteLine("Generated birthDate is {0}", applicantDateOfBirth.ToString());
            return applicantDateOfBirth;
        }

        public static string GetLastName()
        {
            var rand = new Random();
            int index = rand.Next(0, syllables.Length);
            string lastName = syllables[index];
            index = rand.Next(0, syllables.Length);
            lastName += syllables[index].ToLower();
            lastName += "yan";
            //Console.WriteLine(lastName);
            return lastName;
        }

        public static string GetFirstName()
        {
            var rand = new Random();
            int index = rand.Next(0, firstNames.Length);
            string firstName = firstNames[index];
            //Console.WriteLine(firstName);
            return firstName;
        }

        public static QualificationLevel GetQualificationLevel()
        {
            var rand = new Random();
            var qualificationLevelCount = Enum.GetNames(typeof(QualificationLevel)).Length;
            return (QualificationLevel)rand.Next(1, qualificationLevelCount);
        }
        public static SpecialistType GetSpecialistType()
        {
            var rand = new Random();
            var specialistTypeCount = Enum.GetNames(typeof(SpecialistType)).Length;
            return (SpecialistType)rand.Next(1, specialistTypeCount);
        }



    }
}
