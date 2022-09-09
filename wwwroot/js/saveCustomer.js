function saveCustomer() {
    const customer = {
        firstname: $("#firstname").val(),
        lastname: $("#lastname").val(),
        address: $("#address").val(),
        zipCode: $("#zipCode").val(),
        city: $("#city").val()
    }
    const url = "Customer/Save";
    $.post(url, customer, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#error").html("Error in db - try again later");
        }
    });
};
