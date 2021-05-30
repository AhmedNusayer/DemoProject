"use strict";

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (userid, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${userid} says ${message}`;
});

/*
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("username").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});*/

document.getElementById("send").addEventListener("click", function (event) {
    var user = document.getElementById("userId").value;
    var message = document.getElementById("messageInput").value;
    var touser = document.getElementById("touserId").value;
    connection.invoke("SendPrivateMessage", touser, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
