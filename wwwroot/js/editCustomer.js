$(function () {
    // Gets the customer with the requested id and  render the edit-form

    const id = window.location.search.substring(1);
    const url = "Customer/GetOne?" + id;
    $.get(url, function (customer) {
        $("#id").val(customer.id); // includes the id in the form, hidden in html
        $("#name").val(customer.name);
        $("#address").val(customer.address);
    });
});

function editCustomer() {
    const customer = {
        id: $("#id").val(), // the id refer to the customer that is being edited
        name: $("#name").val(),
        address: $("#address").val()
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
