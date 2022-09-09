$(function () {
    // Gets the customer with the requested id and  render the edit-form

    const id = window.location.search.substring(1);
    const url = "Customer/GetOne?" + id;
    $.get(url, function (customer) {
        $("#id").val(customer.id); // includes the id in the form, hidden in html
        $("#firstname").val(customer.firstname);
        $("#lastname").val(customer.lastname);
        $("#address").val(customer.address);
        $("#zipCode").val(customer.zipCode);
        $("#city").val(customer.city);
    });
});

function editCustomer() {
    const customer = {
        id: $("#id").val(), // the id refer to the customer that is being edited
        firstname: $("#firstname").val(),
        lastname: $("#lastname").val(),
        address: $("#address").val(),
        zipCode: $("#zipCode").val(),
        city: $("#city").val(),
    }
    $.post("Customer/Edit", customer, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#error").html("Error in db - try again later");
        }
    });
}
