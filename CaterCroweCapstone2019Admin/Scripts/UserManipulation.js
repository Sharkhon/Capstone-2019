$(document).ready(function () {

    $("#form-type").change(function () {
        SwapForm($(this).val());
    });

    function SwapForm(form) {

        $("form").each(function (index, element) {
            element.setAttribute("hidden", "hidden");
        });

        $("#" + form + "-Form").removeAttr("hidden");
    }

    $("#clear-create-user-button").click(ClearCreateForm);

    function ClearCreateForm() {
        var form = document.getElementById("Create-Form");
        var inputs = form.querySelectorAll("input");

        for (var input of inputs) {
            var hold = input.getAttribute("type");
            if (input.getAttribute("type") !== "button" && input.getAttribute("type") !== "submit") {
                input.value = "";
            }
        }
    }

    $("#find-selected-user-button").click(function () {
        GetUserForEdit($("#selected-username").val());
    });

    function GetUserForEdit(username) {
        $.get("/User/GetUser",
            {
                username: username
            },
            function (response) {
                FillOutEdit(response); 
            });
    }

    function FillOutEdit(user) {
        $("#selected-user-id").val(user.ID);
        var form = document.getElementById("Edit-Form");
        form.querySelector("[id='FirstName']").value = user.FirstName;
        form.querySelector("[id='MInit']").value = user.MInit;
        form.querySelector("[id='LastName']").value = user.LastName;
        form.querySelector("[id='Username']").value = user.Username;
        form.querySelector("[id='Password']").value = user.Password;

        document.getElementById("edit-form-content").removeAttribute("hidden");
    }

    $("#clear-edit-user-button").click(ClearEditForm);

    function ClearEditForm() {

    }

    $("#clear-teacher-assign-button").click(ClearAssignTeacherForm);

    function ClearAssignTeacherForm() {

    }
});