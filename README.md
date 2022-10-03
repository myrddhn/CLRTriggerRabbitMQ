# CLRTriggerRabbitMQ"# CLRTriggerRabbitMQ" 


RabbitMQ server hosted in the USA, SQL Server hosted on Azure in the USA

1) Application updates a table in the DB on the Azure server
2) This fires a .NET CLR trigger ON UPDATE, which submits the value of the "message" column as a SubTextMessage to the RabbitMQ Server
3) The Application is subscribed to the queue on RabbitMQ and receives a TextMessage response of the submitted message and logs it to the debug console

This is basically a round trip from the Local Application -> Azure MSSQL -> RabbitMQ on VPS -> Back to Local Application

The purpose of this experiment is to prove that instead of Polling a database for updates, which is slow and resource intensive, we can subscribe to an asynchronous queue which receives the message as it arrives in an Event Handler or Callbak fashion.  Waiting for events consumes virtually no resources in the main local application, and the ON UPDATE trigger is much more efficient since it is fired on a Database Event and not in a polled fashion.

The reason for using servers on different continents was to simulate worst-case latency.  If all servers were on-premise, the performance should be a lot better.
