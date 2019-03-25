$(document).ready(function () {
    $('input[type=submit]').click(function (e) {
        var dateTime = '';

        var dateGiven = $('#datepicker').val();
        var timeGiven = $('#timeForDueDate').val();

        var timeGivenSplit = timeGiven.split(':');
        var parsedTime = '';

        if (parseInt(timeGivenSplit[0]) - 12 >= 0) {
            parsedTime = (parseInt(timeGivenSplit[0]) - 12) + ':' + timeGivenSplit[1] + ' PM';
        } else {
            parsedTime = timeGivenSplit[0] + ':' + timeGivenSplit[1] + ' AM';
        }

        if (parsedTime === '00:00 AM') {
            parsedTime = '12:00 AM';
        }



        dateTime += dateGiven + ' ' + parsedTime;

        $('#DueDate').val(dateTime);
    }); 
});