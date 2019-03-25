$(document).ready(function () {
    $('#enrolledCourses table thead').click(function () {
        var hold = $(this).parent().find('tbody').height();
        if ($(this).parent().find('tbody').height() > 0) {
            $(this).parent().find('tbody').height(0);
        } else {
            $(this).parent().find('tbody').height('auto');
        }
    });
});