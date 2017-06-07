ASU CSE 445 ASSIGNMENT 2: Event-driven programming and Multi-threading (06/03/2017)
 
Student: Harith Neralla

Files included in the Visual Studio 2017 project:
Program.cs:		contains main method
ChickenFarm.cs:		contains pricingModel() and priceCut events 
Retailer.cs:		contains Retailer class and orderCreated events
MultiCellBuffer.cs	contains setOneCell and getOneCell along with the rest of the 
			MultiCellBuffer information
EncodeDecode.cs		contains encode and decode methods
OrderClass.cs		class definition for an orderObject
OrderProcessing.cs	contains order processing functions

There are multiple events:

priceCutEvent:		lets the retailer know when the price has decreased
orderCreatedEvent:	lets the orderProccessing class know to process a new order
orderProcessedEvent:	sends confirmation that order has been processed

How the program works:

There are 5 retailer threads, along with one chicken farm thread, started in the main method. 
A multi-cell buffer is also created with 3 as the default size (line 25 in Program.cs). 
The retailer threads execute until the chicken farm thread ends (which is after there have 
been 10 priceCut events). A new order is created everytime the price is decreased. The retailer
also creates its own orders regardless of the price decrease (to keep business going). These orders
are automatically generated every 1.5 sec to 3.0 sec.

The pricingModel randomly generates a price between $10 and $40. The price is only changed when the
new price is not the same as the older price. But, a priceCut event is only emitted when the price has
been decreased.

The encode and decode methods use the format of: senderID:cardNo:amount.



If there are any questions, please contact hneralla@asu.edu 