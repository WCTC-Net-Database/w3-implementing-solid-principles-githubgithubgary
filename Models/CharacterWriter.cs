using CharacterConsole;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using static PlayerCharacter;

public class CharacterWriter
{
    private List<PlayerCharacter> _characterlist = new List<PlayerCharacter>();
    public List<PlayerCharacter> characterlist
    {
        set
        {
            string? path = Directory.GetCurrentDirectory();
            if (path != null)
            {
                using (var writer = new StreamWriter(path + "\\Files\\input.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CharacterPlayerMap>();
                    csv.WriteRecords(value);
                }
            }
        }
    }
}