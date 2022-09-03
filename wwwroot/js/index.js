$(function () {
    getAllCustomers();
});

function getAllCustomers() {
    $.get("Customer/getAllCustomers", function (customers) {
        formatCustomers(customers);
    });
}

function formatCustomers(customers) {
    let out = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Name</th><th>Address</th><th></th><th></th>" +
        "</tr>";
    for (let customer of customers) {
        out += "<tr>" +
            "<td>" + customer.name + "</td>" +
            "<td>" + customer.address + "</td>" +
            "</tr>";
    }
    out += "</table>";
    $("#customers").html(out);
    
}
