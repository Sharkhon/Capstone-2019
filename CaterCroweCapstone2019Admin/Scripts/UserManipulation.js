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
        GetUserForEdit($(this).val());
    });

    function GetUserForEdit(username) {

    }

    $("#clear-edit-user-button").click(ClearEditForm);

    function ClearEditForm() {

    }

    $("#clear-teacher-assign-button").click(ClearAssignTeacherForm);

    function ClearAssignTeacherForm() {

    }
});