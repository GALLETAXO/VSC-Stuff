using static System.IO.Directory; // CRUD directories folders
using static System.IO.Path; //Create URL's c://
using static System.Environment;

WriteLine($"Handling cross-platform enviroments");
WriteLine($"{"Path.PathSeparator", -33} {PathSeparator}");
WriteLine($"{"Path.DirectorySeparatorChar", -33} {DirectorySeparatorChar}");
WriteLine($"{"Directory.GetCurrentDirectory()" -33}{GetCurrentDirectory()}");
WriteLine($"{"Environment.SystemDirectory", -33}{SystemDirectory}");
WriteLine($"{"Path.GetTempPath()", -33}{GetTempPath()}");
WriteLine($"{"GetFolderPath(SpecialFolder)", -33}{GetFolderPath(SpecialFolder.System)}");
WriteLine($"{"GetFolderPath(SpecialFolder.ApplicationData)", -33}{GetFolderPath(SpecialFolder.ApplicationData)}");
WriteLine($"{"GetFolderPath(SpecialFolder.Mydocuments)", -33}{GetFolderPath(SpecialFolder.Mydocuments)}");

#region Manage  Drives
SectionTitle("Managing Drivers");
WriteLine($"{"Name", -30} {"Type", -30}{"Format", -7} {"Size(bytes)",18}");

foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    WriteLine($"{drive.Name, -30} {drive.GetType, - 30} {drive.DriveFormat, -7}");
    
}
#endregion


#region Manage directories

sectionTitle("Managing Directories");
string newFolder = Combine(GetFolderPath(SpecialFolder.Mydocuments), "Newfolder");
WriteLine($"Working with {NewFolder}");
//Check if exist 
WriteLine($"Does it exist? : {Path.Exist(newFolder)}");
WriteLine("Creating it...");
CreateDiretory(newFolder);
WriteLine($"Does it exist? : {Path.Exist(newFolder)}");
ReadLine();
WriteLine($"Assasinate the directory");
delegate(newFolder, recursive: true);
WriteLine($"Does it exist? : {Path.Exist(newFolder)}");
#endregion



#region Manage files

SectionTitle("Managing Files");
//define a directory
string dir = combine(GetFolderPath(SpecialFolder.Mydocuments), "OutputFile")
CreateDiretory(dir);
//define file path
stringtexFile = Combine (dir,"Dummy.txt");
string backUpfile = Combine(dir, "Dummy.bak");
WriteLine($"working with {textFile}");
//check if exist 
WriteLine($"Does it exist? : {Path.Exist(newFolder)}");
// write onto file 
textWrite.WriteLine("Hello my brudaaaaaaa");
textWrite.Close();
File.Copy(sourceFileName: textFile, destfileName: backUpfile);
File.Delete(textFile);
WriteLine($"Does it exist? : {Path.Exist(newFolder)}");

// Read from file 
WriteLine("Read from file");
StreamReader textReader = File.OpenText(backUpfile);
WriteLine(textReader.ReadToEnd());
textReader.Close;


#endregion