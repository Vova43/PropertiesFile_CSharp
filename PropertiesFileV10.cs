using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class PropertiesFile {
    public string FileName = "";
    public char separatorChar = '=';
    public char commentChar = '#';
    public Dictionary<string, string> DictionaryProperties = new Dictionary<string, string>();
    public Dictionary<string, string> GetDictionary() { return DictionaryProperties; }

    public Dictionary<string, string> LoadDictionary(string FileName) {
        this.FileName = FileName;
        DictionaryProperties.Clear();
        string line;

        string key = "";
        string value = "";
        bool endKey = false;
        bool comment = false;
        char ch = (char)0x0;
        using (StreamReader reader = new StreamReader(FileName)) {
            while ((line = reader.ReadLine()) != null) {
                // не подерживает коментарии
                //var parts = line.Split(separatorChar);
                //if (parts.Length == 2 && parts[0] != "") {
                //    DictionaryProperties.Add(parts[0], parts[1]);
                //}

                // c подержкой коментарий
                key = "";
                value = "";
                endKey = false;
                comment = false;
                ch = (char)0x0;
                for (int i = 0; i < line.Length; i++) {
                    ch = line[i];
                    if (ch == separatorChar) {
                        endKey = true;
                        continue;
                    }
                    if (ch == commentChar) {
                        comment = true;
                        continue;
                    }
                    if (!comment) {
                        if (endKey) {
                            value += ch;
                        }
                        else {
                            key += ch;
                        }
                    }
                }
                if (key.Length > 0)
                    DictionaryProperties.Add(key, value);
            }
        }
        return DictionaryProperties;
    }

    public void SaveDictionary() {
        using (StreamWriter writer = new StreamWriter(FileName)) {
            foreach (var item in DictionaryProperties) {
                if (item.Key.StartsWith("#")) {
                    writer.WriteLine(item.Key + item.Value);
                    continue;
                }
                writer.WriteLine(item.Key + separatorChar + item.Value);
            }
        }
    }

    public void SaveDictionary(string FileName) {
        using (StreamWriter writer = new StreamWriter(FileName)) {
            foreach (var item in DictionaryProperties) {
                if (item.Key.StartsWith("#")) {
                    writer.WriteLine(item.Key + item.Value);
                    continue;
                }
                writer.WriteLine(item.Key + separatorChar + item.Value);
            }
        }
    }

    public void SaveDictionary(string FileName, bool setFilePath) {
        if (setFilePath)
            this.FileName = FileName;
        using (StreamWriter writer = new StreamWriter(FileName)) {
            foreach (var item in DictionaryProperties) {
                if (item.Key.StartsWith("#")) {
                    writer.WriteLine(item.Key + item.Value);
                    continue;
                }
                writer.WriteLine(item.Key + separatorChar + item.Value);
            }
        }
    }

    public string GetValueByKey(string Key) {
        string line;
        using (StreamReader reader = new StreamReader(FileName)) {
            try {
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(separatorChar);
                    if (parts.Length == 2 && parts[0].Equals(Key)) {
                        return parts[1];
                    }
                }
            }
            catch { }
        }
        return null;
    }

    public string GetKeyByValue(string Value) {
        string line;
        using (StreamReader reader = new StreamReader(FileName)) {
            try {
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(separatorChar);
                    if (parts.Length == 2 && parts[1].Equals(Value)) {
                        return parts[0];
                    }
                }
            }
            catch { }
        }
        return null;
    }
}
