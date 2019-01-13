$(document).ready(function () {
    $('#loginButton').click(loginUser);

    function loginUser() {
        if (!validateLogin()) {
            return;
        }

        var username = $('#username').text();
        var password = $('#password').text();

        $.post('/Home/Login',
            {
                username: username,
                password: password
            },
            function () {
                //TODO Actually check login 

                location.reload();
            });
    }

    function validateLogin() {
        var username = $('#username').val();
        var password = $('#password').val();

        if (username.length === 0 || password.length === 0) {
            $('#loginError').text('Fill out username and password.');
            $('#loginError').css('display', 'block');
            return false;
        }

        return true;
    }
});