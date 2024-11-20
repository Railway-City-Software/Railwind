## Chat Feature
Please register the Chat services in-order to use any of the Chat functionality.

Create new hubs and services to inherit the chat functionality.

### Classes to inherit and register
_You may have to register the overriding class twice if the functionality required is not present in the rail classes_

_Ensure you register AddChatRailwindServices_

- RailChatService - _Utilizes the Hub and defines methods for sending a message and getting all messages_
- RailChatHub - _Inherits the hub and automatically defines a SendMessage method to send a receive message via signalR_
- RailChatHubListener - _Inherits IAsyncDisposable and predefines methods to initialize the hub and handle receiving a message._

### Map the hub
Ensure to map the hub and ensure to pass in the RailChatConstants.CHAT_URL to the hub. 

### ChatHubListener
This is a compoenent that listens to the chat hub and handles the receiving of messages.
You should wrap this component at a higher level in your application to ensure that the chat functionality is available throughout the application.

You can easily subscribe and unsubscribe content to the chat hub by using the Subscribe and Unsubscribe methods.