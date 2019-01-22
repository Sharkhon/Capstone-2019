$(document).ready(function () {
    $('#loginButton').click(loginUser);

    $("#logout").click(logoutUser);

    checkIfLoggedIn();

    function checkIfLoggedIn() {
        $.get('/Login/IsLoggedIn', function (result) {
            result = $.parseJSON(result);

            var atHome = window.location.pathname === '/';

            if (!result && !atHome) {
                window.location.replace('/');
            }
        });
    }

    function loginUser() {
        if (!validateLogin()) {
            return;
        }

        var username = $('#username').val();
        var password = $('#password').val();

        $.post('/Login/Login',
            {
                username: username,
                password: password
            },
            function (result) {
                result = $.parseJSON(result);

                if (!result) {
                    $('#loginError').text('Either username or password is incorrect.')
                        .css('display', 'inline-block');
                } else {
                    location.reload();
                }
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

    function checkIfLoggedIn() {
        $.get('/Login/IsLoggedIn', function (result) {
            result = $.parseJSON(result);

            var atHome = window.location.pathname === '/';

            if (!result && !atHome) {
                window.location.replace('/');
            }
        });
    }

    function logoutUser() {
        $.post('/Login/LogoutUser', function () {
            window.history.pushState(null, null, 'login');//TODODODODODODO
            window.location.replace('/');
        });
    }
});