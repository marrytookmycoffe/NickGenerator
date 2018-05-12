using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickGenerator
{
    /// <summary>
    /// bibloteka, używam polskich nazw bo się zmęczyłem już szukaniem angielskich odpowiedników
    /// </summary>
    public static class Alfabet
    {
        /// <summary>
        /// samogłoski
        /// </summary>
        public static readonly char[] Vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'ó', 'ą', 'ę' };
        /// <summary>
        /// spółgłoski
        /// </summary>
        public static readonly char[] Consonants = { 'b', 'c', 'ć', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 'ś', 't', 'w', 'y', 'z', 'ż', 'ź'};
        /// <summary>
        /// głoski łączone
        /// </summary>
        public static readonly string[] PhonesCombined = { "ci", "si", "ni", "rz", "cz", "ch", "dź", "sz", "dzi", "dz"};
        /// <summary>
        /// głoski łączone z samogłoską
        /// </summary>
        public static readonly string[] PhonesCombinedWithVowel = { "ci", "si", "ni", "dzi"};
        /// <summary>
        /// głoski łączone bez samogłoski
        /// </summary>
        public static readonly string[] PhonesCombinedWithOnlyConsonants = { "rz", "cz", "ch", "dź", "sz", "dz" };
        /// <summary>
        /// głoski dźwięczne
        /// </summary>
        public static readonly string[] PhonesVoiced = { "b", "d", "g", "w", "z", "ź", "ż", "l", "ł", "r", "m", "n", "j", "dz", "dź", "dż", "a", "e", "i", "o", "u", "y", "ó", "ą", "ę" };
        /// <summary>
        /// głoski bezdźwięczne
        /// </summary>
        public static readonly string[] PhonesUnVoiced = { "p", "t", "k", "f", "s", "ś", "sz", "c", "ć", "cz", "ch" };

        /// <summary>
        /// spółgłoski miękkie
        /// </summary>
        public static readonly string[] ConsonantsSoft = {"p","b","f","w","ś","ź","ć","ch","dź","m","n","l","j","k","g", "ci", "si", "ni"};
        /// <summary>
        /// spółgłoski twarde
        /// </summary>
        public static readonly string[] ConsonantsHard = {"p","b","f","w","s","z","c","ch","dz","n","m","l","ł","k","g","t","d","sz","ż","cz","dż","r"};

        /// <summary>
        /// przedrostki
        /// </summary>
        public static readonly string[] Prefixes = { "przed", "nie", "roz", "naj" };
        /// <summary>
        /// końcówki
        /// </summary>
        public static readonly string[] Ends = { "wski", "wska", "ski", "ska" };
        /// <summary>
        /// nielegalne znaki
        /// </summary>
        public static readonly string[] IllegalSigns = { "/", "\\", "!", "@", "_", "-", "+", "=", "?", "*", "&" };
    }
}
