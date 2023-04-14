
$(document).ready(function () {

    $('#btn-login').click(function (ev) {
        let username = $('#username').val();
        let password = $('#password').val();

        if (!username || !password) {
            alert("Unesite sve podatke.");
        }
        else {
            $.ajax({
                type: "POST",
                url: "https://localhost:44389/api/user/login",
                data: { Username: username, Password: password },
                success: function (data) {
                    if (data) {
                        localStorage.setItem('KruzerKorisnik', JSON.stringify(data));
                        let url = `${window.location.origin}/Home/Index`
                        window.location.href = url;
                    } else {
                        alert('Try again');
                    }
                }
            })
        }
    })

})