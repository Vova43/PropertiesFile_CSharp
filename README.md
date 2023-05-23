# PropertiesFile_CSharp
A simple class for working with .properties files. / Простой класс для работы с файлами .properties.
Usage example: / Пример использования:

```
// Save settings / Сохранить настройки
string FileConfig = "Config.properties";
Dictionary<string, string> KeyValue = Properties_File.LoadDictionary(FileConfig);
KeyValue["Form.Point.Top"] = this.Top + "";
KeyValue["Form.Point.Left"] = this.Left + "";
Properties_File.SaveDictionary();
```
```
// Load settings / Загрузить настройки
string FileConfig = "Config.properties";
Dictionary<string, string> KeyValue = Properties_File.LoadDictionary(FileConfig);
this.Top = Convert.ToInt32(KeyValue["Form.Point.Top"]);
this.Left = Convert.ToInt32(KeyValue["Form.Point.Left"]);
```
