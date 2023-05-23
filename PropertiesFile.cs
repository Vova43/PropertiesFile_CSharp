using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class PropertiesFile
{
    public string FileName = "";
    public char separatorChar = '=';
    public Dictionary<string, string> DictionaryProperties = new Dictionary<string, string>();
    public Dictionary<string, string> GetDictionary() { return DictionaryProperties; }

    public Dictionary<string, string> LoadDictionary(string FileName)
    {
        this.FileName = FileName;
        DictionaryProperties.Clear();
        string line;
        using (StreamReader reader = new StreamReader(FileName))
        {
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(separatorChar);
                if (parts.Length == 2 && parts[0] != "")
                {
                    DictionaryProperties.Add(parts[0], parts[1]);
                }
            }
        }
        return DictionaryProperties;
    }

    public void SaveDictionary()
    {
        using (StreamWriter writer = new StreamWriter(FileName))
        {
            foreach (var item in DictionaryProperties)
            {
                writer.WriteLine(item.Key + separatorChar + item.Value);
            }
        }
    }

    public void SaveDictionary(string FileName)
    {
        using (StreamWriter writer = new StreamWriter(FileName))
        {
            foreach (var item in DictionaryProperties)
            {
                writer.WriteLine(item.Key + separatorChar + item.Value);
            }
        }
    }

    public string GetValueByKey(string Key)
    {
        string line;
        using (StreamReader reader = new StreamReader(FileName))
        {
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(separatorChar);
                    if (parts.Length == 2 && parts[0].Equals(Key))
                    {
                        return parts[1];
                    }
                }
            }
            catch { }
        }
        return null;
    }

    public string GetKeyByValue(string Value)
    {
        string line;
        using (StreamReader reader = new StreamReader(FileName))
        {
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(separatorChar);
                    if (parts.Length == 2 && parts[1].Equals(Value))
                    {
                        return parts[0];
                    }
                }
            }
            catch { }
        }
        return null;
    }
}
