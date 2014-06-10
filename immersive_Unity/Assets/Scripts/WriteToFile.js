import System.IO;
import System;  // Used for getting the date
 
private var menuScript : MonoScript;
 
public function writeFile () {

	menuScript = GetComponent(MonoScript);

    // Create an instance of StreamWriter to write text to a file.
    sw = new StreamWriter("TestFile.txt");
    // Add some text to the file.
    sw.Write("This is the ");
    sw.WriteLine("header for the file.");
    sw.WriteLine("-------------------");
    // Arbitrary objects can also be written to the file.
    sw.Write("The date is: ");
    sw.WriteLine(DateTime.Now);
    sw.WriteLine("-------------------");
    sw.WriteLine(menuScript.caseNum);
    sw.WriteLine("-------------------");
    sw.Close();
}