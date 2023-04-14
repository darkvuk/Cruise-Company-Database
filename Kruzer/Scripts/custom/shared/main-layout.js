$(document).ready(function () {

    let kruzerkorisnik = localStorage.getItem('KruzerKorisnik');
    if (!kruzerkorisnik) {
        $('#list-item-login').show();
        $('a:contains("Register")').css('visibility', 'visible');
        $('#list-item-logout').hide();
    }
    else {
        $('#list-item-login').hide();
        $('a:contains("Register")').css('visibility', 'hidden');
        $('#list-item-logout').show();
    }

    $('#list-item-logout').click(function () {
        localStorage.login = "false";
        localStorage.removeItem("KruzerKorisnik");
        window.location.href = "https://localhost:44389/KorisnikManagement/Login";
    });

})