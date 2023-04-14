$(document).ready(function () {

    

    let kruzerkorisnik = localStorage.getItem('KruzerKorisnik');
    var user = JSON.parse(kruzerkorisnik);


    if (!kruzerkorisnik) {
        $(":button").css(
            "visibility", "hidden");

        $("a").filter(function () {
            return $(this).text() === "Edit";
        }).css("visibility", "hidden");

        $('a:contains("Dodaj")').css('visibility', 'hidden');
    }
    else if (user['isAdmin'] == 0) {
        $(":button").css(
            "visibility", "visible");

        $("a").filter(function () {
            return $(this).text() === "Edit";
        }).css("visibility", "visible");

        $('a:contains("Dodaj")').css('visibility', 'hidden');
    }
    else {
        $(":button").css(
            "visibility", "visible");

        $("a").filter(function () {
            return $(this).text() === "Edit";
        }).css("visibility", "visible");

        $('a:contains("Dodaj")').css('visibility', 'visible');
    }
    
})