# PathlockAutomationPipeline

## Solution Structure
- PathlockAutomationPipeline project - The main project, console application<br />
- PluginBase - A common library for the plugin library and the main project<br />
- CommandPlugins - The plugin library<br />
- The CommandPlugins and PathlockAutomationPipeline projects are both depdendt on the PluginBase project.<br />

## Design patterns used:
- Factory Method
- Command
- Template Method
- Note : There are some static classes in the project. I could make them singletons, I thought that's too much of a show off and nto really nessecary so I skipped that.

## Instructions

In the PathlockAutomationPipeline projects, there are two textual files:<br />
CommandFile.txt<br />
CommandFile.xml<br />
Those are coppied to the output directory upon build<br />
You can run the program with either filenames as an argument from the CLI:<br />

PathlockAutomationPipeline.exe [filename]<br />
  
or set it as a command line argument in the project settings.<br />


## Plugins
To test the plugin system, build the CommandPlugins project and copy its build output (dll) to the output folder of the PathlockAutomationPipeline project.
The dll name is defined as a setting in the App.config file.

The plugin I wrote add support to the following command:<br />
print-time [format]<br />
this command prints the current time with the given format.<br />
  
Once you have the Dll next to the executable, you might add this command to either the XML or plain text files.

## Some general notes:
1. I believe in simplicity, I tried to keep it is a simple as possible while still filling the requirements.<br />
I focused on two things: Class Design\Design patterns and making the program work. You don't see that in this solution because that's not my style.
2. I don't believe in complex inhertience trees and I am not a big fan of abstract classes, thus, thus I didn't practice that in this solution.
3. The xml format is not strongly typed, that is, the semantics of the arguments is infered by convension (that is, the sequential order of the arguments), rather than explicit tag names.
4. There's no support for empty command files nor input validation at all or invalid plugin dll, the program supposes that the client made no errors.
5. You might want to manually clear the PathlockAutomationPipeline's output directory if the program terminated abnormally. In that case, there might be some garbage files that interfare with a normal execution of the next run.

