using System.Text.Json;

class Program
{
    public class JsonObject
    {
        public string id { get; set; }
        public string featureId { get; set; } = "";
        public string path { get; set; } = "";
        public int accessScope { get; set; } = 104;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter the number of objects to generate: ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Enter the folder path where JSON should be saved: ");
            string folderPath = Console.ReadLine().Trim();

            Console.Write("Enter the JSON file name (e.g., data.json): ");
            string fileName = Console.ReadLine().Trim();

            List<JsonObject> data = new List<JsonObject>();

            for (int i = 0; i < count; i++)
            {
                data.Add(new JsonObject
                {
                    id = Guid.NewGuid().ToString()
                });
            }

            Directory.CreateDirectory(folderPath); 

            string fullPath = Path.Combine(folderPath, fileName);
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fullPath, json);

            Console.WriteLine($"JSON file is successfully saved to: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
