$(function () {
    getAllCustomers();
});

function getAllCustomers() {
    $.get("Customer/GetAllCustomers", function (customers) {
        console.log(customers);
        formatCustomers(customers);
    });
}

function formatCustomers(customers) {
    let out = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Firstname</th><th>Lastname</th><th>Adress</th><th>Zip Code</th><th>City</th><th></th><th></th>" +
        "</tr>";
    for (let customer of customers) {
        out += "<tr>" +
            "<td>" + customer.firstname + "</td>" +
            "<td>" + customer.lastname + "</td>" +
            "<td>" + customer.address + "</td>" +
            "<td>" + customer.zipCode + "</td>" +
            "<td>" + customer.city + "</td>" +
            "<td><a class='btn btn-primary' href='editCustomer.html?id=" + customer.id + "'>Edit</a></td>" +
            "<td><button class='btn btn-danger' onclick='deleteCustomer(" + customer.id + ")'>Delete</button></td>" +
            "</tr>";
    }
    out += "</table>";
    $("#customers").html(out);   
}

function deleteCustomer(id) {
    const url = "Customer/Delete?id=" + id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#error").html("Error in db - try again later");
        }

    });
};
