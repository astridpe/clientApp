$(function () {
    getAllClients();
});

function getAllClients() {
    $.get("Client/getAllClients", function (clients) {
        formatClients(clients);
    });
}

function formatClients(clients) {
    let out = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Name</th><th>Address</th><th></th><th></th>" +
        "</tr>";
    for (let client of clients) {
        out += "<tr>" +
            "<td>" + client.name + "</td>" +
            "<td>" + client.address + "</td>" +
            "</tr>";
    }
    out += "</table>";
    $("#clients").html(out);
    
}
