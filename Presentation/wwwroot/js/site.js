var token = localStorage.getItem("meus-jogos-token");

var isLoginAction = window.location.href.includes("/Home/Login");

if (token === null && !isLoginAction) window.location.href = "/Home/Login";
