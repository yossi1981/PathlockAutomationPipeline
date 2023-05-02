# PathlockAutomationPipeline

Just some general notes:
1. I believe in simplicity, I tried to keep it is a simple as possible while still filling the requirements. That means:<br />
I used design patterns, per your request.<br />
I didn't pay attention to other practices such as input validaiton, logging, exception handling, dependency injection and other so on... that doesn't means that I am not aware of these concepts and wouldn't think about it in a real world situations.<br />
2. I don't believe in complex inhertience trees and I am not a big fan of abstract classes. I think that it adds more 
complexity and difficulity than anything else, Thus I just used flat out interfaces and concrete classess.
3. Remember, I haven't been programming for awhile, surely not in C# or .NET, I'm well aware that I might have done some weird things or 
used old approaches for doing stuff. Please take that in mind.




Solution Structure:
- PathlockAutomationPipeline project - The main project, console application
- PluginBase - A common library for the plugin library and the main project
- CommandPlugins - The plugin library
- The CommandPlugins and PathlockAutomationPipeline projects are both depdendt on the PluginBase project.


Design patterns used:
- Factory Method
- Command
note : There are some static classes in the project. I could make them singletons, I thought that's too much of a show off so I skipped that.


Instructions:

In the PathlockAutomationPipeline projects, there are two textual files:
CommandFile.txt
CommandFile.xml
Those are coppied to the output directory upon build
You can run the program with either filenames as an argument from the CLI:

PathlockAutomationPipeline.exe <filename>
  
or set it as a command line argument in the project settings.





