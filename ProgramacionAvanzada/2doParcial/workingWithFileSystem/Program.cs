using static System.IO.Directory; // CRUD directories folders
using static System.IO.Path; //Create URL's c://
using static System.Environment;

WriteLine($"Handling cross-platform enviroments");
WriteLine($"{"Path.PathSeparator", -33} {PathSeparator}");
WriteLine($"{"Path.DirectorySeparatorChar", -33} {DirectorySeparatorChar}");
WriteLine($"{"Directory.GetCurrentDirectory()", - 33}{GetCurrentDirectory()}");
WriteLine($"{"Environment.SystemDirectory", -33}{SystemDirectory}");
WriteLine($"{"Path.GetTempPath()", -33}{GetTempPath()}");
WriteLine($"{"GetFolderPath(SpecialFolder)", -33}{GetFolderPath(SpecialFolder.System)}");
WriteLine($"{"GetFolderPath(SpecialFolder.ApplicationData)", -33}{GetFolderPath(SpecialFolder.ApplicationData)}");
WriteLine($"{"GetFolderPath(SpecialFolder.Mydocuments)", -33}{GetFolderPath(SpecialFolder.MyDocuments)}");

#region Manage  Drives
SectionTitle("Managing Drivers");
WriteLine($"{"Name", -30} {"Type", -30}{"Format", -7} {"Size(bytes)",18}");

foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    WriteLine($"{drive.Name, -30} {drive.GetType, - 30} {drive.DriveFormat, -7}");
    
}
#endregion


#region Manage directories

SectionTitle("Managing Directories");
string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "newFolder");
WriteLine($"Working with {newFolder}");
//Check if exist 
WriteLine($"Does it exist? : {Path.Exists(newFolder)}");
WriteLine("Creating it...");
CreateDirectory(newFolder);
WriteLine($"Does it exist? : {Path.Exists(newFolder)}");
ReadLine();
WriteLine($"Assasinate the directory");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist? : {Path.Exists(newFolder)}");
#endregion



#region Manage files

SectionTitle("Managing Files");
//define a directory
string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments), "OutputFile");
CreateDirectory(dir);
//define file path
string textFile = Combine (dir,"Dummy.txt");
string backUpfile = Combine(dir, "Dummy.bak");
WriteLine($"working with {textFile}");
//check if exist 
WriteLine($"Does it exist? : {Path.Exists(newFolder)}");
// write onto file 
StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello my brudaaaaaaa");
textWriter.Close();
File.Copy(sourceFileName: textFile, destFileName: backUpfile);
File.Delete(textFile);
WriteLine($"Does it exist? : {Path.Exists(newFolder)}");

// Read from file 
WriteLine("Read from file");
StreamReader textReader = File.OpenText(backUpfile);
WriteLine(textReader.ReadToEnd());
textReader.Close();


#endregion
