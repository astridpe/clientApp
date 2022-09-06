function saveCustomer() {
    const customer = {
        name: $("#name").val(),
        address: $("#address").val()
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
