
Author: Ronald Norman
Date: October 1, 2018

Main Functionality
=============================================
This solution polls an API for math formulas with basic operations and calculates the results, displaying them in a simple list.
The key feature is to enable the user to start and stop the polling on demand.

Extra Functionality
=============================================
I added the following extra functionality because I thought it's a minimum for a very basic functionality

1) Ability to clear the UI list
2) Added a timestamp for each entry in the list
3) Inserted from the top so the latest entries are visible
4) Connectivity alerts bar at the top


Quality Attributes:
=============================================
I included the following quality attributes in the implementation:

1) Network fault tolerance. The app recovers from brief internet disconnection issues gracefully.
2) Unit tests sample. I included a couple of basic unit tests.
3) Configurability. I stored API url and polling interval in the configuration file
4) Seperation of concerns. Implemented a simple layered architecture to make it easier to extend and maintain.
5) Comments. Increased readability by adding comments where I thought they were needed for the "skimming" reader.

Known Potential Issues:
=============================================
I think the following issues should be addressed in future versions:

1) No way to save the content of the list/log to a file. It would be nice to save the list.
2) The list can grow huge if the app is left running for a long time
3) Kept any decimal results for the calculation without rounding. I thought maybe the math-oriented user want to see this level of precision.
4) 