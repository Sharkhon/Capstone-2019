$(document).ready(function () {

    $("#form-select").change(function () {
        $("form").each(function(index, element) {
            element.setAttribute("hidden", "hidden");
        });
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

        for (var prereq of course.Prereqs) {
            $("#edit-course-prereqs tbody").append(CreatePrereqRowFromPrereq(prereq));
        }

        $("#edit-form-content").removeAttr("hidden");
    }

    function CreatePrereqRowFromPrereq(prereq) {
        var rowCount = $("#edit-course-prereqs tbody tr").length;
        var row = $("<tr></tr>");

        var nameCol = $("<td>" + prereq.PrereqName + "<input name='Prereqs[" + rowCount + "].PrereqId' value='" + prereq.PrereqId + "' hidden/></td>");
        var gradeRequiredCol = $("<td><input type='number' name='Prereqs[" + rowCount + "].PrereqGrade' value='" + prereq.PrereqGrade + "' /></td>");

        var removeRowButton =
            $("<input type='button' value='Remove' data-row='" + rowCount + "' class='btn btn-dark' />")
                .click(function () { RemoveEditPrereq(parseInt($(this).data("row"))) });

        var buttonCol = $("<td></td>");
        buttonCol.append(removeRowButton);

        row.append(nameCol);
        row.append(gradeRequiredCol);
        row.append(buttonCol);

        return row;
    }

    $("#add-row-create-prereqs").click(function () {
        AddCreatePrereq($("#Create-Prereq-Selection option:selected").text(), parseInt($("#Create-Prereq-Selection").val()));
    });

    function AddCreatePrereq(courseName, courseID) {
        var rowCount = $("#create-course-prereqs tbody tr").length;
        var row = $("<tr></tr>");

        var nameCol = $("<td>" + courseName + "<input name='Prereqs[" + rowCount + "].PrereqId' value='" + courseID + "' hidden/></td>");
        var gradeRequiredCol = $("<td><input type='number' name='Prereqs[" + rowCount + "].PrereqGrade' /></td>");

        var removeRowButton =
            $("<input type='button' value='Remove' data-row=" + rowCount + " class='btn btn-dark' />")
            .click(function () { RemoveCreatePrereq(parseInt($(this).data("row"))) });

        var buttonCol = $("<td></td>");
        buttonCol.append(removeRowButton);

        row.append(nameCol);
        row.append(gradeRequiredCol);
        row.append(buttonCol);

        $("#create-course-prereqs tbody").append(row);
    }

    function RemoveCreatePrereq(index) {
        $("#create-course-prereqs tbody tr").eq(index).remove();

        $("#create-course-prereqs tbody tr").each(function(index, element) {
            var name = element.firstElementChild.querySelector("input").getAttribute("Name");   
            var newName = name.replace(/(\[\d*\])/, "[" + index + "]");
            element.firstElementChild.querySelector("input").setAttribute("Name", newName);

            name = element.firstElementChild.nextElementSibling.querySelector("input").getAttribute("Name");
            newName = name.name.replace(/(\[\d*\])/, "[" + index + "]");
            element.firstElementChild.nextElementSibling.querySelector("input").setAttribute("Name", newName);

            element.lastElementChild.querySelector("input").dataset["row"] = index;
        });
    }

    $("#add-row-edit-prereqs").click(function () {
        AddEditPrereq($("#Edit-Prereq-Selection option:selected").text(), parseInt($("#Edit-Prereq-Selection").val()));
    });

    function AddEditPrereq(courseName, courseID) {
        var rowCount = $("#edit-course-prereqs tbody tr").length;
        var row = $("<tr></tr>");

        var nameCol = $("<td>" + courseName + "<input name='Prereqs[" + rowCount + "].PrereqId' value='" + courseID + "' hidden/></td>");
        var gradeRequiredCol = $("<td><input type='number' name='Prereqs[" + rowCount + "].PrereqGrade' /></td>");

        var removeRowButton =
            $("<input type='button' value='Remove' data-row=" + rowCount + " class='btn btn-dark' />")
                .click(function () { RemoveEditPrereq(parseInt($(this).data("row"))) });

        var buttonCol = $("<td></td>");
        buttonCol.append(removeRowButton);

        row.append(nameCol);
        row.append(gradeRequiredCol);
        row.append(buttonCol);

        $("#edit-course-prereqs tbody").append(row);
    }

    function RemoveEditPrereq(index) {
        $("#edit-course-prereqs tbody tr").eq(index).remove();

        $("#edit-course-prereqs tbody tr").each(function (index, element) {
            var name = element.firstElementChild.querySelector("input").getAttribute("Name");
            var newName = name.replace(/(\[\d*\])/, "[" + index + "]");
            element.firstElementChild.querySelector("input").setAttribute("Name", newName);

            name = element.firstElementChild.nextElementSibling.querySelector("input").getAttribute("Name");
            newName = name.name.replace(/(\[\d*\])/, "[" + index + "]");
            element.firstElementChild.nextElementSibling.querySelector("input").setAttribute("Name", newName);

            element.lastElementChild.querySelector("input").dataset["row"] = index;
        });
    }
});