"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();


connection.on("ReceiveMessage", function (user, message) {
    alert(message);
    $("#data").append("<tr><td>" + message + "</td><td>" + user+"</td></tr>");
});

connection.start().then(function () {
    }).catch(function (err) {
    return console.error(err.toString());
});