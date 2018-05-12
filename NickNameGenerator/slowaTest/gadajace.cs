using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NickGenerator;
using System.Collections.Generic;

namespace slowaTest
{
    [TestClass]
    public class gadajace
    {
        [TestMethod]
        public void przedrostek()
        {
            bool  amIright = FindSylaby.ExistPrzedrostek("przedpokój", "przed");
        }

        [TestMethod]
        public void checBetwenRule()
        {
            string słowo = "pokój";
            char samogłoska = 'o';
            bool amIRight = FindSylaby.ExistRuleLastConsonants(słowo, samogłoska);
            string sylaba;
            if(FindSylaby.FindRuleLastConsonants(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

        [TestMethod]
        public void checMirrrorRule()
        {
            string słowo = "anna";
            char samogłoska = 'a';
            bool amIRight = FindSylaby.ExistMirrorRule(słowo, samogłoska);
            string sylaba;
            if (FindSylaby.FindMirrorRule(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

        [TestMethod]
        public void checJednoGłoskoweRule()
        {
            string słowo = "sztela";
            char samogłoska = 'e';
            bool amIRight = FindSylaby.ExistJednoGłoskoweRule(słowo, samogłoska);
            string sylaba;
            if (FindSylaby.FindJednoGłoskoweRule(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

        [TestMethod]
        public void checFuzionSpółgłoskoweRule()
        {
            string słowo = "sztela";
            char samogłoska = 'e';
            bool amIRight = FindSylaby.ExistSpółgłoskiFuzionRule(słowo, samogłoska);
            string sylaba;
            if (FindSylaby.FindSpółgłoskiFuzionRule(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

        [TestMethod]
        public void secondSamogłoska()
        {
            string słowo = "pajęczyna";
            char samogłoska;
            int position;
            if(FindSylaby.findSecondVowels(słowo, out samogłoska, out position))
            {
                char samogłoskaDruga = słowo[position];
            }
            else
            {

            }
        }

        [TestMethod]
        public void checŁączoneFuzionSpółgłoskoweRule()
        {
            string słowo = "sierbica";
            char samogłoska = 'i';
            bool amIRight = FindSylaby.ExistJednoGłoskoweFuzionRule(słowo, samogłoska);
            string sylaba;
            if (FindSylaby.FindJednoGłoskoweFuzionRule(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

        [TestMethod]
        public void naSylaby()
        {
            string słowo = "waute";
            List<string> sylaby;
            sylaby = FindSylaby.AllSyllable(słowo);
        }

        [TestMethod]
        public void nakoncówka()
        {
            string słowo = "manasterski";
            string sylaby;
            string słow2;
            sylaby = FindSylaby.EndingsOfPolishSecondNames(słowo, out słow2);
        }

        //FindSpółgłoskiIJednoGłoskoweRule

        [TestMethod]
        public void checDwiesamogłoski()
        {
            string słowo = "sierbica";
            char samogłoska = 'i';
            string sylaba;
            if (FindSylaby.FindSpółgłoskiIJednoGłoskoweRule(słowo, samogłoska, out sylaba))
            {

            }
            else
            {

            }
        }

    }
}
