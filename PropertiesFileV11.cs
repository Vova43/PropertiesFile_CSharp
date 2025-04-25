// by Vova43 / vova436612
public class PropertiesFile {

    public string fileName = "";
    public char separatorChar = '=';
    public char commentChar   = '#';

    public bool createMOTD = false;

    public System.Collections.Generic.List<string> keys   = new System.Collections.Generic.List<string>();
    public System.Collections.Generic.List<string> values = new System.Collections.Generic.List<string>();

    public PropertiesFile() { }

    public void addKeyAndValue(string key, string value) {
        if (key != "" || value != "") {
            //System.Console.WriteLine(key + " => " + value);
            keys.Add(key);
            values.Add(value);
        }
    }

    public void loadFile(string filePath) {
        this.fileName = filePath;
        string str = System.IO.File.ReadAllText(filePath);
        char ch = (char)0x00;
        string key = "";
        string value = "";
        bool keyToValue = false;
        bool isComment = false;
        int strLength = str.Length;
        for (int i = 0; i < strLength; i += 1) {
            ch = str[i];
            if (ch == commentChar) {
                isComment = true;
            }
            if (ch == '\r') {
                continue;
            }
            if (ch == separatorChar) {
                keyToValue = true;
                continue;
            }
            if (ch == '\n') {
                keyToValue = false;
                if (isComment) {
                    isComment = false;
                    addKeyAndValue(key, value);
                    //if (key != "" || value != "")
                    //    System.Console.WriteLine(key + " => " + value);
                    key = "";
                    value = "";
                    continue;
                }
                isComment = false;
                addKeyAndValue(key, value);
                //System.Console.WriteLine(key + " => " + value);
                key = "";
                value = "";
                continue;
            }
            if (isComment)
                continue;
            if (keyToValue)
                value += ch;
            else
                key += ch;
        }
        addKeyAndValue(key, value);
        //if (key != "" || value != "")
        //    System.Console.WriteLine(key + " => " + value);
    }

    public void saveFile(string filePath) {
        string str = "";
        if (createMOTD)
            str += "# save " + filePath + " \n";
        int listLength = keys.Count;
        for (int i = 0; i < listLength; i++) {
            str += keys[i] + separatorChar + values[i] + '\n';
        }
        System.IO.File.WriteAllText(filePath, str);
    }

    public void saveFile(string filePath, bool createMOTD) {
        string str = "";
        if (createMOTD)
            str += "# save " + filePath + " \n";
        int listLength = keys.Count;
        for (int i = 0; i < listLength; i++) {
            str += keys[i] + separatorChar + values[i] + '\n';
        }
        System.IO.File.WriteAllText(filePath, str);
    }

    public PropertiesFile(string filePath) {
        this.fileName = filePath;
        loadFile(this.fileName);
    }

    public void removeKeyAndValue(string key, string value) {
        if (key != "" || value != "") {
            //System.Console.WriteLine(key + " => " + value);
            keys.Remove(key);
            values.Remove(value);
        }
    }

    public void removeKeyAndValue(int index) {
        keys.RemoveAt(index);
        values.RemoveAt(index);
    }

    public void setKeyAndValue(int index, string key, string value) {
        keys[index] = key;
        values[index] = value;
    }

    public void destroy() {
        keys = null;
        values = null;
    }
}