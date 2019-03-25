$(document).ready(function () {
    $(".verify").click(function (e) {
        var answer = window.confirm('Are you sure that you want to?');

        if (!answer) {
            e.preventDefault();
        }
    });
});