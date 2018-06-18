const connection = new signalR.HubConnectionBuilder()
    .withUrl("/AppHub")
    .build();

// connection.on("showButton", )

connection.start().catch(ErrorEvent => console.error(ErrorEvent.toString()));