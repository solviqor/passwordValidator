static int CountValidPasswords(string filepath)
{
    int validCount = 0;

    using (StreamReader reader = new StreamReader(filepath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();

            int charIndex = line.IndexOf(':');
            if (charIndex == -1)
                continue;

            string[] requirements = line.Substring(0, charIndex).Trim().Split();
            string password = line.Substring(charIndex + 1).Trim();

            if (requirements.Length != 2)
                continue;

            char symbol = requirements[0][0];
            string[] lengthRequirements = requirements[1].Split('-');
            if (lengthRequirements.Length != 2)
                continue;

            if (int.TryParse(lengthRequirements[0], out int min) && int.TryParse(lengthRequirements[1], out int max))
            {
                int symbolCount = password.Count(c => c == symbol);
                if (symbolCount >= min && symbolCount <= max)
                    validCount++;
            }
        }
    }

    return validCount;
}

string filename = "E:\\fasgfasga.txt"; // Замените на путь к вашему файлу
Console.WriteLine("В файле " + filename);
Console.WriteLine("Количество валидных паролей: " + CountValidPasswords(filename));
