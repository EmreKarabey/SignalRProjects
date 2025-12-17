var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7042/SignalRHub")
    .withAutomaticReconnect() // Baðlantý koparsa kendi kendine tekrar denesin
    .build();

document.getElementById("sendbutton").disabled = true;

connection.on("ClientMessage00", function (user, message) {

    var currentTime = new Date();

    var currentHoure = currentTime.getHours();
    var currentMinutes = currentTime.getMinutes();

    var li = document.createElement("li");

    var span = document.createElement("span");

    span.style.font = "bold";

    span.textContent = user;

    li.appendChild(span);

    li.innerHTML += `: ${message} - ${currentHoure}:${currentMinutes}`;

    document.getElementById("messagelist").appendChild(li);


});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("ClientsMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
