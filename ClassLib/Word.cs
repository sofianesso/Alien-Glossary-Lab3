namespace ClassLib;

public class Word
{
    public string[] Translations {get;}
    public int FromLanguage{get;}
    public int ToLanguage{get;}
    

    public Word(params string[] translations)
    {
        Translations = translations;

    }

    public Word(int fromLanguage, int toLanguage, params string[] translations)
    : this(translations)
    {
        FromLanguage = fromLanguage;
        ToLanguage = toLanguage;
    
    }


}
