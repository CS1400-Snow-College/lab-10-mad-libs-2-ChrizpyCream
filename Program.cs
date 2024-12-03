//Christopher Hercules, 11/20/2024, lab 10

using System.Diagnostics;

class Program {
    static void Main(string[] filenames) // adding varibles 
    {
        Random rand = new Random();
        List<string> noun = new List<string> () {"sheep","fortune","flock","rose","blue","happiness","cake","diamond","wish","dog" };
        List<string> ProperNoun = new List<string>() {"Seattle","oreo","empire state building","Tuesday","Ryan gosling","joyce","Christmas","Paris","Ocean","United States"};
        List<string> adjective = new List<string>(){"excited","calm","amazing","energetic","hungry","joyful","rich","elegant","funny","greedy"};
        List<string> adverb = new List<string>(){"often","here","never","cheerfully","fast","accordingly","almost","yesterday","loudly","often"};
        List<string> periodOfTime = new List<string>(){"day","hour","year","week","second","minute","fortnight","millennium","decade",};
        List<string> verbEndingInING = new List<string>() {"trying","liking","dying","stroking","cleaning","drawing","flying","cooking","running","doing"};
        List<string> verb = new List<string>() {"accept","be","have","do","say","adapt","add","beg","ask","attach"};
        List<string> pluralNoun = new List<string>() {"oranges","dresses","benches","dishes","puppies","cherries","boats","classes","heroses","pistachois"};
        List<string> bodyPart = new List<string>() {"hands","eyes","nose","kidneys","lungs","toes","arms","fingers","feet","head"};
        List<string> pastTenseVerb = new List<string>() {"tried","started","played","worked","watched","camped","catched","baked","blushed","agreed"};

        Dictionary<string,List<string>> words = new Dictionary<string, List<string>>();

        words.Add("noun",noun);
        words.Add("Proper-Noun",ProperNoun);
        words.Add("adjective", adjective);
        words.Add("adverb",adverb);
        words.Add("period-of-time",periodOfTime);
        words.Add("verb-ending-in-ing",verbEndingInING);
        words.Add("verb",verb);
        words.Add("plural-noun",pluralNoun);
        words.Add("body-parts",bodyPart);
        words.Add("past-tense-verb",pastTenseVerb);

        Console.Clear();
 // cretae the story
        string story1 = File.ReadAllText("story1.txt");
        string newStory1 = "";
        string story2 = File.ReadAllText("story2.txt");
        string newStory2 = "";

        string[] story1Words = story1.Split(' ');
        string[] story2Words = story2.Split(' ');



        for(int i =0; i<story1Words.Count(); i++)
        {
            char punctuation = '\0';
            bool isreplaceWord = story1Words[i].Contains("::");
            if(isreplaceWord == true)
            {
                string partOfSpeech1 = story1Words[i].Split("::")[1];

                if(".?!".Contains(partOfSpeech1[partOfSpeech1.Length-1]))
                {
                    punctuation = partOfSpeech1[partOfSpeech1.Length-1];
                    //(punctuation)
                    partOfSpeech1 = partOfSpeech1.Substring(0, partOfSpeech1.Length-1);
                    story1Words[i] = words[partOfSpeech1][rand.Next(0,10)] + punctuation;
                }else
                {
                    story1Words[i] = words[partOfSpeech1][rand.Next(0,10)];
                }

            }
            //($"{story1Words[i]} ")
            newStory1 = newStory1 + story1Words[i] + " ";
        }
    
        //maybe file.WriteAllText("generated-story1.txt", newStory1);


        for(int i =0; i<story2Words.Count(); i++)
        {
            char punctuation = '\0';
            bool isreplaceWord = story2Words[i].Contains("::");
            if(isreplaceWord == true)
            {
                string partOfSpeech2 = story2Words[i].Split("::")[1];
                if(".?!".Contains(partOfSpeech2[partOfSpeech2.Length-1]))
                {
                    punctuation = partOfSpeech2[partOfSpeech2.Length-1];
                    partOfSpeech2 = partOfSpeech2.Substring(0, partOfSpeech2.Length-1);
                    story2Words[i] = words[partOfSpeech2][rand.Next(0,10)] + punctuation;
                }else
                {
                    story2Words[i] = words[partOfSpeech2][rand.Next(0,10)];
                }

            }
        
            newStory2 = newStory2 + story2Words[i] + " ";
        }
        File.WriteAllText($"generated-{filenames[0]}.txt", newStory1);
        File.WriteAllText($"generated-{filenames[1]}.txt", newStory2);
    }
}




