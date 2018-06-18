const connection = new signalR.HubConnectionBuilder()
    .withUrl("/AppHub")
    .build();

// connection.on("showButton", )
/*connection.start()
connection.start().catch(ErrorEvent => console.error(ErrorEvent.toString()));*/

connection.start()
    .then(function () {
        joinGroup()
    })
    .catch(function () {
        alert("failed")
    });

function joinGroup() {
    
    let sessieName = document.getElementById("sessieName").innerHTML;
    
    connection.invoke("JoinRoom", sessieName).catch(err => console.log(err.toString()));
}

connection.on("ActivateStartButton", () => {
    
    let a = document.getElementById("startButton");
    a.removeAttribute("disabled");
    
});