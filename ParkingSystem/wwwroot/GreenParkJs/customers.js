
$(document).ready(function () {

});


function DeleteRecord(e) {

    //$("#divLoader").show();
    var id = e;

    console.log(id);

    swal(

        {
            title: "Are you sure?",

            text: "Once deleted, you will not be able to recover this  file!",

            type: "success",

            showCancelButton: true,

            confirmButtonColor: "##62b76e",

            confirmButtonText: "Yes, Procceed!",

            closeOnConfirm: false
        },

        function () {

            $.ajax({

                type: "GET",

                url: "/Customers/Delete/" + id,

                success: function (response) {

                    if (response.success) {

                        swal({

                            position: 'top-end',

                            type: "success",

                            title: response.responseText,

                            showConfirmButton: false,

                            // timer: 2000,

                        });
                        setTimeout(function () { location.reload(); }, 3000);

                    }

                    else {
                        swal({
                            position: 'top-end',
                            type: "error",
                            title: response.responseText,
                            showConfirmButton: true,
                            timer: 5000,
                        });
                        $("#divLoader").hide();
                    }

                },
                error: function (response) {
                    swal({
                        position: 'top-end',
                        type: "error",
                        title: "Server error ,kindly contact the admin for assistance",
                        showConfirmButton: false,
                        timer: 5000,
                    });
                    $("#divLoader").hide();
                }

            })

        }
    );
}

$("#btnSubmitCustomer").click(function () {

    if ($('#txtFirstName').val() == '') {
        $('#txtFirstName').focus();
        swal({
            position: 'top-end',
            type: "error",
            title: "Please enter first name",
            showConfirmButton: true,
        });

        return false;
    }
    if ($('#txtLastName').val() == '') {
        $('#txtLastName').focus();
        swal({
            position: 'top-end',
            type: "error",
            title: "Please enter last name",
            showConfirmButton: true,
        });

        return false;
    }


    $("#ModalCreateCustomer").modal('hide');

    $("#divLoader").show();


    var formData = new FormData($('#frmAddCustomer').get(0));

    $.ajax({
        type: "POST",
        url: "/Customers/Create", // NB: Use the correct action name
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,


        success: function (response) {
            if (response.success) {

                swal({
                    position: 'top-end',

                    type: "success",

                    title: response.responseText,

                    showConfirmButton: false,

                }), setTimeout(function () { location.reload(); }, 3000);

            } else {

                swal({
                    position: 'top-end',
                    type: "error",
                    title: response.responseText,
                    showConfirmButton: true,
                    timer: 5000,
                });

            }

            $("#divLoader").hide();
        },


        error: function (error) {
            alert("errror");
        }
    });

});

$("#btnUpdateCustomer").click(function () {


    if ($('#txtName1').val() == '') {
        $('#txtName1').focus();
        swal({
            position: 'top-end',
            type: "error",
            title: "Please enter category name",
            showConfirmButton: true,
        });

        return false;
    }



    $("#ModalEditCustomer").modal('hide');

    $("#divLoader").show();


    var formData = new FormData($('#frmUpdateCustomer').get(0));

    $.ajax({
        type: "POST",
        url: "/Customers/Update", // NB: Use the correct action name
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,


        success: function (response) {
            if (response.success) {

                swal({
                    position: 'top-end',

                    type: "success",

                    title: response.responseText,

                    showConfirmButton: false,

                }), setTimeout(function () { location.reload(); }, 3000);

            } else {

                swal({
                    position: 'top-end',
                    type: "error",
                    title: response.responseText,
                    showConfirmButton: true,
                    timer: 5000,
                });

            }

            $("#divLoader").hide();
        },


        error: function (error) {
            alert("errror");
        }
    });

});

function GetRecord(e) {

    var id = e;

    $.get("/Customers/GetById/?Id=" + id, function (data, status) {

        console.log(data);
        if (data == null) {
            alert("Does not exist");
        } else {

            $("#txtId").val(data.data.id);
            $("#txtFirstName1").val(data.data.firstName);
            $("#txtLastName1").val(data.data.lastName);
            $("#txtEmail1").val(data.data.email);
            $("#txtPhoneNumber1").val(data.data.phoneNumber);
            $("#txtCarRegNo1").val(data.data.carRegNo);

            $('#ModalEditCustomer').modal({ backdrop: 'static', keyboard: false })
            $("#ModalEditCustomer").modal('show');
        }

    });
};




//Allow users to enter numbers only
$(".numericOnly").bind('keypress', function (e) {
    if (e.keyCode == '9' || e.keyCode == '16') {
        return;
    }
    var code;
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;
    if (e.which == 46)
        return false;
    if (code == 8 || code == 46)
        return true;
    if (code < 48 || code > 57)
        return false;
});

//Disable paste
$(".numericOnly").bind("paste", function (e) {
    e.preventDefault();
});

$(".numericOnly").bind('mouseenter', function (e) {
    var val = $(this).val();
    if (val != '0') {
        val = val.replace(/[^0-9]+/g, "")
        $(this).val(val);
    }
});


