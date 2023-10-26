function SetCookie(name, value, days) {
    var expiration = "";

    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expiration = "; expires=" + date.toUTCString();
    }

    document.cookie = name + "=" + (value || "") + expiration + "; path=/"
}


function GetCookie(name) {
    var name = name + "=";
    var cookies = document.cookie.split(";");

    for (var i = 0; i < cookies.length; i++) {
        var c = cookies[i];

        while (c.charAt(0) == ' ') c = c.substring(1, c.length);

        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
}