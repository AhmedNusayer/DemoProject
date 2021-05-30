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