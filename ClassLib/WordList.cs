    namespace ClassLib;

    public class WordList 
    {
        public string Name{get;}
        public string[] Languages {get;}
        private List<Word> words = new List<Word>();


        //Metoder

        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public static string[] GetLists()
        {
            string directoryPath = @"C:\Users\Soffe\AppData\Local";
            
            string[] files = Directory.GetFiles(directoryPath, "*.dat");

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            return files;
        }

        public static WordList LoadList (string name)
        {
             string filePath = $@"C:\Users\Soffe\AppData\Local\{name}.dat";
             if (!File.Exists(filePath))
             {
                throw new FileNotFoundException($"Filen '{name}.dat' hittades inte i registret.");
             }

             var lines = File.ReadAllLines(filePath);
             if(lines.Length==0)
             {
                throw new InvalidOperationException("Filformatet är inte giltigt, programmet stödjer endast .dat filer");
             }

             string[] languages = lines[0].Split(';');
             
            
        }

    }