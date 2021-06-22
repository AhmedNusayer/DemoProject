"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.start().then(function () {
    var id = document.getElementById("selfid").textContent;
    var username = document.getElementById("selfusername").textContent;
    var name = document.getElementById("selfname").textContent;
    connection.invoke("OnConnect", id, username, name).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (userid, message) {
    document.getElementById("messageicon").style.color = "red";
});

function changecolor() {
    document.getElementById("messageicon").style.color = "seashell";
}