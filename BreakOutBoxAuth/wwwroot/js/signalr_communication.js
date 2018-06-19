const connection = new signalR.HubConnection("/hubs/apphub");

// connection.on("showButton", )
/*connection.start()
connection.start().catch(ErrorEvent => console.error(ErrorEvent.toString()));*/

connection.start()
    .then(function () {
        joinGroup()
    })
    .catch(function () {
        console.log("failed")
    });

function joinGroup() {
    
    let sessieName = document.getElementById("sessieName").innerHTML;
    
    connection.invoke("JoinRoom", sessieName).catch(err => console.log(err.toString()));
}

connection.on("ActivateStartButton", (value) => {
    
    let a = document.getElementById("startButton");
    a.removeAttribute("disabled");
    alert("blub" + value);
});