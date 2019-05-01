$(document).ready(function () {

    $("#form-select").change(function () {
        $("form").each(function (index, element) {
            element.setAttribute("hidden", "hidden");
        })
        $("#" + $(this).val() + "-Form").removeAttr("hidden");
    });

    $("#select-class-button").click(function () {
        GetCourseForEdit($("#selected-class-id").val());
    });

    function GetCourseForEdit(courseID) {
        $.get("/Course/GetCourseByID",
            {
                courseID: parseInt(courseID)
            },
            function (response) {
                FillOutEdit(response);
            });
    }

    function FillOutEdit(course) {
        var form = document.getElementById("Edit-Form");
        form.querySelector("[name='Id']").value = course.Id;
        form.querySelector("[name='TeacherId'").value = course.TeacherId;
        form.querySelector("[id='Name']").value = course.Name;
        form.querySelector("[id='MaxSeats']").value = course.MaxSeats;
        form.querySelector("[id='RemainingSeats']").value = course.RemainingSeats;
        form.querySelector("[id='SemesterId']").value = course.SemesterId;
        form.querySelector("[id='StartTime']").value = course.StartTime;
        form.querySelector("[id='EndTime']").value = course.EndTime;
        form.querySelector("[id='Location']").value = course.Location;
        form.querySelector("[id='RoomNumber']").value = course.RoomNumber;
        form.querySelector("[id='DaysOfWeek']").value = course.DaysOfWeek;

        $("#edit-form-content").removeAttr("hidden");
    }
});