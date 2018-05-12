using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace NickGenerator
{
    public static partial class FindSylaby
    {
        /// <summary>
        /// dzieli słowo na sylaby
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<string> AllSyllable(string word)
        {
            List<string> syllabe = new List<string>();
            if (word != null && word != "")
            {
                word = word.ToLower();
                removeIllegal(ref word);
                word = modulePrzedrostek(word, ref syllabe);
                string endings;
                word = EndingsOfPolishSecondNames(word, out endings);
                while (true)
                {
                    //usuwanie znaków nielegalnych
                    //znajdowanie przedrostka

                    char samogłoska;
                    if (findSamoGłoska(word, out samogłoska))
                    {
                        string sylaba;
                        if (word.Count() > 3)
                        {
                            //if (Rule(ref słowo, samogłoska, out sylaba, "FindSpółgłoskiFuzionRule", ref sylaby))
                            //    continue;

                            if (FindSpółgłoskiFuzionRule(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;
                            }

                            if (FindMirrorRule(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;

                            }
                            if (FindJednoGłoskoweRule(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;
                            }
                            if (FindRuleLastConsonants(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;
                            }
                            if (FindRuleLastTwoConsonants(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;
                            }

                            if (FindSpółgłoskiIJednoGłoskoweRule(word, samogłoska, out sylaba))
                            {
                                syllabe.Add(sylaba);
                                word = word.Replace(sylaba, "");
                                continue;
                            }

                            int position;
                            char samogłoska2;
                            if (findSecondVowels(word, out samogłoska2, out position))
                            {
                                if (word.IndexOf(samogłoska) + 1 == position)
                                {
                                    sylaba = word.Remove(word.IndexOf(samogłoska) + 2);
                                    word = word.Replace(sylaba, "");
                                    syllabe.Add(sylaba);
                                    continue;
                                }
                                else
                                {

                                    sylaba = word.Remove(word.IndexOf(samogłoska) + 1);
                                    word = word.Replace(sylaba, "");
                                    syllabe.Add(sylaba);
                                    continue;
                                }
                            }
                            else
                            {
                                syllabe.Add(word);
                                if (endings != "")
                                    syllabe.Add(endings);
                                return syllabe;
                            }
                        }
                        else
                        {
                            syllabe.Add(word);
                            if (endings != "")
                                syllabe.Add(endings);
                            return syllabe;
                        }


                    }

                    syllabe.Add(word);
                    if (endings != "")
                        syllabe.Add(endings);
                    return syllabe;
                }
            }

            return syllabe;
        }
        /// <summary>
        /// dzieli słowo na sylaby, użwywa Reflection. Zrobione dla zabawy
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<string> GetSylaby(string word)
        {
            List<string> sylaby = new List<string>();
            if (word != null && word != "")
            {
                word = word.ToLower();
                removeIllegal(ref word);
                word = modulePrzedrostek(word, ref sylaby);
                string kon;
                word = EndingsOfPolishSecondNames(word, out kon);
                while (true)
                {
                    //usuwanie znaków nielegalnych
                    //znajdowanie przedrostka

                    char samogłoska;
                    if (findSamoGłoska(word, out samogłoska))
                    {
                        string sylaba;
                        if (word.Count() > 3)
                        {
                            if (Rule(ref word, samogłoska, out sylaba, "FindSpółgłoskiFuzionRule", ref sylaby))
                                continue;
                            if (Rule(ref word, samogłoska, out sylaba, "FindMirrorRule", ref sylaby))
                                continue;
                            if (Rule(ref word, samogłoska, out sylaba, "FindJednoGłoskoweRule", ref sylaby))
                                continue;
                            if (Rule(ref word, samogłoska, out sylaba, "FindRuleLastSpółGłoska", ref sylaby))
                                continue;
                            if (Rule(ref word, samogłoska, out sylaba, "FindRuleLastTwoSpółGłoska", ref sylaby))
                                continue;
                            if (Rule(ref word, samogłoska, out sylaba, "FindSpółgłoskiIJednoGłoskoweRule", ref sylaby))
                                continue;


                            int position;
                            char samogłoska2;
                            if (findSecondVowels(word, out samogłoska2, out position))
                            {
                                if (word.IndexOf(samogłoska) + 1 == position)
                                {
                                    sylaba = word.Remove(word.IndexOf(samogłoska) + 2);
                                }
                                else
                                {
                                    sylaba = word.Remove(word.IndexOf(samogłoska) + 1);
                                }
                                word = word.Replace(sylaba, "");
                                sylaby.Add(sylaba);
                                continue;
                            }
                        }
                    }
                    sylaby.Add(word);
                    if (kon != "")
                        sylaby.Add(kon);
                    return sylaby;
                }
            }
            return sylaby;
        }

        /// <summary>
        /// nadawanie zasad, adaptacja do Reflection
        /// </summary>
        /// <param name="word"></param>
        /// <param name="vowel"></param>
        /// <param name="syllable"></param>
        /// <param name="metods"></param>
        /// <param name="syllables"></param>
        /// <returns></returns>
        public static bool Rule(ref string word, char vowel, out string syllable, string metods, ref List<string> syllables)
        {
            //FindSpółgłoskiFuzionRule
            syllable = string.Empty;
            object[] args = new object[3] { word, vowel, syllable };

            Type type = typeof(FindSylaby);
            MethodInfo mf = type.GetMethod(metods);
            bool end = (bool)mf.Invoke(null, args);
            if (end)
            {
                syllable = (string)args[2];
                syllables.Add(syllable);
                word = word.Replace(syllable, "");
            }

            return end;

        }


        #region rules
        /// <summary>
        /// find first samogłoska
        /// </summary>
        /// <param name="word"></param>
        /// <param name="vowel"></param>
        /// <returns></returns>
        public static bool findSamoGłoska(string word, out char vowel)
        {
            foreach (char item in word)
            {
                if (Alfabet.Vowel.Contains(item))
                {
                    vowel = item;
                    return true;
                }
            }
            vowel = ' ';
            return false;
        }
        /// <summary>
        /// find second samogłoska
        /// </summary>
        /// <param name="word"></param>
        /// <param name="vowel"></param>
        /// <returns></returns>
        public static bool findSecondSamoGłoska(string word, out char vowel)
        {
            int number = 0;
            int position = 0;
            foreach (char item in word)
            {

                if (Alfabet.Vowel.Contains(item))
                {
                    vowel = item;
                    position += word.IndexOf(item);
                    word = word.Remove(0, word.IndexOf(item) + 1);
                    if (number == 1)
                    {
                        position++;
                        vowel = item;
                        return true;
                    }
                    number++;
                }

            }
            vowel = ' ';
            return false;
        }
        /// <summary>
        /// find second samogłoska
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool findSecondVowels(string word, out char samogłoska, out int position)
        {
            int number = 0;
            position = 0;
            foreach (char item in word)
            {

                if (Alfabet.Vowel.Contains(item))
                {
                    samogłoska = item;
                    position += word.IndexOf(item);
                    word = word.Remove(0, word.IndexOf(item) + 1);
                    if (number == 1)
                    {
                        position++;
                        samogłoska = item;
                        return true;
                    }
                    number++;
                }

            }
            samogłoska = ' ';
            return false;
        }
        /// <summary>
        /// check if przedrostek istnieje
        /// </summary>
        /// <param name="word"></param>
        /// <param name="przedrostek"></param>
        /// <returns></returns>
        public static bool ExistPrzedrostek(string word, string przedrostek)
        {
            if (word.Count() > przedrostek.Count())
            {
                string inword = word.Remove(przedrostek.Count());
                if (inword == przedrostek)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// #1 znajduje przedrostek
        /// </summary>
        /// <param name="word"></param>
        /// <param name="sylaby"></param>
        /// <returns></returns>
        public static string modulePrzedrostek(string word, ref List<string> sylaby)
        {
            foreach (string przedrostek in Alfabet.Prefixes)
            {
                if (ExistPrzedrostek(word, przedrostek))
                {
                    sylaby.Add(przedrostek);
                    word = word.Remove(0, przedrostek.Count());
                    return word;
                }
            }
            return word;
        }
        /// <summary>
        /// #2 znajduje końcówki nazwisk
        /// </summary>
        /// <param name="word"></param>
        /// <param name="końcówka"></param>
        /// <returns></returns>
        public static string EndingsOfPolishSecondNames(string word, out string końcówka)
        {
            foreach (string k in Alfabet.Ends)
            {
                if (word.LastIndexOf(k) != -1)
                {
                    końcówka = k;
                    word = word.Remove(word.LastIndexOf(k));
                    return word;

                }
            }
            końcówka = "";
            return word;
        }
        /// <summary>
        /// rozpoznaje czy zasada istnieje
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistRuleLastConsonants(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);

            if (canIMakeSylabe(word, samogłoska))
            {
                char spółgłoska = word.ElementAt(localization + 1);
                if (Alfabet.Consonants.Contains(spółgłoska))
                {
                    char nextsamogłoska = word.ElementAt(localization + 2);
                    if (Alfabet.Vowel.Contains(nextsamogłoska))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Zawsze trzeba oddzielić, czyli przenieść do następnej linijki pojedynczą spółgłoskę,
        ///  która stoi między samogłoskami,
        ///  np.: ma – lu – nek, po – ra – nek, po – ca – łu – nek, ry – su – nek, ra – tu – nek, po – ra – chu – nek.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindRuleLastConsonants(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);

            if (canIMakeSylabe(word, samogłoska))
            {
                char spółgłoska = word.ElementAt(localization + 1);
                if (Alfabet.Consonants.Contains(spółgłoska))
                {
                    char nextsamogłoska = word.ElementAt(localization + 2);
                    if (Alfabet.Vowel.Contains(nextsamogłoska))
                    {
                        sylaba = word.Remove(localization + 1);
                        return true;
                    }
                }
            }
            sylaba = "";
            return false;
        }
        /// <summary>
        /// rozpoznaje czy zasada istnieje
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistRuleLastTwoConsonants(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (word.Count() > localization + 3)
                if (canIMakeSylabe(word, samogłoska))
                {
                    char spółgłoska = word.ElementAt(localization + 1);
                    char spółgłoska2 = word.ElementAt(localization + 2);
                    if (Alfabet.Consonants.Contains(spółgłoska) && Alfabet.Consonants.Contains(spółgłoska2))
                    {
                        char nextsamogłoska = word.ElementAt(localization + 3);
                        if (Alfabet.Vowel.Contains(nextsamogłoska))
                        {
                            return true;
                        }
                    }
                }
            return false;

        }
        /// <summary>
        /// podzielić po połowie gdy są tylko dwie samogłoski
        /// 
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindRuleLastTwoConsonants(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (word.Count() > localization + 3)
                if (canIMakeSylabe(word, samogłoska))
                {
                    char spółgłoska = word.ElementAt(localization + 1);
                    char spółgłoska2 = word.ElementAt(localization + 2);
                    if (Alfabet.Consonants.Contains(spółgłoska) && Alfabet.Consonants.Contains(spółgłoska2))
                    {
                        char nextsamogłoska = word.ElementAt(localization + 3);
                        if (Alfabet.Vowel.Contains(nextsamogłoska))
                        {
                            sylaba = word.Remove(localization + 2);
                            return true;
                        }
                    }
                }
            sylaba = "";
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistMirrorRule(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                if (word[localization + 1] == word[localization + 2])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Zawsze należy rozdzielić dwie jednakowe spółgłoski,
        ///  np.: wan – na, pan – na, Jo – an – na, sa- wan – na, An – na, Ju – lian –na, Ma- rian – na, ma – rzan – na.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindMirrorRule(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                if (word[localization + 1] == word[localization + 2])
                {
                    sylaba = word.Remove(localization + 2);
                    return true;
                }
            }
            sylaba = "";
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistJednoGłoskoweRule(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                foreach (var item in Alfabet.PhonesCombinedWithOnlyConsonants)
                {
                    if (word.Contains(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Nie dzieli się nigdy liter oznaczających jedną głoskę,
        ///  np.: po – rze – czka, a nie por- zec – zka, cza- szka, a nie czas – zka, ka – szka, a nie kas – zka.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindJednoGłoskoweRule(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                    char samogłoska2;
                    int position2;
                if (findSecondVowels(word, out samogłoska2, out position2))
                {
                    foreach (var item in Alfabet.PhonesCombinedWithOnlyConsonants)
                    {
                        if (word.Remove(position2).Contains(item))
                        {
                            if (word.IndexOf(item) > localization)
                            {
                                sylaba = word.Remove(word.IndexOf(item));
                                if (sylaba == "")
                                {
                                    sylaba = word;
                                }
                                return true;
                            }
                            else
                            {
                                if (position2 == word.Count() - 1)
                                {
                                    sylaba = word.Remove(position2 - 1);
                                    return true;
                                }
                                else
                                {
                                    sylaba = word.Remove(position2);
                                    return true;

                                }
                            }
                        }
                    }
                }
                
            }
            sylaba = "";
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistJednoGłoskoweFuzionRule(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                if (localization != 0)
                    foreach (var item in Alfabet.PhonesCombinedWithVowel)
                    {
                        if (word.IndexOf(item) == 0)
                        {
                            if (Alfabet.Vowel.Contains(word[item.Count()]))
                            {
                                return true;
                            }
                        }
                    }
            }
            return false;
        }
        /// <summary>
        /// Nie dzieli się nigdy liter oznaczających jedną głoskę,
        ///  np.: po – rze – czka, a nie por- zec – zka, cza- szka, a nie czas – zka, ka – szka, a nie kas – zka.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindJednoGłoskoweFuzionRule(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                if (localization != 0)
                    foreach (var item in Alfabet.PhonesCombinedWithVowel)
                    {
                        if (word.IndexOf(item) == 0)
                        {
                            if (Alfabet.Vowel.Contains(word[item.Count()]))
                            {
                                int numerSG = 0;
                                for (int i = item.Count(); i < word.Count(); i++)
                                {
                                    if (Alfabet.Vowel.Contains(word[i]))
                                    {
                                        numerSG = i - 2;
                                    }
                                }
                                sylaba = word.Remove(numerSG);
                                return true;
                            }

                        }
                    }
            }
            sylaba = "";
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool ExistSpółgłoskiFuzionRule(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                string[] list = { "au", "eu" };
                foreach (var item in list)
                {
                    if (word.IndexOf(item) == localization)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Nie rozbija się nigdy połączeń spółgłosek au, eu, jeżeli wymieniamy je jednosylabowo, a podczas wymowy samogłoska „u” brzmi jak „ł”,
        ///  np.: Lau – ra, Pau – li – na, pau – za, hy – drau – lik, eu – ta – na – zja, Eu – ro – pa.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindSpółgłoskiFuzionRule(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                string[] list = { "au", "eu" };
                foreach (var item in list)
                {
                    if (word.IndexOf(item) == localization)
                    {
                        sylaba = word.Remove(localization + item.Count());
                        return true;
                    }
                }
            }
            sylaba = "";
            return false;
        }

        /// <summary>
        /// gdy głoski są jedno głosowe i zawierają samogłoski
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <param name="sylaba"></param>
        /// <returns></returns>
        public static bool FindSpółgłoskiIJednoGłoskoweRule(string word, char samogłoska, out string sylaba)
        {
            int localization = word.IndexOf(samogłoska);
            if (canIMakeSylabe(word, samogłoska))
            {
                foreach (var item in Alfabet.PhonesCombinedWithVowel)
                {
                    if (word.IndexOf(item) != -1)
                    {
                        if (word.IndexOf(item) == localization - 1)
                        {
                            word = word.Remove(0, item.Count());
                            char samogłoska2;
                            if (findSamoGłoska(word, out samogłoska2))
                            {
                                if (FindRuleLastTwoConsonants(word, samogłoska2, out sylaba))
                                {

                                }
                                sylaba = item + sylaba;
                                return true;
                            }
                        }
                    }
                }
            }
            sylaba = "";
            return false;
        }

        #endregion



        

        /// <summary>
        /// czysczenie nielegalnych znaków
        /// </summary>
        /// <param name="word"></param>
        public static void removeIllegal(ref string word)
        {
            foreach (var item in Alfabet.IllegalSigns)
            {
                if (word.Contains(item))
                {
                    word.Replace(item, " ");
                }
            }
        }

        /// <summary>
        /// sprawdza czy sylaba jest możliwa do złorzenia
        /// </summary>
        /// <param name="word"></param>
        /// <param name="samogłoska"></param>
        /// <returns></returns>
        public static bool canIMakeSylabe(string word, char samogłoska)
        {
            int localization = word.IndexOf(samogłoska);
            if (localization < 0)
            {
                return false;
            }
            else
            {
                if (localization + 2 <= word.Count() - 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

    }
}
