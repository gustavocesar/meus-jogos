$(document).ready(function () {
    var token = localStorage.getItem("meus-jogos-token");

    var loginAction = "/Home/Login";

    var isLoginAction = window.location.href.includes(loginAction);

    $(document).on("click","#btn-logout",function() {
        localStorage.removeItem("meus-jogos-token");
        window.location.href = loginAction;
    });

    if (token === null && !isLoginAction) {
        window.location.href = loginAction;
    } else {
        $("#top-menu").append('<li class="nav-item"><a class="nav-link text-dark" href="javascript:;" id="btn-logout">Logout</a></li>');
    }

});