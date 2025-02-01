## Project Setup
```
<link href="_content/Railwind/railwind.css?cacheBust=@(DateTime.Now.Ticks)" rel="stylesheet"/>
<link href="_content/Railwind/additional.css?cacheBust=@(DateTime.Now.Ticks)" rel="stylesheet"/>
<link href="_content/Railwind/keen_outline/style.css" rel="stylesheet" />
```

## Going Forward
The project should be referenced or used as a sub-module, you will then on that project need to update the references
to include the Railwind file locations, this will make tailwind compile the css files and include them in the project.
Please reference the given sample of the PRM

```js
   content: [
        './**/*.html',
        './**/*.razor',
        '../Shared/**/*.html',
        '../Shared/**/*.razor',
        '../Shared/**/*.cs',
        "./wwwroot/**/*.html",
        "./Layout/**/*.{razor,cshtml,cs}",
        "./Core/**/*.{razor,cshtml,cs}",
        "./Models/**/*.{razor,cshtml,cs}",
        "./Pages/**/*.{razor,cshtml,cs}",
        "./Components/**/*.{razor,cshtml,cs}",

        './../../../../TailwindComponents/TwComponents/Railwind/**/*.html',
        './../../../../TailwindComponents/TwComponents/Railwind/**/*.razor',
        './../../../../TailwindComponents/TwComponents/Railwind/**/*.cs',
        './../../../../TailwindComponents/TwComponents/Railwind/Shared/**/*.html',
        './../../../../TailwindComponents/TwComponents/Railwind/Shared/**/*.razor',
        './../../../../TailwindComponents/TwComponents/Railwind/Shared/**/*.cs',
        "./../../../../TailwindComponents/TwComponents/Railwind/wwwroot/**/*.html",
        "./../../../../TailwindComponents/TwComponents/Railwind/Layout/**/*.{razor,cshtml,cs}",
        "./../../../../TailwindComponents/TwComponents/Railwind/Core/**/*.{razor,cshtml,cs}",
        "./../../../../TailwindComponents/TwComponents/Railwind/Models/**/*.{razor,cshtml,cs}",
        "./../../../../TailwindComponents/TwComponents/Railwind/Pages/**/*.{razor,cshtml,cs}",
        "./../../../../TailwindComponents/TwComponents/Railwind/Components/**/*.{razor,cshtml,cs}",
    ]
```

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